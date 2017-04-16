using Baskerville.App.Constants;
using Baskerville.Data;
using Baskerville.Models.ViewModels.Public;
using Baskerville.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Baskerville.App.Controllers
{
    public class VerificationController : Controller
    {
        private VerificationService service;

        public VerificationController()
        {
            this.service = new VerificationService(new BaskervilleContext());
        }

        // GET: Verification
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Subscribe(string code)
        {
            var result = this.service.VerificateSubscribtionCode(code);
            if (result)
            {
                MessagePageViewModel model = new MessagePageViewModel
                {
                    Title = PublicMessages.SubscribeVerifiedTitleEn,
                    Content = PublicMessages.SubscribeVerifiedContentEn
                };

                return View("MessagePage", model);
            }
            else
            {
                MessagePageViewModel model = new MessagePageViewModel
                {
                    Title = PublicMessages.WrongCodeTitleEn,
                    Content = PublicMessages.WrongCodeContentEn
                };

                return View("MessagePage", model);
            }
        }

        public ActionResult Unsubscribe(string code)
        {
            var result = this.service.VerificateUnsubscribeCode(code);
            if (result)
            {
                MessagePageViewModel model = new MessagePageViewModel
                {
                    Title = PublicMessages.UnsubscribeVerifiedTitleEn,
                    Content = PublicMessages.UnsubscribeVerifiedContentEn
                };

                return View("MessagePage", model);
            }
            else
            {
                MessagePageViewModel model = new MessagePageViewModel
                {
                    Title = PublicMessages.WrongCodeTitleEn,
                    Content = PublicMessages.WrongCodeContentEn
                };

                return View("MessagePage", model);
            }
        }
    }
}