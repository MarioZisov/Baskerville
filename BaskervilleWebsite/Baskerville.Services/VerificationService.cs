namespace Baskerville.Services
{
    using System;
    using Data.Contracts.Repository;
    using Models.DataModels;
    using Data.Repository;
    using Utilities;
    using Constants;
    using System.Web;
    using Contracts;
    using Enums;

    public class VerificationService : Service, IVerificationService
    {
        private const DisplayLanguage DefaultLanguage = DisplayLanguage.BG;

        private string currentSubscriberEmail;

        public VerificationService(IDbContext context)
            : base(context)
        {
            this.Lang = DefaultLanguage;
        }

        public DisplayLanguage Lang { get; set; }

        public bool VerificateSubscribtionCode(string code)
        {
            var subscriber = this.Subscribers.GetFirstOrNull(s => s.SubscriptionVerificationCode == code && !s.IsActive && !s.IsRemoved);

            if (subscriber == null)
                return false;

            int passedHours = (DateTime.Now - subscriber.SubscriptionPendingDate).Hours;
            if (passedHours > 24)
                return false;

            this.currentSubscriberEmail = subscriber.Email;

            string unsubsribeCode = CodeGenerator.GenerateVerificationCode(subscriber.Email);

            subscriber.IsActive = true;
            subscriber.SubscriptionDate = DateTime.Now;
            subscriber.SubscriptionVerificationCode = null;
            subscriber.UnsubscribeVerificationCode = unsubsribeCode;

            this.Subscribers.Update(subscriber);

            var statIncr = new StatisticsIncrementer(this.Statistics);
            statIncr.IncrementSubscribers();

            return true;
        }               

        public void SendWelcomeEmail()
        {
            var subscriber = this.Subscribers.GetFirst(s => s.Email == this.currentSubscriberEmail);
            Emailer emailer = new Emailer(MailSettings.SensatoSettings);

            string verificationUrl = this.GenerateUnsubscribeUrl(subscriber.UnsubscribeVerificationCode);

            string body = verificationUrl;
            string subject = "Unsubcribe";

            emailer.SendEmail(body, subject, true, subscriber.Email);
        }

        public bool VerificateUnsubscribeCode(string code)
        {
            var subscriber = this.Subscribers.GetFirstOrNull(s => s.UnsubscribeVerificationCode == code && s.IsActive && !s.IsRemoved);

            if (subscriber == null)
                return false;

            subscriber.IsActive = false;
            subscriber.UnsubscribeDate = DateTime.Now;

            this.Subscribers.Update(subscriber);
            return true;
        }

        private string GenerateUnsubscribeUrl(string code)
        {
            string url = this.Lang == DisplayLanguage.BG
                ? "http://localhost:55555/verification/unsubscribe?code="
                : "http://localhost:55555/en/verification/unsubscribe?code=";

            string verificationUrl = url + HttpUtility.UrlEncode(code);

            return verificationUrl;
        }
    }
}