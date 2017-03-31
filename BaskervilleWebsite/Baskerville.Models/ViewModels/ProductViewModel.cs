using Baskerville.Models.DataModels;
using System;
using System.Collections.Generic;
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

        public string NameBg { get; set; }

        public string NameEn { get; set; }

        public string DescriptionBg { get; set; }

        public string DescriptionEn { get; set; }

        public double Quantity { get; set; }

        public double Price { get; set; }

        public int PrimaryCategoryId { get; set; }

        public int? SubcategoryId { get; set; }

        public bool IsPublic { get; set; }

        public IEnumerable<ProductCategory> PrimaryCategories { get; set; }

        public IEnumerable<SelectListItem> Subcategories { get; set; }
    }
}
