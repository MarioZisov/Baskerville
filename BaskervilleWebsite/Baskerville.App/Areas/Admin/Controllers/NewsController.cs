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
    public class NewsController : AuthorizedController
    {
        NewsService service;

        public NewsController()
        {
            this.service = new NewsService(new BaskervilleContext());
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = this.service.GetAllNews();

            return View("NewsList", model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new NewsViewModel();

            return View("NewsForm", model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = this.service.GetNewsById(id);
            if (model == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("NewsForm", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(NewsViewModel model)
        {
            if (!ModelState.IsValid)
                return View("NewsForm", model);

            if (model.Id == 0)
                this.service.CreateNews(model);
            else
                this.service.UpdateNews(model);

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            HttpStatusCode status =  this.service.DeleteNewsById(id);

            return new HttpStatusCodeResult(status);
        }
    }
}