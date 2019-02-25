using System.Threading.Tasks;
using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap.Abstract.EventChannels
{
    public interface IEventReceiveChannel
    {
        /// <summary>
        /// receive event from claptrap
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        Task Receive(IEvent @event);
    }
}