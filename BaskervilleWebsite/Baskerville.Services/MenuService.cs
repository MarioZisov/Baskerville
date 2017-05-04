namespace Baskerville.Services
{
    using System.Linq;
    using Data.Contracts.Repository;
    using System.Data.Entity;
    using Utilities.HtmlBuilders;
    using Models.ViewModels.Public;
    using Enums;
    using Contracts;

    public class MenuService : Service, IMenuService
    {
        private const DisplayLanguage DefaultLanguage = DisplayLanguage.BG;

        private HtmlBuilder htmlBuilder;

        public MenuService(IDbContext context)
            : base(context)
        {
            this.Lang = DefaultLanguage;
        }

        public DisplayLanguage Lang { get; set; }

        public MenuViewModel GetMenuModel()
        {
            var filteredCategories = this.Categoires
                .Find(c => c.IsPrimary && !c.IsRemoved)
                .Include("Products")
                .Include("Subcategories.Products")
                .ToList();

            this.htmlBuilder = new MenuBuilder(filteredCategories, this.Lang);
            var menuHtml = this.htmlBuilder.Render();

            var allActiveNews = this.News
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