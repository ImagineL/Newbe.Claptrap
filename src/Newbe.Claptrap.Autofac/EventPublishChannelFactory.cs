using System.Collections.Generic;
using System.Linq;
using Newbe.Claptrap.Abstract.Core;
using Newbe.Claptrap.Abstract.EventChannels;
using Newbe.Claptrap.Abstract.Relations;

namespace Newbe.Claptrap.Autofac
{
    public interface IEventPublishChannelFactory
    {
        IEnumerable<IEventPublishChannel> Create(IActorIdentity identity);
    }

    public class EventPublishChannelFactory : IEventPublishChannelFactory
    {
        private readonly IClaptrapRelationProvider _claptrapRelationProvider;
        private readonly IEventPublishChannelProvider _eventPublishChannelProvider;

        public EventPublishChannelFactory(
            IClaptrapRelationProvider claptrapRelationProvider,
            IEventPublishChannelProvider eventPublishChannelProvider)
        {
            _claptrapRelationProvider = claptrapRelationProvider;
            _eventPublishChannelProvider = eventPublishChannelProvider;
        }

        public IEnumerable<IEventPublishChannel> Create(IActorIdentity identity)
        {
            var claptrapRelation = _claptrapRelationProvider.Find(identity.Kind);
            if (claptrapRelation == null)
            {
                return Enumerable.Empty<IEventPublishChannel>();
            }

            var channels = claptrapRelation.MinionKinds.Select(x => _eventPublishChannelProvider.Create(identity, x));
            return channels;
        }
    }
}