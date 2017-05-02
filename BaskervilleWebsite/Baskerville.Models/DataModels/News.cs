namespace Baskerville.Models.DataModels
{
    using Constants;
    using System.ComponentModel.DataAnnotations;

    public class News
    {
        public int Id { get; set; }

        [Required]
        [StringLength(
            maximumLength: AdminMessages.MaxTitleLength,
            MinimumLength = AdminMessages.MinTitleLength)]
        public string TitleBg { get; set; }

        [Required]
        [StringLength(
            maximumLength: AdminMessages.MaxTitleLength,
            MinimumLength = AdminMessages.MinTitleLength)]
        public string TitleEn { get; set; }

        [Required]
        [StringLength(
            maximumLength: AdminMessages.MaxNewsLength,
            MinimumLength = AdminMessages.MinNewsLength)]
        public string MessageBg { get; set; }

        [Required]
        [StringLength(
            maximumLength: AdminMessages.MaxNewsLength,
            MinimumLength = AdminMessages.MinNewsLength)]
        public string MessageEn { get; set; }

        [Required]
        [StringLength(
            maximumLength: AdminMessages.MaxFromLength,
            MinimumLength = AdminMessages.MinFromLength)]
        public string FromBg { get; set; }

        [Required]
        [StringLength(
            maximumLength: AdminMessages.MaxFromLength,
            MinimumLength = AdminMessages.MinFromLength)]
        public string FromEn { get; set; }

        public bool IsRemoved { get; set; }

        public bool IsPublic { get; set; }
    }
}
