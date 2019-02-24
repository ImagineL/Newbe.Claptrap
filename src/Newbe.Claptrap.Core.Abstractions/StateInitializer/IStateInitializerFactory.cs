using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap.Abstract.StateInitializer
{
    public interface IStateInitializerFactory
    {
        IStateInitializer Create(IActorIdentity actorIdentity);
    }
}