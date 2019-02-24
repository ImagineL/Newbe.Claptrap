using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap.Orleans
{
    public static class GrainIdHelper
    {
        public static string GetGrainId(IActorIdentity identity)
        {
            return $"{identity.Kind.Catalog}_{identity.Id}";
        }
    }
}