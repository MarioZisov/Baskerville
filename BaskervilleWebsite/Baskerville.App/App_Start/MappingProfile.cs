using AutoMapper;
using Baskerville.Models.DataModels;
using Baskerville.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Baskerville.App.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {           
            this.CreateMap<Subscriber, SubscriberDto>();
        }
    }
}