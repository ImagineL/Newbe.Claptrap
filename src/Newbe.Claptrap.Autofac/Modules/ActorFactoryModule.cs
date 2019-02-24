using Autofac;
using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap.Autofac.Modules
{
    public class ActorFactoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<ActorFactory>()
                .As<IActorFactory>();
            builder.RegisterType<Actor>()
                .AsSelf();
        }
    }
}