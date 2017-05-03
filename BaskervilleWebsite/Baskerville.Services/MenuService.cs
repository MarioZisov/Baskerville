namespace Baskerville.Services
{
    using System.Linq;
    using Data.Contracts.Repository;
    using Models.DataModels;
    using Data.Repository;
    using System.Data.Entity;
    using Utilities.HtmlBuilders;
    using Models.ViewModels.Public;
    using Enums;
    using Contracts;

    public class MenuService : Service, IMenuService
    {
        private const DisplayLanguage DefaultLanguage = DisplayLanguage.BG;

        private IRepository<ProductCategory> categories;
        private IRepository<News> news;
        private HtmlBuilder htmlBuilder;
        
        public MenuService()
        {
            this.categories = new Repository<ProductCategory>(this.Context);
            this.news = new Repository<News>(this.Context);
            this.Lang = DefaultLanguage;
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