using System.Threading.Tasks;
using Newbe.Claptrap.Abstract.Core;
using Newbe.Claptrap.Attributes;
using Newbe.Claptrap.Demo.Interfaces;
using Orleans;

namespace Newbe.Claptrap.Demo.Impl.AccountImpl.Minions.ActorFlow
{
    public class AccountMinion
        : Grain, IAccountActorFlowMinion
    {
        public override async Task OnActivateAsync()
        {
            await base.OnActivateAsync();
            var actorFactory = (IActorFactory) ServiceProvider.GetService(typeof(IActorFactory));
            var identity =
                new GrainActorIdentity(new MinionGrainActorKind(ActorType.Minion, nameof(Account), "Database"),
                    this.GetPrimaryKeyString());
            Actor = actorFactory.Create(identity);
            await Actor.ActivateAsync();
        }

        public IActor Actor { get; private set; }

        public override async Task OnDeactivateAsync()
        {
            await base.OnDeactivateAsync();
            await Actor.DeactivateAsync();
        }

        public Task Handle(GrainEvent grainEvent)
        {
            return Actor.HandleEvent(grainEvent);
        }
    }
}