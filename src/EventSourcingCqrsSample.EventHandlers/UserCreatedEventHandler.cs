using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using Aliencube.EntityContextLibrary.Interfaces;

using EventSourcingCqrsSample.EventHandlers.Map;
using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Repositories;

using Newtonsoft.Json;

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
        private readonly string _eventType;

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

            this._eventType = typeof(UserCreatedEvent).FullName;
        }

        /// <summary>
        /// Called while loading events from the repository asynchronously.
        /// </summary>
        /// <param name="streamId">The stream id.</param>
        /// <returns>Returns the list of events.</returns>
        protected override async Task<IEnumerable<BaseEvent>> OnLoadAsync(Guid streamId)
        {
            var streams = await this._eventRepository
                                    .Get()
                                    .Where(p => p.EventType.Equals(this._eventType, StringComparison.InvariantCultureIgnoreCase))
                                    .OrderByDescending(p => p.Sequence)
                                    .ToListAsync();

            var events = streams.Select(p => JsonConvert.DeserializeObject<UserCreatedEvent>(p.EventBody));
            return events;
        }

        /// <summary>
        /// Called while processing the event asynchronously.
        /// </summary>
        /// <param name="ev">Event instance.</param>
        /// <returns>Returns <c>True</c>, if the given event has been processed; otherwise returns <c>False</c>.</returns>
        protected override async Task<bool> OnProcessingAsync(BaseEvent ev)
        {
            var @event = (ev as UserCreatedEvent);
            var stream = this._mapper.Map(@event);
            this._eventRepository.Add(stream);

            var user = new User
                           {
                               Title = @event.Title,
                               Name = @event.Username,
                               Email = @event.Email
                           };
            this._userRepository.AddOrUpdate(user);

            return await Task.FromResult(true);
        }
    }
}