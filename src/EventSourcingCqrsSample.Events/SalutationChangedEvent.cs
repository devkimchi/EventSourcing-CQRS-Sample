namespace EventSourcingCqrsSample.Events
{
    /// <summary>
    /// This represents the event entity when salutation change occurs.
    /// </summary>
    public class SalutationChangedEvent : InputValueChangedEvent
    {
        /// <summary>
        /// Gets the name of the event.
        /// </summary>
        public override string Name => this.GetType().Name;
    }
}