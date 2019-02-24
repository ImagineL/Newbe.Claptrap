using System.Threading.Tasks;

namespace Newbe.Claptrap.Abstract.EventHub
{
    public interface IEventHubReceiver
    {
        Task StartAsync();
    }
}