﻿using System.Threading.Tasks;
using Newbe.Claptrap.Abstract.Core;
using Newbe.Claptrap.Abstract.EventChannels;

namespace Newbe.Claptrap.EventHub.Memory
{
    public class EventPublishChannel : IEventPublishChannel
    {

        public delegate EventPublishChannel Factory();
        
        private readonly IEventHubManager _eventHubManager;

        public EventPublishChannel(
            IEventHubManager eventHubManager)
        {
            _eventHubManager = eventHubManager;
        }

        public Task Publish(IEvent @event)
        {
            _eventHubManager.Publish(@event.ActorIdentity, @event);
            return Task.CompletedTask;
        }
    }
}