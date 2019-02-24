using System;
using System.Collections.Generic;
using System.Linq;
using Newbe.Claptrap.Abstract.Core;
using Newbe.Claptrap.Abstract.StateInitializer;
using Newbe.Claptrap.Autofac.Reflection;

namespace Newbe.Claptrap.Autofac
{
    public class DefaultStateDataFactoryFinder : IDefaultStateDataFactoryFinder
    {
        private readonly IClaptrapReflectionInfoProvider _claptrapReflectionInfoProvider;

        public DefaultStateDataFactoryFinder(
            IClaptrapReflectionInfoProvider claptrapReflectionInfoProvider)
        {
            _claptrapReflectionInfoProvider = claptrapReflectionInfoProvider;
        }

        public IEnumerable<DefaultStateDataFactoryRegistration> FindAll(Type[] types)
        {
            var factoryTypes = types
                .Where(x => x.GetInterface(nameof(IDefaultStateDataFactory)) != null)
                .ToArray();

            IRegistrationResolver[] resolvers =
            {
                new BaseTypeRegistrationResolver(_claptrapReflectionInfoProvider)
            };

            var re = factoryTypes.Select(Resolve).Where(x => x != null).ToArray();
            return re;

            DefaultStateDataFactoryRegistration? Resolve(Type type)
            {
                foreach (var resolver in resolvers)
                {
                    var registration = resolver.Resolve(type);
                    if (registration != null)
                    {
                        return registration;
                    }
                }

                return null;
            }
        }

        public interface IRegistrationResolver
        {
            DefaultStateDataFactoryRegistration? Resolve(Type type);
        }

        /// <summary>
        /// if it is implement of DefaultStateDataFactory&lt;TStateData&gt;, then we thick it is the IDefaultStateDataFactory for the actor which has the same StateDataType in actor metadata.
        /// </summary>
        public class BaseTypeRegistrationResolver : IRegistrationResolver
        {
            private readonly IClaptrapReflectionInfoProvider _claptrapReflectionInfoProvider;

            public BaseTypeRegistrationResolver(
                IClaptrapReflectionInfoProvider claptrapReflectionInfoProvider)
            {
                _claptrapReflectionInfoProvider = claptrapReflectionInfoProvider;
            }

            public DefaultStateDataFactoryRegistration? Resolve(Type type)
            {
                var reflectionActorMetadata = _claptrapReflectionInfoProvider.GetReflectionInfos();
                var baseTypes = ReflectionHelper.GetBaseType(type);
                foreach (var baseType in baseTypes)
                {
                    if (baseType.IsGenericType
                        && baseType.GetGenericTypeDefinition() == typeof(DefaultStateDataFactory<>))
                    {
                        var stateDataType = baseType.GenericTypeArguments[0];
                        foreach (var metadata in reflectionActorMetadata)
                        {
                            if (metadata.StateDataType == stateDataType)
                            {
                                var key = new DefaultStateDataFactoryRegistrationKey(metadata.ActorKind);
                                return new DefaultStateDataFactoryRegistration(type, key);
                            }
                        }
                    }
                }

                return null;
            }
        }
    }
}