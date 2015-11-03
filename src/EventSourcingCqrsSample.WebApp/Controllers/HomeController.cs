using System.Web.Mvc;

using EventSourcingCqrsSample.Models.ViewModels.Home;

namespace EventSourcingCqrsSample.WebApp.Controllers
{
    /// <summary>
    /// This represents the controller entity for /home
    /// </summary>
    [RoutePrefix("")]
    public class HomeController : Controller
    {
        /// <summary>
        /// Runs when /home/index is requested.
        /// </summary>
        /// <returns>Returns the <see cref="HomeIndexViewModel" /> instance.</returns>
        [Route("")]
        public virtual ActionResult Index()
        {
            var vm = new HomeIndexViewModel();
            return this.View(vm);
        }
    }
}