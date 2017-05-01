namespace Baskerville.Services.Contracts
{
    using Models.DataModels;
    using Models.ViewModels;
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Mvc;

    public interface IProductService
    {
        ProductViewModel GetProduct(int id);

        IEnumerable<ProductViewModel> GetAllProducts();

        ProductViewModel GetEmptyProduct();

        void CreateProduct(ProductViewModel model);

        void RemoveProduct(int id);

        HttpStatusCode UpdatePublicity(int id);

        void UpdateProduct(ProductViewModel model);

        IEnumerable<ProductCategory> GetPrimaryCategories();

        IEnumerable<SelectListItem> GetSubCategories(int categoryId);
    }
}
