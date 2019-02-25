using System.Threading.Tasks;
using Newbe.Claptrap.Attributes;
using Newbe.Claptrap.Orleans;
using Orleans;

namespace Newbe.Claptrap.Demo.Interfaces
{
    [Minion("Database", "Account", typeof(NoneStateData))]
    public interface IAccountActorFlowMinion : IMinionGrain
    {
    }
}