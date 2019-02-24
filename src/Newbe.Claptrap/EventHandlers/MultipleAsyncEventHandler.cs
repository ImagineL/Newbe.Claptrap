using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newbe.Claptrap.Abstract.Context;
using Newbe.Claptrap.Abstract.Core;
using Newbe.Claptrap.Abstract.EventHandler;

namespace Newbe.Claptrap.EventHandlers
{
    public class MultipleAsyncEventHandler : IEventHandler
    {
        private readonly IEnumerable<IEventHandler> _eventHandlers;

        public MultipleAsyncEventHandler(
            IEnumerable<IEventHandler> eventHandlers)
        {
            _eventHandlers = eventHandlers;
        }

        public Task HandleEvent(IEventContext eventContext)
        {
            return Task.WhenAll(_eventHandlers.Select(x => x.HandleEvent(eventContext)));
        }

        public async ValueTask DisposeAsync()
        {
            foreach (var handler in _eventHandlers)
            {
                await handler.DisposeAsync();
            }
        }
    }
}