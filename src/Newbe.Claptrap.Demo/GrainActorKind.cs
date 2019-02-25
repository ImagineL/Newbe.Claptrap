using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap.Demo
{
    public class GrainActorKind : IActorKind
    {
        public GrainActorKind(ActorType actorType, string catalog)
        {
            ActorType = actorType;
            Catalog = catalog;
        }

        public ActorType ActorType { get; }
        public string Catalog { get; }

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
    }

    public class MinionGrainActorKind : IMinionKind
    {
        public MinionGrainActorKind(ActorType actorType, string catalog, string minionKind)
        {
            ActorType = actorType;
            Catalog = catalog;
            MinionCatalog = minionKind;
        }

        public ActorType ActorType { get; }
        public string Catalog { get; }
        public string MinionCatalog { get; }

        public bool Equals(IActorKind other)
        {
            if (other is IMinionKind kind)
            {
                return Equals(kind);
            }

            return false;
        }

        public bool Equals(IMinionKind other)
        {
            return other.Catalog == Catalog &&
                   other.MinionCatalog == MinionCatalog &&
                   other.ActorType == ActorType;
        }
    }
}