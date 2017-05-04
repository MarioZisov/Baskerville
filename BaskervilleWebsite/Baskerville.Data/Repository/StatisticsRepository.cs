namespace Baskerville.Data.Repository
{
    using Models.DataModels;
    using System.Linq;
    using Contracts.Repository;

    public class StatisticsRepositroy : Repository<Statistics>
    {
        public StatisticsRepositroy(IDbContext context)
            : base(context)
        {
        }

        public new Statistics GetById(object id)
        {
            return this.Entities.FirstOrDefault(s => s.Id == (int)id);
        }
    }
}
