namespace EventSourcingCqrsSample.Events
{
    /// <summary>
    /// This represents the event entity for default.
    /// </summary>
    public class DefaultEvent : BaseEvent
    {
        /// <summary>
        /// Gets the name of the event.
        /// </summary>
        public override string Name => this.GetType().Name;
    }
}