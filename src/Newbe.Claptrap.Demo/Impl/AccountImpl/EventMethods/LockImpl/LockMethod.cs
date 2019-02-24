using System.Threading.Tasks;
using Newbe.Claptrap.Demo.Models;
using Newbe.Claptrap.Demo.Models.EventData;

namespace Newbe.Claptrap.Demo.Impl.AccountImpl.EventMethods.LockImpl
{
    public class LockMethod : ILockMethod
    {
        public Task<EventMethodResult<LockEventData>> Invoke(AccountStateData stateData)
        {
            if (stateData.Status != AccountStatus.Locked)
            {
                var result = EventMethodResult.Ok(new LockEventData());
                return Task.FromResult(result);
            }

            return Task.FromResult(EventMethodResult.None<LockEventData>());
        }
    }
}