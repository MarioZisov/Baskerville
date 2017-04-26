using Baskerville.Models.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace Baskerville.Models.ViewModels
{
    public class EventViewModel
    {
        private DateTime? startDate;

        public int Id { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [Display(Name = "Име (БГ)")]
        [StringLength(
            maximumLength: AdminMessages.MaxEventNameLegnth
            , MinimumLength = AdminMessages.MinEventNameLegnth
            , ErrorMessage = AdminMessages.NameLenghtMessage)]
        public string NameBg { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [Display(Name = "Име (АНГ)")]
        [StringLength(
            maximumLength: AdminMessages.MaxEventNameLegnth
            , MinimumLength = AdminMessages.MinEventNameLegnth
            , ErrorMessage = AdminMessages.NameLenghtMessage)]
        public string NameEn { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [Display(Name = "Описание (БГ)")]
        [StringLength(
            maximumLength: AdminMessages.MaxEventDescriptionLegnth
            , MinimumLength = AdminMessages.MinEventDescriptionLegnth
            , ErrorMessage = AdminMessages.DescriptionLenghtMessage)]
        public string DescriptionBg { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [Display(Name = "Описание (АНГ)")]
        [StringLength(
            maximumLength: AdminMessages.MaxEventDescriptionLegnth
            , MinimumLength = AdminMessages.MinEventDescriptionLegnth
            , ErrorMessage = AdminMessages.DescriptionLenghtMessage)]
        public string DescriptionEn { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [Display(Name = "Снимка (URL)")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
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