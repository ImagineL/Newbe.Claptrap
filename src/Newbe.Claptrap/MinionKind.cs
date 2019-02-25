using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap
{
    public class MinionKind : IMinionKind
    {
        public ActorType ActorType { get; }
        public string Catalog { get; }
        public string MinionCatalog { get; }

        public MinionKind(ActorType actorType, string catalog, string minionCatalog)
        {
            ActorType = actorType;
            Catalog = catalog;
            MinionCatalog = minionCatalog;
        }

        protected bool Equals(MinionKind other)
        {
            return ActorType == other.ActorType && string.Equals(Catalog, other.Catalog) &&
                   string.Equals(MinionCatalog, other.MinionCatalog);
        }

        public bool Equals(IActorKind other)
        {
            return other is IMinionKind a && Equals(a);
        }

        public bool Equals(IMinionKind other)
        {
            return other is MinionKind a && Equals(a);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MinionKind) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) ActorType;
                hashCode = (hashCode * 397) ^ (Catalog != null ? Catalog.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (MinionCatalog != null ? MinionCatalog.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(MinionKind left, MinionKind right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MinionKind left, MinionKind right)
        {
            return !Equals(left, right);
        }
    }
}