using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

using EventSourcingCqrsSample.WebApp.Models.Salutations;

namespace EventSourcingCqrsSample.WebApp.Controllers
{
    /// <summary>
    /// The salutation controller.
    /// </summary>
    [RoutePrefix("api/salutations")]
    public class SalutationController : ApiController
    {
        /// <summary>
        /// Gets the list of <see cref="Salutation" />s.
        /// </summary>
        /// <returns>Returns the list of <see cref="Salutation" />s.</returns>
        [Route("")]
        public virtual async Task<List<Salutation>> Get()
        {
            var salutations = new List<Salutation>()
                                      {
                                          new Salutation("Mr", "Mr"),
                                          new Salutation("Mrs", "Mrs"),
                                          new Salutation("Ms", "Ms"),
                                          new Salutation("Mx", "Mx"),
                                      };

            return await Task.FromResult(salutations);
        }
    }
}