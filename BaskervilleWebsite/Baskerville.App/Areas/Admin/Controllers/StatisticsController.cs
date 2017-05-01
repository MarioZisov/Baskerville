namespace Baskerville.App.Areas.Admin.Controllers
{
    using Services.Contracts;
    using System.Web.Mvc;

    public class StatisticsController : AuthorizedController
    {
        private IStatisticsService service;

        public StatisticsController(IStatisticsService service)
        {
            this.service = service;
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