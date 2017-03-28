using AutoMapper;
using Baskerville.Data;
using Baskerville.Data.Contracts.Repository;
using Baskerville.Data.Repository;
using Baskerville.Models.DataModels;
using Baskerville.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Routing;

namespace Baskerville.App.Controllers.WebApi
{
    public class SubscribersController : ApiController
    {
        private IDbContext context;
        private IRepository<Subscriber> subscribers;

        public SubscribersController()
        {
            this.context = new BaskervilleContext();
            this.subscribers = new Repository<Subscriber>(this.context);
        }

        [HttpGet]
        public IHttpActionResult GetSubscribers()
        {
            var subscribersDtos = this.subscribers
                .Find(s => s.IsActive && !s.IsRemoved)
                .Select(Mapper.Map<Subscriber, SubscriberDto>)
                .ToList();

            return this.Ok(subscribersDtos);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var subscriber = this.subscribers.GetById(id);
            if (subscriber == null)
                return this.NotFound();

            subscriber.IsRemoved = true;
            this.subscribers.Update(subscriber);

            return this.Ok();
        }
    }
}
