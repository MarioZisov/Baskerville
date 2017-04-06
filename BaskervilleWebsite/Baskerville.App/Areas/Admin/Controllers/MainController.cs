using Baskerville.App.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Baskerville.App.Areas.Admin.Controllers
{
    public class MainController : AuthorizedController
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }
    }
}