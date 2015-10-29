namespace EventSourcingCqrsSample.Events
{
    /// <summary>
    /// This represents the event entity for all inputs when their values have been changed. This must be inherited.
    /// </summary>
    public abstract class InputValueChangedEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string Value { get; set; }
    }
}