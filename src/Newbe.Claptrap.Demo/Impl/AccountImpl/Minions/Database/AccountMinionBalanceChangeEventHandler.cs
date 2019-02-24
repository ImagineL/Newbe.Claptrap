using System;
using System.Threading.Tasks;
using Newbe.Claptrap.Demo.Models.EventData;

namespace Newbe.Claptrap.Demo.Impl.AccountImpl.Minions.Database
{
    public class AccountMinionBalanceChangeEventHandler :
        MinionEventHandlerBase<NoneStateData, BalanceChangeEventData>
    {
        public override Task HandleEventCore(NoneStateData state, BalanceChangeEventData @event)
        {
            Console.WriteLine(@event.Amount);
            return Task.CompletedTask;
        }
    }
}