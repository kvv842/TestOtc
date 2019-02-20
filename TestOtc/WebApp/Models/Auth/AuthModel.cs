using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Auth
{
    public class AuthModel
    {
        //[Required]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        //[Required]
        [Display(Name = "Пароль")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
    }
}