using System;
using System.Threading.Tasks;

using EventSourcingCqrsSample.Models.Requests;
using EventSourcingCqrsSample.Models.Responses;

namespace EventSourcingCqrsSample.Services
{
    /// <summary>
    /// This provides interfaces to the <see cref="EventStreamService" /> class.
    /// </summary>
    public interface IEventStreamService : IDisposable
    {
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