namespace Baskerville.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Contracts.Repository;
    using Models.DataModels;
    using Data.Repository;
    using Models.ViewModels;
    using AutoMapper;
    using System.Web.Mvc;
    using System.Data.Entity;
    using System.Net;
    using Contracts;

    public class ProductsService : Service, IProductService
    {
        private IRepository<Product> products;
        private IRepository<ProductCategory> categories;

        public ProductsService()
        {
            this.products = new Repository<Product>(this.Context);
            this.categories = new Repository<ProductCategory>(this.Context);
        }

        public ProductViewModel GetProduct(int id)
        {
            var product = this.products
                .GetAll()
                .Include("Category")
                .FirstOrDefault(p => !p.IsRemoved && p.Id == id);

            if (product == null)
                return null;

            var model = Mapper.Map<Product, ProductViewModel>(product);

            if (product.Category.IsPrimary)
                model.PrimaryCategoryId = (int)product.CategoryId;
            else
            {
                model.PrimaryCategoryId = (int)product.Category.PrimaryCategoryId;
                model.SubcategoryId = (int)product.CategoryId;
            }

            model.PrimaryCategories = this.GetPrimaryCategories();
            model.Subcategories = this.GetSubCategories((int)model.PrimaryCategoryId);

            return model;
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
            productViewModel.PrimaryCategories = this.GetPrimaryCategories();

            return productViewModel;
        }

        public void CreateProduct(ProductViewModel model)
        {
            var product = Mapper.Map<ProductViewModel, Product>(model);
            if (model.SubcategoryId != null)
                product.CategoryId = model.SubcategoryId;
            else
                product.CategoryId = model.PrimaryCategoryId;

            this.products.Insert(product);
        }

        public void RemoveProduct(int id)
        {
            var product = this.products.GetById(id);
            product.IsRemoved = true;
            this.products.Update(product);
        }

        public HttpStatusCode UpdatePublicity(int id)
        {
            var product = this.products.GetById(id);
            if (product == null)
                return HttpStatusCode.NotFound;

            product.IsPublic = !product.IsPublic;
            this.products.Update(product);

            return HttpStatusCode.OK;
        }

        public void UpdateProduct(ProductViewModel model)
        {
            var product = this.products.GetById(model.Id);
            Mapper.Map(model, product);
            if (model.SubcategoryId != null)
                product.CategoryId = model.SubcategoryId;
            else
                product.CategoryId = model.PrimaryCategoryId;

            this.products.Update(product);
        }        

        public IEnumerable<ProductCategory> GetPrimaryCategories()
        {
            return this.categories.Find(c => c.IsPrimary).ToList();
        }

        public IEnumerable<SelectListItem> GetSubCategories(int categoryId)
        {
            List<SelectListItem> selectedCategories = new List<SelectListItem>();
            IDictionary<string, string> categoriesDict = new Dictionary<string, string>();
            var subCategories = this.categories.Find(c => c.PrimaryCategoryId == categoryId);
            foreach (var subCategory in subCategories)
            {
                selectedCategories.Add(new SelectListItem() { Text = subCategory.NameBg, Value = subCategory.Id.ToString() });
            }

            return selectedCategories;
        }
    }
}
