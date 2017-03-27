using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Baskerville.Models.ViewModels.Account
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {
            this.RolesNames = new List<string>();
        }

        [Required]
        [MinLength(2), MaxLength(255)]
        [Display(Name = "Потребител")]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Потвърди парола")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Роля")]
        public string RoleName { get; set; }

        public IEnumerable<string> RolesNames { get; set; }
    }
}
