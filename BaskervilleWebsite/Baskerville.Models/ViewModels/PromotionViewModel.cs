namespace Baskerville.Models.ViewModels
{
    using Constants;
    using System.ComponentModel.DataAnnotations;

    public class PromotionViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [StringLength(
            maximumLength: AdminMessages.MaxPromotionNameLength,
            MinimumLength = AdminMessages.MinPromotionNameLength,
            ErrorMessage = AdminMessages.NameLenghtMessage)]
        [Display(Name = "Име (бг)")]
        public string NameBg { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [StringLength(
            maximumLength: AdminMessages.MaxPromotionNameLength,
            MinimumLength = AdminMessages.MinPromotionNameLength,
            ErrorMessage = AdminMessages.NameLenghtMessage)]
        [Display(Name = "Име (анг)")]
        public string NameEn { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [StringLength(
            maximumLength: AdminMessages.MaxPromotionDescriptionLength,
            MinimumLength = AdminMessages.MinPromotionDescriptionLength,
            ErrorMessage = AdminMessages.DescriptionLenghtMessage)]
        [Display(Name = "Описание (бг)")]
        public string DescriptionBg { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [StringLength(
            maximumLength: AdminMessages.MaxPromotionDescriptionLength,
            MinimumLength = AdminMessages.MinPromotionDescriptionLength,
            ErrorMessage = AdminMessages.DescriptionLenghtMessage)]
        [Display(Name = "Описание (анг)")]
        public string DescriptionEn { get; set; }

        [Display(Name = "Публично")]
        public bool IsPublic { get; set; }
    }
}
