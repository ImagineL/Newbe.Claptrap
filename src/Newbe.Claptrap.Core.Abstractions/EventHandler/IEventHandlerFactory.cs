using Newbe.Claptrap.Abstract.Context;

namespace Newbe.Claptrap.Abstract.EventHandler
{
    public interface IEventHandlerFactory
    {
        IEventHandler Create(IEventContext eventContext);
    }
}