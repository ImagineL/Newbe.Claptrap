using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap.Abstract.EventStore
{
    public interface IEventStoreFactory
    {
        IEventStore Create(IActorIdentity identity);
    }
}