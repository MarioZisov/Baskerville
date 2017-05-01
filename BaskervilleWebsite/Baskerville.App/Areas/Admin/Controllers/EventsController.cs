namespace Baskerville.App.Areas.Admin.Controllers
{
    using Data;
    using Models.ViewModels;
    using Services;
    using Services.Contracts;
    using System.Net;
    using System.Web.Mvc;

    public class EventsController : AuthorizedController
    {
        private IEventsService service;

        public EventsController(IEventsService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = this.service.GetAllEvents();

            if (this.User.IsInRole("Employee"))
                return View("EventsEditOnlyList", model);

            return View("EventsList", model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = this.service.GetEvent(id);
            if (model == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("EventForm", model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = this.service.GetEmptyEvent();

            return View("EventForm", model);
        }      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(EventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("EventForm", model);
            }

            //Model is newly created and should be added to the database.
            if (model.Id == 0)
                this.service.CreateEvent(model);
            else
                this.service.UpdateEvent(model);

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            this.service.RemoveEvent(id);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        public ActionResult UpdatePublicity(int id)
        {
            var status = this.service.UpdatePublicity(id);

            return new HttpStatusCodeResult(status);
        }
    }
}