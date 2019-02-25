using Newbe.Claptrap.Abstract.Core;

namespace Newbe.Claptrap.Abstract.EventChannels
{
    public interface IEventPublishChannelProvider
    {
        IEventPublishChannel Create(IActorIdentity claptrapIdentity, IMinionKind minionKind);
    }
}