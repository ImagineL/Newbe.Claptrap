using Newbe.Claptrap.Abstract.Context;

namespace Newbe.Claptrap.Autofac
{
    public class AutofacEventLifetimeScope : IEventLifetimeScope
    {
        public IEventContext EventContext { get; set; }
    }
}