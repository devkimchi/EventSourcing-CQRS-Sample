using System.Threading.Tasks;
using System.Web.Http;

using EventSourcingCqrsSample.Models.Requests;
using EventSourcingCqrsSample.Models.Responses;

namespace EventSourcingCqrsSample.WebApp.Controllers
{
    /// <summary>
    /// This represents the API controller entity for input value changed events.
    /// </summary>
    [RoutePrefix("api/events")]
    public class InputValueChangedEventController : ApiController
    {
        /// <summary>
        /// Sets the salutation value.
        /// </summary>
        /// <param name="request">The <see cref="SalutationChangeRequest" /> instance.</param>
        /// <returns>Returns the <see cref="SalutationChangeResponse" /> instance.</returns>
        [HttpPost]
        [Route("salutation-changed")]
        public virtual async Task<SalutationChangeResponse> SetSalutation([FromBody] SalutationChangeRequest request)
        {
            var response = new SalutationChangeResponse();
            return await Task.FromResult(response);
        }
    }
}