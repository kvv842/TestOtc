using AutoMapper;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApp.IoC;

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // внедрение зависимостей
            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);

            GlobalConfiguration.Configure(WebApiConfig.Register);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Инициализация БД
            AuthService.Utils.Helpers.InitializerDb();
            OperationsService.Utils.Helpers.InitializerDb();

            // Инициализация AutoMapper
            Mapper.Initialize(configurationExpression =>
            {
                configurationExpression.AddProfile<OperationsService.Mapping.MapperProfileToDTO>();
            });
        }
    }
}
