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

    public class PromotionsService : Service, IPromotionService
    {
        public PromotionsService(IDbContext context)
            : base(context)
        {
        }

        public IEnumerable<PromotionViewModel> GetAllPromotions()
        {
            var model = this.Promotions
                .Find(e => !e.IsRemoved)
                .Select(Mapper.Map<Promotion, PromotionViewModel>);

            return model;
        }

        public PromotionViewModel GetPromotion(int id)
        {
            var entity = this.Promotions.GetById(id);
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

            this.Promotions.Insert(entity);
        }

        public void UpdatePromotion(PromotionViewModel model)
        {
            var entity = this.Promotions.GetById(model.Id);
            Mapper.Map(model, entity);

            this.Promotions.Update(entity);
        }

        public void RemovePromotion(int id)
        {
            var entity = this.Promotions.GetById(id);
            entity.IsRemoved = true;
            this.Promotions.Update(entity);
        }

        public HttpStatusCode UpdatePublicity(int id)
        {
            var promo = this.Promotions.GetById(id);
            if (promo == null)
                return HttpStatusCode.NotFound;

            promo.IsPublic = !promo.IsPublic;
            this.Promotions.Update(promo);

            return HttpStatusCode.OK;
        }
    }
}
