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
    public class VerificationController : BaseController
    {
        private VerificationService service;

        public VerificationController()
        {
            this.service = new VerificationService(new BaskervilleContext());
        }

        public ActionResult Subscribe(string code)
        {
            code = HttpUtility.UrlEncode(code);
            var result = this.service.VerificateSubscribtionCode(code);
            if (result)
            {
                this.service.SendWelcomeEmail(code);

                this.ViewBag.Header = PublicMessages.SubscribeVerifiedTitleEn;
                this.ViewBag.Paragraph = PublicMessages.SubscribeVerifiedContentEn;

                return View("MessagePage");
            }
            else
            {
                this.ViewBag.Header = PublicMessages.WrongCodeTitleEn;
                this.ViewBag.Paragraph = PublicMessages.WrongCodeContentEn;

                return View("MessagePage");
            }
        }

        public ActionResult Unsubscribe(string code)
        {
            code = HttpUtility.UrlEncode(code);
            var result = this.service.VerificateUnsubscribeCode(code);
            if (result)
            {
                this.ViewBag.Header = PublicMessages.UnsubscribeVerifiedTitleEn;
                this.ViewBag.Paragraph = PublicMessages.UnsubscribeVerifiedContentEn;

                return View("MessagePage");
            }
            else
            {
                this.ViewBag.Header = PublicMessages.WrongCodeTitleEn;
                this.ViewBag.Paragraph = PublicMessages.WrongCodeContentEn;

                return View("MessagePage");
            }
        }
    }
}