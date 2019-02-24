using Autofac;
using Newbe.Claptrap.Abstract.Context;
using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap.Autofac.Modules
{
    public class ActorContextModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<AutofacActorLifetimeScope>()
                .AsSelf()
                .As<IActorLifetimeScope>()
                .PerActorScope();
            builder.Register(context =>
                    context.Resolve<IActorLifetimeScope>().Identity)
                .As<IActorIdentity>()
                .PerActorScope();

            builder.RegisterType<ActorContext>()
                .As<IActorContext>()
                .PerActorScope();
        }
    }
}