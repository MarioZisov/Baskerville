using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Models.DataTransferObjects
{
    public class SubscriberDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public DateTime SubscriptionDate { get; set; }
    }
}
