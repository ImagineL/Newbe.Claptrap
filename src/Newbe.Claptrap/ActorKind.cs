using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap
{
    public class ActorKind : IActorKind
    {
        public ActorType ActorType { get; }
        public string Catalog { get; }

        public ActorKind(ActorType actorType, string catalog)
        {
            ActorType = actorType;
            Catalog = catalog;
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

        public static bool operator ==(ActorKind left, ActorKind right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ActorKind left, ActorKind right)
        {
            return !Equals(left, right);
        }
    }
}