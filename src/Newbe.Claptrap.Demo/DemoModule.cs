using Autofac;
using Newbe.Claptrap.Abstract.Assemblies;
using Newbe.Claptrap.Autofac;
using Newbe.Claptrap.Autofac.Reflection;
using Newbe.Claptrap.Demo.Impl.AccountImpl;
using Newbe.Claptrap.Demo.Impl.AccountImpl.EventMethods.AddBalanceImpl;
using Newbe.Claptrap.Demo.Impl.AccountImpl.EventMethods.LockImpl;
using Newbe.Claptrap.Demo.Impl.AccountImpl.EventMethods.TransferImpl;
using Newbe.Claptrap.Demo.Interfaces;

namespace Newbe.Claptrap.Demo
{
    public class DemoModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<Account>()
                .PropertiesAutowired()
                .As<IAccount>();

            builder.RegisterType<AddBalanceMethod>()
                .As<IAddBalanceMethod>();
            builder.RegisterType<LockMethod>()
                .As<ILockMethod>();
            builder.RegisterType<TransferMethod>()
                .As<ITransferMethod>();

            var assembly = typeof(DemoModule).Assembly;
            builder.RegisterDefaultStateDataFactories(assembly);
            builder.RegisterUpdateStateDataHandlers(assembly);
            builder.Register(context =>
                    new ActorAssemblyProvider(assembly))
                .As<IActorAssemblyProvider>();
        }
    }
}