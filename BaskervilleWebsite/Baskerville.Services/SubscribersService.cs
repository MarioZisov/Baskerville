namespace Baskerville.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Contracts.Repository;
    using Models.DataModels;
    using Data.Repository;
    using Models.ViewModels;
    using AutoMapper;
    using Utilities;
    using Constants;
    using Models.Enums;
    using System.Net;
    using Contracts;

    public class SubscribersService : Service, ISubscribersService
    {
        private IRepository<Subscriber> subscribers;

        public SubscribersService()
        {
            this.subscribers = new Repository<Subscriber>(this.Context);
        }

        public IEnumerable<SubscriberViewModel> GetActiveSubscribers()
        {
            var subscribersViewModel = this.subscribers
                .Find(s => s.IsActive && !s.IsRemoved)
                .Select(Mapper.Map<Subscriber, SubscriberViewModel>)
                .ToList();

            return subscribersViewModel;
        }

        public HttpStatusCode RemoveSubscriber(int id)
        {
            var subscriber = this.subscribers.GetById(id);
            if (subscriber != null)
            {
                subscriber.IsRemoved = true;
                this.subscribers.Update(subscriber);

                return HttpStatusCode.OK;
            }

            return HttpStatusCode.NotFound;
        }

        public void SendMessageToSubscribers(MessageViewModel model)
        {
            var subscribersBg = this.subscribers
                .Find(s => s.IsActive && !s.IsRemoved && s.PreferedLanguage == Language.BG
                ).Select(s => s.Email)
                .ToList();

            var subscribersEn = this.subscribers
                .Find(s => s.IsActive && !s.IsRemoved && s.PreferedLanguage == Language.EN)
                .Select(s => s.Email)
                .ToList();

            Emailer emailer = new Emailer(MailSettings.SensatoSettings);

            emailer.SendEmail(model.ContentBg, model.SubjectBg, false, subscribersBg);
            emailer.SendEmail(model.ContentEn, model.SubjectEn, false, subscribersEn);
        }
    }
}
