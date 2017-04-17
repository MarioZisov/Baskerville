using Baskerville.Models.Constants;
using System.ComponentModel.DataAnnotations;

namespace Baskerville.Models.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [Display(Name = "Потребител")]
        public string Username { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [Display(Name = "Запомни ме?")]
        public bool RememberMe { get; set; }
    }
}
