namespace Baskerville.Models.DataModels
{
    using Constants;
    using System.ComponentModel.DataAnnotations;

    public class Promotion
    {
        public int Id { get; set; }

        [Required]
        [StringLength(
            maximumLength: AdminMessages.MaxPromotionNameLength,
            MinimumLength = AdminMessages.MinPromotionNameLength)]
        public string NameBg { get; set; }

        [Required]
        [StringLength(
            maximumLength: AdminMessages.MaxPromotionNameLength,
            MinimumLength = AdminMessages.MinPromotionNameLength)]
        public string NameEn { get; set; }

        [Required]
        [StringLength(
            maximumLength: AdminMessages.MaxPromotionDescriptionLength,
            MinimumLength = AdminMessages.MinPromotionDescriptionLength)]
        public string DescriptionBg { get; set; }

        [Required]
        [StringLength(
            maximumLength: AdminMessages.MaxPromotionDescriptionLength,
            MinimumLength = AdminMessages.MinPromotionDescriptionLength)]
        public string DescriptionEn { get; set; }

        public bool IsRemoved { get; set; }

        public bool IsPublic { get; set; }
    }
}
