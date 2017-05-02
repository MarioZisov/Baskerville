using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Baskerville.App.Controllers
{
    public class StaticContentController : Controller
    {
        [HttpGet]
        public ActionResult NotFound()
        {
            return View("404");
        }
    }
}