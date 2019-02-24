using System;
using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap.Abstract.Context
{
    public interface IEventContext
    {
        IEvent Event { get; }
        IActorContext ActorContext { get; }
    }
}