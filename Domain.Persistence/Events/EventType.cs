using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain.Persistence.Events
{
    public enum EventType
    {
        PropertyChanged,
        Created,
        Deleted,
        Activation
    }

    public static class EventCollection
    {
        public static readonly IDictionary<EventType, Type> All = new Dictionary<EventType, Type>
        {
            { EventType.Activation, typeof(ActivationChangedEvent) }
        };
    }
}