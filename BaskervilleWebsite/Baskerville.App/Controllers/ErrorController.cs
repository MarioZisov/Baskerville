namespace Baskerville.App.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        [HttpGet]
        public ActionResult NotFound()
        {
            return View("404");
        }
    }
}