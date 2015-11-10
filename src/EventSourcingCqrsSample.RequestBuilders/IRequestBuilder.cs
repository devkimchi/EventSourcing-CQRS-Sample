using System;
using System.Threading.Tasks;

using EventSourcingCqrsSample.Models.Requests;

namespace EventSourcingCqrsSample.RequestBuilders
{
    /// <summary>
    /// This provides interfaces to request builders.
    /// </summary>
    public interface IRequestBuilder : IDisposable
    {
        /// <summary>
        /// Builds requests asynchronously.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Returns <see cref="Task" />.</returns>
        Task BuildAsync(BaseRequest request);
    }
}