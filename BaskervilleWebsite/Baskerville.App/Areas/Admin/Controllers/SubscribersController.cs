namespace Baskerville.App.Areas.Admin.Controllers
{
    using Models.ViewModels;
    using Services.Contracts;
    using System.Net;
    using System.Web.Mvc;

    public class SubscribersController : AuthorizedController
    {
        private ISubscribersService service;

        public SubscribersController(ISubscribersService service)
        {
            this.service = service;
        }

        // GET: Subscribers
        public ActionResult Index()
        {
            var model = this.service.GetActiveSubscribers();
            if (this.User.IsInRole("Employee"))
                return View("SubscribersReadOnlyList", model);

            return View("SubscribersList", model);
        }

        [HttpGet]
        public ActionResult Message()
        {
            MessageViewModel model = new MessageViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Message(MessageViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            this.service.SendMessageToSubscribers(model);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Owner")]
        public ActionResult Delete(int id)
        {
            var status = this.service.RemoveSubscriber(id);

            return new HttpStatusCodeResult(status);
        }

    }
}