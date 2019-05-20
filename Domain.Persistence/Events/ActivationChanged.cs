namespace Domain.Persistence.Events
{
    public class ActivationChangedEvent : IEvent
    {
        public ActivationChangedEvent()
        {
            Type = EventType.Activation;
        }

        public bool Active { get; set; }

        public EventType Type { get; set; }
    }
}
