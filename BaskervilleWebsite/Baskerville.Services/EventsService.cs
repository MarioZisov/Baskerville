using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baskerville.Data.Contracts.Repository;
using Baskerville.Models.DataModels;
using Baskerville.Data.Repository;
using Baskerville.Models.ViewModels;
using AutoMapper;

namespace Baskerville.Services
{
    public class EventsService : Service
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
    }
}
