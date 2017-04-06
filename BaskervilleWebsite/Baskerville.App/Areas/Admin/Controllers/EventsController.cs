using Baskerville.Data;
using Baskerville.Models.ViewModels;
using Baskerville.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Baskerville.App.Areas.Admin.Controllers
{
    public class EventsController : Controller
    {
        private EventsService service;

        public EventsController()
        {
            this.service = new EventsService(new BaskervilleContext());
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = this.service.GetAllEvents();
            return View(model);
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
    }
}