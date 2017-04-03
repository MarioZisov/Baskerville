using Baskerville.Data;
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

        // GET: Admin/Events
        public ActionResult Index()
        {
            var model = this.service.GetAllEvents();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = this.service.GetEvent(id);
            if (model == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("EventForm", model);
        }
    }
}