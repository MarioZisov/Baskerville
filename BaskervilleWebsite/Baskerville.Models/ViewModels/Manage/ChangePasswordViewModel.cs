﻿using Baskerville.Models.Constants;
using System.ComponentModel.DataAnnotations;

namespace Baskerville.Models.ViewModels.Manage
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [DataType(DataType.Password)]
        [Display(Name = "Текуща парола")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [StringLength(100, ErrorMessage = "Паролата трябва да бъде поне {2} символа", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Нова парола")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Потвърдете новата парола")]
        [Compare("NewPassword", ErrorMessage = "Паролите не съвпадат")]
        public string ConfirmPassword { get; set; }
    }
}
