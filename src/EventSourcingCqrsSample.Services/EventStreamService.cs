using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EventSourcingCqrsSample.EventProcessors;
using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Models.Requests;
using EventSourcingCqrsSample.Models.Responses;
using EventSourcingCqrsSample.Models.Responses.Data;
using EventSourcingCqrsSample.RequestHandlers;

namespace EventSourcingCqrsSample.Services
{
    /// <summary>
    /// This represents the service entity for event stream.
    /// </summary>
    public class EventStreamService : IEventStreamService
    {
        private readonly IEventProcessor _processor;
        private readonly IEnumerable<IRequestHandler> _handlers;

        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventStreamService" /> class.
        /// </summary>
        /// <param name="processor">The event processor instance.</param>
        /// <param name="handlers">The list of request handlers.</param>
        public EventStreamService(IEventProcessor processor, params IRequestHandler[] handlers)
        {
            if (processor == null)
            {
                throw new ArgumentNullException(nameof(processor));
            }

            this._processor = processor;

            if (handlers == null)
            {
                throw new ArgumentNullException(nameof(handlers));
            }

            this._handlers = handlers;
        }

        /// <summary>
        /// Creates a new event stream asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="EventStreamCreateRequest" /> instance.</param>
        /// <returns>Returns the <see cref="EventStreamCreateResponse" /> instance.</returns>
        public async Task<EventStreamCreateResponse> CreateEventStreamAsync(EventStreamCreateRequest request)
        {
            var handler = this._handlers.SingleOrDefault(p => p.CanHandle(request));
            if (handler == null)
            {
                return await Task.FromResult(default(EventStreamCreateResponse));
            }

            var ev = handler.CreateEvent(request) as EventStreamCreatedEvent;
            PopulateBaseProperties(ev);

            EventStreamCreateResponse response;
            try
            {
                await this._processor.ProcessEventsAsync(new[] { ev });
                response = new EventStreamCreateResponse()
                               {
                                   Data = new EventStreamResponseData()
                                              {
                                                  StreamId = request.StreamId
                                              }
                               };
            }
            catch (Exception ex)
            {
                response = new EventStreamCreateResponse()
                               {
                                   Error = new ResponseError()
                                               {
                                                   Message = ex.Message,
                                                   StackTrace = ex.StackTrace,
                                               }
                               };
            }

            return await Task.FromResult(response);
        }

        /// <summary>
        /// Changes salutation asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="SalutationChangeRequest" /> instance.</param>
        /// <returns>Returns the <see cref="SalutationChangeResponse" /> instance.</returns>
        public async Task<SalutationChangeResponse> ChangeSalutationAsync(SalutationChangeRequest request)
        {
            var handler = this._handlers.SingleOrDefault(p => p.CanHandle(request));
            if (handler == null)
            {
                return await Task.FromResult(default(SalutationChangeResponse));
            }

            var ev = handler.CreateEvent(request) as SalutationChangedEvent;
            PopulateBaseProperties(ev);

            SalutationChangeResponse response;
            try
            {
                await this._processor.ProcessEventsAsync(new[] { ev });
                response = new SalutationChangeResponse()
                               {
                                   Data = new SalutationResponseData()
                                              {
                                                  Value = request.Value
                                              }
                               };
            }
            catch (Exception ex)
            {
                response = new SalutationChangeResponse()
                               {
                                   Error = new ResponseError()
                                               {
                                                    Message = ex.Message,
                                                    StackTrace = ex.StackTrace,
                                               }
                               };
            }

            return await Task.FromResult(response);
        }

        /// <summary>
        /// Changes username asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="UsernameChangeRequest" /> instance.</param>
        /// <returns>Returns the <see cref="UsernameChangeResponse" /> instance.</returns>
        public async Task<UsernameChangeResponse> ChangeUsernameAsync(UsernameChangeRequest request)
        {
            var handler = this._handlers.SingleOrDefault(p => p.CanHandle(request));
            if (handler == null)
            {
                return await Task.FromResult(default(UsernameChangeResponse));
            }

            var ev = handler.CreateEvent(request) as UsernameChangedEvent;
            PopulateBaseProperties(ev);

            UsernameChangeResponse response;
            try
            {
                await this._processor.ProcessEventsAsync(new[] { ev });
                response = new UsernameChangeResponse()
                               {
                                   Data = new UsernameResponseData()
                                              {
                                                  Value = request.Value
                                              }
                               };
            }
            catch (Exception ex)
            {
                response = new UsernameChangeResponse()
                               {
                                   Error = new ResponseError()
                                               {
                                                   Message = ex.Message,
                                                   StackTrace = ex.StackTrace,
                                               }
                               };
            }

            return await Task.FromResult(response);
        }

        /// <summary>
        /// Changes email asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="EmailChangeRequest" /> instance.</param>
        /// <returns>Returns the <see cref="EmailChangeResponse" /> instance.</returns>
        public async Task<EmailChangeResponse> ChangeEmailAsync(EmailChangeRequest request)
        {
            var handler = this._handlers.SingleOrDefault(p => p.CanHandle(request));
            if (handler == null)
            {
                return await Task.FromResult(default(EmailChangeResponse));
            }

            var ev = handler.CreateEvent(request) as EmailChangedEvent;
            PopulateBaseProperties(ev);

            EmailChangeResponse response;
            try
            {
                await this._processor.ProcessEventsAsync(new[] { ev });
                response = new EmailChangeResponse()
                               {
                                   Data = new EmailResponseData()
                                              {
                                                  Value = request.Value
                                              }
                               };
            }
            catch (Exception ex)
            {
                response = new EmailChangeResponse()
                               {
                                   Error = new ResponseError()
                                               {
                                                   Message = ex.Message,
                                                   StackTrace = ex.StackTrace,
                                               }
                               };
            }

            return await Task.FromResult(response);
        }

        /// <summary>
        /// Creates user asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="UserCreateRequest" /> instance.</param>
        /// <returns>Returns the <see cref="UserCreateResponse" /> instance.</returns>
        public async Task<UserCreateResponse> CreateUserAsync(UserCreateRequest request)
        {
            var handler = this._handlers.SingleOrDefault(p => p.CanHandle(request));
            if (handler == null)
            {
                return await Task.FromResult(default(UserCreateResponse));
            }

            var ev = handler.CreateEvent(request) as UserCreatedEvent;
            PopulateBaseProperties(ev);

            UserCreateResponse response;
            try
            {
                await this._processor.ProcessEventsAsync(new[] { ev });
                response = new UserCreateResponse()
                               {
                                   Data = new UserResponseData()
                                              {
                                                  Title = ev.Title,
                                                  Name = ev.Username,
                                                  Email = ev.Email,
                                              }
                               };
            }
            catch (Exception ex)
            {
                response = new UserCreateResponse()
                               {
                                   Error = new ResponseError()
                                               {
                                                   Message = ex.Message,
                                                   StackTrace = ex.StackTrace,
                                               }
                               };
            }

            return await Task.FromResult(response);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            if (this._disposed)
            {
                return;
            }

            this._disposed = true;
        }

        private static void PopulateBaseProperties<T>(T ev) where T : BaseEvent
        {
            ev.EventId = Guid.NewGuid();
            ev.Sequence = DateTime.UtcNow.Ticks;
            ev.DateOccurred = DateTime.UtcNow;
            ev.Projector = Projector.System;
        }
    }
}