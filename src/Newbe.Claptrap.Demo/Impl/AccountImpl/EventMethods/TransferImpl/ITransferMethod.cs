using System.Threading.Tasks;
using Newbe.Claptrap.Demo.Interfaces;
using Newbe.Claptrap.Demo.Models;
using Newbe.Claptrap.Demo.Models.EventData;

namespace Newbe.Claptrap.Demo.Impl.AccountImpl.EventMethods.TransferImpl
{
    public interface ITransferMethod
    {
        Task<EventMethodResult<BalanceChangeEventData, TransferResult>> Invoke(AccountStateData stateData,
            decimal amount);
    }
}