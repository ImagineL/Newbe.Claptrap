using System;

namespace Newbe.Claptrap.Autofac.Reflection
{
    public class ActorEventReflectionInfo
    {
        public ActorEventReflectionInfo(string eventType, Type eventDataType)
        {
            EventType = eventType;
            EventDataType = eventDataType;
        }

        public string EventType { get; set; }
        public Type EventDataType { get; set; }
    }
}