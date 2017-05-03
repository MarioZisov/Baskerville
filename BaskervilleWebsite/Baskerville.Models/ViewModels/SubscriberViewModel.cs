namespace Baskerville.Models.ViewModels
{
    using Enums;
    using System;
    using System.ComponentModel.DataAnnotations;

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
