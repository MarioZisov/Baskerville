namespace Baskerville.Data.Repository
{
    using Models.DataModels;
    using System.Linq;
    using Contracts.Repository;

    public class NewsRepositroy : Repository<News>
    {
        public NewsRepositroy(IDbContext context)
            : base(context)
        {
        }

        public new News GetById(object id)
        {
            return this.Entities.FirstOrDefault(s => s.Id == (int)id);
        }
    }
}
