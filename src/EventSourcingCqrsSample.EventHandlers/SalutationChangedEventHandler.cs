using System;
using System.Threading.Tasks;

using Aliencube.EntityContextLibrary.Interfaces;

using EventSourcingCqrsSample.EventHandlers.Map;
using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Repositories;

namespace EventSourcingCqrsSample.EventHandlers
{
    /// <summary>
    /// This represents the processor entity for the <see cref="SalutationChangedEvent" /> class.
    /// </summary>
    public class SalutationChangedEventHandler : BaseEventHandler<SalutationChangedEvent>
    {
        private readonly IEventToEventStreamMapper<SalutationChangedEvent> _mapper;
        private readonly IBaseRepository<EventStream> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SalutationChangedEventHandler" /> class.
        /// </summary>
        /// <param name="mapper">The event stream mapper instance.</param>
        /// <param name="repository">The event stream repository instance.</param>
        public SalutationChangedEventHandler(IEventToEventStreamMapper<SalutationChangedEvent> mapper, IBaseRepository<EventStream> repository)
        {
            if (mapper == null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }

            this._mapper = mapper;

            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            this._repository = repository;
        }

        /// <summary>
        /// Called while processing the event.
        /// </summary>
        /// <param name="ev">Event instance.</param>
        /// <returns>Returns <c>True</c>, if the given event has been processed; otherwise returns <c>False</c>.</returns>
        protected override bool OnProcessing(BaseEvent ev)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called while processing the event asynchronously.
        /// </summary>
        /// <param name="ev">Event instance.</param>
        /// <returns>Returns <c>True</c>, if the given event has been processed; otherwise returns <c>False</c>.</returns>
        protected override async Task<bool> OnProcessingAsync(BaseEvent ev)
        {
            var stream = this._mapper.Map(ev as SalutationChangedEvent);

            this._repository.AddAsync(stream);
            return await Task.FromResult(true);
        }
    }
}