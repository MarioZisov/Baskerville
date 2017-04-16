using AutoMapper;
using Baskerville.Data;
using Baskerville.Models.ViewModels;
using Baskerville.Models.ViewModels.Public;
using Baskerville.Services;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Baskerville.App.Controllers
{
    public class HomeController : Controller
    {
        private HomeService service;

        public HomeController()
        {
            this.service = new HomeService(new BaskervilleContext());
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = this.service.GetHomeModel(false);
            return View(model);
        }

        [HttpGet]
        public ActionResult Menu()
        {
            var html = this.service.GetMenuHtml(false);
            return View(html);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Send(ContactBindingModel bindingModel)
        {
            if (!ModelState.IsValid)
            {
                var homeModel = this.service.GetHomeModel(false);
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
            this.service.CheckEmailUnicness(bindingModel, this.ModelState, false);

            if (!ModelState.IsValid)
            {
                var homeModel = this.service.GetHomeModel(false);
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