using Baskerville.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Models.ViewModels
{
    public class SubscriberViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Имейл")]
        public string Email { get; set; }

        public Language PreferedLanguage { get; set; }

        [Display(Name = "Дата на абониране")]
        public DateTime SubscriptionDate { get; set; }
    }
}
