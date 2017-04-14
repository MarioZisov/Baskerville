using Baskerville.Models.Constants;
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

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [MinLength(2), MaxLength(255)]
        [Display(Name = "Потребител")]
        public string Username { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [StringLength(100, ErrorMessage = "Паралота трябва да бъде поне {2} символа", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Потвърди парола")]
        [Compare("Password", ErrorMessage = "Паролите не съвпадат")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [Display(Name = "Роля")]
        public string RoleName { get; set; }

        public IEnumerable<string> RolesNames { get; set; }
    }
}
