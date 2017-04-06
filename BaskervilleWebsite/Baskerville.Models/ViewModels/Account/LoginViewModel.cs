using System.ComponentModel.DataAnnotations;

namespace Baskerville.Models.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Потребител")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [Display(Name = "Запомни ме?")]
        public bool RememberMe { get; set; }
    }
}
