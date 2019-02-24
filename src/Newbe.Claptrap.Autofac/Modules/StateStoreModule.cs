using Autofac;
using Newbe.Claptrap.Abstract.Core;
using Newbe.Claptrap.Abstract.StateStore;

namespace Newbe.Claptrap.Autofac.Modules
{
    public class StateStoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<StateStoreFactory>()
                .As<IStateStoreFactory>();
            builder.Register(context =>
                    context.Resolve<IStateStoreFactory>().Create(context.Resolve<IActorIdentity>()))
                .As<IStateStore>()
                .PerActorScope();
        }
    }
}