namespace Baskerville.Models.ViewModels.Public
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class SubscribeViewModelEn
    {
        private readonly IEnumerable<SelectListItem> languages = new List<SelectListItem>
        {
            new SelectListItem { Text = "English", Value = "en" },
            new SelectListItem { Text = "Bulgarian", Value = "bg" }
        };

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Prefered Language")]
        public string PreferedLanguage { get; set; }

        public IEnumerable<SelectListItem> Languages => this.languages;
    }
}
