using AutoMapper;

using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Repositories;

namespace EventSourcingCqrsSample.EventHandlers.Map
{
    /// <summary>
    /// This represents the mapper entity for event inheriting <see cref="BaseEvent" /> to <see cref="EventStream" />. This must be inherited.
    /// </summary>
    /// <typeparam name="T">Type of event.</typeparam>
    public abstract class BaseEventToEventStreamMapper<T> : IEventToEventStreamMapper<T> where T : BaseEvent
    {
        private bool _disposed;

        /// <summary>
        /// Gets or sets a value indicating whether the mapper definition has been initialised or not.
        /// </summary>
        protected bool Initialised { get; set; }

        /// <summary>
        /// Checks whether the event instance can be mapped to <see cref="EventStream" /> class.
        /// </summary>
        /// <param name="ev">Event instance</param>
        /// <returns>Returns <c>True</c>; if the given event can be mapped to <see cref="EventStream" />; otherwise returns <c>False</c>.</returns>
        public virtual bool CanMap(BaseEvent ev)
        {
            var @event = ev as T;
            return @event != null;
        }

        /// <summary>
        /// Maps the given event to the <see cref="EventStream" /> class.
        /// </summary>
        /// <param name="ev">Event to map.</param>
        /// <returns>Returns the <see cref="EventStream" /> mapped.</returns>
        public virtual EventStream Map(T ev)
        {
            if (!this.CanMap(ev))
            {
                return null;
            }

            this.Initialise();

            var mapped = Mapper.Map<EventStream>(ev);
            return mapped;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            if (this._disposed)
            {
                return;
            }

            this._disposed = true;
        }

        /// <summary>
        /// Initialises the mapping definition.
        /// </summary>
        protected abstract void Initialise();
    }
}