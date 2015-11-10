using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Models.Requests;

namespace EventSourcingCqrsSample.EventHandlers
{
    /// <summary>
    /// This represents the base event processor entity. This must be inherited.
    /// </summary>
    /// <typeparam name="T">Type of event.</typeparam>
    public abstract class BaseEventHandler<T> : IEventHandler where T : BaseEvent
    {
        private bool _disposed;

        /// <summary>
        /// Loads the list of events.
        /// </summary>
        /// <param name="streamId">The stream id.</param>
        /// <returns>Returns the list of events.</returns>
        public async Task<IEnumerable<BaseEvent>> LoadAsync(Guid streamId)
        {
            var events = await this.OnLoadAsync(streamId);
            return events;
        }

        /// <summary>
        /// Loads the latest event.
        /// </summary>
        /// <param name="streamId">The stream id.</param>
        /// <returns>Returns the latest event.</returns>
        public async Task<BaseEvent> LoadLatestAsync(Guid streamId)
        {
            if (streamId == Guid.Empty)
            {
                return null;
            }

            var events = await this.LoadAsync(streamId);
            return events.FirstOrDefault();
        }

        /// <summary>
        /// Checks whether the given event can be processed or not.
        /// </summary>
        /// <param name="ev">Event instance.</param>
        /// <returns>Returns <c>True</c>, if the given event can be processed; otherwise returns <c>False</c>.</returns>
        public virtual bool CanProcess(BaseEvent ev)
        {
            var @event = ev as T;
            return @event != null;
        }

        /// <summary>
        /// Processes the event asynchronously.
        /// </summary>
        /// <param name="ev">Event instance.</param>
        /// <returns>Returns <c>True</c>, if the given event has been processed; otherwise returns <c>False</c>.</returns>
        public async Task<bool> ProcessAsync(BaseEvent ev)
        {
            ev.DateRecorded = DateTime.UtcNow;
            return await this.OnProcessingAsync(ev);
        }

        /// <summary>
        /// Checks whether the given request can be built or not.
        /// </summary>
        /// <typeparam name="TReq">Type of request.</typeparam>
        /// <param name="request">Request instance.</param>
        /// <returns>Returns <c>True</c>, if the given request can be built; otherwise returns <c>False</c>.</returns>
        public virtual bool CanBuild<TReq>(BaseRequest request) where TReq : BaseRequest
        {
            return false;
        }

        /// <summary>
        /// Builds the request using the latest event stored asynchronously.
        /// </summary>
        /// <param name="request">The request instance.</param>
        /// <returns>Returns the <see cref="Task"/>.</returns>
        public virtual async Task BuildRequestAsync(BaseRequest request)
        {
            await Task.FromResult(false);
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

        /// <summary>
        /// Called while loading events from the repository asynchronously.
        /// </summary>
        /// <param name="streamId">The stream id.</param>
        /// <returns>Returns the list of events.</returns>
        protected abstract Task<IEnumerable<BaseEvent>> OnLoadAsync(Guid streamId);

        /// <summary>
        /// Called while processing the event asynchronously.
        /// </summary>
        /// <param name="ev">Event instance.</param>
        /// <returns>Returns <c>True</c>, if the given event has been processed; otherwise returns <c>False</c>.</returns>
        protected abstract Task<bool> OnProcessingAsync(BaseEvent ev);
    }
}