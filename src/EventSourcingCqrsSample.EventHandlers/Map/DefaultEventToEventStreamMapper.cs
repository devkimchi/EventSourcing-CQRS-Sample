using AutoMapper;

using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Repositories;

using Newtonsoft.Json;

namespace EventSourcingCqrsSample.EventHandlers.Map
{
    /// <summary>
    /// This represents the mapper entity for <see cref="DefaultEvent" /> to <see cref="EventStream" />.
    /// </summary>
    public class DefaultEventToEventStreamMapper : BaseEventToEventStreamMapper<DefaultEvent>
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

            Mapper.CreateMap<DefaultEvent, EventStream>()
                .ForMember(es => es.StreamId, o => o.MapFrom(ev => ev.EventStream))
                .ForMember(es => es.EventName, o => o.MapFrom(ev => ev.Name))
                .ForMember(es => es.EventType, o => o.MapFrom(ev => ev.GetType().FullName))
                .ForMember(es => es.EventBody, o => o.MapFrom(ev => JsonConvert.SerializeObject(ev)))
                .ForMember(es => es.DateProjected, o => o.MapFrom(ev => ev.Projector.DateProjected))
                .ForMember(es => es.ProjectedBy, o => o.MapFrom(ev => ev.Projector.ProjectorId));

            this.Initialised = true;
        }
    }
}