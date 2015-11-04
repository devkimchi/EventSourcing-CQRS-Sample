using System;
using System.Threading.Tasks;

using EventSourcingCqrsSample.Models.Requests;
using EventSourcingCqrsSample.Models.Responses;

namespace EventSourcingCqrsSample.Services
{
    /// <summary>
    /// This represents the service entity for event stream.
    /// </summary>
    public class EventStreamService : IEventStreamService
    {
        private bool _disposed;

        /// <summary>
        /// Changes salutation.
        /// </summary>
        /// <param name="request">The <see cref="SalutationChangeRequest" /> instance.</param>
        /// <returns>
        /// Returns the <see cref="SalutationChangeResponse" /> instance.
        /// </returns>
        public SalutationChangeResponse ChangeSalutation(SalutationChangeRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Changes salutation asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="SalutationChangeRequest" /> instance.</param>
        /// <returns>
        /// Returns the <see cref="SalutationChangeResponse" /> instance.
        /// </returns>
        public async Task<SalutationChangeResponse> ChangeSalutationAsync(SalutationChangeRequest request)
        {
            var response = new SalutationChangeResponse();
            return await Task.FromResult(response);
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
    }
}