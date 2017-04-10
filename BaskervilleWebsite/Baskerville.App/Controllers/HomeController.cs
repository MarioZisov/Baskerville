using Baskerville.Data;
using Baskerville.Models.ViewModels;
using Baskerville.Services;
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
            var model = this.service.GetHomeModel(false);
            return View(model);
        }

        [HttpGet]
        public ActionResult Menu()
        {
            var html = this.service.GetMenuHtml(false);      
            return View(html);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Send(ContactViewModel contactModel)
        {
            if (!ModelState.IsValid)
            {
                var model = this.service.GetHomeModel(false);
                model.ContactModel = contactModel;
                return View("Index", model);
            }

            bool success = this.service.SendEmail(contactModel);
            if (success)
                return View("MessageSent");
            else
                return View("404");

        }
    }
}