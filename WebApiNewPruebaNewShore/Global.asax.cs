using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Aplicacion.Implementacion;
using Aplicacion.Interfaces;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Servicios.Implementacion;
using Servicios.Interfaces;
using WebApiNewPruebaNewShore.CastleWindsor;

namespace WebApiNewPruebaNewShore
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer container;

        protected void Application_Start()
        {
            ConfigureWindsor(GlobalConfiguration.Configuration);
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        public static void ConfigureWindsor(HttpConfiguration configuration)
        {
            //Se inicializa contenedor Windsor
            container = new WindsorContainer();
            //Se realiza registro de dependecias en contenedor
            container.Register(Component.For<IAplicacionClientes>().ImplementedBy<AplicacionClientes>()
                .LifestylePerThread());
            container.Register(Component.For<IServiciosClientes>().ImplementedBy<ServicioClientes>()
                .LifestylePerThread());
            container.Install(FromAssembly.This());

            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));
            var dependencyResolver = new WindsorDependencyResolver(container);
            configuration.DependencyResolver = dependencyResolver;
        }

        protected void Application_End()
        {
            container.Dispose();
            base.Dispose();
        }
    }
}
