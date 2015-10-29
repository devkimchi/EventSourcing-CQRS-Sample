using System;

namespace EventSourcingCqrsSample.Events
{
    /// <summary>
    /// This represents the entity for the projector who raised an event.
    /// </summary>
    public class Projector
    {
        private static readonly Guid SystemId = Guid.Parse("E2749C64-8955-4A70-92D7-9FBDF1E0E0C1");

        /// <summary>
        /// Initializes a new instance of the <see cref="Projector" /> class.
        /// </summary>
        /// <param name="dateProjected">Date when the event has been projected.</param>
        public Projector(DateTime? dateProjected = null)
        {
            this.DateProjected = dateProjected.GetValueOrDefault(DateTime.Now);
        }

        /// <summary>
        /// Gets the <see cref="Projector" /> instance as "SYSTEM".
        /// </summary>
        public static Projector System => new Projector() { ProjectorId = SystemId };

        /// <summary>
        /// Gets or sets the unique Id who raised the event.
        /// </summary>
        public Guid ProjectorId { get; set; }

        /// <summary>
        /// Gets or sets the date when the event has been projected.
        /// </summary>
        public DateTime DateProjected { get; set; }
    }
}