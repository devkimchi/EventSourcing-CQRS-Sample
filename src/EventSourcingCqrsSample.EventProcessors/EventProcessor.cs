using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Aliencube.EntityContextLibrary;
using Aliencube.EntityContextLibrary.Interfaces;

using EventSourcingCqrsSample.EventHandlers;
using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Repositories;

namespace EventSourcingCqrsSample.EventProcessors
{
    /// <summary>
    /// This represents the processor entity for events.
    /// </summary>
    public class EventProcessor : IEventProcessor
    {
        private readonly IUnitOfWorkManager _uowm;
        private readonly IEnumerable<IEventHandler> _handlers;

        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventProcessor" /> class.
        /// </summary>
        /// <param name="uowm"><see cref="UnitOfWorkManager" /> instance.</param>
        /// <param name="handlers">List of event handlers.</param>
        public EventProcessor(IUnitOfWorkManager uowm, params IEventHandler[] handlers)
        {
            if (uowm == null)
            {
                throw new ArgumentNullException(nameof(uowm));
            }

            this._uowm = uowm;

            if (handlers == null)
            {
                throw new ArgumentNullException(nameof(handlers));
            }

            this._handlers = handlers;
        }

        /// <summary>
        /// Processes the list of events asynchronously.
        /// </summary>
        /// <param name="evs">List of events.</param>
        /// <returns>Returns <c>True</c>, if all events have been consumed; otherwise returns <c>False.</c></returns>
        public async Task<bool> ProcessEventsAsync(IEnumerable<BaseEvent> evs)
        {
            var results = new List<bool>();
            using (var uow = this._uowm.CreateInstance<SampleDbContext>())
            {
                uow.BeginTransaction();

                try
                {
                    foreach (var ev in evs)
                    {
                        var handlers = this.GetHandlers(ev);
                        foreach (var handler in handlers)
                        {
                            var result = await handler.ProcessAsync(ev);
                            results.Add(result);
                        }
                    }

                    uow.Commit();
                }
                catch
                {
                    uow.Rollback();
                    results.Add(false);
                    throw;
                }
            }

            return await Task.FromResult(results.TrueForAll(p => p));
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

        private IEnumerable<IEventHandler> GetHandlers(BaseEvent ev)
        {
            var handlers = this._handlers.Where(p => p.CanProcess(ev));
            return handlers;
        }
    }
}