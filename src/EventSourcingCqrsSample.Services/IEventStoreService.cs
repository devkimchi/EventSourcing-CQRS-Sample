using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using EventSourcingCqrsSample.Events;

namespace EventSourcingCqrsSample.Services
{
    /// <summary>
    /// This provides interfaces to the <see cref="EventStoreService" /> class.
    /// </summary>
    public interface IEventStoreService : IDisposable
    {
        /// <summary>
        /// Consumes the list of events.
        /// </summary>
        /// <param name="evs">List of events.</param>
        /// <returns>Returns <c>True</c>, if all events have been consumed; otherwise returns <c>False.</c></returns>
        bool Consume(IEnumerable<BaseEvent> evs);

        /// <summary>
        /// Consumes the list of events asynchronously.
        /// </summary>
        /// <param name="evs">List of events.</param>
        /// <returns>Returns <c>True</c>, if all events have been consumed; otherwise returns <c>False.</c></returns>
        Task<bool> ConsumeAsync(IEnumerable<BaseEvent> evs);
    }
}