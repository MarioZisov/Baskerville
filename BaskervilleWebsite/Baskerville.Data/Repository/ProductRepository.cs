namespace Baskerville.Data.Repository
{
    using Models.DataModels;
    using System.Linq;
    using Contracts.Repository;

    public class ProductRepositroy : Repository<Product>
    {
        public ProductRepositroy(IDbContext context)
            : base(context)
        {
        }

        public new Product GetById(object id)
        {
            return this.Entities.FirstOrDefault(s => s.Id == (int)id);
        }
    }
}
