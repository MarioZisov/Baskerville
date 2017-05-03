namespace Baskerville.Models.ViewModels.Public
{
    using Constants;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

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

        [Required(ErrorMessage = PublicMessages.RequiredMessage)]
        [Display(Name = "Предпочитам Език")]
        public string PreferedLanguage { get; set; }

        public IEnumerable<SelectListItem> Languages => this.languages;
    }
}
