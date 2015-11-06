using System;
using System.Collections.Generic;
using System.Linq;

using Aliencube.EntityContextLibrary.Interfaces;

using EventSourcingCqrsSample.EventHandlers;
using EventSourcingCqrsSample.Models.Requests;
using EventSourcingCqrsSample.Repositories;

namespace EventSourcingCqrsSample.RequestBuilders
{
    /// <summary>
    /// This represents the builder entity for user create request.
    /// </summary>
    public class UserCreateRequestBuilder : IRequestBuilder<UserCreateRequest>
    {
        private readonly IBaseRepository<EventStream> _repository;
        private readonly IEnumerable<IEventHandler> _handlers;
         
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserCreateRequestBuilder" /> class.
        /// </summary>
        /// <param name="repository">The event stream repository instance.</param>
        /// <param name="handlers">The list of event handler instances.</param>
        public UserCreateRequestBuilder(IBaseRepository<EventStream> repository, params IEventHandler[] handlers)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            this._repository = repository;

            if (handlers == null)
            {
                throw new ArgumentNullException(nameof(handlers));
            }

            this._handlers = handlers;
        }

        /// <summary>
        /// Builds requests.
        /// </summary>
        /// <param name="request">The request.</param>
        public void Build(UserCreateRequest request)
        {
            var handlers = this._handlers.Where(p => p.CanBuild<UserCreateRequest>(request));
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
    }
}