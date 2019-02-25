using Autofac;
using Newbe.Claptrap.Abstract.Context;
using Newbe.Claptrap.Abstract.Core;
using Newbe.Claptrap.Abstract.EventHandler;
using Newbe.Claptrap.Abstract.EventStore;
using Newbe.Claptrap.Abstract.StateInitializer;
using Newbe.Claptrap.Abstract.StateStore;
using Newbe.Claptrap.Autofac.Modules;
using Newbe.Claptrap.EventHandlers;

namespace Newbe.Claptrap.Autofac
{
    public class ClaptrapModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterModule<ActorFactoryModule>();
            builder.RegisterModule<ActorContextModule>();
            builder.RegisterModule<EventStoreModule>();
            builder.RegisterModule<StateStoreModule>();
            builder.RegisterModule<EventHandlerModule>();
            builder.RegisterModule<StateInitializerModule>();
        }
    }
}