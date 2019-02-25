using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection;
using Newbe.Claptrap.Abstract.Assemblies;
using Newbe.Claptrap.Abstract.Core;
using Newbe.Claptrap.Attributes;

namespace Newbe.Claptrap.Autofac.Reflection
{
    public class ClaptrapReflectionInfoProvider : IClaptrapReflectionInfoProvider
    {
        private readonly IEnumerable<IActorAssemblyProvider> _actorAssemblyProviders;

        public ClaptrapReflectionInfoProvider(
            IEnumerable<IActorAssemblyProvider> actorAssemblyProviders)
        {
            _actorAssemblyProviders = actorAssemblyProviders;
        }

        private IEnumerable<ActorReflectionInfo> _metadata;

        private void Init()
        {
            if (_metadata != null)
            {
                return;
            }

            var assemblies = _actorAssemblyProviders.SelectMany(x => x.GetAssemblies());
            var types = assemblies.SelectMany(x => x.GetTypes());
            var list = new List<ActorReflectionInfo>();
            foreach (var type in types)
            {
                var actorAttribute = type.GetCustomAttribute<ActorAttribute>();
                if (actorAttribute != null)
                {
                    var methodInfos = type.GetMethods();
                    var methodList = methodInfos.Select(m =>
                        {
                            var claptrapEventAttribute = m.GetCustomAttribute<ClaptrapEventAttribute>();
                            if (claptrapEventAttribute != null)
                            {
                                var actorEventReflectionInfo = new ActorEventReflectionInfo(
                                    claptrapEventAttribute.EventType,
                                    claptrapEventAttribute.EventDataType);
                                return actorEventReflectionInfo;
                            }

                            return null;
                        })
                        .Where(x => x != null)
                        .GroupBy(x => x.EventType)
                        .ToDictionary(x => x.Key, x => x.First());

                    var actorMetadata = new ActorReflectionInfo
                    {
                        ActorKind = new ActorKind(actorAttribute.ActorType, actorAttribute.Catalog),
                        StateDataType = actorAttribute.StateDataType,
                        ActorEventReflectionInfos = methodList.Values,
                    };
                    list.Add(actorMetadata);
                }
            }

            _metadata = list;
        }

        public ActorReflectionInfo FindActorReflectionInfo(IActorKind actorKind)
        {
            Init();
            return _metadata.FirstOrDefault(x => x.ActorKind.Equals(actorKind));
        }

        public IEnumerable<ActorReflectionInfo> GetReflectionInfos()
        {
            Init();
            return _metadata;
        }
    }
}