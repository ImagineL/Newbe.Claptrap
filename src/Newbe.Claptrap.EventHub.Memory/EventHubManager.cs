using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Newbe.Claptrap.Abstract.Core;
using Newbe.Claptrap.Abstract.Relations;
using Orleans;

namespace Newbe.Claptrap.EventHub.Memory
{
    public class EventHubManager : IEventHubManager
    {
        private readonly IClaptrapRelationProvider _claptrapRelationProvider;
        private readonly IClusterClient _clusterClient;

        public EventHubManager(
            IClaptrapRelationProvider claptrapRelationProvider,
            IClusterClient clusterClient)
        {
            _claptrapRelationProvider = claptrapRelationProvider;
            _clusterClient = clusterClient;
        }

        private readonly ConcurrentDictionary<IActorKind, BufferBlock<IEvent>> _dictionary
            = new ConcurrentDictionary<IActorKind, BufferBlock<IEvent>>();

        public Task Publish(IActorIdentity @from, IEvent @event)
        {
            if (!_dictionary.TryGetValue(@from.Kind, out var block))
            {
                var newBlock = CreateBlock(from.Kind);
                _dictionary.AddOrUpdate(from.Kind, newBlock, (kind, bufferBlock) => CreateBlock(kind));
                block = newBlock;
            }

            return block.SendAsync(@event);
        }

        private BufferBlock<IEvent> CreateBlock(IActorKind kind)
        {
            var claptrapRelation = _claptrapRelationProvider.Find(kind);
            var eventReceiveChannels = claptrapRelation.MinionKinds
                .Select(x => new EventReceiveChannel(_clusterClient, x))
                .ToArray();
            var bufferBlock = new BufferBlock<IEvent>();
            var broadcastBlock = new BroadcastBlock<IEvent>(x => x);
            bufferBlock.LinkTo(broadcastBlock);
            foreach (var eventReceiveChannel in eventReceiveChannels)
            {
                broadcastBlock.LinkTo(
                    new ActionBlock<IEvent>(new Func<IEvent, Task>(@event => eventReceiveChannel.Receive(@event))));
            }

            return bufferBlock;
        }
    }
}