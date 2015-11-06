using System;

using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Models.Requests;
using EventSourcingCqrsSample.RequestHandlers.Map;

namespace EventSourcingCqrsSample.RequestHandlers
{
    /// <summary>
    /// This represents the request handler entity for username change.
    /// </summary>
    public class UsernameChangeRequestHandler : BaseRequestHandler<UsernameChangeRequest, UsernameChangedEvent>
    {
        private readonly IRequestToEventMapper<UsernameChangeRequest, UsernameChangedEvent> _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsernameChangeRequestHandler" /> class.
        /// </summary>
        /// <param name="mapper">The event mapper instance.</param>
        public UsernameChangeRequestHandler(IRequestToEventMapper<UsernameChangeRequest, UsernameChangedEvent> mapper)
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
        protected override UsernameChangedEvent OnCreatingEvent(BaseRequest request)
        {
            var @event = this._mapper.Map(request as UsernameChangeRequest);
            return @event;
        }
    }
}