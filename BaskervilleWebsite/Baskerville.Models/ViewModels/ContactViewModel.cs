using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Baskerville.Models.ViewModels
{
    public class ContactViewModel
    {
        public readonly IEnumerable<SelectListItem> ListItems = new List<SelectListItem>
        {
            new SelectListItem {Text = "Question asdasdadsad", Value = "Question asdasdadsad" },
            new SelectListItem {Text = "Another asdasdadsad", Value = "Another asdasdadsad" },
            new SelectListItem {Text = "AAAA fakQuestion asdasdadsad", Value = "AAAA fakQuestion asdasdadsad" }
        };

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }        
    }
}
