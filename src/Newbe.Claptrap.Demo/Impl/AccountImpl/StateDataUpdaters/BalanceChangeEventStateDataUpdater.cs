using Newbe.Claptrap.Demo.Models;
using Newbe.Claptrap.Demo.Models.EventData;

namespace Newbe.Claptrap.Demo.Impl.AccountImpl.StateDataUpdaters
{
    public class BalanceChangeEventStateDataUpdater
        : StateDataUpdaterBase<AccountStateData, BalanceChangeEventData>
    {
        public override void UpdateState(AccountStateData stateData, BalanceChangeEventData eventData)
        {
            stateData.Balance = eventData.Balance;
        }
    }
}