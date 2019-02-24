using System.Threading.Tasks;
using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap.Abstract.StateInitializer
{
    public interface IDefaultStateDataFactory
    {
        IActorIdentity ActorIdentity { get; }
        Task<IStateData> Create();
    }
}