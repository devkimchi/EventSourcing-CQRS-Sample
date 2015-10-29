using System;
using System.Threading.Tasks;

using Aliencube.EntityContextLibrary.Interfaces;

using EventSourcingCqrsSample.EventProcessors.Map;
using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Repositories;

namespace EventSourcingCqrsSample.EventProcessors
{
    /// <summary>
    /// This represents the processor entity for the <see cref="DefaultEvent" /> class.
    /// </summary>
    public class DefaultEventProcessor : BaseEventProcessor<DefaultEvent>
    {
        private readonly IEventToEventStreamMapper<DefaultEvent> _mapper;
        private readonly IBaseRepository<EventStream> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultEventProcessor" /> class.
        /// </summary>
        /// <param name="mapper">event stream mapper instance.</param>
        /// <param name="repository">event stream repository instance.</param>
        public DefaultEventProcessor(IEventToEventStreamMapper<DefaultEvent> mapper, IBaseRepository<EventStream> repository)
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
        /// Checks whether the given event can be processed or not.
        /// </summary>
        /// <param name="ev">Event instance.</param>
        /// <returns>Returns <c>True</c>, if the given event can be processed; otherwise returns <c>False</c>.</returns>
        public override bool CanProcess(BaseEvent ev)
        {
            return true;
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
            var stream = this._mapper.Map(ev as DefaultEvent);

            this._repository.AddAsync(stream);
            return await Task.FromResult(true);
        }
    }
}