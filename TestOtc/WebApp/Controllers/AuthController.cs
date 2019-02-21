using AuthService.Contracts;
using AuthService.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApp.Models.Auth;

namespace WebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public ActionResult Login()
        {
            var model = new LoginModel();

            return View("login", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Non Valid";
                return View("login", loginModel);
            }

            var authRequest = new AuthRequest()
            {
                Login = loginModel.Login,
                Password = loginModel.Password,
            };

            var authResult = await _authService.AuthAsync(authRequest);

            if (authResult.IsSuccess)
            {
                FormsAuthentication.SetAuthCookie(authResult.Login, true);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
            return View("login", loginModel);
        }
    }
}