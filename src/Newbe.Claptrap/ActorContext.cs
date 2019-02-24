using System.Threading.Tasks;
using Newbe.Claptrap.Abstract.Context;
using Newbe.Claptrap.Abstract.Core;
using Newbe.Claptrap.Abstract.StateInitializer;

namespace Newbe.Claptrap
{
    public class ActorContext : IActorContext
    {
        private readonly IStateInitializer _stateInitializer;

        public ActorContext(
            IActorIdentity identity,
            IStateInitializer stateInitializer)
        {
            _stateInitializer = stateInitializer;
            Identity = identity;
        }

        public IActorIdentity Identity { get; }
        public IState State { get; private set; }

        public async Task InitializeAsync()
        {
            var state = await _stateInitializer.InitializeAsync();
            State = state;
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }
    }
}