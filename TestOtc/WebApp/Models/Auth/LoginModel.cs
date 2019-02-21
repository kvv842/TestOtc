using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Auth
{
    public class LoginModel
    {
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}