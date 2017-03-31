using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Models.DataModels
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            this.Products = new HashSet<Product>();
            this.Subcategories = new HashSet<ProductCategory>();
        }

        public int Id { get; set; }

        public string NameBg { get; set; }

        public string NameEn { get; set; }

        public bool IsRemoved { get; set; }

        public bool IsPrimary { get; set; }

        public ICollection<Product> Products { get; set; }

        public ICollection<ProductCategory> Subcategories { get; set; }

        public int? PrimaryCategoryId { get; set; }

        public ProductCategory PrimaryCategory { get; set; }
    }
}
