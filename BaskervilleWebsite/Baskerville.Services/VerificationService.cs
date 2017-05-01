namespace Baskerville.Services
{
    using System;
    using Data.Contracts.Repository;
    using Models.DataModels;
    using Data.Repository;
    using Utilities;
    using Constants;
    using System.Web;

    public class VerificationService : Service
    {
        private IRepository<Subscriber> subscribers;
        private IRepository<Statistics> statistics;

        public VerificationService(IDbContext context)
            : base(context)
        {
            this.subscribers = new Repository<Subscriber>(context);
            this.statistics = new Repository<Statistics>(context);
        }

        public bool VerificateSubscribtionCode(string code)
        {
            var subscriber = this.subscribers.GetFirstOrNull(s => s.SubscriptionVerificationCode == code && !s.IsActive && !s.IsRemoved);

            if (subscriber == null)
                return false;

            int passedHours = (DateTime.Now - subscriber.SubscriptionPendingDate).Value.Hours;
            if (passedHours > 24)
                return false;

            string unsubsribeCode = CodeGenerator.GenerateVerificationCode(subscriber.Email);

            subscriber.IsActive = true;
            subscriber.SubscriptionDate = DateTime.Now;
            subscriber.UnsubscribeVerificationCode = unsubsribeCode;

            this.subscribers.Update(subscriber);

            var statIncr = new StatisticsIncrementer(this.statistics);
            statIncr.IncrementSubscribers();

            return true;
        }               

        public void SendWelcomeEmail(string code)
        {
            var subscriber = this.subscribers.GetFirst(s => s.SubscriptionVerificationCode == code && s.IsActive && !s.IsRemoved);
            Emailer emailer = new Emailer(MailSettings.NoReplySettings);
            string verificationUrl = "http://localhost:55555/verification/unsubscribe?code=" + HttpUtility.UrlEncode(subscriber.UnsubscribeVerificationCode);

            string body = verificationUrl;
            string subject = "Unsubcribe";

            emailer.SendEmail(body, subject, true, subscriber.Email);
        }

        public bool VerificateUnsubscribeCode(string code)
        {
            var subscriber = this.subscribers.GetFirstOrNull(s => s.UnsubscribeVerificationCode == code && s.IsActive && !s.IsRemoved);

            if (subscriber == null)
                return false;

            subscriber.IsActive = false;
            subscriber.UnsubscribeDate = DateTime.Now;

            this.subscribers.Update(subscriber);
            return true;
        }
    }
}
