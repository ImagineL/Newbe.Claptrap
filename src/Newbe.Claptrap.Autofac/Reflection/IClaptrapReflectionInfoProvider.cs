using System.Collections.Generic;
using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap.Autofac.Reflection
{
    public interface IClaptrapReflectionInfoProvider
    {
        IEnumerable<ActorReflectionInfo> GetReflectionInfos();

        ActorReflectionInfo FindActorReflectionInfo(IActorKind actorKind);
    }
}