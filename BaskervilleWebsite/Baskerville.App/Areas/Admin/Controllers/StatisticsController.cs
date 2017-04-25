using Baskerville.App.Attributes;
using Baskerville.Data;
using Baskerville.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Baskerville.App.Areas.Admin.Controllers
{
    public class StatisticsController : AuthorizedController
    {
        private StatisticsService service;

        public StatisticsController()
        {
            this.service = new StatisticsService(new BaskervilleContext());
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = this.service.GetStatistics();

            return View(model);
        }

        [HttpGet]
        public ActionResult MontlyData(int year)
        {
            var model = this.service.GetBarChartData(year);

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}