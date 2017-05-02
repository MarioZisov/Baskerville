namespace Baskerville.Models.ViewModels
{
    using Constants;
    using DataModels;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class ProductViewModel
    {       
        public ProductViewModel()
        {
            this.PrimaryCategories = new List<ProductCategory>();
            this.Subcategories = new List<SelectListItem>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [StringLength(
            maximumLength: AdminMessages.MaxProductNameLegnth,
            MinimumLength = AdminMessages.MinProductNameLegnth,
            ErrorMessage = AdminMessages.NameLenghtMessage)]
        [Display(Name = "Име (БГ)")]
        public string NameBg { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [StringLength(
            maximumLength: AdminMessages.MaxProductNameLegnth,
            MinimumLength = AdminMessages.MinProductNameLegnth,
            ErrorMessage = AdminMessages.NameLenghtMessage)]
        [Display(Name = "Име (АНГ)")]
        public string NameEn { get; set; }

        [Display(Name = "Описание (БГ)")]
        public string DescriptionBg { get; set; }

        [Display(Name = "Описание (АНГ)")]
        public string DescriptionEn { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [Display(Name = "Цена")]
        public double Price { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [Display(Name = "Категория")]
        public int PrimaryCategoryId { get; set; }

        [Display(Name = "Подкатегория")]
        public int? SubcategoryId { get; set; }

        [Display(Name = "Публично")]
        public bool IsPublic { get; set; }

        public IEnumerable<ProductCategory> PrimaryCategories { get; set; }

        public IEnumerable<SelectListItem> Subcategories { get; set; }
    }
}
