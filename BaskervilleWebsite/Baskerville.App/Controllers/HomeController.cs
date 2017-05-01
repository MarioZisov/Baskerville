namespace Baskerville.App.Controllers
{
    using AutoMapper;
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
                this.ViewBag.Header = "Message sent";
                this.ViewBag.Paragraph = "Thank you for your message.";

                return View("MessagePage");
            }
            else
            {
                this.ViewBag.Header = "Problem occurred";
                this.ViewBag.Paragraph = "Please try to send your message again.";

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

            this.ViewBag.Header = "One last step.";
            this.ViewBag.Paragraph = "Confirm your email adress and will become part of our club";

            return View("MessagePage");
        }
    }
}