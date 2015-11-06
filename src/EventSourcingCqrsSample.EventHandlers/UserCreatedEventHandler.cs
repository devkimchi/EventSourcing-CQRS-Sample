using System;
using System.Threading.Tasks;

using Aliencube.EntityContextLibrary.Interfaces;

using EventSourcingCqrsSample.EventHandlers.Map;
using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Repositories;

namespace EventSourcingCqrsSample.EventHandlers
{
    /// <summary>
    /// This represents the processor entity for the <see cref="UserCreatedEvent" /> class.
    /// </summary>
    public class UserCreatedEventHandler : BaseEventHandler<UserCreatedEvent>
    {
        private readonly IEventToEventStreamMapper<UserCreatedEvent> _mapper;
        private readonly IBaseRepository<EventStream> _eventRepository;
        private readonly IBaseRepository<User> _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserCreatedEventHandler" /> class.
        /// </summary>
        /// <param name="mapper">event stream mapper instance.</param>
        /// <param name="eventRepository">event stream repository instance.</param>
        /// <param name="userRepository">user repository instance.</param>
        public UserCreatedEventHandler(
            IEventToEventStreamMapper<UserCreatedEvent> mapper,
            IBaseRepository<EventStream> eventRepository,
            IBaseRepository<User> userRepository)
        {
            if (mapper == null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }

            this._mapper = mapper;

            if (eventRepository == null)
            {
                throw new ArgumentNullException(nameof(eventRepository));
            }

            this._eventRepository = eventRepository;

            if (userRepository == null)
            {
                throw new ArgumentNullException(nameof(userRepository));
            }

            this._userRepository = userRepository;
        }

        /// <summary>
        /// Called while processing the event asynchronously.
        /// </summary>
        /// <param name="ev">Event instance.</param>
        /// <returns>Returns <c>True</c>, if the given event has been processed; otherwise returns <c>False</c>.</returns>
        protected override async Task<bool> OnProcessingAsync(BaseEvent ev)
        {
            var stream = this._mapper.Map(ev as UserCreatedEvent);

            this._eventRepository.Add(stream);
            return await Task.FromResult(true);
        }
    }
}