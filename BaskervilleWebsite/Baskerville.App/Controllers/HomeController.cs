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

            bool success = this.service.SendEmail(bindingModel);
            if (success)
                return View("MessageSent");
            else
                return View("404");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Subscribe(SubscribeBindingModel bindingModel)
        {
            if (bindingModel != null)
            {
                bool isUnique = this.service.ValidateEmailUniqueness(bindingModel.Email);
                if (!isUnique)
                {
                    string message = true ? "Already exist" : "Съществува";
                    this.ModelState.AddModelError("Email", message);
                }
            }

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

            return View("MessageSent");
        }                    
    }
}