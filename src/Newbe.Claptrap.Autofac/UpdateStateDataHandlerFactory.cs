using System;
using Autofac;
using Newbe.Claptrap.Abstract.Core;
using Newbe.Claptrap.Abstract.EventHandler;

namespace Newbe.Claptrap.Autofac
{
    public class StateDataUpdaterFactory : IStateDataUpdaterFactory
    {
        private readonly IComponentContext _componentContext;

        public StateDataUpdaterFactory(
            IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public IStateDataUpdater Create(IState state, IEvent @event)
        {
            var key = new StateDataUpdaterRegistrationKey(state.Identity.Kind, @event.EventType);
            if (_componentContext.TryResolveKeyed(key,
                    typeof(IStateDataUpdater),
                    out var service)
                && service is IStateDataUpdater updater)
            {
                return updater;
            }

            throw new ArgumentOutOfRangeException(state.Identity.Kind.Catalog);
        }
    }
}