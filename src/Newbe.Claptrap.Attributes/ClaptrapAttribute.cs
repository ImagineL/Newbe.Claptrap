using System;
using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap.Attributes
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class ClaptrapAttribute : ActorAttribute
    {
        public ClaptrapAttribute(string catalog, Type stateDataType)
            : base(ActorType.Claptrap, catalog, stateDataType)
        {
        }
    }
}