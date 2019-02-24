using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newbe.Claptrap.Abstract;
using Newbe.Claptrap.Abstract.Context;
using Newbe.Claptrap.Abstract.Core;
using Newbe.Claptrap.Abstract.EventHandler;

namespace Newbe.Claptrap
{
    public class Actor : IActor
    {
        private readonly IActorContext _actorContext;
        private readonly IEventHandlerFactory _eventHandlerFactory;

        public Actor(
            IActorContext actorContext,
            IEventHandlerFactory eventHandlerFactory)
        {
            _actorContext = actorContext;
            _eventHandlerFactory = eventHandlerFactory;
        }

        public IState State => _actorContext.State;

        public Task ActivateAsync()
        {
            return _actorContext.InitializeAsync();
        }

        public Task DeactivateAsync()
        {
            return _actorContext.DisposeAsync();
        }

        public async Task HandleEvent(IEvent @event)
        {
            var eventContext = new EventContext(@event, _actorContext);
            await using (var handler = _eventHandlerFactory.Create(eventContext))
            {
                await handler.HandleEvent(eventContext);
            }
        }
    }
}