namespace Baskerville.Services
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Data.Contracts.Repository;
    using Models.DataModels;
    using Models.Enums;
    using Models.ViewModels.Public;
    using Constants;
    using Utilities;
    using Utilities.HtmlBuilders;
    using Enums;
    using Contracts;

    public class HomeService : Service, IHomeService
    {
        private const DisplayLanguage DefaultLanguage = DisplayLanguage.BG;

        private HtmlBuilder htmlBuilder;

        public HomeService(IDbContext context)
            : base(context)
        {
            this.Lang = DefaultLanguage;
        }

        public DisplayLanguage Lang { get; set; }

        public HomeViewModel GetHomeModel()
        {
            HomeViewModel model = new HomeViewModel();

            model.Promotions = this.GetPromotionsHtml();
            model.Events = this.GetEventsHtml();
            model.News = this.GetNewsHtml();

            model.ContactModelBg = new ContactViewModelBg();
            model.ContactModelEn = new ContactViewModelEn();

            model.SubscribeModelEn = new SubscribeViewModelEn();
            model.SubscribeModelBg = new SubscribeViewModelBg();

            return model;
        }        

        public void CheckEmailUnicness(SubscribeBindingModel model, ModelStateDictionary modelState)
        {
            if (model != null && model.Email != null)
            {
                bool exists = this.Subscribers.Exists(s => s.Email == model.Email && s.IsActive && !s.IsRemoved);

                if (exists)
                {
                    string message = this.Lang == DisplayLanguage.BG ? PublicMessages.EmailExistMessageBg : PublicMessages.EmailExistMessageEn;
                    modelState.AddModelError("Email", message);
                }
            }
        }

        public bool SendContactEmail(ContactBindingModel contactModel)
        {
            var emailer = new Emailer(MailSettings.SensatoSettings);

            string body = $"Name: {contactModel.Name}{Environment.NewLine}Phone: {contactModel.PhoneNumber}{Environment.NewLine}Email: {contactModel.Email}{Environment.NewLine}{contactModel.Message}";
            string subject = contactModel.Subject;

            return emailer.SendEmail(body, subject, false, MailSettings.SensatoEmail);
        }

        public void AddSubscriber(SubscribeBindingModel subscribeModel)
        {
            string email = subscribeModel.Email;
            Language lang = subscribeModel.PreferedLanguage == "en" ? Language.EN : Language.BG;

            string verificationCode = CodeGenerator.GenerateVerificationCode(email);

            if (this.Subscribers.Exists(s => s.Email == email && (!s.IsActive || s.IsRemoved)))
            {
                var subscriberFromDb = this.Subscribers.GetFirst(s => s.Email == email);

                subscriberFromDb.Email = email;
                subscriberFromDb.PreferedLanguage = lang;
                subscriberFromDb.SubscriptionVerificationCode = verificationCode;
                subscriberFromDb.IsActive = false;
                subscriberFromDb.IsRemoved = false;
                subscriberFromDb.SubscriptionPendingDate = DateTime.Now;
                subscriberFromDb.SubscriptionDate = null;
                subscriberFromDb.UnsubscribeDate = null;
                subscriberFromDb.UnsubscribeVerificationCode = null;

                this.Subscribers.Update(subscriberFromDb);
            }
            else
            {
                Subscriber subscriber = new Subscriber
                {
                    Email = email,
                    PreferedLanguage = lang,
                    SubscriptionVerificationCode = verificationCode,
                    IsActive = false,
                    IsRemoved = false,
                    SubscriptionPendingDate = DateTime.Now,
                    SubscriptionDate = null,
                    UnsubscribeDate = null,
                    UnsubscribeVerificationCode = null
                };

                this.Subscribers.Insert(subscriber);
            }

            this.SendVerificationEmail(verificationCode, email);
        }

        private HtmlString GetPromotionsHtml()
        {
            var fitleredPromotions = this.Promotions
                .Find(c => c.IsPublic && !c.IsRemoved)
                .ToList();

            this.htmlBuilder = new PromotionsBuilder(fitleredPromotions, this.Lang);
            var html = this.htmlBuilder.Render();

            return html;
        }

        private HtmlString GetEventsHtml()
        {
            var filteredEvents = this.Events
                .Find(e => e.IsPublic && !e.IsRemoved)
                .ToList();

            this.htmlBuilder = new EventsBuilder(filteredEvents, this.Lang);
            var html = this.htmlBuilder.Render();

            return html;
        }

        private HtmlString GetNewsHtml()
        {
            var filteredNews = this.News
                .Find(n => n.IsPublic && !n.IsRemoved)
                .ToList();

            this.htmlBuilder = new NewsBuilder(filteredNews, this.Lang);
            var html = this.htmlBuilder.Render();

            return html;
        }

        private void SendVerificationEmail(string verificationCode, string email)
        {
            var emailer = new Emailer(MailSettings.SensatoSettings);

            string verificationUrl = this.GenerateSubscribtionUrl(verificationCode);

            string body = verificationUrl;
            string subject = "Subcribe";

            emailer.SendEmail(body, subject, true, email);
        }

        private string GenerateSubscribtionUrl(string verificationCode)
        {
            string url = this.Lang == DisplayLanguage.BG
                ? "http://localhost:55555/verification/subscribe?code="
                : "http://localhost:55555/en/verification/subscribe?code=";

            string verificationUrl = url + HttpUtility.UrlEncode(verificationCode);

            return verificationUrl;
        }
    }
}