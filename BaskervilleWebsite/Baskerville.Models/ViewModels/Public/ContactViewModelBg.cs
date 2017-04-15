
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
    public class ContactViewModelBg
    {
        private readonly IEnumerable<SelectListItem> subjects = new List<SelectListItem>
        {
            new SelectListItem {Text = "Question asdasdadsad", Value = "Question asdasdadsad" },
            new SelectListItem {Text = "Another asdasdadsad", Value = "Another asdasdadsad" },
            new SelectListItem {Text = "AAAA fakQuestion asdasdadsad", Value = "AAAA fakQuestion asdasdadsad" }
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
