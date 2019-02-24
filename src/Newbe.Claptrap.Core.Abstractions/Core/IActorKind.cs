using System;

namespace Newbe.Claptrap.Abstract.Core
{
    /// <inheritdoc />
    /// <summary>
    /// the kind of a actor. actor must be the same if they have the same ActorKind and Id
    /// </summary>
    public interface IActorKind : IEquatable<IActorKind>
    {
        /// <summary>
        /// actor type
        /// </summary>
        ActorType ActorType { get; }

        /// <summary>
        /// catalog of actor. that can be related to business info.
        /// </summary>
        string Catalog { get; }
    }
}