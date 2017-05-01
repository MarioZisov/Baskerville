namespace Baskerville.Services.Contracts
{
    using Models.ViewModels;
    using System.Collections.Generic;
    using System.Net;

    public interface ISubscribersService
    {
        IEnumerable<SubscriberViewModel> GetActiveSubscribers();

        HttpStatusCode RemoveSubscriber(int id);

        void SendMessageToSubscribers(MessageViewModel model);
    }
}
