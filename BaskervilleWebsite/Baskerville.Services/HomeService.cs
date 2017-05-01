namespace Baskerville.Services
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Data.Contracts.Repository;
    using Data.Repository;
    using Models.DataModels;
    using Models.Enums;
    using Models.ViewModels;
    using Models.ViewModels.Public;
    using Constants;
    using Utilities;
    using Utilities.HtmlBuilders;
    using Enums;

    public class HomeService : Service
    {
        private IRepository<Subscriber> subscribers;
        private IRepository<ProductCategory> categories;
        private IRepository<Promotion> promotions;
        private IRepository<Event> events;
        private IRepository<News> news;
        private HtmlBuilder htmlBuilder;
        private DisplayLanguage lang;

        public HomeService(IDbContext context, DisplayLanguage language)
            : base(context)
        {
            this.categories = new Repository<ProductCategory>(context);
            this.promotions = new Repository<Promotion>(context);
            this.events = new Repository<Event>(context);
            this.news = new Repository<News>(context);
            this.subscribers = new Repository<Subscriber>(context);
            this.lang = language;
        }

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
                bool exists = this.subscribers.Exists(s => s.Email == model.Email && s.IsActive);

                if (exists)
                {
                    string message = this.lang == DisplayLanguage.BG ? PublicMessages.EmailExistMessageBg : PublicMessages.EmailExistMessageEn;
                    modelState.AddModelError("Email", message);
                }
            }
        }

        public bool SendContactEmail(ContactBindingModel contactModel)
        {
            var emailer = new Emailer(MailSettings.NoReplySettings);

            string body = $"Name: {contactModel.Name}{Environment.NewLine}Phone: {contactModel.PhoneNumber}{Environment.NewLine}Email: {contactModel.Email}{Environment.NewLine}{contactModel.Message}";
            string subject = contactModel.Subject;

            return emailer.SendEmail(body, subject, false, MailSettings.NoReplyEmailAdress);
        }

        public void AddSubscriber(SubscribeBindingModel subscribeModel)
        {
            string email = subscribeModel.Email;
            Language lang = subscribeModel.PreferedLanguage == "en" ? Language.EN : Language.BG;

            string verificationCode = CodeGenerator.GenerateVerificationCode(email);

            if (this.subscribers.Exists(s => s.Email == email && !s.IsActive))
            {
                var subscriberFromDb = this.subscribers.GetFirst(s => s.Email == email);

                subscriberFromDb.Email = email;
                subscriberFromDb.PreferedLanguage = lang;
                subscriberFromDb.SubscriptionVerificationCode = verificationCode;
                subscriberFromDb.IsActive = false;
                subscriberFromDb.IsRemoved = false;
                subscriberFromDb.SubscriptionPendingDate = DateTime.Now;
                subscriberFromDb.SubscriptionDate = null;
                subscriberFromDb.UnsubscribeDate = null;
                subscriberFromDb.UnsubscribeVerificationCode = null;

                this.subscribers.Update(subscriberFromDb);
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

                this.subscribers.Insert(subscriber);
            }

            this.SendVerificationEmail(verificationCode, email);
        }

        private HtmlString GetPromotionsHtml()
        {
            var fitleredPromotions = this.promotions
                .Find(c => c.IsPublic && !c.IsRemoved)
                .ToList();

            this.htmlBuilder = new PromotionsBuilder(fitleredPromotions, this.lang);
            var html = this.htmlBuilder.Render();

            return html;
        }

        private HtmlString GetEventsHtml()
        {
            var filteredEvents = this.events
                .Find(e => e.IsPublic && !e.IsRemoved)
                .ToList();

            this.htmlBuilder = new EventsBuilder(filteredEvents, this.lang);
            var html = this.htmlBuilder.Render();

            return html;
        }

        private HtmlString GetNewsHtml()
        {
            var filteredNews = this.news
                .Find(n => n.IsPublic && !n.IsRemoved)
                .ToList();

            this.htmlBuilder = new NewsBuilder(filteredNews, this.lang);
            var html = this.htmlBuilder.Render();

            return html;
        }

        private void SendVerificationEmail(string verificationCode, string email)
        {
            var emailer = new Emailer(MailSettings.NoReplySettings);

            string verificationUrl = "http://localhost:55555/verification/subscribe?code=" + HttpUtility.UrlEncode(verificationCode);

            string body = verificationUrl;
            string subject = "Subcribe";

            emailer.SendEmail(body, subject, true, email);
        }
    }
}