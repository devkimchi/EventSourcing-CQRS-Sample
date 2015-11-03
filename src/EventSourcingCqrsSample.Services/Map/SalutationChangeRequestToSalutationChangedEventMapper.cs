using AutoMapper;

using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Models.Requests;

namespace EventSourcingCqrsSample.Services.Map
{
    /// <summary>
    /// This represents the mapper entity for <see cref="SalutationChangeRequest" /> to <see cref="SalutationChangedEvent" />.
    /// </summary>
    public class SalutationChangeRequestToSalutationChangedEventMapper :
        BaseRequestToEventMapper<SalutationChangeRequest, SalutationChangedEvent>
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

            Mapper.CreateMap<SalutationChangeRequest, SalutationChangedEvent>()
                .ForMember(ev => ev.ElementId, o => o.MapFrom(req => req.Id))
                .ForMember(ev => ev.ElementName, o => o.MapFrom(req => req.Name))
                .ForMember(ev => ev.ElementValue, o => o.MapFrom(req => req.Value));

            this.Initialised = true;
        }
    }
}