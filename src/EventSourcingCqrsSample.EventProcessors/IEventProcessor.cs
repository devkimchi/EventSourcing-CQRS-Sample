using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Models.Requests;
using EventSourcingCqrsSample.Models.Responses;

namespace EventSourcingCqrsSample.EventProcessors
{
    /// <summary>
    /// This provides interfaces to the <see cref="EventProcessor" /> class.
    /// </summary>
    public interface IEventProcessor : IDisposable
    {
        /// <summary>
        /// Processes the list of events.
        /// </summary>
        /// <param name="evs">List of events.</param>
        /// <returns>Returns <c>True</c>, if all events have been consumed; otherwise returns <c>False.</c></returns>
        bool ProcessEvents(IEnumerable<BaseEvent> evs);

        /// <summary>
        /// Processes the list of events asynchronously.
        /// </summary>
        /// <param name="evs">List of events.</param>
        /// <returns>Returns <c>True</c>, if all events have been consumed; otherwise returns <c>False.</c></returns>
        Task<bool> ProcessEventsAsync(IEnumerable<BaseEvent> evs);
    }
}