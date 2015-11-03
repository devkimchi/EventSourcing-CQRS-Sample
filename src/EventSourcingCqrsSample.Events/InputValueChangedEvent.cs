namespace EventSourcingCqrsSample.Events
{
    /// <summary>
    /// This represents the event entity for all inputs when their values have been changed. This must be inherited.
    /// </summary>
    public abstract class InputValueChangedEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the element Id.
        /// </summary>
        public string ElementId { get; set; }

        /// <summary>
        /// Gets or sets the element name.
        /// </summary>
        public string ElementName { get; set; }

        /// <summary>
        /// Gets or sets the element value.
        /// </summary>
        public string ElementValue { get; set; }
    }
}