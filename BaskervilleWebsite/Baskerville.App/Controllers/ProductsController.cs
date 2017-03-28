using Baskerville.Data;
using Baskerville.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Baskerville.App.Controllers
{
    public class ProductsController : Controller
    {
        private ProductsService service;

        public ProductsController()
        {
            this.service = new ProductsService(new BaskervilleContext());
        }

        // GET: Products
        public ActionResult Index()
        {
            var model = this.service.GetAllProducts();
            return View(model);
        }
    }
}