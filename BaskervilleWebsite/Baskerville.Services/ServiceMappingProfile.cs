using AutoMapper;
using Baskerville.Models.DataModels;
using Baskerville.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Services
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            this.CreateMap<Subscriber, SubscriberViewModel>();
            this.CreateMap<Product, ProductViewModel>();
        }
    }
}
