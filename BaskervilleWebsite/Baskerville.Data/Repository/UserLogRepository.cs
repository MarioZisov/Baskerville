namespace Baskerville.Data.Repository
{
    using Models.DataModels;
    using System.Linq;
    using Contracts.Repository;

    public class UserLogRepositroy : Repository<UserLog>
    {
        public UserLogRepositroy(IDbContext context)
            : base(context)
        {
        }

        public new UserLog GetById(object id)
        {
            return this.Entities.FirstOrDefault(s => s.Id == (int)id);
        }
    }
}
