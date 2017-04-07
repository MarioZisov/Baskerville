using System.ComponentModel.DataAnnotations;

namespace Baskerville.Models.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = Constants.RequiredFildMessage)]
        [Display(Name = "Потребител")]
        public string Email { get; set; }

        [Required(ErrorMessage = Constants.RequiredFildMessage)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [Display(Name = "Запомни ме?")]
        public bool RememberMe { get; set; }
    }
}
