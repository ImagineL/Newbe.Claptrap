using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap.Autofac
{
    public interface IActorLifetimeScope
    {
        IActorIdentity Identity { get; }
    }
}