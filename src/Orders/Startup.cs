using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Owin;
using Owin;
using ProyectoConrado.Api.Controllers;
using ProyectoConrado.Api.Helpers;
using ProyectoConrado.Api.Managers;
using ProyectoConrado.Api.Models;
using ProyectoConrado.Core.Models;
using ProyectoConrado.Data;
using ProyectoConrado.Extensions;
using ProyectoConrado.Logging.Extensions;
using ProyectoConrado.Repositories.Repositories.Orders;
using ProyectoConrado.Services.Orders;
using ProyectoConrado.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(ProyectoConrado.Web.Startup))]
namespace ProyectoConrado.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var resolver = new DefaultDependencyResolver(services.BuildServiceProvider());
            DependencyResolver.SetResolver(resolver);

            InitDB();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
            services.AddTransient<IOrderDetailService, OrderDetailService>();
            services.AddTransient<ILoggerFactory, LoggerFactory>();

            services.AddControllersAsServices(typeof(Startup).Assembly.GetExportedTypes()
           .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
           .Where(t => typeof(IController).IsAssignableFrom(t)
           || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)));
        }

        private async void InitDB()
        {
            LoggerFactory loggerFactory = new LoggerFactory();
            loggerFactory.AddFile(System.Configuration.ConfigurationManager.AppSettings["LogFilePath"]);
            ILogger logger = loggerFactory.CreateLogger<OrderApiController>();

            ApiDBManager apiDBManager = new ApiDBManager(logger);
            ApiDBModel apiDbModel = await apiDBManager.CreateIfNotExistAndFillDB();
        }
    }

    public class DefaultDependencyResolver : IDependencyResolver
    {
        protected IServiceProvider serviceProvider;

        public DefaultDependencyResolver(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public object GetService(Type serviceType)
        {
            return this.serviceProvider.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.serviceProvider.GetServices(serviceType);
        }
    }

    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddControllersAsServices(this IServiceCollection services,
           IEnumerable<Type> controllerTypes)
        {
            foreach (var type in controllerTypes)
            {
                services.AddTransient(type);
            }

            return services;
        }
    }
}