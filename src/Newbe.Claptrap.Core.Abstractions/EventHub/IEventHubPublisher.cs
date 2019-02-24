using System.Threading.Tasks;

namespace Newbe.Claptrap.Abstract.EventHub
{
    public interface IEventHubPublisher
    {
        Task StartAsync();
    }
}