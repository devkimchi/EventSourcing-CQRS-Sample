using System;

using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Models.Requests;
using EventSourcingCqrsSample.RequestHandlers.Map;

namespace EventSourcingCqrsSample.RequestHandlers
{
    /// <summary>
    /// This represents the request handler entity for salutation change.
    /// </summary>
    public class SalutationChangeRequestHandler : BaseRequestHandler<SalutationChangeRequest, SalutationChangedEvent>
    {
        private readonly IRequestToEventMapper<SalutationChangeRequest, SalutationChangedEvent> _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="SalutationChangeRequestHandler" /> class.
        /// </summary>
        /// <param name="mapper">The event mapper instance.</param>
        public SalutationChangeRequestHandler(IRequestToEventMapper<SalutationChangeRequest, SalutationChangedEvent> mapper)
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
        protected override SalutationChangedEvent OnCreatingEvent(BaseRequest request)
        {
            var @event = this._mapper.Map(request as SalutationChangeRequest);
            return @event;
        }
    }
}