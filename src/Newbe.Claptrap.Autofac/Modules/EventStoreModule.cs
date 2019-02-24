using Autofac;
using Newbe.Claptrap.Abstract.Core;
using Newbe.Claptrap.Abstract.EventStore;

namespace Newbe.Claptrap.Autofac.Modules
{
    public class EventStoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<EventStoreFactory>()
                .As<IEventStoreFactory>();
            builder.Register(context =>
                    context.Resolve<IEventStoreFactory>().Create(context.Resolve<IActorIdentity>()))
                .As<IEventStore>()
                .PerActorScope();
        }
    }
}