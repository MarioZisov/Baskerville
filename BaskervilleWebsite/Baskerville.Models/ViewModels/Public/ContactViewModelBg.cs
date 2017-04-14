using Baskerville.Models.ViewModels.Public.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Baskerville.Models.ViewModels.Public
{
    public class ContactViewModelBg : IContactViewModel
    {
        private readonly IEnumerable<SelectListItem> subjects = new List<SelectListItem>
        {
            new SelectListItem {Text = "Question asdasdadsad", Value = "Question asdasdadsad" },
            new SelectListItem {Text = "Another asdasdadsad", Value = "Another asdasdadsad" },
            new SelectListItem {Text = "AAAA fakQuestion asdasdadsad", Value = "AAAA fakQuestion asdasdadsad" }
        };

        public string Email { get; set; }        

        public string Message { get; set; }       

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Subject { get; set; }

        public IEnumerable<SelectListItem> Subjects => this.subjects;
    }
}
