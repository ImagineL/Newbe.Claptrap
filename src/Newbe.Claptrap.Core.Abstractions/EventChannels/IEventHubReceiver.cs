using System.Threading.Tasks;

namespace Newbe.Claptrap.Abstract.EventChannels
{
    public interface IEventHubReceiver
    {
        Task StartAsync();
    }
}