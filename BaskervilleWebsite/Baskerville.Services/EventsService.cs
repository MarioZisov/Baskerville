namespace Baskerville.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Contracts.Repository;
    using Models.DataModels;
    using Models.ViewModels;
    using AutoMapper;
    using System.Net;
    using Contracts;

    public class EventsService : Service, IEventsService
    {
        public EventsService(IDbContext context)
            : base(context)
        {
        }

        public IEnumerable<EventViewModel> GetAllEvents()
        {
            var eventsViewModels = this.Events
                .Find(e => !e.IsRemoved)
                .Select(Mapper.Map<Event, EventViewModel>);

            return eventsViewModels;
        }

        public EventViewModel GetEvent(int id)
        {
            var evnt = this.Events.GetById(id);
            if (evnt == null)
                return null;

            var eventViewModel = Mapper.Map<Event, EventViewModel>(evnt);

            return eventViewModel;
        }

        public EventViewModel GetEmptyEvent()
        {
            var eventViewModel = new EventViewModel();

            return eventViewModel;
        }

        public void CreateEvent(EventViewModel model)
        {
            var entity = Mapper.Map<EventViewModel, Event>(model);

            this.Events.Insert(entity);
        }

        public void UpdateEvent(EventViewModel model)
        {
            var entity = this.Events.GetById(model.Id);
            Mapper.Map(model, entity);

            this.Events.Update(entity);
        }

        public void RemoveEvent(int id)
        {
            var entity = this.Events.GetById(id);
            entity.IsRemoved = true;
            this.Events.Update(entity);
        }

        public HttpStatusCode UpdatePublicity(int id)
        {
            var @event = this.Events.GetById(id);
            if (@event == null)
                return HttpStatusCode.NotFound;

            @event.IsPublic = !@event.IsPublic;
            this.Events.Update(@event);

            return HttpStatusCode.OK;
        }
    }
}
