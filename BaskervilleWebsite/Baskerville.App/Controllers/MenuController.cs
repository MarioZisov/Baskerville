using Baskerville.Data;
using Baskerville.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Baskerville.App.Controllers
{
    public class MenuController : Controller
    {
        MenuService service;

        public MenuController()
        {
            this.service = new MenuService(new BaskervilleContext());
        }

        protected override void Initialize(RequestContext requestContext)
        {
            if (requestContext.HttpContext.Session["test"] != null)
            {

            }
            else
            {
                requestContext.HttpContext.Session["test"] = "pruc";
            }

            base.Initialize(requestContext);
        }

        [HttpGet]
        public ActionResult Index()
        {
            var html = this.service.GetMenuHtml(false);
            return View(html);
        }
    }
}