using System;
using System.Threading.Tasks;

using EventSourcingCqrsSample.Events;

namespace EventSourcingCqrsSample.EventHandlers
{
    /// <summary>
    /// This provides interfaces to the classes inheriting the <see cref="BaseEventHandler{T}" /> class.
    /// </summary>
    public interface IEventHandler : IDisposable
    {
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
    }
}