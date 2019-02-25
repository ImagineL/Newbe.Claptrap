using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Builder;
using Newbe.Claptrap.Abstract.EventHandler;
using Newbe.Claptrap.Abstract.StateInitializer;
using Newbe.Claptrap.Autofac.Reflection;

namespace Newbe.Claptrap.Autofac
{
    public static class AutofacHelper
    {
        public static void PerActorScope<TLimit, TActivatorData, TRegistrationStyle>(
            this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> builder)
        {
            builder.InstancePerMatchingLifetimeScope(Constants.ActorLifetimeScope);
        }

        public static void PerEventScope<TLimit, TActivatorData, TRegistrationStyle>(
            this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> builder)
        {
            builder.InstancePerMatchingLifetimeScope(Constants.EventLifetimeScope);
        }

        public static void RegisterUpdateStateDataHandlers(this ContainerBuilder builder,
            IEnumerable<Assembly> assemblies)
        {
            var assemblyArray = assemblies as Assembly[] ?? assemblies.ToArray();
            var provider = new ClaptrapReflectionInfoProvider(new[] {new ActorAssemblyProvider(assemblyArray),});
            IStateDataUpdaterRegistrationFinder finder = new StateDataUpdaterRegistrationFinder(provider);
            var allTypes = assemblyArray.SelectMany(x => x.GetTypes()).ToArray();
            var registrations = finder.FindAll(allTypes);
            foreach (var registration in registrations)
            {
                builder.RegisterType(registration.Type)
                    .Keyed<IStateDataUpdater>(registration.Key);
            }
        }

        public static void RegisterDefaultStateDataFactories(this ContainerBuilder builder,
            IEnumerable<Assembly> assemblies)
        {
            var assemblyArray = assemblies as Assembly[] ?? assemblies.ToArray();
            var provider = new ClaptrapReflectionInfoProvider(new[] {new ActorAssemblyProvider(assemblyArray)});
            var allTypes = assemblyArray.SelectMany(x => x.GetTypes()).ToArray();
            IDefaultStateDataFactoryFinder finder = new DefaultStateDataFactoryFinder(provider);
            var registrations = finder.FindAll(allTypes);
            foreach (var registration in registrations)
            {
                builder.RegisterType(registration.Type)
                    .Keyed<IDefaultStateDataFactory>(registration.Key);
            }
        }
    }
}