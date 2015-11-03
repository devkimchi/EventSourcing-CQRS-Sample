using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Models.Requests;
using EventSourcingCqrsSample.Models.Responses;

namespace EventSourcingCqrsSample.Services
{
    /// <summary>
    /// This provides interfaces to the <see cref="EventStoreService" /> class.
    /// </summary>
    public interface IEventStoreService : IDisposable
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

        /// <summary>
        /// Changes salutation.
        /// </summary>
        /// <param name="request">The <see cref="SalutationChangeRequest" /> instance.</param>
        /// <returns>
        /// Returns the <see cref="SalutationChangeResponse" /> instance.
        /// </returns>
        SalutationChangeResponse ChangeSalutation(SalutationChangeRequest request);

        /// <summary>
        /// Changes salutation asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="SalutationChangeRequest" /> instance.</param>
        /// <returns>
        /// Returns the <see cref="SalutationChangeResponse" /> instance.
        /// </returns>
        Task<SalutationChangeResponse> ChangeSalutationAsync(SalutationChangeRequest request);
    }
}