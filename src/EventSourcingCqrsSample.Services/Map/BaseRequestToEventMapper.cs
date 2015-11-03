using AutoMapper;

using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Models.Requests;

namespace EventSourcingCqrsSample.Services.Map
{
    /// <summary>
    /// This represents the mapper entity for requests to events. This must be inherited.
    /// </summary>
    /// <typeparam name="TRequest">Type of request.</typeparam>
    /// <typeparam name="TEvent">Type of event.</typeparam>
    public abstract class BaseRequestToEventMapper<TRequest, TEvent> : IRequestToEventMapper<TRequest, TEvent>
        where TRequest : BaseRequest where TEvent : BaseEvent
    {
        private bool _disposed;

        /// <summary>
        /// Gets or sets a value indicating whether the mapper definition has been initialised or not.
        /// </summary>
        protected bool Initialised { get; set; }

        /// <summary>
        /// Checks whether the request instance can be mapped to the event class.
        /// </summary>
        /// <param name="request">Request instance</param>
        /// <returns>Returns <c>True</c>; if the given request can be mapped to the event class; otherwise returns <c>False</c>.</returns>
        public virtual bool CanMap(BaseRequest request)
        {
            var casted = request as TRequest;
            return casted != null;
        }

        /// <summary>
        /// Maps the given request to the event class.
        /// </summary>
        /// <param name="request">Request to map.</param>
        /// <returns>Returns the <see cref="TEvent" /> mapped.</returns>
        public virtual TEvent Map(TRequest request)
        {
            if (!this.CanMap(request))
            {
                return null;
            }

            this.Initialise();

            var mapped = Mapper.Map<TEvent>(request);
            return mapped;
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
        /// Initialises the mapping definition.
        /// </summary>
        protected abstract void Initialise();
    }
}