using System.Threading.Tasks;
using Newbe.Claptrap.Abstract.Core;
using Newbe.Claptrap.Demo.Models;

namespace Newbe.Claptrap.Demo.Impl.AccountImpl
{
    public class DefaultStateDataDataFactory
        : DefaultStateDataFactory<AccountStateData>
    {
        public DefaultStateDataDataFactory(IActorIdentity actorIdentity) : base(actorIdentity)
        {
        }

        public override Task<AccountStateData> Create()
        {
            var accountStateData = new AccountStateData
            {
                Status = AccountStatus.Active,
                Balance = 0
            };
            return Task.FromResult(accountStateData);
        }
    }
}