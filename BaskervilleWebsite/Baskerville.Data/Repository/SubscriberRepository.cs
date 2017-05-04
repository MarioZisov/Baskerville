namespace Baskerville.Data.Repository
{
    using Models.DataModels;
    using System.Linq;
    using Contracts.Repository;

    public class SubscriberRepository : Repository<Subscriber>
    {
        public SubscriberRepository(IDbContext context)
            : base(context)
        {
        }

        public new Subscriber GetById(object id)
        {
            return this.Entities.FirstOrDefault(s => s.Id == (int)id);
        }
    }
}
