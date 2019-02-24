using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap.Abstract.EventHandler
{
    public interface IStateDataUpdaterFactory
    {
        IStateDataUpdater Create(IState state, IEvent @event);
    }
}