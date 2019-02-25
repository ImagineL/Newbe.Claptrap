using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newbe.Claptrap.Abstract.Assemblies;
using Newbe.Claptrap.Abstract.Core;
using Newbe.Claptrap.Abstract.Relations;
using Newbe.Claptrap.Attributes;

namespace Newbe.Claptrap.Autofac.Reflection
{
    public class ClaptrapRelationProvider : IClaptrapRelationProvider
    {
        private readonly Lazy<IEnumerable<ClaptrapRelation>> _cache;

        public ClaptrapRelationProvider(
            IEnumerable<IActorAssemblyProvider> actorAssemblyProviders)
        {
            _cache = new Lazy<IEnumerable<ClaptrapRelation>>(() =>
            {
                var allTypes = actorAssemblyProviders.SelectMany(x => x.GetAssemblies()).SelectMany(x => x.GetTypes());
                var actorAttributes =
                    allTypes.Select(x => x.GetCustomAttribute<ActorAttribute>()).Where(x => x != null);

                var claptrapRelations = actorAttributes.GroupBy(x => x.Catalog).Select(x =>
                {
                    return new ClaptrapRelation
                    {
                        ActorKind = new ActorKind(ActorType.Claptrap, x.Key),
                        MinionKinds = x.OfType<MinionAttribute>()
                            .Select(a => new MinionKind(ActorType.Minion, a.Catalog, a.MinionCatalog)).ToArray()
                    };
                });
                return claptrapRelations;
            });
        }

        public IEnumerable<ClaptrapRelation> GetRelations()
        {
            return _cache.Value;
        }

        public ClaptrapRelation? Find(IActorKind actorKind)
        {
            return _cache.Value.FirstOrDefault(x => x.ActorKind.Equals(actorKind));
        }
    }
}