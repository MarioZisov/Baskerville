using Baskerville.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Models.DataModels
{
    public class Subscriber
    {
        public int Id { get; set; }
        
        public string Email { get; set; }

        public bool IsActive { get; set; }

        public Language PreferedLanguage { get; set; }

        public DateTime? SubscriptionPendingDate { get; set; }

        public DateTime? SubscriptionDate { get; set; }

        public DateTime? UnsubscribeDate { get; set; }

        public string SubscriptionVerificationCode { get; set; }

        public string UnsubscribeVerificationCode { get; set; }

        public bool IsRemoved { get; set; }
    }
}