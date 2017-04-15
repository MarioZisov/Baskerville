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
    }

    public class HomeBM
    {
        public ContactViewModelEn ContactModelEn { get;  set; }
    }

    public class ContactViewModelEn
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength: 500, MinimumLength = 10)]
        public string Message { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Subject { get; set; }

    }
}