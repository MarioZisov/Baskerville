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
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Baskerville.Services
{
    public class HomeService : Service
    {
        private IRepository<Subscriber> subscribers;
        private IRepository<ProductCategory> categories;
        private IRepository<Promotion> promotions;
        private IRepository<Event> events;
        private HtmlBuilder htmlBuilder;

        public HomeService(IDbContext context)
            : base(context)
        {
            this.categories = new Repository<ProductCategory>(context);
            this.promotions = new Repository<Promotion>(context);
            this.events = new Repository<Event>(context);
            this.subscribers = new Repository<Subscriber>(context);
        } 

        public HtmlString GetMenuHtml(bool isLangBg)
        {
            var filteredCategories = this.categories
                .Find(c => c.IsPrimary && !c.IsRemoved)
                .Include("Products")
                .Include("Subcategories.Products")
                .ToList();

            this.htmlBuilder = new MenuBuilder(filteredCategories, isLangBg);
            var html = this.htmlBuilder.Render();

            return html;
        }        

        public HomeViewModel GetHomeModel(bool isLangBg)
        {
            HomeViewModel model = new HomeViewModel();

            model.Promotions = this.GetPromotionsHtml(isLangBg);
            model.Events = this.GetEventsHtml(isLangBg);

            model.ContactModelBg = new ContactViewModelBg();
            model.ContactModelEn = new ContactViewModelEn();

            model.SubscribeModelEn = new SubscribeViewModelEn();
            model.SubscribeModelBg = new SubscribeViewModelBg();

            return model;
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

        public bool SendEmail(ContactBindingModel contactModel)
        {
            var emailer = new Emailer(MailSettings.NoReplySettings);

            string body = $"Name: {contactModel.Name}{Environment.NewLine}Phone: {contactModel.PhoneNumber}{Environment.NewLine}Email: {contactModel.Email}{Environment.NewLine}{contactModel.Message}";
            string subject = contactModel.Subject;

            return emailer.SendEmail(body, subject, false, MailSettings.NoReplyEmailAdress);
        }

        public void AddSubscriber(SubscribeBindingModel subscribeModel)
        {

        }
    }
}