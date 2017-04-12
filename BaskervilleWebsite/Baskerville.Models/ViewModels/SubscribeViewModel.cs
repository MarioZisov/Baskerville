using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Baskerville.Models.ViewModels
{
    public class SubscribeViewModel
    {
        public readonly IEnumerable<SelectListItem> LanguagesEn = new List<SelectListItem>
        {
            new SelectListItem { Text = "Bulgarian", Value = "bg" },
             new SelectListItem { Text = "English", Value = "en" }
        };

        public readonly IEnumerable<SelectListItem> LanguagesBg = new List<SelectListItem>
        {
            new SelectListItem { Text = "Български", Value = "bg" },
             new SelectListItem { Text = "Английски", Value = "en" }
        };

        public string Email { get; set; }

        public string PreferedLanguage { get; set; }
    }
}
