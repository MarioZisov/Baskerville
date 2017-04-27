using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baskerville.Data.Contracts.Repository;
using Baskerville.Models.DataModels;
using Baskerville.Data.Repository;
using System.Web;
using System.Data.Entity;
using Baskerville.Services.Utilities.HtmlBuilders;
using Baskerville.Models.ViewModels.Public;

namespace Baskerville.Services
{
    public class MenuService : Service
    {
        private IRepository<ProductCategory> categories;
        private IRepository<News> news;
        private HtmlBuilder htmlBuilder;

        public MenuService(IDbContext context)
            : base(context)
        {
            this.categories = new Repository<ProductCategory>(context);
            this.news = new Repository<News>(context);
        }

        public MenuViewModel GetMenuModel(bool isLangBg)
        {
            var filteredCategories = this.categories
                .Find(c => c.IsPrimary && !c.IsRemoved)
                .Include("Products")
                .Include("Subcategories.Products")
                .ToList();

            this.htmlBuilder = new MenuBuilder(filteredCategories, isLangBg);
            var menuHtml = this.htmlBuilder.Render();

            var allActiveNews = this.news
                .Find(n => n.IsPublic && !n.IsRemoved)
                .ToList();

            this.htmlBuilder = new NewsBuilder(allActiveNews, isLangBg);
            var newsHtml = this.htmlBuilder.Render();

            MenuViewModel model = new MenuViewModel
            {
                Menu = menuHtml,
                News = newsHtml
            };

            return model;
        }
    }
}
