namespace Baskerville.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Contracts.Repository;
    using Models.DataModels;
    using Models.ViewModels;
    using AutoMapper;
    using Utilities;
    using Constants;
    using Models.Enums;
    using System.Net;
    using Contracts;

    public class SubscribersService : Service, ISubscribersService
    {
        public SubscribersService(IDbContext context)
            : base(context)
        {
        }

        public IEnumerable<SubscriberViewModel> GetActiveSubscribers()
        {
            var subscribersViewModel = this.Subscribers
                .Find(s => s.IsActive && !s.IsRemoved)
                .Select(Mapper.Map<Subscriber, SubscriberViewModel>)
                .ToList();

            return subscribersViewModel;
        }

        public HttpStatusCode RemoveSubscriber(int id)
        {
            var subscriber = this.Subscribers.GetById(id);
            if (subscriber != null)
            {
                subscriber.IsRemoved = true;
                this.Subscribers.Update(subscriber);

                return HttpStatusCode.OK;
            }

            return HttpStatusCode.NotFound;
        }

        public void SendMessageToSubscribers(MessageViewModel model)
        {
            var subscribersBg = this.Subscribers
                .Find(s => s.IsActive && !s.IsRemoved && s.PreferedLanguage == Language.BG
                ).Select(s => s.Email)
                .ToList();

            var subscribersEn = this.Subscribers
                .Find(s => s.IsActive && !s.IsRemoved && s.PreferedLanguage == Language.EN)
                .Select(s => s.Email)
                .ToList();

            Emailer emailer = new Emailer(MailSettings.SensatoSettings);

            emailer.SendEmail(model.ContentBg, model.SubjectBg, false, subscribersBg);
            emailer.SendEmail(model.ContentEn, model.SubjectEn, false, subscribersEn);
        }
    }
}
