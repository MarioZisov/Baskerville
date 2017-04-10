using Baskerville.Data.Contracts.Repository;
using Baskerville.Data.Repository;
using Baskerville.Models.DataModels;
using Baskerville.Models.ViewModels;
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
            model.ContactModel = new ContactViewModel();

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

        public bool SendEmail(ContactViewModel contactModel)
        {
            SmtpSection section = (SmtpSection)ConfigurationManager.GetSection("myMailSettings/smtp");            

            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Port = section.Network.Port;
                smtpClient.Host = section.Network.Host;
                smtpClient.Credentials = new NetworkCredential(section.Network.UserName, section.Network.Password);
                smtpClient.EnableSsl = section.Network.EnableSsl;

                using (MailMessage message = new MailMessage())
                {
                    message.From = new MailAddress(section.From);
                    message.Subject = contactModel.Subject;
                    message.Body = $"Name: {contactModel.Name}{Environment.NewLine}Phone: {contactModel.PhoneNumber}{Environment.NewLine}Email: {contactModel.Email}{Environment.NewLine}{contactModel.Message}";
                    message.IsBodyHtml = false;
                    message.To.Add(new MailAddress("sensato.report@gmail.com"));
                    try
                    {
                        smtpClient.Send(message);
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }
    }
}