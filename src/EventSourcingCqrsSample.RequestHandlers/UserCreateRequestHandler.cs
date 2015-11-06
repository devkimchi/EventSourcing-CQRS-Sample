using System;

using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Models.Requests;
using EventSourcingCqrsSample.RequestHandlers.Map;

namespace EventSourcingCqrsSample.RequestHandlers
{
    /// <summary>
    /// This represents the request handler entity for username change.
    /// </summary>
    public class UserCreateRequestHandler : BaseRequestHandler<UserCreateRequest, UserCreatedEvent>
    {
        private readonly IRequestToEventMapper<UserCreateRequest, UserCreatedEvent> _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserCreateRequestHandler" /> class.
        /// </summary>
        /// <param name="mapper">The event mapper instance.</param>
        public UserCreateRequestHandler(IRequestToEventMapper<UserCreateRequest, UserCreatedEvent> mapper)
        {
            if (mapper == null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }

            this._mapper = mapper;
        }

        /// <summary>
        /// Called while creating the event from the request.
        /// </summary>
        /// <param name="request">Request instance.</param>
        /// <returns>Returns the event created.</returns>
        protected override UserCreatedEvent OnCreatingEvent(BaseRequest request)
        {
            var @event = this._mapper.Map(request as UserCreateRequest);
            return @event;
        }
    }
}