using System;
using System.ComponentModel.DataAnnotations;

namespace Baskerville.Models.ViewModels
{
    public class EventViewModel
    {
        private DateTime? startDate;

        public int Id { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Име (БГ)")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Името трябва да е между 5 и 50 символа")]
        public string NameBg { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Име (АНГ)")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Името трябва да е между 5 и 50 символа")]
        public string NameEn { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Описание (БГ)")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Описанието трябва да е между 5 и 500 символа")]
        public string DescriptionBg { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Описание (АНГ)")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Описанието трябва да е между 5 и 500 символа")]
        public string DescriptionEn { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Снимка (URL)")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
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