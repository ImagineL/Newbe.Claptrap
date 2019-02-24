using System;
using System.Collections.Generic;

namespace Newbe.Claptrap.Abstract.Core
{
    /// <inheritdoc />
    /// <summary>
    ///  unique id of event, events with the same uid will be process only once.
    /// </summary>
    public interface IEventUid : IEquatable<IEventUid>
    {
    }
}