using AutoMapper;

using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Models.Requests;

namespace EventSourcingCqrsSample.RequestHandlers.Map
{
    /// <summary>
    /// This represents the mapper entity for <see cref="EventStreamCreateRequest" /> to <see cref="EventStreamCreatedEvent" />.
    /// </summary>
    public class EventStreamCreateRequestToEventStreamCreatedEventMapper :
        BaseRequestToEventMapper<EventStreamCreateRequest, EventStreamCreatedEvent>
    {
        /// <summary>
        /// Initialises the mapping definition.
        /// </summary>
        protected override void Initialise()
        {
            if (this.Initialised)
            {
                return;
            }

            Mapper.CreateMap<EventStreamCreateRequest, EventStreamCreatedEvent>()
                  .ForMember(ev => ev.EventStream, o => o.MapFrom(req => req.StreamId));

            this.Initialised = true;
        }
    }
}