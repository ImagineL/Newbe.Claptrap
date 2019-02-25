using Newbe.Claptrap.Abstract.Core;
using Newbe.Claptrap.Abstract.EventChannels;

namespace Newbe.Claptrap.EventHub.Memory
{
    public class MemoryEventPublishChannelProvider
        : IEventPublishChannelProvider
    {
        private readonly EventPublishChannel.Factory _factory;

        public MemoryEventPublishChannelProvider(
            EventPublishChannel.Factory factory)
        {
            _factory = factory;
        }

        public IEventPublishChannel Create(IActorIdentity claptrapIdentity, IMinionKind minionKind)
        {
            var eventPublishChannel = _factory.Invoke();
            return eventPublishChannel;
        }
    }
}