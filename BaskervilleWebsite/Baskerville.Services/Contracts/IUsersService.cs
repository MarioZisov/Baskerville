namespace Baskerville.Services.Contracts
{
    using Baskerville.Models.ViewModels;
    using System.Collections.Generic;

    public interface IUsersService
    {
        UserViewModel GetUser(string id);

        void UpdateUserRole(UserViewModel model);

        bool DeleteUser(string id);

        IEnumerable<UserListViewModel> GetAllUsers();
    }
}
