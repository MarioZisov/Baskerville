namespace Baskerville.App.Controllers
{
    using AutoMapper;
    using Constants;
    using Models.ViewModels.Public;
    using Services.Contracts;
    using Services.Enums;
    using System.Web.Mvc;

    public class HomeController : BaseController
    {
        private const DisplayLanguage DefaultLanguage = DisplayLanguage.BG;

        private IHomeService service;

        public HomeController(IHomeService service)
        {
            this.service = service;
            this.service.Lang = DefaultLanguage;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = this.service.GetHomeModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Send(ContactBindingModel bindingModel)
        {
            if (!ModelState.IsValid)
            {
                var homeModel = this.service.GetHomeModel();
                Mapper.Map(bindingModel, homeModel.ContactModelBg);

                return View("Index", homeModel);
            }

            bool success = this.service.SendContactEmail(bindingModel);
            if (success)
            {
                this.ViewBag.Header = PublicMessages.MessageSentHeaderBg;
                this.ViewBag.Paragraph = PublicMessages.MessageSentParagraphBg;

                return View("MessagePage");
            }
            else
            {
                this.ViewBag.Header = PublicMessages.MessageNotSentHeaderBg;
                this.ViewBag.Paragraph = PublicMessages.MessageNotSentParagraphBg;

                return View("MessagePage");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Subscribe(SubscribeBindingModel bindingModel)
        {
            this.service.CheckEmailUnicness(bindingModel, this.ModelState);

            if (!ModelState.IsValid)
            {
                var homeModel = this.service.GetHomeModel();

                Mapper.Map(bindingModel, homeModel.SubscribeModelBg);

                return View("Index", homeModel);
            }

            this.service.AddSubscriber(bindingModel);

            this.ViewBag.Header = PublicMessages.ConfirmEmailHeaderBg;
            this.ViewBag.Paragraph = PublicMessages.ConfirmEmailParagraphBg;

            return View("MessagePage");
        }
    }
}