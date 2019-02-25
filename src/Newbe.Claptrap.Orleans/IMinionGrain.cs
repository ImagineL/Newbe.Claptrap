using System.Threading.Tasks;
using Newbe.Claptrap.Abstract.Core;
using Orleans;

namespace Newbe.Claptrap.Orleans
{
    public interface IMinionGrain : IGrainWithStringKey
    {
        Task HandleEvent(IEvent @event);
    }
}