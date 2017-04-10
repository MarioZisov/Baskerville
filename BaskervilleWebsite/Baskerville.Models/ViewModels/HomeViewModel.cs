using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Baskerville.Models.ViewModels
{
    public class HomeViewModel
    {
        public ContactViewModel ContactModel { get; set; }

        public HtmlString Promotions { get; set; }

        public HtmlString Events { get; set; }
    }
}
