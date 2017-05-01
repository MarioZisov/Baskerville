namespace Baskerville.Services.Contracts
{
    using Models.ViewModels;
    using System.Collections.Generic;
    using System.Net;

    public interface IEventsService
    {
        IEnumerable<EventViewModel> GetAllEvents();

        EventViewModel GetEvent(int id);

        EventViewModel GetEmptyEvent();

        void CreateEvent(EventViewModel model);

        void UpdateEvent(EventViewModel model);

        void RemoveEvent(int id);

        HttpStatusCode UpdatePublicity(int id);
    }
}
