using Autofac;
using Newbe.Claptrap.Abstract.Context;
using Newbe.Claptrap.Abstract.EventHandler;
using Newbe.Claptrap.EventHandlers;

namespace Newbe.Claptrap.Autofac.Modules
{
    public class EventHandlerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<ClaptrapStateEventHandler>()
                .AsSelf()
                .PerEventScope();
            builder.RegisterType<ClaptrapEventPublishEventHandler>()
                .AsSelf()
                .PerEventScope();
            builder.RegisterType<MinionEventHandler>()
                .AsSelf()
                .PerEventScope();
            builder.RegisterType<StateRestoreEventHandler>()
                .AsSelf()
                .PerEventScope();
            builder.RegisterType<AutofacEventLifetimeScope>()
                .AsSelf()
                .As<IEventLifetimeScope>()
                .PerEventScope();
            builder.Register(context =>
                    context.Resolve<IEventLifetimeScope>().EventContext)
                .As<IEventContext>()
                .PerEventScope();
            builder.RegisterType<EventHandlerFactory>()
                .As<IEventHandlerFactory>();
            builder.RegisterType<StateDataUpdaterFactory>()
                .As<IStateDataUpdaterFactory>();
        }
    }
}