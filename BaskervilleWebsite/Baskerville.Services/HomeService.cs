using Baskerville.Data.Contracts.Repository;
using Baskerville.Data.Repository;
using Baskerville.Models.DataModels;
using Baskerville.Models.ViewModels;
using Baskerville.Services.Utilities.HtmlBuilders;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Baskerville.Services
{
    public class HomeService : Service
    {
        private IRepository<ProductCategory> categories;
        private IRepository<Promotion> promotions;
        private HtmlBuilder htmlBuilder;

        public HomeService(IDbContext context)
            : base(context)
        {
            this.categories = new Repository<ProductCategory>(context);
            this.promotions = new Repository<Promotion>(context);
        }

        public HtmlString GetMenuHtml(bool isLangBg)
        {

            var primaryCategories = this.categories
                .Find(c => c.IsPrimary && !c.IsRemoved)
                .Include("Products")
                .Include("Subcategories.Products")
                .ToList();

            this.htmlBuilder = new MenuBuilder(primaryCategories, isLangBg);
            var html = this.htmlBuilder.Render();

            return html;
        }

        public HomeViewModel GetHomeModel(bool isLangBg)
        {
            HomeViewModel model = new HomeViewModel();

            model.Promotions = this.GetPromotionsHtml(isLangBg);

            return model;
        }

        private HtmlString GetPromotionsHtml(bool isLangBg)
        {
            var promotions = this.promotions
                .Find(c => c.IsPublic && !c.IsRemoved)
                .ToList();

            HomeViewModel model = new HomeViewModel();

            this.htmlBuilder = new PromotionsBuilder(promotions, isLangBg);
            var html = this.htmlBuilder.Render();

            return html;
        }
    }
}