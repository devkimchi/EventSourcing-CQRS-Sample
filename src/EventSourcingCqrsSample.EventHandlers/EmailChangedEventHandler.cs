using System;
using System.Threading.Tasks;

using Aliencube.EntityContextLibrary.Interfaces;

using EventSourcingCqrsSample.EventHandlers.Map;
using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Models.Requests;
using EventSourcingCqrsSample.Repositories;

namespace EventSourcingCqrsSample.EventHandlers
{
    /// <summary>
    /// This represents the processor entity for the <see cref="EmailChangedEvent" /> class.
    /// </summary>
    public class EmailChangedEventHandler : BaseEventHandler<EmailChangedEvent>
    {
        private readonly IEventToEventStreamMapper<EmailChangedEvent> _mapper;
        private readonly IBaseRepository<EventStream> _repository;


        /// <summary>
        /// Initializes a new instance of the <see cref="EmailChangedEventHandler" /> class.
        /// </summary>
        /// <param name="mapper">event stream mapper instance.</param>
        /// <param name="repository">event stream repository instance.</param>
        public EmailChangedEventHandler(IEventToEventStreamMapper<EmailChangedEvent> mapper, IBaseRepository<EventStream> repository)
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
        /// Checks whether the given request can be built or not.
        /// </summary>
        /// <typeparam name="TReq">Type of request.</typeparam>
        /// <param name="request">Request instance.</param>
        /// <returns>Returns <c>True</c>, if the given request can be built; otherwise returns <c>False</c>.</returns>
        public override bool CanBuild<TReq>(BaseRequest request)
        {
            var req = request as TReq;
            return req != null;
        }

        /// <summary>
        /// Called while processing the event asynchronously.
        /// </summary>
        /// <param name="ev">Event instance.</param>
        /// <returns>Returns <c>True</c>, if the given event has been processed; otherwise returns <c>False</c>.</returns>
        protected override async Task<bool> OnProcessingAsync(BaseEvent ev)
        {
            var stream = this._mapper.Map(ev as EmailChangedEvent);

            this._repository.Add(stream);
            return await Task.FromResult(true);
        }
    }
}