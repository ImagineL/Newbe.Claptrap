using Newbe.Claptrap.Abstract.Context;

namespace Newbe.Claptrap.Autofac
{
    public interface IEventLifetimeScope
    {
        IEventContext EventContext { get; }
    }
}