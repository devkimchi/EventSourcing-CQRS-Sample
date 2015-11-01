using System;

using Owin;

namespace EventSourcingCqrsSample.WebApp
{
    /// <summary>
    /// This represents the entity for OWIN pipeline startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configures the OWIN pipeline.
        /// </summary>
        /// <param name="appBuilder">
        /// The <see cref="IAppBuilder" /> instance.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws when <c>appBuilder</c> is null.
        /// </exception>
        public void Configuration(IAppBuilder appBuilder)
        {
            if (appBuilder == null)
            {
                throw new ArgumentNullException(nameof(appBuilder));
            }

            var container = DependencyConfig.Configure();

            MvcConfig.Configure(appBuilder, container);
            WebApiConfig.Configure(appBuilder, container);
        }
    }
}