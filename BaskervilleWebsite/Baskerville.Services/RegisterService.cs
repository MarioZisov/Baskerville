namespace Baskerville.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Contracts.Repository;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Data.Repository;
    using Models.DataModels;

    public class RegisterService : Service
    {
        private IRepository<IdentityRole> roles;
        private IRepository<ApplicationUser> users;

        public RegisterService(IDbContext context)
            : base(context)
        {
            this.roles = new Repository<IdentityRole>(context);
            this.users = new Repository<ApplicationUser>(context);
        }

        public IEnumerable<string> GetRolesNames()
        {
            return this.roles.GetAll().Select(r => r.Name).ToList();
            //Exclude creating administrators from register form.
            //return this.roles.Find(r => r.Name != "Admin").Select(r => r.Name).ToList();
        }

        public void RegisterUserLog(string username)
        {
            var user = this.users.GetFirst(u => u.UserName == username);
            user.Logs.Add(new UserLog { Date = DateTime.Now });
            this.users.Update(user);
        }
    }
}
