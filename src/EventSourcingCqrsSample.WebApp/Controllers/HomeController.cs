using System;
using System.Web;
using System.Web.Mvc;

using EventSourcingCqrsSample.Models.ViewModels.Home;
using EventSourcingCqrsSample.Services;

namespace EventSourcingCqrsSample.WebApp.Controllers
{
    /// <summary>
    /// This represents the controller entity for /home
    /// </summary>
    [RoutePrefix("")]
    public class HomeController : Controller
    {
        private readonly IEventStreamService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController" /> class.
        /// </summary>
        /// <param name="service">The <see cref="EventStreamService" /> instance.</param>
        public HomeController(IEventStreamService service)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            this._service = service;

            this.HttpContext = base.HttpContext;
        }

        /// <summary>
        /// Gets the <see cref="HttpContextBase" /> instance.
        /// </summary>
        public new HttpContextBase HttpContext { get; private set; }

        /// <summary>
        /// Sets the <see cref="HttpContextBase" /> instance.
        /// </summary>
        /// <param name="httpContext">
        /// The <see cref="HttpContextBase" /> instance.
        /// </param>
        public void SetHttpContext(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            this.HttpContext = httpContext;
        }

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