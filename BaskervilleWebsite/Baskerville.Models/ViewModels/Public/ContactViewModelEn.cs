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
    public class ContactViewModelEn
    {
        private readonly IEnumerable<SelectListItem> subjects = new List<SelectListItem>
        {
            new SelectListItem {Text = "Question asdasdadsad", Value = "Question asdasdadsad" },
            new SelectListItem {Text = "Another asdasdadsad", Value = "Another asdasdadsad" },
            new SelectListItem {Text = "AAAA fakQuestion asdasdadsad", Value = "AAAA fakQuestion asdasdadsad" }
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
