using Baskerville.App.Utilities.HtmlBuilders;
using Baskerville.Data;
using Baskerville.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Baskerville.App.Controllers
{
    public class HomeController : Controller
    {
        private HomeService service;

        public HomeController()
        {
            this.service = new HomeService(new BaskervilleContext());
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Menu()
        {
            var primaryCategories = this.service.GetPrimaryCategories();
            var htmlBuilder = new MenuBuilder(primaryCategories, false);
            var html = htmlBuilder.Render();            
            return View(html);
        }
    }
}