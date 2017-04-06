using System;
using System.ComponentModel.DataAnnotations;

namespace Baskerville.Models.ViewModels
{
    public class EventViewModel
    {
        private DateTime? startDate;

        public int Id { get; set; }

        [Required(ErrorMessage = Constants.RequiredFildMessage)]
        [Display(Name = "Име (БГ)")]
        [StringLength(
            maximumLength: Constants.MaxEventNameLegnth
            , MinimumLength = Constants.MinEventNameLegnth
            , ErrorMessage = Constants.NameLenghtMessage)]
        public string NameBg { get; set; }

        [Required(ErrorMessage = Constants.RequiredFildMessage)]
        [Display(Name = "Име (АНГ)")]
        [StringLength(
            maximumLength: Constants.MaxEventNameLegnth
            , MinimumLength = Constants.MinEventNameLegnth
            , ErrorMessage = Constants.NameLenghtMessage)]
        public string NameEn { get; set; }

        [Required(ErrorMessage = Constants.RequiredFildMessage)]
        [Display(Name = "Описание (БГ)")]
        [StringLength(
            maximumLength: Constants.MaxEventDescriptionLegnth
            , MinimumLength = Constants.MinEventDescriptionLegnth
            , ErrorMessage = Constants.DescriptionLenghtMessage)]
        public string DescriptionBg { get; set; }

        [Required(ErrorMessage = Constants.RequiredFildMessage)]
        [Display(Name = "Описание (АНГ)")]
        [StringLength(
            maximumLength: Constants.MaxEventNameLegnth
            , MinimumLength = Constants.MinEventNameLegnth
            , ErrorMessage = Constants.DescriptionLenghtMessage)]
        public string DescriptionEn { get; set; }

        [Required(ErrorMessage = Constants.RequiredFildMessage)]
        [Display(Name = "Снимка (URL)")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = Constants.RequiredFildMessage)]
        [Display(Name = "Начало")]
        public DateTime? StartDate
        {
            get { return this.startDate ?? DateTime.Now; }
            set { this.startDate = value; }
        }

        [Display(Name = "Публично")]
        public bool IsPublic { get; set; }
    }
}