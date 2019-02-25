using System;
using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap.Attributes
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class MinionAttribute : ActorAttribute
    {
        public string MinionCatalog { get; }

        public MinionAttribute(string minionCatalog, string catalog, Type stateDataType)
            : base(ActorType.Minion, catalog, stateDataType)
        {
            MinionCatalog = minionCatalog;
        }
    }
}