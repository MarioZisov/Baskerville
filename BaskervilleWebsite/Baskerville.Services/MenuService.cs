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

namespace Baskerville.Services
{
    public class MenuService : Service
    {
        private IRepository<ProductCategory> categories;
        private HtmlBuilder htmlBuilder;

        public MenuService(IDbContext context)
            : base(context)
        {
            this.categories = new Repository<ProductCategory>(context);
        }

        public HtmlString GetMenuHtml(bool isLangBg)
        {
            var filteredCategories = this.categories
                .Find(c => c.IsPrimary && !c.IsRemoved)
                .Include("Products")
                .Include("Subcategories.Products")
                .ToList();

            this.htmlBuilder = new MenuBuilder(filteredCategories, isLangBg);
            var html = this.htmlBuilder.Render();

            return html;
        }
    }
}
