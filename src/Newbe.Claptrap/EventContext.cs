using Newbe.Claptrap.Abstract.Context;
using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap
{
    public class EventContext : IEventContext
    {
        public EventContext(IEvent @event, IActorContext actorContext)
        {
            Event = @event;
            ActorContext = actorContext;
        }

        public IEvent Event { get; }
        public IActorContext ActorContext { get; }
    }
}