using System;

using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Models.Requests;
using EventSourcingCqrsSample.RequestHandlers.Map;

namespace EventSourcingCqrsSample.RequestHandlers
{
    /// <summary>
    /// This represents the request handler entity for email change.
    /// </summary>
    public class EmailChangeRequestHandler : BaseRequestHandler<EmailChangeRequest, EmailChangedEvent>
    {
        private readonly IRequestToEventMapper<EmailChangeRequest, EmailChangedEvent> _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailChangeRequestHandler" /> class.
        /// </summary>
        /// <param name="mapper">The event mapper instance.</param>
        public EmailChangeRequestHandler(IRequestToEventMapper<EmailChangeRequest, EmailChangedEvent> mapper)
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
        protected override EmailChangedEvent OnCreatingEvent(BaseRequest request)
        {
            var @event = this._mapper.Map(request as EmailChangeRequest);
            return @event;
        }
    }
}