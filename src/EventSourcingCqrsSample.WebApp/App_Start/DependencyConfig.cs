using System.Reflection;
using System.Web;

using Aliencube.EntityContextLibrary;
using Aliencube.EntityContextLibrary.Interfaces;

using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

using EventSourcingCqrsSample.EventHandlers;
using EventSourcingCqrsSample.EventHandlers.Map;
using EventSourcingCqrsSample.EventProcessors;
using EventSourcingCqrsSample.Repositories;
using EventSourcingCqrsSample.RequestBuilders;
using EventSourcingCqrsSample.RequestHandlers;
using EventSourcingCqrsSample.RequestHandlers.Map;
using EventSourcingCqrsSample.Services;
using EventSourcingCqrsSample.WebApp.Controllers;

namespace EventSourcingCqrsSample.WebApp
{
    /// <summary>
    /// This represents the configuration entity for dependency injection.
    /// </summary>
    public static class DependencyConfig
    {
        private const string SampleDbContext = "SampleDbContext";

        /// <summary>
        /// Configures <see cref="Autofac" /> dependency injection.
        /// </summary>
        /// <returns>Returns <see cref="IContainer" /> instance.</returns>
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            RegisterDbContext(builder);
            RegisterRepositories(builder);
            RegisterServices(builder);
            RegisterEventHandlerMappers(builder);
            RegisterEventHandlers(builder);
            RegisterRequestBuilders(builder);
            RegisterRequestHandlerMappers(builder);
            RegisterRequestHandlers(builder);
            RegisterEventProcessors(builder);
            RegisterWebAbstractions(builder);
            RegisterMvcControllers(builder);
            RegisterApiControllers(builder);

            var container = builder.Build();
            return container;
        }

        private static void RegisterDbContext(ContainerBuilder builder)
        {
            // DB context.
            builder.RegisterType<DbContextFactory<SampleDbContext>>()
                   .Named<IDbContextFactory>(SampleDbContext)
                   .As<IDbContextFactory>()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();

            // unit of work managers.
            builder.Register(p => new UnitOfWorkManager(p.ResolveNamed<IDbContextFactory>(SampleDbContext)))
                   .As<IUnitOfWorkManager>()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<BaseRepository<EventStream>>()
                   .AsImplementedInterfaces()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();

            builder.RegisterType<BaseRepository<User>>()
                   .AsImplementedInterfaces()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<EventStreamService>()
                   .As<IEventStreamService>()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();
        }

        private static void RegisterEventHandlerMappers(ContainerBuilder builder)
        {
            builder.RegisterType<EmailChangedEventToEventStreamMapper>()
                   .AsImplementedInterfaces()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();

            builder.RegisterType<EventStreamCreatedEventToEventStreamMapper>()
                   .AsImplementedInterfaces()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();

            builder.RegisterType<SalutationChangedEventToEventStreamMapper>()
                   .AsImplementedInterfaces()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();

            builder.RegisterType<UsernameChangedEventToEventStreamMapper>()
                   .AsImplementedInterfaces()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();

            builder.RegisterType<UserCreatedEventToEventStreamMapper>()
                   .AsImplementedInterfaces()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();
        }

        private static void RegisterEventHandlers(ContainerBuilder builder)
        {
            builder.RegisterType<EmailChangedEventHandler>()
                   .As<IEventHandler>()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();

            builder.RegisterType<EventStreamCreatedEventHandler>()
                   .As<IEventHandler>()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();

            builder.RegisterType<SalutationChangedEventHandler>()
                   .As<IEventHandler>()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();

            builder.RegisterType<UsernameChangedEventHandler>()
                   .As<IEventHandler>()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();

            builder.RegisterType<UserCreatedEventHandler>()
                   .As<IEventHandler>()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();
        }

        private static void RegisterRequestBuilders(ContainerBuilder builder)
        {
            builder.RegisterType<UserCreateRequestBuilder>()
                   .As<IRequestBuilder>()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();
        }

        private static void RegisterRequestHandlerMappers(ContainerBuilder builder)
        {
            builder.RegisterType<EmailChangeRequestToEmailChangedEventMapper>()
                   .AsImplementedInterfaces()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();

            builder.RegisterType<EventStreamCreateRequestToEventStreamCreatedEventMapper>()
                   .AsImplementedInterfaces()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();

            builder.RegisterType<SalutationChangeRequestToSalutationChangedEventMapper>()
                   .AsImplementedInterfaces()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();

            builder.RegisterType<UserCreateRequestToUserCreatedEventMapper>()
                   .AsImplementedInterfaces()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();

            builder.RegisterType<UsernameChangeRequestToUsernameChangedEventMapper>()
                   .AsImplementedInterfaces()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();
        }

        private static void RegisterRequestHandlers(ContainerBuilder builder)
        {
            builder.RegisterType<EmailChangeRequestHandler>()
                   .As<IRequestHandler>()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();

            builder.RegisterType<EventStreamCreateRequestHandler>()
                   .As<IRequestHandler>()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();

            builder.RegisterType<SalutationChangeRequestHandler>()
                   .As<IRequestHandler>()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();

            builder.RegisterType<UserCreateRequestHandler>()
                   .As<IRequestHandler>()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();

            builder.RegisterType<UsernameChangeRequestHandler>()
                   .As<IRequestHandler>()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();
        }

        private static void RegisterEventProcessors(ContainerBuilder builder)
        {
            builder.RegisterType<EventProcessor>()
                   .As<IEventProcessor>()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();
        }

        private static void RegisterWebAbstractions(ContainerBuilder builder)
        {
            builder.RegisterModule<AutofacWebTypesModule>();
        }

        private static void RegisterMvcControllers(ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof(Startup).Assembly)
                   .OnActivating(e =>
                                 {
                                     var httpContext = e.Context.Resolve<HttpContextBase>();
                                 
                                     ((HomeController)e.Instance).SetHttpContext(httpContext);
                                 })
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();
        }

        private static void RegisterApiControllers(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly())
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();
        }
    }
}