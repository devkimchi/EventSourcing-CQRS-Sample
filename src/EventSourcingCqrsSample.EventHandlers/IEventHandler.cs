using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Models.Requests;

namespace EventSourcingCqrsSample.EventHandlers
{
    /// <summary>
    /// This provides interfaces to the classes inheriting the <see cref="BaseEventHandler{T}" /> class.
    /// </summary>
    public interface IEventHandler : IDisposable
    {
        /// <summary>
        /// Loads the list of events asynchronously.
        /// </summary>
        /// <param name="streamId">The stream id.</param>
        /// <returns>Returns the list of events.</returns>
        Task<IEnumerable<BaseEvent>> LoadAsync(Guid streamId);

        /// <summary>
        /// Loads the latest event asynchronously.
        /// </summary>
        /// <param name="streamId">The stream id.</param>
        /// <returns>Returns the latest event.</returns>
        Task<BaseEvent> LoadLatestAsync(Guid streamId);

        /// <summary>
        /// Checks whether the given event can be processed or not.
        /// </summary>
        /// <param name="ev">Event instance.</param>
        /// <returns>Returns <c>True</c>, if the given event can be processed; otherwise returns <c>False</c>.</returns>
        bool CanProcess(BaseEvent ev);

        /// <summary>
        /// Processes the event asynchronously.
        /// </summary>
        /// <param name="ev">Event instance.</param>
        /// <returns>Returns <c>True</c>, if the given event has been processed; otherwise returns <c>False</c>.</returns>
        Task<bool> ProcessAsync(BaseEvent ev);

        /// <summary>
        /// Checks whether the given request can be built or not.
        /// </summary>
        /// <typeparam name="TReq">Type of request.</typeparam>
        /// <param name="request">Request instance.</param>
        /// <returns>Returns <c>True</c>, if the given request can be built; otherwise returns <c>False</c>.</returns>
        bool CanBuild<TReq>(BaseRequest request) where TReq : BaseRequest;

        /// <summary>
        /// Builds the request using the latest event stored asynchronously.
        /// </summary>
        /// <param name="request">The request instance.</param>
        /// <returns>Returns the <see cref="Task"/>.</returns>
        Task BuildRequestAsync(BaseRequest request);
    }
}