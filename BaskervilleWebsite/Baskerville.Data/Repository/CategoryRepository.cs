namespace Baskerville.Data.Repository
{
    using Models.DataModels;
    using System.Linq;
    using Contracts.Repository;

    public class CategoryRepositroy : Repository<ProductCategory>
    {
        public CategoryRepositroy(IDbContext context)
            : base(context)
        {
        }

        public new ProductCategory GetById(object id)
        {
            return this.Entities.FirstOrDefault(s => s.Id == (int)id);
        }
    }
}
