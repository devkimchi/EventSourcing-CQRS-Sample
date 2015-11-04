using System;
using System.Threading.Tasks;
using System.Web.Http;

using EventSourcingCqrsSample.Models.Requests;
using EventSourcingCqrsSample.Models.Responses;
using EventSourcingCqrsSample.Services;

namespace EventSourcingCqrsSample.WebApp.Controllers
{
    /// <summary>
    /// This represents the API controller entity for input value changed events.
    /// </summary>
    [RoutePrefix("api/events")]
    public class InputValueChangedEventController : ApiController
    {
        private readonly IEventStreamService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="InputValueChangedEventController" /> class.
        /// </summary>
        /// <param name="service">The <see cref="EventStreamService "/> instance.
        /// </param>
        public InputValueChangedEventController(IEventStreamService service)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            this._service = service;
        }

        /// <summary>
        /// Sets the salutation value.
        /// </summary>
        /// <param name="request">The <see cref="SalutationChangeRequest" /> instance.</param>
        /// <returns>Returns the <see cref="SalutationChangeResponse" /> instance.</returns>
        [HttpPost]
        [Route("salutation-changed")]
        public virtual async Task<SalutationChangeResponse> SetSalutation([FromBody] SalutationChangeRequest request)
        {
            var response = await this._service.ChangeSalutationAsync(request);
            return response;
        }
    }
}