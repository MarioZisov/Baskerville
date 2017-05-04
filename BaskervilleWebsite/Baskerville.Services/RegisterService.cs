namespace Baskerville.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Contracts.Repository;
    using Models.DataModels;
    using Contracts;

    public class RegisterService : Service, IRegisterService
    {
        public RegisterService(IDbContext context)
            : base(context)
        {
        }

        public IEnumerable<string> GetRolesNames()
        {
            return this.Roles.GetAll().Select(r => r.Name).ToList();
            //Exclude creating administrators from register form.
            //return this.roles.Find(r => r.Name != "Admin").Select(r => r.Name).ToList();
        }

        public void RegisterUserLog(string username)
        {
            var user = this.Users.GetFirst(u => u.UserName == username);
            user.Logs.Add(new UserLog { Date = DateTime.Now });
            this.Users.Update(user);
        }
    }
}
