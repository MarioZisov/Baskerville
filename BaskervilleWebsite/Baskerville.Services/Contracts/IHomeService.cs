namespace Baskerville.Services.Contracts
{
    using Models.ViewModels;
    using Models.ViewModels.Public;
    using System.Web.Mvc;

    public interface IHomeService
    {
        HomeViewModel GetHomeModel();

        void CheckEmailUnicness(SubscribeBindingModel model, ModelStateDictionary modelState);

        bool SendContactEmail(ContactBindingModel contactModel);

        void AddSubscriber(SubscribeBindingModel subscribeModel);
    }
}
