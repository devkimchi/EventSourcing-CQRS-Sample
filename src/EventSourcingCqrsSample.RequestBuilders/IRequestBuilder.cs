using System;

using EventSourcingCqrsSample.Models.Requests;

namespace EventSourcingCqrsSample.RequestBuilders
{
    /// <summary>
    /// This provides interfaces to request builders.
    /// </summary>
    /// <typeparam name="T">Type of request.</typeparam>
    public interface IRequestBuilder<in T> : IDisposable where T : BaseRequest
    {
        /// <summary>
        /// Builds requests.
        /// </summary>
        /// <param name="request">The request.</param>
        void Build(T request);
    }
}