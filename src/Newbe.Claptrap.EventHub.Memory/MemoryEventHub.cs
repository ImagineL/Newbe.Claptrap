using System.Threading.Tasks;
using Newbe.Claptrap.Abstract.EventHub;

namespace Newbe.Claptrap.EventHub.Memory
{
    public class MemoryEventHub : IEventHubReceiver
    {
        public Task StartAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}