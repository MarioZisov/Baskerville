namespace Baskerville.Models.DataModels
{
    using Constants;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Event
    {
        public int Id { get; set; }

        [Required]
        [StringLength(
            maximumLength: AdminMessages.MaxEventNameLegnth, 
            MinimumLength = AdminMessages.MinEventNameLegnth)]
        public string NameBg { get; set; }

        [Required]
        [StringLength(
            maximumLength: AdminMessages.MaxEventNameLegnth,
            MinimumLength = AdminMessages.MinEventNameLegnth)]
        public string NameEn { get; set; }

        [Required]
        [StringLength(
            maximumLength: AdminMessages.MaxEventDescriptionLegnth, 
            MinimumLength = AdminMessages.MinEventDescriptionLegnth)]
        public string DescriptionBg { get; set; }

        [Required]
        [StringLength(
            maximumLength: AdminMessages.MaxEventDescriptionLegnth,
            MinimumLength = AdminMessages.MinEventDescriptionLegnth)]
        public string DescriptionEn { get; set; }

        public DateTime StartDate { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public bool IsRemoved { get; set; }

        public bool IsPublic { get; set; }
    }
}