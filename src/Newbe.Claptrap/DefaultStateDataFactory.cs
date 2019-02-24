using System.Threading.Tasks;
using Newbe.Claptrap.Abstract.Core;
using Newbe.Claptrap.Abstract.StateInitializer;

namespace Newbe.Claptrap
{
    public abstract class DefaultStateDataFactory<TStateData>
        : IDefaultStateDataFactory
        where TStateData : class, IStateData
    {
        protected DefaultStateDataFactory(IActorIdentity actorIdentity)
        {
            ActorIdentity = actorIdentity;
        }

        public abstract Task<TStateData> Create();

        public IActorIdentity ActorIdentity { get; }

        async Task<IStateData> IDefaultStateDataFactory.Create()
        {
            var re = await Create();
            return re;
        }
    }
}