using Newbe.Claptrap.Abstract;
using Newbe.Claptrap.Abstract.Context;
using Newbe.Claptrap.Abstract.Core;
using Newbe.Claptrap.Abstract.StateInitializer;

namespace Newbe.Claptrap.Autofac
{
    public class StateInitializerFactory : IStateInitializerFactory
    {
        private readonly Factory _factory;

        public delegate StateInitializer Factory(
            EventSourcingStateBuilderOptions options);

        public StateInitializerFactory(
            Factory factory)
        {
            _factory = factory;
        }

        public IStateInitializer Create(IActorIdentity actorIdentity)
        {
            var re = _factory(new EventSourcingStateBuilderOptions
            {
                RestoreEventVersionCountPerTime = 5000
            });
            return re;
        }
    }
}