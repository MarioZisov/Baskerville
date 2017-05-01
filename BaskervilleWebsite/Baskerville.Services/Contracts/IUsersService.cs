namespace Baskerville.Services.Contracts
{
    using Models.ViewModels;
    using System.Collections.Generic;
    using System.Net;

    public interface IUsersService
    {
        UserViewModel GetUser(string id);

        void UpdateUserRole(UserViewModel model);

        HttpStatusCode DeleteUser(string id);

        IEnumerable<UserListViewModel> GetAllUsers();
    }
}
