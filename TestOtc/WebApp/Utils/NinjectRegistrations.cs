using AuthService.Contracts;
using Ninject.Modules;

namespace WebApp.Utils
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IAuthService>().To<AuthService.AuthService>();
        }
    }
}