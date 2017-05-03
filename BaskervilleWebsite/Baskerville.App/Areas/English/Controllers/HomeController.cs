namespace Baskerville.App.Areas.English.Controllers
{
    using App.Controllers;
    using AutoMapper;
    using Constants;
    using Models.ViewModels.Public;
    using Services.Contracts;
    using Services.Enums;
    using System.Web.Mvc;

    public class HomeController : BaseController
    {
        private const DisplayLanguage DefaultLanguage = DisplayLanguage.EN;

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
                //check language
                if (true)
                    Mapper.Map(bindingModel, homeModel.ContactModelEn);
                else
                    Mapper.Map(bindingModel, homeModel.ContactModelBg);

                return View("Index", homeModel);
            }

            bool success = this.service.SendContactEmail(bindingModel);
            if (success)
            {
                this.ViewBag.Header = PublicMessages.MessageSentHeaderEn;
                this.ViewBag.Paragraph = PublicMessages.MessageSentParagraphEn;

                return View("MessagePage");
            }
            else
            {
                this.ViewBag.Header = PublicMessages.MessageNotSentHeaderEn;
                this.ViewBag.Paragraph = PublicMessages.MessageNotSentParagraphEn;

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
                //check language
                if (true)
                    Mapper.Map(bindingModel, homeModel.SubscribeModelEn);
                else
                    Mapper.Map(bindingModel, homeModel.SubscribeModelBg);

                return View("Index", homeModel);
            }

            this.service.AddSubscriber(bindingModel);

            this.ViewBag.Header = PublicMessages.ConfirmEmailHeaderEn;
            this.ViewBag.Paragraph = PublicMessages.ConfirmEmailParagraphEn;

            return View("MessagePage");
        }
    }
}