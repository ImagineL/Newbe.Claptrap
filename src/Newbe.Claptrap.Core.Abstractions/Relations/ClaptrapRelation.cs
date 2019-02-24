using System.Collections.Generic;
using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap.Abstract.Relations
{
    public class ClaptrapRelation
    {
        public IActorKind ActorKind { get; set; }

        public IEnumerable<IMinionKind> MinionKinds { get; set; }
    }
}