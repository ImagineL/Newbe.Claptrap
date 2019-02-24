using System;
using System.Collections.Generic;
using System.Linq;
using Newbe.Claptrap.Autofac.Reflection;
using Newbe.Claptrap.EventHandlers;

namespace Newbe.Claptrap.Autofac
{
    class StateDataUpdaterRegistrationFinder : IStateDataUpdaterRegistrationFinder
    {
        private readonly IClaptrapReflectionInfoProvider _claptrapReflectionInfoProvider;

        public StateDataUpdaterRegistrationFinder(
            IClaptrapReflectionInfoProvider claptrapReflectionInfoProvider)
        {
            _claptrapReflectionInfoProvider = claptrapReflectionInfoProvider;
        }

        public IEnumerable<StateDataUpdaterRegistration> FindAll(Type[] types)
        {
            IRegistrationResolver[] finders =
            {
                new BaseTypeRegistrationResolver(_claptrapReflectionInfoProvider),
            };
            var re = FindAllCore();
            return re;

            IEnumerable<StateDataUpdaterRegistration> FindAllCore()
            {
                foreach (var type in types)
                {
                    foreach (var finder in finders)
                    {
                        var registration = finder.Resolve(type);
                        if (registration != null)
                        {
                            yield return (StateDataUpdaterRegistration) registration;
                        }
                    }
                }
            }
        }

        public interface IRegistrationResolver
        {
            StateDataUpdaterRegistration? Resolve(Type type);
        }

        public class BaseTypeRegistrationResolver : IRegistrationResolver
        {
            private readonly IClaptrapReflectionInfoProvider _claptrapReflectionInfoProvider;

            public BaseTypeRegistrationResolver(
                IClaptrapReflectionInfoProvider claptrapReflectionInfoProvider)
            {
                _claptrapReflectionInfoProvider = claptrapReflectionInfoProvider;
            }

            public StateDataUpdaterRegistration? Resolve(Type type)
            {
                var reflectionActorMetadata = _claptrapReflectionInfoProvider.GetReflectionInfos();
                var reflectionActorMetadatas = reflectionActorMetadata as ActorReflectionInfo[] ??
                                               reflectionActorMetadata.ToArray();
                var baseTypes = ReflectionHelper.GetBaseType(type);
                foreach (var baseType in baseTypes)
                {
                    if (baseType.IsGenericType
                        && baseType.GetGenericTypeDefinition() == typeof(StateDataUpdaterBase<,>))
                    {
                        var stateDataType = baseType.GenericTypeArguments[0];
                        var eventDataType = baseType.GenericTypeArguments[1];
                        foreach (var metadata in reflectionActorMetadatas)
                        {
                            if (metadata.StateDataType == stateDataType)
                            {
                                foreach (var actorEventMetadata in metadata.ActorEventReflectionInfos)
                                {
                                    if (actorEventMetadata is ActorEventReflectionInfo eventMetadata
                                        && eventMetadata.EventDataType == eventDataType)
                                    {
                                        var key = new StateDataUpdaterRegistrationKey(metadata.ActorKind,
                                            actorEventMetadata.EventType);
                                        var re = new StateDataUpdaterRegistration(key, type);
                                        return re;
                                    }
                                }
                            }
                        }
                    }
                }

                return null;
            }
        }
    }
}