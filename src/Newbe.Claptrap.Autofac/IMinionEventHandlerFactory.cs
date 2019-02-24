using System.Collections.Generic;
using Newbe.Claptrap.Abstract.Context;
using Newbe.Claptrap.Abstract.EventHandler;

namespace Newbe.Claptrap.Autofac
{
    public interface IMinionEventHandlerFactory
    {
        IEnumerable<IEventHandler> Create(IEventContext eventContext);
    }
}