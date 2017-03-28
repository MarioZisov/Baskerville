using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baskerville.Data.Contracts.Repository;
using Baskerville.Models.DataModels;
using Baskerville.Data.Repository;
using Baskerville.Models.ViewModels;
using AutoMapper;

namespace Baskerville.Services
{
    public class ProductsService : Service
    {
        private IRepository<Product> products;

        public ProductsService(IDbContext context) 
            : base(context)
        {
            this.products = new Repository<Product>(context);
        }

        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            var productViewModels = this.products
                .GetAll()
                .Select(Mapper.Map<Product, ProductViewModel>).ToList();

            return productViewModels;
        }
    }
}
