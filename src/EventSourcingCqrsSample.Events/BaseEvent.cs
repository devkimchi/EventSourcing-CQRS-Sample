using System;

namespace EventSourcingCqrsSample.Events
{
    /// <summary>
    /// This represents the base event entity. This must be inherited.
    /// </summary>
    public abstract class BaseEvent
    {
        /// <summary>
        /// Gets or sets the event Id.
        /// </summary>
        public Guid EventId { get; set; }

        /// <summary>
        /// Gets the name of the event.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets or sets the event stream.
        /// </summary>
        public Guid EventStream { get; set; }

        /// <summary>
        /// Gets or sets the sequence of the event.
        /// </summary>
        public long Sequence { get; set; }

        /// <summary>
        /// Gets or sets the date in UTC when the event has occurred.
        /// </summary>
        public DateTime DateOccurred { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Projector" />.
        /// </summary>
        public Projector Projector { get; set; }

        /// <summary>
        /// Gets or sets the date in UTC when the event has been recorded.
        /// </summary>
        public DateTime DateRecorded { get; set; }
    }
}