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
    public abstract class BaseController : Controller
    {
        private VisitsService service;

        protected BaseController()
        {
            this.service = new VisitsService(new BaskervilleContext());
        }

        protected override void Initialize(RequestContext requestContext)
        {
            if (requestContext.HttpContext.Session["newHit"] == null)
            {
                requestContext.HttpContext.Session["newHit"] = true;
                this.service.VisitsIncrement();
            }

            base.Initialize(requestContext);
        }
    }
}