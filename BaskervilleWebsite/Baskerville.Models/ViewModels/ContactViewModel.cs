using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Baskerville.Models.ViewModels
{
    public class ContactViewModel
    {
        #region English Properties       
        public readonly IEnumerable<SelectListItem> SubjectsEn = new List<SelectListItem>
        {
            new SelectListItem {Text = "Question asdasdadsad", Value = "Question asdasdadsad" },
            new SelectListItem {Text = "Another asdasdadsad", Value = "Another asdasdadsad" },
            new SelectListItem {Text = "AAAA fakQuestion asdasdadsad", Value = "AAAA fakQuestion asdasdadsad" }
        };

        [Required]
        public string NameEn { get; set; }

        [Required]
        public string EmailEn { get; set; }

        [Required]
        public string PhoneNumberEn { get; set; }

        [Required]
        public string SubjectEn { get; set; }

        [Required]
        public string MessageEn { get; set; }
        #endregion

        #region Builgarian Properties
        public readonly IEnumerable<SelectListItem> SubjectsBg = new List<SelectListItem>
        {
            new SelectListItem {Text = "Question asdasdadsad", Value = "Question asdasdadsad" },
            new SelectListItem {Text = "Another asdasdadsad", Value = "Another asdasdadsad" },
            new SelectListItem {Text = "AAAA fakQuestion asdasdadsad", Value = "AAAA fakQuestion asdasdadsad" }
        };
        
        public string NameBg { get; set; }

        public string EmailBg { get; set; }

        public string PhoneNumberBg { get; set; }

        public string SubjectBg { get; set; }

        public string MessageBg { get; set; }
        #endregion
    }
}
