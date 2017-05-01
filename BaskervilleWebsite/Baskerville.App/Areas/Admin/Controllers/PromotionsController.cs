namespace Baskerville.App.Areas.Admin.Controllers
{
    using Models.ViewModels;
    using Services.Contracts;
    using System.Net;
    using System.Web.Mvc;

    public class PromotionsController : AuthorizedController
    {
        private IPromotionService service;

        public PromotionsController(IPromotionService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = this.service.GetAllPromotions();
            return View("PromotionsList", model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = this.service.GetPromotion(id);
            if (model == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("PromotionForm", model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = this.service.GetEmptyPromotion();

            return View("PromotionForm", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(PromotionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("PromotionForm", model);
            }

            //Model is newly created and should be added to the database.
            if (model.Id == 0)
                this.service.CreatePromotion(model);
            else
                this.service.UpdatePromotion(model);

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            this.service.RemovePromotion(id);
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