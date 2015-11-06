using AutoMapper;

using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Models.Requests;

namespace EventSourcingCqrsSample.RequestHandlers.Map
{
    /// <summary>
    /// This represents the mapper entity for <see cref="UserCreateRequest" /> to <see cref="UserCreatedEvent" />.
    /// </summary>
    public class UserCreateRequestToUserCreatedEventMapper :
        BaseRequestToEventMapper<UserCreateRequest, UserCreatedEvent>
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

            Mapper.CreateMap<UserCreateRequest, UserCreatedEvent>()
                  .ForMember(ev => ev.EventStream, o => o.MapFrom(req => req.StreamId));

            this.Initialised = true;
        }
    }
}