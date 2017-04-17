using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baskerville.Data.Contracts.Repository;
using Baskerville.Models.DataModels;
using Baskerville.Data.Repository;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Baskerville.Models.ViewModels;
using System.Data.Entity;

namespace Baskerville.Services
{
    public class UsersService : Service
    {
        private IRepository<ApplicationUser> users;
        private IRepository<IdentityRole> roles;
        private IRepository<IdentityUserRole> userRoles;

        public UsersService(IDbContext context) 
            : base(context)
        {
            this.users = new Repository<ApplicationUser>(context);
            this.roles = new Repository<IdentityRole>(context);
            this.userRoles = new Repository<IdentityUserRole>(context);
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
                    RoleName = this.GetRoleNameByUserId(user.Id),
                    LastLogDate = user.Logs.OrderByDescending(l => l.Date).First().Date
                });
            }

            return model;         
        }

        private string GetRoleNameByUserId(string userId)
        {
            string roleId = this.userRoles.GetFirst(ur => ur.UserId == userId).RoleId;
            string roleName = this.roles.GetById(roleId).Name;

            return roleName;
        }
    }
}
