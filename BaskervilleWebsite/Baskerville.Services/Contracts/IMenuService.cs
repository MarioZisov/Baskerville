namespace Baskerville.Services.Contracts
{
    using Models.ViewModels.Public;

    public interface IMenuService : IMultilingual
    {
        MenuViewModel GetMenuModel();
    }
}
