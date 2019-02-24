using Autofac;
using Newbe.Claptrap.Autofac.Reflection;

namespace Newbe.Claptrap.Autofac.Modules
{
    public class ReflectionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<ClaptrapReflectionInfoProvider>()
                .As<IClaptrapReflectionInfoProvider>()
                .SingleInstance();
        }
    }
}