using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using Aliencube.EntityContextLibrary.Interfaces;

using EventSourcingCqrsSample.EventHandlers.Map;
using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Repositories;

using Newtonsoft.Json;

namespace EventSourcingCqrsSample.EventHandlers
{
    /// <summary>
    /// This represents the processor entity for the <see cref="EventStreamCreatedEvent" /> class.
    /// </summary>
    public class EventStreamCreatedEventHandler : BaseEventHandler<EventStreamCreatedEvent>
    {
        private readonly IEventToEventStreamMapper<EventStreamCreatedEvent> _mapper;
        private readonly IBaseRepository<EventStream> _repository;
        private readonly string _eventType;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventStreamCreatedEventHandler" /> class.
        /// </summary>
        /// <param name="mapper">event stream mapper instance.</param>
        /// <param name="repository">event stream repository instance.</param>
        public EventStreamCreatedEventHandler(IEventToEventStreamMapper<EventStreamCreatedEvent> mapper, IBaseRepository<EventStream> repository)
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

            this._eventType = typeof(EventStreamCreatedEvent).FullName;
        }

        /// <summary>
        /// Called while loading events from the repository asynchronously.
        /// </summary>
        /// <param name="streamId">The stream id.</param>
        /// <returns>Returns the list of events.</returns>
        protected override async Task<IEnumerable<BaseEvent>> OnLoadAsync(Guid streamId)
        {
            var streams = await this._repository
                                    .Get()
                                    .Where(p => p.EventType.Equals(this._eventType, StringComparison.InvariantCultureIgnoreCase))
                                    .OrderByDescending(p => p.Sequence)
                                    .ToListAsync();

            var events = streams.Select(p => JsonConvert.DeserializeObject<EventStreamCreatedEvent>(p.EventBody));
            return events;
        }

        /// <summary>
        /// Called while processing the event asynchronously.
        /// </summary>
        /// <param name="ev">Event instance.</param>
        /// <returns>Returns <c>True</c>, if the given event has been processed; otherwise returns <c>False</c>.</returns>
        protected override async Task<bool> OnProcessingAsync(BaseEvent ev)
        {
            var stream = this._mapper.Map(ev as EventStreamCreatedEvent);

            this._repository.Add(stream);
            return await Task.FromResult(true);
        }
    }
}