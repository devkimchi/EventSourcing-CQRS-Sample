using System;
using System.Web.Http;

using Autofac;
using Autofac.Integration.WebApi;

using Newtonsoft.Json.Serialization;

using Owin;

namespace EventSourcingCqrsSample.WebApp
{
    /// <summary>
    /// This represents the config entity for Web API.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Configures the Web API.
        /// </summary>
        /// <param name="builder">
        /// The <see cref="IAppBuilder" /> instance.
        /// </param>
        /// <param name="container">
        /// The <see cref="IContainer" /> instance.
        /// </param>
        public static void Configure(IAppBuilder builder, IContainer container)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            var config = new HttpConfiguration()
                             {
                                 DependencyResolver = new AutofacWebApiDependencyResolver(container),
                             };

            // Routes
            config.MapHttpAttributeRoutes();

            // Formatters
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            builder.UseWebApi(config);
        }
    }
}