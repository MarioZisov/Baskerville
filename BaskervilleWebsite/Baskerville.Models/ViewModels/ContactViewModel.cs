namespace Baskerville.Models.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class ContactViewModel
    {
        #region English Properties       
        public readonly IEnumerable<SelectListItem> SubjectsEn = new List<SelectListItem>
        {
            new SelectListItem {Text = "Option 1", Value = "Option 1" },
            new SelectListItem {Text = "Option 2", Value = "Option 2" },
            new SelectListItem {Text = "Option 3", Value = "Option 3" }
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
            new SelectListItem {Text = "Вариант 1", Value = "Вариант 1" },
            new SelectListItem {Text = "Вариант 2", Value = "Вариант 2" },
            new SelectListItem {Text = "Вариант 3", Value = "Вариант 3" }
        };
        
        public string NameBg { get; set; }

        public string EmailBg { get; set; }

        public string PhoneNumberBg { get; set; }

        public string SubjectBg { get; set; }

        public string MessageBg { get; set; }
        #endregion
    }
}
