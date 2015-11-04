using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EventSourcingCqrsSample.EventProcessors;
using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Models.Requests;
using EventSourcingCqrsSample.Models.Responses;
using EventSourcingCqrsSample.RequestHandlers;

namespace EventSourcingCqrsSample.Services
{
    /// <summary>
    /// This represents the service entity for event stream.
    /// </summary>
    public class EventStreamService : IEventStreamService
    {
        private readonly IEventProcessor _processor;
        private readonly IEnumerable<IRequestHandler> _handlers;

        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventStreamService" /> class.
        /// </summary>
        /// <param name="processor">The event processor instance.</param>
        /// <param name="handlers">The list of request handlers.</param>
        public EventStreamService(IEventProcessor processor, params IRequestHandler[] handlers)
            : this(processor, handlers.ToList())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventStreamService" /> class.
        /// </summary>
        /// <param name="processor">The event processor instance.</param>
        /// <param name="handlers">The list of request handlers.</param>
        public EventStreamService(IEventProcessor processor, IEnumerable<IRequestHandler> handlers)
        {
            if (processor == null)
            {
                throw new ArgumentNullException(nameof(processor));
            }

            this._processor = processor;

            if (handlers == null)
            {
                throw new ArgumentNullException(nameof(handlers));
            }

            this._handlers = handlers;
        }

        /// <summary>
        /// Changes salutation.
        /// </summary>
        /// <param name="request">The <see cref="SalutationChangeRequest" /> instance.</param>
        /// <returns>
        /// Returns the <see cref="SalutationChangeResponse" /> instance.
        /// </returns>
        public SalutationChangeResponse ChangeSalutation(SalutationChangeRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Changes salutation asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="SalutationChangeRequest" /> instance.</param>
        /// <returns>
        /// Returns the <see cref="SalutationChangeResponse" /> instance.
        /// </returns>
        public async Task<SalutationChangeResponse> ChangeSalutationAsync(SalutationChangeRequest request)
        {
            var handler = this._handlers.SingleOrDefault(p => p.CanHandle(request));
            if (handler == null)
            {
                return await Task.FromResult(default(SalutationChangeResponse));
            }

            var ev = handler.CreateEvent(request) as SalutationChangedEvent;
            this.PopulateBaseProperties(ev);

            var processed = await this._processor.ProcessEventsAsync(new[] { ev });
            var response = new SalutationChangeResponse();
            return await Task.FromResult(response);
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

        private void PopulateBaseProperties<T>(T ev) where T : BaseEvent
        {
            ev.EventId = Guid.NewGuid();
            ev.Sequence = DateTime.UtcNow.Ticks;
            ev.DateOccurred = DateTime.UtcNow;
            ev.Projector = Projector.System;
        }
    }
}