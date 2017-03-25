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
        }

        public int Id { get; set; }

        public string NameBg { get; set; }

        public string NameEn { get; set; }

        public bool IsRemoved { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
