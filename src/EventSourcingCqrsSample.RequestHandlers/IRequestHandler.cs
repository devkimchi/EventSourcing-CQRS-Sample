using System;

using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Models.Requests;

namespace EventSourcingCqrsSample.RequestHandlers
{
    /// <summary>
    /// This provides interfaces to the classes inheriting the <see cref="BaseRequestHandler{TRequest, TEvent}" /> class.
    /// </summary>
    /// <typeparam name="TEvent">Type of event.</typeparam>
    public interface IRequestHandler<out TEvent> : IDisposable where TEvent : BaseEvent
    {
        /// <summary>
        /// Checks whether the given request can be processed or not.
        /// </summary>
        /// <param name="request">Request instance.</param>
        /// <returns>Returns <c>True</c>, if the given request can be processed; otherwise returns <c>False</c>.</returns>
        bool CanProcess(BaseRequest request);

        /// <summary>
        /// Processes the request.
        /// </summary>
        /// <param name="request">Request instance.</param>
        /// <returns>Returns the event.</returns>
        TEvent Process(BaseRequest request);
    }
}