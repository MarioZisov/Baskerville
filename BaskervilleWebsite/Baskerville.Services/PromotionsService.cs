using System.Collections.Generic;
using System.Linq;
using Baskerville.Data.Contracts.Repository;
using Baskerville.Models.DataModels;
using Baskerville.Data.Repository;
using Baskerville.Models.ViewModels;
using AutoMapper;
using System;
using System.Net;

namespace Baskerville.Services
{
    public class PromotionsService : Service
    {
        private IRepository<Promotion> promotions;

        public PromotionsService(IDbContext context)
            : base(context)
        {
            this.promotions = new Repository<Promotion>(context);
        }

        public IEnumerable<PromotionViewModel> GetAllPromotions()
        {
            var model = this.promotions
                .Find(e => !e.IsRemoved)
                .Select(Mapper.Map<Promotion, PromotionViewModel>);

            return model;
        }

        public PromotionViewModel GetPromotion(int id)
        {
            var entity = this.promotions.GetById(id);
            if (entity == null)
                return null;

            var PromotionViewModel = Mapper.Map<Promotion, PromotionViewModel>(entity);

            return PromotionViewModel;
        }

        public PromotionViewModel GetEmptyPromotion()
        {
            var model = new PromotionViewModel();

            return model;
        }

        public void CreatePromotion(PromotionViewModel model)
        {
            var entity = Mapper.Map<PromotionViewModel, Promotion>(model);

            this.promotions.Insert(entity);
        }

        public void UpdatePromotion(PromotionViewModel model)
        {
            var entity = this.promotions.GetById(model.Id);
            Mapper.Map(model, entity);

            this.promotions.Update(entity);
        }

        public void RemovePromotion(int id)
        {
            var entity = this.promotions.GetById(id);
            entity.IsRemoved = true;
            this.promotions.Update(entity);
        }

        public HttpStatusCode UpdatePublicity(int id)
        {
            var promo = this.promotions.GetById(id);
            if (promo == null)
                return HttpStatusCode.NotFound;

            promo.IsPublic = !promo.IsPublic;
            this.promotions.Update(promo);

            return HttpStatusCode.OK;
        }
    }
}
