using System.Threading.Tasks;

namespace Newbe.Claptrap.Abstract.EventChannels
{
    public interface IEventHubPublisher
    {
        Task StartAsync();
    }
}