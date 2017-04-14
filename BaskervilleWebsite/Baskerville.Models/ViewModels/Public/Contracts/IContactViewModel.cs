using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Baskerville.Models.ViewModels.Public.Contracts
{
    public interface IContactViewModel
    {
        IEnumerable<SelectListItem> Subjects { get; }

        string Name { get; set; }

        string Email { get; set; }

        string PhoneNumber { get; set; }

        string Subject { get; set; }

        string Message { get; set; }
    }
}
