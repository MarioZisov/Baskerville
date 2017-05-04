namespace Baskerville.Data.Repository
{
    using Models.DataModels;
    using System.Linq;
    using Contracts.Repository;

    public class EventRepositroy : Repository<Event>
    {
        public EventRepositroy(IDbContext context)
            : base(context)
        {
        }

        public new Event GetById(object id)
        {
            return this.Entities.FirstOrDefault(s => s.Id == (int)id);
        }
    }
}
