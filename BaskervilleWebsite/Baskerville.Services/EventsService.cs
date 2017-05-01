namespace Baskerville.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Contracts.Repository;
    using Models.DataModels;
    using Data.Repository;
    using Models.ViewModels;
    using AutoMapper;
    using System.Net;
    using Contracts;

    public class EventsService : Service, IEventsService
    {
        private IRepository<Event> events;

        public EventsService(IDbContext context)
            : base(context)
        {
            this.events = new Repository<Event>(context);
        }

        public IEnumerable<EventViewModel> GetAllEvents()
        {
            var eventsViewModels = this.events
                .Find(e => !e.IsRemoved)
                .Select(Mapper.Map<Event, EventViewModel>);

            return eventsViewModels;
        }

        public EventViewModel GetEvent(int id)
        {
            var evnt = this.events.GetById(id);
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

            this.events.Insert(entity);
        }

        public void UpdateEvent(EventViewModel model)
        {
            var entity = this.events.GetById(model.Id);
            Mapper.Map(model, entity);

            this.events.Update(entity);
        }

        public void RemoveEvent(int id)
        {
            var entity = this.events.GetById(id);
            entity.IsRemoved = true;
            this.events.Update(entity);
        }

        public HttpStatusCode UpdatePublicity(int id)
        {
            var @event = this.events.GetById(id);
            if (@event == null)
                return HttpStatusCode.NotFound;

            @event.IsPublic = !@event.IsPublic;
            this.events.Update(@event);

            return HttpStatusCode.OK;
        }
    }
}
