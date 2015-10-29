namespace EventSourcingCqrsSample.Events
{
    /// <summary>
    /// This represents the event entity when email change occurs.
    /// </summary>
    public class EmailChangedEvent : InputValueChangedEvent
    {
        /// <summary>
        /// Gets the name of the event.
        /// </summary>
        public override string Name => this.GetType().Name;
    }
}