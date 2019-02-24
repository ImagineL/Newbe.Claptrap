using System.Threading.Tasks;
using Newbe.Claptrap.Demo.Models;
using Newbe.Claptrap.Demo.Models.EventData;

namespace Newbe.Claptrap.Demo.Impl.AccountImpl.EventMethods.AddBalanceImpl
{
    public interface IAddBalanceMethod
    {
        Task<EventMethodResult<BalanceChangeEventData>> Invoke(AccountStateData stateData, decimal amount);
    }
}