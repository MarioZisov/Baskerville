using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baskerville.Data.Contracts.Repository;
using Microsoft.AspNet.Identity.EntityFramework;
using Baskerville.Data.Repository;

namespace Baskerville.Services
{
    public class RegisterService : Service
    {
        private IRepository<IdentityRole> roles;

        public RegisterService(IDbContext context)
            : base(context)
        {
            this.roles = new Repository<IdentityRole>(this.Context);
        }

        public IEnumerable<string> GetRolesNames()
        {
            return this.roles.GetAll().Select(r => r.Name).ToList();
            //Exclude creating administrators from register form.
            //return this.roles.Find(r => r.Name != "Admin").Select(r => r.Name).ToList();
        }
    }
}
