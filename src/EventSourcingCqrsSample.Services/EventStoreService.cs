using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aliencube.EntityContextLibrary;
using Aliencube.EntityContextLibrary.Interfaces;

using EventSourcingCqrsSample.EventProcessors;
using EventSourcingCqrsSample.Events;
using EventSourcingCqrsSample.Repositories;

namespace EventSourcingCqrsSample.Services
{
    /// <summary>
    /// This represents the service entity for event store.
    /// </summary>
    public class EventStoreService : IEventStoreService
    {
        private readonly IUnitOfWorkManager _uowm;
        private readonly IEnumerable<IEventProcessor> _processors;

        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventStoreService" /> class.
        /// </summary>
        /// <param name="uowm"><see cref="UnitOfWorkManager" /> instance.</param>
        /// <param name="processors">List of event processors.</param>
        public EventStoreService(IUnitOfWorkManager uowm, params IEventProcessor[] processors)
            : this(uowm, processors.ToList())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventStoreService" /> class.
        /// </summary>
        /// <param name="uowm"><see cref="UnitOfWorkManager" /> instance.</param>
        /// <param name="processors">List of event processors.</param>
        public EventStoreService(IUnitOfWorkManager uowm, IEnumerable<IEventProcessor> processors)
        {
            if (uowm == null)
            {
                throw new ArgumentNullException(nameof(uowm));
            }

            this._uowm = uowm;

            if (processors == null)
            {
                throw new ArgumentNullException(nameof(processors));
            }

            this._processors = processors;
        }

        /// <summary>
        /// Processes the list of events.
        /// </summary>
        /// <param name="evs">List of events.</param>
        /// <returns>Returns <c>True</c>, if all events have been consumed; otherwise returns <c>False.</c></returns>
        public bool ProcessEvents(IEnumerable<BaseEvent> evs)
        {
            throw new NotImplementedException();
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
                        var processors = this.GetProcessors(ev);
                        foreach (var processor in processors)
                        {
                            var result = await processor.ProcessAsync(ev);
                            results.Add(result);
                        }
                    }

                    uow.Commit();
                }
                catch
                {
                    uow.Rollback();
                    results.Add(false);
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

        private IEnumerable<IEventProcessor> GetProcessors(BaseEvent ev)
        {
            var processors = this._processors.Where(p => p.CanProcess(ev));
            return processors;
        }
    }
}