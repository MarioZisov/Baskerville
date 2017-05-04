namespace Baskerville.Data.Repository
{
    using Models.DataModels;
    using System.Linq;
    using Contracts.Repository;

    public class PromotionRepositroy : Repository<Promotion>
    {
        public PromotionRepositroy(IDbContext context)
            : base(context)
        {
        }

        public new Promotion GetById(object id)
        {
            return this.Entities.FirstOrDefault(s => s.Id == (int)id);
        }
    }
}
