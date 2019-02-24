using System.Threading.Tasks;
using Newbe.Claptrap.Attributes;
using Newbe.Claptrap.Demo.Models.EventData;
using Orleans;

namespace Newbe.Claptrap.Demo.Interfaces
{
    [Minion("Database", "Account", typeof(NoneStateData))]
    [MinionEvent(nameof(BalanceChangeEventData))]
    [MinionEvent(nameof(LockEventData))]
    public interface IAccountDatabaseMinion : IGrainWithStringKey
    {
        Task Handle(GrainEvent grainEvent);
    }
}