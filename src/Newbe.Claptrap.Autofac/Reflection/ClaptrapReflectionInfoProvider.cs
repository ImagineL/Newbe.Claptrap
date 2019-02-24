using System;
using System.Collections.Generic;
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

            var assemblies = _actorAssemblyProviders.Select(x => x.GetAssembly());
            var types = assemblies.SelectMany(x => x.GetTypes());
            var list = new List<ActorReflectionInfo>();
            foreach (var type in types)
            {
                var actorAttribute = type.GetCustomAttribute<ActorAttribute>();
                if (actorAttribute != null)
                {
                    var methodList = new Dictionary<string, ActorEventReflectionInfo>();
                    var claptrapEventAttributes = type.GetCustomAttributes<ClaptrapEventAttribute>();
                    foreach (var claptrapEventAttribute in claptrapEventAttributes)
                    {
                        var eventType = claptrapEventAttribute.EventType;
                        methodList[eventType] = new ActorEventReflectionInfo
                        {
                            EventType = eventType,
                            EventDataType = claptrapEventAttribute.EventDataType,
                        };
                    }

                    var actorMetadata = new ActorReflectionInfo
                    {
                        ActorKind = new ReflectionActorKind(actorAttribute.ActorType, actorAttribute.Catalog, type),
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

        public class ReflectionActorKind : IActorKind
        {
            public ActorType ActorType { get; }
            public string Catalog { get; }
            public Type ActorClassType { get; }

            public ReflectionActorKind(ActorType actorType, string catalog, Type actorClassType)
            {
                ActorType = actorType;
                Catalog = catalog;
                ActorClassType = actorClassType;
            }

            public bool Equals(IActorKind other)
            {
                return ActorType == other.ActorType && string.Equals(Catalog, other.Catalog);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                return Equals((IActorKind) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((int) ActorType * 397) ^ (Catalog != null ? Catalog.GetHashCode() : 0);
                }
            }

            public static bool operator ==(ReflectionActorKind left, ReflectionActorKind right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(ReflectionActorKind left, ReflectionActorKind right)
            {
                return !Equals(left, right);
            }
        }
    }
}