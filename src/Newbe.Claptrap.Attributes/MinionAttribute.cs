using System;
using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap.Attributes
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class MinionAttribute : ActorAttribute
    {
        public string ClaptrapCatalog { get; }

        public MinionAttribute(string catalog, string claptrapCatalog, Type stateDataType)
            : base(ActorType.Minion, catalog, stateDataType)
        {
            ClaptrapCatalog = claptrapCatalog;
        }
    }
}