using System;

namespace EventSourcingCqrsSample.Models.Requests
{
    /// <summary>
    /// This represents the request entity for event stream created event.
    /// </summary>
    public class EventStreamCreateRequest : BaseRequest
    {
        /// <summary>
        /// Gets or sets the stream Id.
        /// </summary>
        public Guid StreamId { get; set; }
    }
}