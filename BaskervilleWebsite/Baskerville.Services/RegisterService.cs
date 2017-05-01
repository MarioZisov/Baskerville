namespace Baskerville.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Contracts.Repository;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Data.Repository;
    using Models.DataModels;
    using Contracts;

    public class RegisterService : Service, IRegisterService
    {
        private IRepository<IdentityRole> roles;
        private IRepository<ApplicationUser> users;

        public RegisterService()
        {
            this.roles = new Repository<IdentityRole>(this.Context);
            this.users = new Repository<ApplicationUser>(this.Context);
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
