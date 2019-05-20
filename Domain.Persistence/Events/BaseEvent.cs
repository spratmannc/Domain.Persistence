using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Persistence.Events
{
    /// <summary>
    /// Entity that gets save to the event store
    /// </summary>
    public class EventEntity
    {
        public long Id { get; set; }

        public DateTimeOffset Occurred { get; set; } = DateTimeOffset.Now;

        public EventType Type { get; set; }

        public IEvent Event { get; set; }

        public EventEntity()
        {
        }

        public EventEntity(IEvent evt)
        {
            Event = evt;
            Type = evt.Type;
        }
    }

    public interface IEvent
    {
        EventType Type { get; set; }
    }

    public class BaseEvent : IEvent
    {
        public EventType Type { get; set; }
    }
}
