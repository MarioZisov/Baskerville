namespace Baskerville.App.Controllers
{
    using Services.Contracts;
    using Services.Enums;
    using System.Web.Mvc;

    public class MenuController : BaseController
    {
        private const DisplayLanguage DefaultLanguage = DisplayLanguage.EN;

        IMenuService service;

        public MenuController(IMenuService service)
        {
            this.service = service;
            this.service.Lang = DefaultLanguage;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = this.service.GetMenuModel();
            return View(model);
        }
    }
}