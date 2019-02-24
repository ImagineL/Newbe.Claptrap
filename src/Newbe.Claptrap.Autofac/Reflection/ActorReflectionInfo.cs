using System;
using System.Collections.Generic;
using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap.Autofac.Reflection
{
    public class ActorReflectionInfo
    {
        public IActorKind ActorKind { get; set; }
        public Type StateDataType { get; set; }
        public IEnumerable<ActorEventReflectionInfo> ActorEventReflectionInfos { get; set; }
    }
}