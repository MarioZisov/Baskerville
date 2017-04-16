using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baskerville.Data.Contracts.Repository;
using Baskerville.Models.DataModels;
using Baskerville.Data.Repository;
using Baskerville.Services.Utilities;

namespace Baskerville.Services
{
    public class VerificationService : Service
    {
        private IRepository<Subscriber> subscribers;

        public VerificationService(IDbContext context)
            : base(context)
        {
            this.subscribers = new Repository<Subscriber>(context);
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
            return true;
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
