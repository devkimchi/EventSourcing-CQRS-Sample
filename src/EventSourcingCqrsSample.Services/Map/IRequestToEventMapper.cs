using System;

using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Models.Requests;

namespace EventSourcingCqrsSample.Services.Map
{
    /// <summary>
    /// This provides interfaces to mappers inheriting the <see cref="BaseRequestToEventMapper{TRequest, TEvent}" /> class.
    /// </summary>
    /// <typeparam name="TRequest">Type of request.</typeparam>
    /// <typeparam name="TEvent">Type of event.</typeparam>
    public interface IRequestToEventMapper<in TRequest, out TEvent> : IDisposable
        where TRequest : BaseRequest where TEvent : BaseEvent
    {
        /// <summary>
        /// Checks whether the request instance can be mapped to the event class.
        /// </summary>
        /// <param name="request">Request instance</param>
        /// <returns>Returns <c>True</c>; if the given request can be mapped to the event class; otherwise returns <c>False</c>.</returns>
        bool CanMap(BaseRequest request);

        /// <summary>
        /// Maps the given request to the event class.
        /// </summary>
        /// <param name="request">Request to map.</param>
        /// <returns>Returns the <see cref="TEvent" /> mapped.</returns>
        TEvent Map(TRequest request);
    }
}