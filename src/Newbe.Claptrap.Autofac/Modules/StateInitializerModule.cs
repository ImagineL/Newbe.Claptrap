using Autofac;
using Newbe.Claptrap.Abstract.Core;
using Newbe.Claptrap.Abstract.StateInitializer;

namespace Newbe.Claptrap.Autofac.Modules
{
    public class StateInitializerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<StateInitializerFactory>()
                .As<IStateInitializerFactory>();
            builder.RegisterType<StateInitializer>()
                .AsSelf();
            builder.Register(context =>
                    context.Resolve<IStateInitializerFactory>().Create(context.Resolve<IActorIdentity>()))
                .As<IStateInitializer>();
            builder.RegisterType<AutofacDefaultStateDataFactory>()
                .As<IDefaultStateDataFactory>();
        }
    }
}