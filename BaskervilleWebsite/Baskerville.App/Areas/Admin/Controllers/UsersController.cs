using Baskerville.Data;
using Baskerville.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Baskerville.App.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Owner")]
    public class UsersController : Controller
    {
        private UsersService service;

        public UsersController()
        {
            this.service = new UsersService(new BaskervilleContext());
        }

        // GET: Admin/Users
        public ActionResult Index()
        {
            var model = this.service.GetAllUsers();

            return View("UsersList", model);
        }
    }
}