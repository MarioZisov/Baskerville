namespace Baskerville.App.Controllers
{
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

                this.ViewBag.Header = PublicMessages.SubscribeVerifiedTitleEn;
                this.ViewBag.Paragraph = PublicMessages.SubscribeVerifiedContentEn;
            }
            else
            {
                this.ViewBag.Header = PublicMessages.WrongCodeTitleEn;
                this.ViewBag.Paragraph = PublicMessages.WrongCodeContentEn;
            }

            return View("MessagePage");
        }

        public ActionResult Unsubscribe(string code)
        {
            var result = this.service.VerificateUnsubscribeCode(code);
            if (result)
            {
                this.ViewBag.Header = PublicMessages.UnsubscribeVerifiedTitleEn;
                this.ViewBag.Paragraph = PublicMessages.UnsubscribeVerifiedContentEn;
            }
            else
            {
                this.ViewBag.Header = PublicMessages.WrongCodeTitleEn;
                this.ViewBag.Paragraph = PublicMessages.WrongCodeContentEn;
            }

            return View("MessagePage");
        }
    }
}