using Baskerville.Data.Contracts.Repository;
using Baskerville.Data.Repository;
using Baskerville.Models.DataModels;
using Baskerville.Models.Enums;
using Baskerville.Models.ViewModels;
using Baskerville.Models.ViewModels.Public;
using Baskerville.Services.Constants;
using Baskerville.Services.Utilities;
using Baskerville.Services.Utilities.HtmlBuilders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Baskerville.Services
{
    public class HomeService : Service
    {
        private IRepository<Subscriber> subscribers;
        private IRepository<ProductCategory> categories;
        private IRepository<Promotion> promotions;
        private IRepository<Event> events;
        private IRepository<News> news;
        private HtmlBuilder htmlBuilder;

        public HomeService(IDbContext context)
            : base(context)
        {
            this.categories = new Repository<ProductCategory>(context);
            this.promotions = new Repository<Promotion>(context);
            this.events = new Repository<Event>(context);
            this.news = new Repository<News>(context);
            this.subscribers = new Repository<Subscriber>(context);
        }

        public HomeViewModel GetHomeModel(bool isLangBg)
        {
            HomeViewModel model = new HomeViewModel();

            model.Promotions = this.GetPromotionsHtml(isLangBg);
            model.Events = this.GetEventsHtml(isLangBg);
            model.News = this.GetNewsHtml(isLangBg);

            model.ContactModelBg = new ContactViewModelBg();
            model.ContactModelEn = new ContactViewModelEn();

            model.SubscribeModelEn = new SubscribeViewModelEn();
            model.SubscribeModelBg = new SubscribeViewModelBg();

            return model;
        }        

        public void CheckEmailUnicness(SubscribeBindingModel model, ModelStateDictionary modelState, bool isLangBg)
        {
            if (model != null && model.Email != null)
            {
                bool exists = this.subscribers.Exists(s => s.Email == model.Email && s.IsActive);

                if (exists)
                {
                    string message = isLangBg ? PublicMessages.EmailExistMessageBg : PublicMessages.EmailExistMessageEn;
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

            string verificationCode = HttpUtility.UrlEncode(CodeGenerator.GenerateVerificationCode(email));

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

        private HtmlString GetPromotionsHtml(bool isLangBg)
        {
            var fitleredPromotions = this.promotions
                .Find(c => c.IsPublic && !c.IsRemoved)
                .ToList();

            this.htmlBuilder = new PromotionsBuilder(fitleredPromotions, isLangBg);
            var html = this.htmlBuilder.Render();

            return html;
        }

        private HtmlString GetEventsHtml(bool isLangBg)
        {
            var filteredEvents = this.events
                .Find(e => e.IsPublic && !e.IsRemoved)
                .ToList();

            this.htmlBuilder = new EventsBuilder(filteredEvents, isLangBg);
            var html = this.htmlBuilder.Render();

            return html;
        }

        private HtmlString GetNewsHtml(bool isLangBg)
        {
            var filteredNews = this.news
                .Find(n => n.IsPublic && !n.IsRemoved)
                .ToList();

            this.htmlBuilder = new NewsBuilder(filteredNews, isLangBg);
            var html = this.htmlBuilder.Render();

            return html;
        }

        private void SendVerificationEmail(string verificationCode, string email)
        {
            var emailer = new Emailer(MailSettings.NoReplySettings);

            string verificationUrl = "http://localhost:55555/verification/subscribe?code=" + verificationCode;

            string body = verificationUrl;
            string subject = "Subcribe";

            emailer.SendEmail(body, subject, true, email);
        }
    }

}