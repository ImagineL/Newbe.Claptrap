using System.Threading.Tasks;
using Newbe.Claptrap.Attributes;
using Orleans;

namespace Newbe.Claptrap.Demo.Interfaces
{
    [Minion("Database", "Account", typeof(NoneStateData))]
    [MinionEvent("")]
    public interface IAccountActorFlowMinion : IGrainWithStringKey
    {
        Task Handle(GrainEvent grainEvent);
    }
}