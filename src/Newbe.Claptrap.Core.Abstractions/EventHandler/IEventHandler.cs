using System;
using System.Threading.Tasks;
using Newbe.Claptrap.Abstract.Context;

namespace Newbe.Claptrap.Abstract.EventHandler
{
    public interface IEventHandler : IAsyncDisposable
    {
        Task HandleEvent(IEventContext eventContext);
    }
}