namespace Baskerville.Services.Contracts
{
    using System.Collections.Generic;

    public interface IRegisterService
    {
        IEnumerable<string> GetRolesNames();

        void RegisterUserLog(string username);
    }
}
