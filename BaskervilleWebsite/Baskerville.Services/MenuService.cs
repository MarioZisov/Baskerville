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
using Baskerville.Services.Enums;
using Baskerville.Services.Contracts;

namespace Baskerville.Services
{
    public class MenuService : Service, IMenuService
    {
        private IRepository<ProductCategory> categories;
        private IRepository<News> news;
        private HtmlBuilder htmlBuilder;
        
        public MenuService()
        {
            this.categories = new Repository<ProductCategory>(this.Context);
            this.news = new Repository<News>(this.Context);
            this.Lang = DisplayLanguage.BG;
        }

        public DisplayLanguage Lang { get; set; }

        public MenuViewModel GetMenuModel()
        {
            var filteredCategories = this.categories
                .Find(c => c.IsPrimary && !c.IsRemoved)
                .Include("Products")
                .Include("Subcategories.Products")
                .ToList();

            this.htmlBuilder = new MenuBuilder(filteredCategories, this.Lang);
            var menuHtml = this.htmlBuilder.Render();

            var allActiveNews = this.news
                .Find(n => n.IsPublic && !n.IsRemoved)
                .ToList();

            this.htmlBuilder = new NewsBuilder(allActiveNews, this.Lang);
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
