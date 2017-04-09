using Baskerville.Data.Contracts.Repository;
using Baskerville.Data.Repository;
using Baskerville.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Services
{
    public class HomeService : Service
    {
        private IRepository<ProductCategory> categories;

        public HomeService(IDbContext context)
            : base(context)
        {
            this.categories = new Repository<ProductCategory>(context);
        }

        public ICollection<ProductCategory> GetPrimaryCategories()
        {
            var primaryCategories = this.categories
                .Find(c => c.IsPrimary)
                .Include("Products")
                .Include("Subcategories.Products")
                .ToList();

            return primaryCategories;
        }
    }
}
