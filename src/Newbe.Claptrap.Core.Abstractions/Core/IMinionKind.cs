using System;

namespace Newbe.Claptrap.Abstract.Core
{
    public interface IMinionKind : IActorKind, IEquatable<IMinionKind>
    {
        string MinionCatalog { get; }
    }
}