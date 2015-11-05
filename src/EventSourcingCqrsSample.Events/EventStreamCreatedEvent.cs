namespace EventSourcingCqrsSample.Events
{
    /// <summary>
    /// This represents the event entity when event stream is created.
    /// </summary>
    public class EventStreamCreatedEvent : BaseEvent
    {
        /// <summary>
        /// Gets the name of the event.
        /// </summary>
        public override string Name => this.GetType().Name;
    }
}