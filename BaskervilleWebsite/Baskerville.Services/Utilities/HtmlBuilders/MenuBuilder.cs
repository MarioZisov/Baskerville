namespace Baskerville.Services.Utilities.HtmlBuilders
{
    using Models.DataModels;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Text;
    using System.Text.RegularExpressions;

    public class MenuBuilder : HtmlBuilder
    {
        private const string ReplaceRegex = "[^a-zA-Z0-9]+";

        private const string CloseButtonBg = "Затвори";
        private const string CurrenyBg = "лв";

        private const string CloseButtonEn = "Close";
        private const string CurrenyEn = "BGN";

        //Representatation of menu template
        //Place holders:
        //{0}: Id of the main <div> element.
        //{1}: Id of the category image.
        //{2}: Category name.
        //{3}: Menu Items.
        //{4}: Close button language.       
        private string menuTemplate = "<div class=\"menu-modal modal fade\" id=\"{0}\" tabindex=\"-1\"><div class=\"modal-content\"><div style=\"padding-bottom: 4%\"><div class=\"close-modal\" data-dismiss=\"modal\"><div class=\"lr\"><div class=\"rl\"> </div></div></div></div><div class=\"row\"><div class=\"col-md-12\"><header id=\"{1}\"><h2 style=\"padding: 100px;\">{2}</h2></header></div></div><div class=\"container\"><div class=\"row\"><div class=\"col-lg-10 col-lg-offset-1\"><div class=\"modal-body\">{3}<button class=\"btn btn-primary\" data-dismiss=\"modal\" type=\"button\"><i class=\"fa fa-times\"></i> {4}</button></div></div></div></div></div></div>";
        private StringBuilder templatesBuilder;

        //Representatation of a menu category
        //Place holders:
        //{0}: Sub category name.
        //{1}: Left column elements.
        //{2}: Right column elements.
        private string menuCategory = "<div class=\"row\"><h2 class=\"text-left\">{0}</h2><div class=\"col-md-6 text-center\">{1}</div><div class=\"col-md-6 text-center\">{2}</div></div>";
        private StringBuilder categoriesBuilder;

        //Representatation of a menu item
        //Place holders:
        //{0}: Product name.
        //{1}: Product prize.
        //{2}: Currency - Language.
        //{3}: Product description.
        private string menuItem = "<h3>{0} <span class=\"dark-accent\">{1}{2}</span></h3><p class=\"text-muted\">{3}</p>";
        private StringBuilder leftItemsBuilder;
        private StringBuilder rightItemsBuilder;

        private bool isLangBg;
        private ICollection<ProductCategory> categories;

        public MenuBuilder(ICollection<ProductCategory> categories, bool isLangBg)
        {
            this.categories = categories;
            this.isLangBg = isLangBg;
            this.leftItemsBuilder = new StringBuilder();
            this.rightItemsBuilder = new StringBuilder();
            this.templatesBuilder = new StringBuilder();
            this.categoriesBuilder = new StringBuilder();
        }

        public override HtmlString Render()
        {
            this.CreateHtml();

            this.Html = new HtmlString(this.Builder.ToString());
            return this.Html;
        }

        private void CreateHtml()
        {
            foreach (var category in categories)
            {               
                if (category.Products.Any())
                {
                    this.GenerateProducts(category);
                    this.GenerateCategory(category);
                    this.GenerateMenuTemplate(category);
                    this.Builder.Append(this.templatesBuilder.ToString());
                }
                else
                {
                    foreach (var subCategory in category.Subcategories)
                    {
                        this.GenerateProducts(subCategory);
                        this.GenerateCategory(subCategory);

                        this.leftItemsBuilder.Clear();
                        this.rightItemsBuilder.Clear();
                    }

                    this.GenerateMenuTemplate(category);
                    this.Builder.Append(this.templatesBuilder.ToString());
                }

                this.leftItemsBuilder.Clear();
                this.rightItemsBuilder.Clear();
                this.templatesBuilder.Clear();
                this.categoriesBuilder.Clear();
            }
        }

        private void GenerateMenuTemplate(ProductCategory category)
        {
            string templateId = this.GenerateHtmlId(category.NameEn);
            string imageId = templateId;

            string categoryName = this.isLangBg ? category.NameBg : category.NameEn;
            string closeButton = this.isLangBg ? CloseButtonBg : CloseButtonEn;

            this.templatesBuilder.AppendFormat(
                this.menuTemplate, 
                templateId,
                imageId,
                categoryName, 
                this.categoriesBuilder.ToString(),
                closeButton);            
        }

        private void GenerateCategory(ProductCategory category)
        {
            string categoryName = this.isLangBg ? category.NameBg : category.NameEn;

            string subCategoryName = category.IsPrimary ? "" : categoryName;
            this.categoriesBuilder.AppendFormat(this.menuCategory, subCategoryName, this.leftItemsBuilder, this.rightItemsBuilder);
        }

        private void GenerateProducts(ProductCategory category)
        {
            int halfProductsCount = GetProductsHalf(category.Products.Count);
            int index = 0;

            foreach (var product in category.Products)
            {
                index++;

                string productName = this.isLangBg ? product.NameBg : product.NameEn;
                string description = this.isLangBg ? product.DescriptionBg : product.DescriptionEn;
                string currency = this.isLangBg ? CurrenyBg : CurrenyEn;

                if (index <= halfProductsCount)
                    this.leftItemsBuilder.AppendFormat(this.menuItem, productName, product.Price, currency, description);
                else
                    this.rightItemsBuilder.AppendFormat(this.menuItem, productName, product.Price, currency, description);
            }
        }

        private int GetProductsHalf(int totalCount)
        {
            int rightHalf = totalCount / 2;
            int leftHalf = totalCount - rightHalf;

            return leftHalf;
        }

        //Replace white spaces and special symbols with empty string.
        private string GenerateHtmlId(string nameEn)
        {
            string templateId = Regex.Replace(nameEn, ReplaceRegex, "");

            return templateId;
        }

        #region Menu Template - Wide View
        //<div class="menu-modal modal fade" id="{0}" tabindex="-1">
        //    <div class="modal-content">
        //        <!-- Close Modal Arrow -->
        //
        //    <div style="padding-bottom: 4%">
        //        <div class="close-modal" data-dismiss="modal">
        //            <div class="lr">
        //                <div class="rl"> </div>
        //            </div>
        //        </div>
        //    </div>
        //
        //    <div class="row">
        //        <div class="col-md-12">
        //            <header id="{1}">
        //                <h2 style="padding: 100px;">{2}</h2>
        //            </header>
        //        </div>
        //    </div>
        //	
        //        <!-- /.Close Modal Arrow -->
        //
        //        <div class="container">
        //            <div class="row">
        //                <div class="col-lg-10 col-lg-offset-1">
        //                    <!-- Modal Body -->
        //
        //                    <div class="modal-body">
        //                        <!-- Menu Details Follow Here -->
        //						  {3}
        //                        <!-- /.Menu Details End Here -->
        //                        <button class="btn btn-primary" data-dismiss="modal" type="button"><i class="fa fa-times"></i> {4}</button>
        //                    </div>
        //                    <!-- /.Modal Body -->
        //                </div>
        //            </div>
        //        </div>
        //        <!-- /.container -->
        //    </div>
        //    <!-- /.Modal Content -->
        //</div>

        #endregion

        #region Menu Category - Wide View
        //<div class="row">
        //    <h2 class="text-left">{0}</h2>
        //    <div class="col-md-6 text-left">
        //        {1}
        //    </div>
        //    <div class="col-md-6 text-left">
        //        {2}
        //    </div>
        //</div>

        #endregion

        #region Menu Item - Wide View
        //<h3>{0} <span class="dark-accent">{1}{2}</span></h3>							
        //<p class="text-muted">{3}</p>

        #endregion
    }
}