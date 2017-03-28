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
    public class SubscribersService : Service
    {
        private IRepository<Subscriber> subscribers;

        public SubscribersService(IDbContext context)
            : base(context)
        {
            this.subscribers = new Repository<Subscriber>(context);
        }

        public IEnumerable<SubscriberViewModel> GetActiveSubscribers()
        {
            var subscribersViewModel = this.subscribers
                .Find(s => s.IsActive && !s.IsRemoved)
                .Select(Mapper.Map<Subscriber, SubscriberViewModel>)
                .ToList();

            return subscribersViewModel;
        }
    }
}
