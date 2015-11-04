using System;

using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Repositories;

namespace EventSourcingCqrsSample.EventHandlers.Map
{
    /// <summary>
    /// This provides interfaces to mappers inheriting the <see cref="BaseEventToEventStreamMapper{T}" /> class.
    /// </summary>
    /// <typeparam name="T">Type of event.</typeparam>
    public interface IEventToEventStreamMapper<in T> : IDisposable where T : BaseEvent
    {
        /// <summary>
        /// Checks whether the event instance can be mapped to <see cref="EventStream" /> class.
        /// </summary>
        /// <param name="ev">Event instance</param>
        /// <returns>Returns <c>True</c>; if the given event can be mapped to <see cref="EventStream" />; otherwise returns <c>False</c>.</returns>
        bool CanMap(BaseEvent ev);

        /// <summary>
        /// Maps the given event to the <see cref="EventStream" /> class.
        /// </summary>
        /// <param name="ev">Event to map.</param>
        /// <returns>Returns the <see cref="EventStream" /> mapped.</returns>
        EventStream Map(T ev);
    }
}