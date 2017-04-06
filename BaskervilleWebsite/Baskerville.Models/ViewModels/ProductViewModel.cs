using Baskerville.Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Baskerville.Models.ViewModels
{
    public class ProductViewModel
    {       
        public ProductViewModel()
        {
            this.PrimaryCategories = new List<ProductCategory>();
            this.Subcategories = new List<SelectListItem>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = Constants.RequiredFildMessage)]
        [StringLength(
            maximumLength: Constants.MaxProductNameLegnth
            , MinimumLength = Constants.MinProductNameLegnth
            , ErrorMessage = Constants.NameLenghtMessage)]
        [Display(Name = "Име (БГ)")]
        public string NameBg { get; set; }

        [Required(ErrorMessage = Constants.RequiredFildMessage)]
        [StringLength(
            maximumLength: Constants.MaxProductNameLegnth
            , MinimumLength = Constants.MinProductNameLegnth
            , ErrorMessage = Constants.NameLenghtMessage)]
        [Display(Name = "Име (АНГ)")]
        public string NameEn { get; set; }

        [Display(Name = "Описание (БГ)")]
        public string DescriptionBg { get; set; }

        [Display(Name = "Описание (АНГ)")]
        public string DescriptionEn { get; set; }

        [Required(ErrorMessage = Constants.RequiredFildMessage)]
        [Display(Name = "Количество")]
        public double Quantity { get; set; }

        [Required(ErrorMessage = Constants.RequiredFildMessage)]
        [Display(Name = "Цена")]
        public double Price { get; set; }

        [Required(ErrorMessage = Constants.RequiredFildMessage)]
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
