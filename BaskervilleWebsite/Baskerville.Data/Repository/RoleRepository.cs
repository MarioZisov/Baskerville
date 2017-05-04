namespace Baskerville.Data.Repository
{
    using System.Linq;
    using Contracts.Repository;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class RoleRepositroy : Repository<IdentityRole>
    {
        public RoleRepositroy(IDbContext context)
            : base(context)
        {
        }

        public new IdentityRole GetById(object id)
        {
            return this.Entities.FirstOrDefault(s => s.Id == (string)id);
        }
    }
}
