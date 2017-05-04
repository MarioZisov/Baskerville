namespace Baskerville.App.Controllers
{
    using Data;
    using Services;
    using Services.Contracts;
    using System.Web.Mvc;
    using System.Web.Routing;

    public abstract class BaseController : Controller
    {
        private IVisitsService service;

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