using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newbe.Claptrap.Abstract.Context;
using Newbe.Claptrap.Abstract.EventChannels;
using Newbe.Claptrap.Abstract.EventHandler;

namespace Newbe.Claptrap.EventHandlers
{
    public class ClaptrapEventPublishEventHandler : IEventHandler
    {
        private readonly IEnumerable<IEventPublishChannel> _eventPublishChannels;

        public ClaptrapEventPublishEventHandler(IEnumerable<IEventPublishChannel> eventPublishChannels)
        {
            _eventPublishChannels = eventPublishChannels;
        }

        public ValueTask DisposeAsync()
        {
            return new ValueTask();
        }

        public Task HandleEvent(IEventContext eventContext)
        {
            return Task.WhenAll(_eventPublishChannels.Select(x => x.Publish(eventContext.Event)));
        }
    }
}