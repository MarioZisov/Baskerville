using Baskerville.Models.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Baskerville.Models.ViewModels.Public
{
    public class SubscribeViewModelBg
    {
        private readonly IEnumerable<SelectListItem> languages = new List<SelectListItem>
        {
            new SelectListItem { Text = "Английски", Value = "en" },
            new SelectListItem { Text = "Български", Value = "bg" }
        };

        [Required(ErrorMessage = PublicMessages.RequiredMessage)]
        [EmailAddress(ErrorMessage = PublicMessages.InvlidEmailMessage)]
        [Display(Name = "Имейл")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Предпочитам Език")]
        public string PreferedLanguage { get; set; }

        public IEnumerable<SelectListItem> Languages => this.languages;
    }
}
