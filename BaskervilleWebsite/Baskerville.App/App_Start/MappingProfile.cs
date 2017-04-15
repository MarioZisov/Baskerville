using AutoMapper;
using Baskerville.Models.DataModels;
using Baskerville.Models.DataTransferObjects;
using Baskerville.Models.ViewModels.Public;
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

            this.CreateMap<ContactBindingModel, ContactViewModelEn>();
            this.CreateMap<ContactBindingModel, ContactViewModelBg>();

            this.CreateMap<SubscribeBindingModel, SubscribeViewModelEn>();
            this.CreateMap<SubscribeBindingModel, SubscribeViewModelBg>();
        }
    }
}