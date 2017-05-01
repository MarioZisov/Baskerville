namespace Baskerville.Services.Contracts
{
    using Baskerville.Models.ViewModels;
    using System.Collections.Generic;

    public interface ISubscribersService
    {
        IEnumerable<SubscriberViewModel> GetActiveSubscribers();

        void RemoveSubscriber(int id);

        void SendMessageToSubscribers(MessageViewModel model);
    }
}
