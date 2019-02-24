using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap.Abstract.EventHandler
{
    public interface IStateDataUpdater
    {
        void UpdateStateData(IStateData state, IEventData @event);
    }
}