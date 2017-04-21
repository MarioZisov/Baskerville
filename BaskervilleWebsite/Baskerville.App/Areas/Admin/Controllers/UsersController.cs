using Baskerville.Data;
using Baskerville.Models.DataModels;
using Baskerville.Models.ViewModels.Public;
using Baskerville.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Baskerville.App.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Owner")]
    public class UsersController : Controller
    {
        private UsersService service;

        public UsersController()
        {
            var context = new BaskervilleContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            this.service = new UsersService(context, userManager);
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = this.service.GetAllUsers();

            return View("UsersList", model);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            UserViewModel model = this.service.GetUser(id);
            if (model == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(UserViewModel model)
        {
            if (!this.ModelState.IsValid)
                return View("Details", model);

            this.service.UpdateUserRole(model);
            return View("UsersList", model);
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            var result = this.service.DeleteUser(id);
            if (result)
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            else
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }
    }
}