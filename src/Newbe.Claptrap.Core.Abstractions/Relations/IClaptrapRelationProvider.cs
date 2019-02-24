using System.Collections.Generic;
using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap.Abstract.Relations
{
    public interface IClaptrapRelationProvider
    {
        IEnumerable<ClaptrapRelation> GetRelations();
        ClaptrapRelation? Find(IActorKind actorKind);
    }
}