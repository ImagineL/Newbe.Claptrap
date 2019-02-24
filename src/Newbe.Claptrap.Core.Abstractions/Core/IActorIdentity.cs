using System;

namespace Newbe.Claptrap.Abstract.Core
{
    /// <inheritdoc />
    /// <summary>
    ///     identity of a actor
    /// </summary>
    public interface IActorIdentity : IEquatable<IActorIdentity>
    {
        /// <summary>
        /// the kind of this actor
        /// </summary>
        IActorKind Kind { get; }

        /// <summary>
        ///     id of a actor. it is unique id if the catalog is the same.
        /// </summary>
        string Id { get; }
    }
}