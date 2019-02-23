using AuthService.Contracts;
using Ninject.Modules;
using OperationsService.Contracts;

namespace WebApp.IoC
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IAuthService>().To<AuthService.AuthService>();
            Bind<IOperationsService>().To<OperationsService.OperationsService>();
        }
    }
}