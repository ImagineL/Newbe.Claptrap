using Newbe.Claptrap.Abstract.Core;
using Newbe.Claptrap.Abstract.EventHandler;

namespace Newbe.Claptrap
{
    public abstract class StateDataUpdaterBase<TStateData, TEventData>
        : IStateDataUpdater
        where TStateData : class, IStateData
        where TEventData : class, IEventData
    {
        void IStateDataUpdater.UpdateStateData(IStateData state, IEventData @event)
        {
            UpdateState((TStateData) state, (TEventData) @event);
        }

        public abstract void UpdateState(TStateData stateData, TEventData eventData);
    }
}