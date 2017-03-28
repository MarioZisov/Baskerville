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
        private IRepository<ProductCategory> categories;

        public ProductsService(IDbContext context)
            : base(context)
        {
            this.products = new Repository<Product>(context);
            this.categories = new Repository<ProductCategory>(context);
        }

        public ProductViewModel GetProduct(int id)
        {
            var product = this.products.GetFirstOrNull(p => !p.IsRemoved && p.Id == id);
            var productViewModel = Mapper.Map<Product, ProductViewModel>(product);
            productViewModel.Categories = this.GetAllCategories();

            return productViewModel;
        }

        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            var productViewModels = this.products
                .Find(p => !p.IsRemoved)
                .Select(Mapper.Map<Product, ProductViewModel>).ToList();

            return productViewModels;
        }

        public ProductViewModel GetEmptyProduct()
        {
            var productViewModel = new ProductViewModel();
            productViewModel.Categories = this.GetAllCategories();

            return productViewModel;
        }

        public void CreateProduct(ProductViewModel model)
        {
            var product = Mapper.Map<ProductViewModel, Product>(model);
            this.products.Insert(product);
        }

        public void RemoveProduct(int id)
        {
            var product = this.products.GetById(id);
            product.IsRemoved = true;
            this.products.Update(product);
        }

        public void UpdateProduct(ProductViewModel productViewModel)
        {
            var product = this.products.GetById(productViewModel.Id);
            Mapper.Map(productViewModel, product);

            this.products.Update(product);
        }

        public IEnumerable<ProductCategory> GetAllCategories()
        {
            return this.categories.GetAll().ToList();
        }
    }
}
