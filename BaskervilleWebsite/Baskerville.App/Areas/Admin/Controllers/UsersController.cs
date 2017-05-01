namespace Baskerville.App.Areas.Admin.Controllers
{
    using Models.ViewModels;
    using Services.Contracts;
    using System.Net;
    using System.Web.Mvc;

    [Authorize(Roles = "Admin,Owner")]
    public class UsersController : AuthorizedController
    {
        private IUsersService service;

        public UsersController(IUsersService service)
        {
            this.service = service;
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
            var status = this.service.DeleteUser(id);

            return new HttpStatusCodeResult(status);
        }
    }
}