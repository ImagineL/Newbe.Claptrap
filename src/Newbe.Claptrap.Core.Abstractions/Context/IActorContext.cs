using System.Threading.Tasks;
using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap.Abstract.Context
{
    public interface IActorContext
    {
        IActorIdentity Identity { get; }
        IState State { get; }
        Task InitializeAsync();
        Task DisposeAsync();
    }
}