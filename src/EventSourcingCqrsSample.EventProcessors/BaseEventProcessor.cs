using System.Threading.Tasks;

using EventSourcingCqrsSample.Events;

namespace EventSourcingCqrsSample.EventProcessors
{
    /// <summary>
    /// This represents the base event processor entity. This must be inherited.
    /// </summary>
    /// <typeparam name="T">Type of event.</typeparam>
    public abstract class BaseEventProcessor<T> : IEventProcessor where T : BaseEvent
    {
        private bool _disposed;

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
        /// Processes the event.
        /// </summary>
        /// <param name="ev">Event instance.</param>
        /// <returns>Returns <c>True</c>, if the given event has been processed; otherwise returns <c>False</c>.</returns>
        public bool Process(BaseEvent ev)
        {
            return this.OnProcessing(ev);
        }

        /// <summary>
        /// Processes the event asynchronously.
        /// </summary>
        /// <param name="ev">Event instance.</param>
        /// <returns>Returns <c>True</c>, if the given event has been processed; otherwise returns <c>False</c>.</returns>
        public async Task<bool> ProcessAsync(BaseEvent ev)
        {
            return await this.OnProcessingAsync(ev);
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
        /// Called while processing the event.
        /// </summary>
        /// <param name="ev">Event instance.</param>
        /// <returns>Returns <c>True</c>, if the given event has been processed; otherwise returns <c>False</c>.</returns>
        protected abstract bool OnProcessing(BaseEvent ev);

        /// <summary>
        /// Called while processing the event asynchronously.
        /// </summary>
        /// <param name="ev">Event instance.</param>
        /// <returns>Returns <c>True</c>, if the given event has been processed; otherwise returns <c>False</c>.</returns>
        protected abstract Task<bool> OnProcessingAsync(BaseEvent ev);
    }
}