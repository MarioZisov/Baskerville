namespace Baskerville.Models.ViewModels.Public
{

    using Constants;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class ContactViewModelBg
    {
        private readonly IEnumerable<SelectListItem> subjects = new List<SelectListItem>
        {
            new SelectListItem {Text = "Вариант 1", Value = "Вариант 1" },
            new SelectListItem {Text = "Вариант 2", Value = "Вариант 2" },
            new SelectListItem {Text = "Вариант 3", Value = "Вариант 3" }
        };

        [Required(ErrorMessage = PublicMessages.RequiredMessage)]
        [EmailAddress(ErrorMessage = PublicMessages.InvlidEmailMessage)]
        [Display(Name = "Имейл")]
        public string Email { get; set; }

        [Required(ErrorMessage = PublicMessages.RequiredMessage)]
        [StringLength(maximumLength: PublicMessages.MaxMessageLength, MinimumLength = PublicMessages.MinMessageLength, ErrorMessage = PublicMessages.LengthMessage)]
        [Display(Name = "Съобщение")]
        public string Message { get; set; }

        [Required(ErrorMessage = PublicMessages.RequiredMessage)]
        [StringLength(maximumLength: PublicMessages.MaxNameLength, MinimumLength = PublicMessages.MinNameLength, ErrorMessage = PublicMessages.LengthMessage)]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required(ErrorMessage = PublicMessages.RequiredMessage)]
        [Display(Name = "Телефоннен Номер")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = PublicMessages.RequiredMessage)]
        [Display(Name = "Тема")]
        public string Subject { get; set; }

        public IEnumerable<SelectListItem> Subjects => this.subjects;
    }
}
