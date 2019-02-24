using System.Threading.Tasks;
using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap.Abstract.EventHub
{
    public interface IEventPublishChannel
    {
        /// <summary>
        /// publish event to minion
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        Task Publish(IEvent @event);
    }
}