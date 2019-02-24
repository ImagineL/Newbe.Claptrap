using System.Threading.Tasks;
using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap.Abstract.StateInitializer
{
    public interface IStateInitializer
    {
        IActorIdentity ActorIdentity { get; }
        Task<IState> InitializeAsync();
    }
}