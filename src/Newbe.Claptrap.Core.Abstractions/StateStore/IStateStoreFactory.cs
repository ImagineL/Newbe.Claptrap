using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap.Abstract.StateStore
{
    public interface IStateStoreFactory
    {
        IStateStore Create(IActorIdentity identity);
    }
}