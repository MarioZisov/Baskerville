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
    public class ProductsController : AuthorizedController
    {
        private ProductsService service;

        public ProductsController()
        {
            this.service = new ProductsService(new BaskervilleContext());
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = this.service.GetAllProducts();
            if (this.User.IsInRole("Employee"))
                return this.View("ProductsReadOnlyList", model);

            return View("ProductsList", model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Owner,Manager")]
        public ActionResult Details(int id)
        {
            var model = this.service.GetProduct(id);
            if (model == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("ProductForm", model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Owner,Manager")]
        public ActionResult Create()
        {
            var model = this.service.GetEmptyProduct();
            return this.View("ProductForm", model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Owner,Manager")]
        public ActionResult Delete(int id)
        {
            this.service.RemoveProduct(id);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.PrimaryCategories = this.service.GetPrimaryCategories();
                return View("ProductForm", model);
            }

            //Model is newly created and should be added to the database.
            if (model.Id == 0)
                this.service.CreateProduct(model);
            else
                this.service.UpdateProduct(model);
                
            return this.RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Owner,Manager")]
        public ActionResult GetSubCategories(int id)
        {
            var subCategories = this.service.GetSubCategories(id);
            return Json(subCategories, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdatePublicity(int id)
        {
            var status = this.service.UpdatePublicity(id);

            return new HttpStatusCodeResult(status);
        }
    }
}