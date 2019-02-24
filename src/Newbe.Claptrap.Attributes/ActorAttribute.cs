using System;
using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap.Attributes
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class ActorAttribute : Attribute
    {
        public ActorType ActorType { get; }
        public string Catalog { get; }
        public Type StateDataType { get; }

        public ActorAttribute(ActorType actorType, string catalog, Type stateDataType)
        {
            ActorType = actorType;
            Catalog = catalog;
            StateDataType = stateDataType;
        }
    }
}