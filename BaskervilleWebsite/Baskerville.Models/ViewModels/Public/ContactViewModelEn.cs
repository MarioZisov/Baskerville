namespace Baskerville.Models.ViewModels.Public
{
    using Constants;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class ContactViewModelEn
    {
        private readonly IEnumerable<SelectListItem> subjects = new List<SelectListItem>
        {
             new SelectListItem {Text = "Option 1", Value = "Option 1" },
            new SelectListItem {Text = "Option 2", Value = "Option 2" },
            new SelectListItem {Text = "Option 3", Value = "Option 3" }
        };

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength: PublicMessages.MaxMessageLength, MinimumLength = PublicMessages.MinMessageLength)]
        public string Message { get; set; }

        [Required]
        [StringLength(maximumLength: PublicMessages.MaxNameLength, MinimumLength = PublicMessages.MinNameLength)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Subject { get; set; }

        public IEnumerable<SelectListItem> Subjects => this.subjects;
    }
}
