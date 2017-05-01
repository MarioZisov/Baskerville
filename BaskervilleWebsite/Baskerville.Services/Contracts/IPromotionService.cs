namespace Baskerville.Services.Contracts
{
    using Models.ViewModels;
    using System.Collections.Generic;
    using System.Net;

    public interface IPromotionService
    {
        IEnumerable<PromotionViewModel> GetAllPromotions();

        PromotionViewModel GetPromotion(int id);

        PromotionViewModel GetEmptyPromotion();

        void CreatePromotion(PromotionViewModel model);

        void UpdatePromotion(PromotionViewModel model);

        void RemovePromotion(int id);

        HttpStatusCode UpdatePublicity(int id);
    }
}
