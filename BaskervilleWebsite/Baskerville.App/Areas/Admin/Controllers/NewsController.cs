namespace Baskerville.App.Areas.Admin.Controllers
{
    using Models.ViewModels;
    using Services.Contracts;
    using System.Net;
    using System.Web.Mvc;

    public class NewsController : AuthorizedController
    {
        INewsService service;

        public NewsController(INewsService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = this.service.GetAllNews();
            if (this.User.IsInRole("Employee"))
                return View("NewsEditOnlyList", model);

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
        [Authorize(Roles = "Admin,Owner,Manager")]
        public ActionResult Delete(int id)
        {
            HttpStatusCode status =  this.service.DeleteNewsById(id);

            return new HttpStatusCodeResult(status);
        }

        [HttpPost]
        public ActionResult UpdatePublicity(int id)
        {
            var status = this.service.UpdatePublicity(id);

            return new HttpStatusCodeResult(status);
        }
    }
}