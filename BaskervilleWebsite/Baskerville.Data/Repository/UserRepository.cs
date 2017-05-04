namespace Baskerville.Data.Repository
{
    using Models.DataModels;
    using System.Linq;
    using Contracts.Repository;

    public class UserRepositroy : Repository<ApplicationUser>
    {
        public UserRepositroy(IDbContext context)
            : base(context)
        {
        }

        public new ApplicationUser GetById(object id)
        {
            return this.Entities.FirstOrDefault(s => s.Id == (string)id);
        }
    }
}
