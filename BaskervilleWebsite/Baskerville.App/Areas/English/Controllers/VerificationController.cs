namespace Baskerville.App.Areas.English.Controllers
{
    using App.Controllers;
    using Constants;
    using Services.Contracts;
    using Services.Enums;
    using System.Web.Mvc;

    public class VerificationController : BaseController
    {
        private const DisplayLanguage DefaultLanguage = DisplayLanguage.EN;

        private IVerificationService service;

        public VerificationController(IVerificationService service)
        {
            this.service = service;
            this.service.Lang = DefaultLanguage;
        }

        public ActionResult Subscribe(string code)
        {
            var result = this.service.VerificateSubscribtionCode(code);
            if (result)
            {
                this.service.SendWelcomeEmail();

                this.ViewBag.Header = PublicMessages.SubscribeVerifiedHeaderEn;
                this.ViewBag.Paragraph = PublicMessages.SubscribeVerifiedParagraphEn;
            }
            else
            {
                this.ViewBag.Header = PublicMessages.WrongCodeHeaderEn;
                this.ViewBag.Paragraph = PublicMessages.WrongCodeParagraphEn;
            }

            return View("MessagePage");
        }

        public ActionResult Unsubscribe(string code)
        {
            var result = this.service.VerificateUnsubscribeCode(code);
            if (result)
            {
                this.ViewBag.Header = PublicMessages.UnsubscribeVerifiedHeaderEn;
                this.ViewBag.Paragraph = PublicMessages.UnsubscribeVerifiedParagraphEn;
            }
            else
            {
                this.ViewBag.Header = PublicMessages.WrongCodeHeaderEn;
                this.ViewBag.Paragraph = PublicMessages.WrongCodeParagraphEn;
            }

            return View("MessagePage");
        }
    }
}