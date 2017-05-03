namespace Baskerville.App.Controllers
{
    using Constants;
    using Services.Contracts;
    using Services.Enums;
    using System.Web.Mvc;

    public class VerificationController : BaseController
    {
        private const DisplayLanguage DefaultLanguage = DisplayLanguage.BG;

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

                this.ViewBag.Header = PublicMessages.SubscribeVerifiedHeaderBg;
                this.ViewBag.Paragraph = PublicMessages.SubscribeVerifiedParagraphBg;
            }
            else
            {
                this.ViewBag.Header = PublicMessages.WrongCodeHeaderBg;
                this.ViewBag.Paragraph = PublicMessages.WrongCodeParagraphBg;
            }

            return View("MessagePage");
        }

        public ActionResult Unsubscribe(string code)
        {
            var result = this.service.VerificateUnsubscribeCode(code);
            if (result)
            {
                this.ViewBag.Header = PublicMessages.UnsubscribeVerifiedHeaderBg;
                this.ViewBag.Paragraph = PublicMessages.UnsubscribeVerifiedParagraphBg;
            }
            else
            {
                this.ViewBag.Header = PublicMessages.WrongCodeHeaderBg;
                this.ViewBag.Paragraph = PublicMessages.WrongCodeParagraphBg;
            }

            return View("MessagePage");
        }
    }
}