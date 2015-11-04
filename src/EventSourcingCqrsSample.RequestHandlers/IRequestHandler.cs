using System;

using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Models.Requests;

namespace EventSourcingCqrsSample.RequestHandlers
{
    /// <summary>
    /// This provides interfaces to the classes inheriting the <see cref="BaseRequestHandler{TRequest, TEvent}" /> class.
    /// </summary>
    public interface IRequestHandler : IDisposable
    {
        /// <summary>
        /// Checks whether the given request can be handled or not.
        /// </summary>
        /// <param name="request">Request instance.</param>
        /// <returns>Returns <c>True</c>, if the given request can be processed; otherwise returns <c>False</c>.</returns>
        bool CanHandle(BaseRequest request);

        /// <summary>
        /// Create the event from the request.
        /// </summary>
        /// <param name="request">Request instance.</param>
        /// <returns>Returns the event created.</returns>
        BaseEvent CreateEvent(BaseRequest request);
    }
}