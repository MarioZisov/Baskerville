namespace Baskerville.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Contracts.Repository;
    using Models.DataModels;
    using Data.Repository;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.ViewModels;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity;
    using System.Net;
    using Contracts;

    public class UsersService : Service, IUsersService
    {
        private IRepository<ApplicationUser> users;
        private IRepository<IdentityRole> roles;
        private IRepository<IdentityUserRole> userRoles;
        private UserManager<ApplicationUser> userManager;

        public UsersService()
        {
            this.users = new Repository<ApplicationUser>(this.Context);
            this.roles = new Repository<IdentityRole>(this.Context);
            this.userRoles = new Repository<IdentityUserRole>(this.Context);
            this.userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>((DbContext)this.Context));

        }

        public UserViewModel GetUser(string id)
        {
            var user = this.users.GetById(id);
            if (user != null)
            {
                UserViewModel model = new UserViewModel();
                model.Id = user.Id;
                model.Username = user.UserName;
                model.RoleName = this.userManager.GetRoles(user.Id)[0];
                model.LastLogs = this.GetUserLogsById(user.Id, 10);
                model.Roles = this.roles.GetAll().ToList();

                return model;
            }
            else
                return null;
        }

        public void UpdateUserRole(UserViewModel model)
        {
            var oldRole = this.userManager.GetRoles(model.Id)[0];
            this.userManager.RemoveFromRole(model.Id, oldRole);
            this.userManager.AddToRole(model.Id, model.RoleName);
        }

        public HttpStatusCode DeleteUser(string id)
        {
            var user = this.users.GetById(id);
            if (user != null)
            {
                this.users.Delete(user);
                return HttpStatusCode.OK;
            }

            return HttpStatusCode.NotFound;
        }        

        public IEnumerable<UserListViewModel> GetAllUsers()
        {
            var usersList = users
                .GetAll()
                .Include("Logs")
                .ToList();

            List<UserListViewModel> model = new List<UserListViewModel>();

            foreach (var user in usersList)
            {
                model.Add(new UserListViewModel
                {
                    Id = user.Id,
                    Username = user.UserName,
                    RoleName = this.userManager.GetRoles(user.Id)[0],
                    LastLogDate = user.Logs.OrderByDescending(l => l.Date).First().Date
                });
            }

            return model;
        }

        private IEnumerable<DateTime> GetUserLogsById(string userId, int logsCount)
        {
            var user = this.users.GetAll().Include("Logs").First(u => u.Id == userId);
            var logs = user.Logs.Select(l => l.Date).OrderByDescending(l => l.Date).Take(logsCount);

            return logs;
        }
    }
}
