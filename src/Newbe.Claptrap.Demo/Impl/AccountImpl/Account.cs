using System.Threading.Tasks;
using Newbe.Claptrap.Demo.Interfaces;
using Orleans;

namespace Newbe.Claptrap.Demo.Impl.AccountImpl
{
    public partial class Account : Grain, IAccount
    {
        public Task<decimal> GetBalance()
        {
            return Task.FromResult(ActorState.Balance);
        }
    }
}