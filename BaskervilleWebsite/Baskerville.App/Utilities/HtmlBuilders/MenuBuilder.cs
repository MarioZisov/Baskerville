using Baskerville.App.Utilities.HtmlBuilders.Contracts;
using Baskerville.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace Baskerville.App.Utilities.HtmlBuilders
{
    public class MenuBuilder : HtmlBuilder
    {
        private const string CloseButtonBg = "Затвори";
        private const string CurrenyBg = "лв";

        private const string CloseButtonEn = "Close";
        private const string CurrenyEn = "BGN";        

        //Representatation of menu template
        //Place holders:
        //{0}: Id of the main <div> element.
        //{1}: Category name.
        //{2}: Short description for the category.
        //{3}: Alternative image text.
        //{4}: Image source.
        //{5}: menuItemsArrangement + menuItems
        private string menuTemplate = "<div class=\"menu-modal modal fade\" id=\"{0}\" tabindex=\"-1\"><div class=\"modal-content\"><div class=\"close-modal\" data-dismiss=\"modal\"><div class=\"lr\"><div class=\"rl\"> </div></div></div><div class=\"container\"><div class=\"row\"><div class=\"col-lg-10 col-lg-offset-1\"><div class=\"modal-body\"><h2>{1}</h2><p class=\"item-intro text-muted\">{2}</p><img alt=\"{3}\" src=\"{4}\">{5}<button class=\"btn btn-primary\" data-dismiss=\"modal\" type=\"button\"><i class=\"fa fa-times\"></i> Close</button></div></div></div></div></div></div>";
        private StringBuilder templatesBuilder;

        //Representatation of a menu category
        //Place holders:
        //{0}: Sub category name.
        //{1}: Left column elements.
        //{2}: Right column elements.
        private string menuCategory = "<div class=\"row\"><h2 class=\"text-left\">{0}</h2><div class=\"col-md-6 text-left\">{1}</div><div class=\"col-md-6 text-left\">{2}</div></div>";
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
        private string imageSource;
        private ICollection<ProductCategory> categories;

        public MenuBuilder(ICollection<ProductCategory> categories, string imageSource, bool isLangBg)
            : base()
        {
            this.categories = categories;
            this.imageSource = imageSource;
            this.isLangBg = isLangBg;
            this.leftItemsBuilder = new StringBuilder();
            this.rightItemsBuilder = new StringBuilder();
            this.templatesBuilder = new StringBuilder();
            this.categoriesBuilder = new StringBuilder();
        }

        public override string Render()
        {
            this.CreateHtml();

            return this.Builder.ToString();
        }

        private void CreateHtml()
        {
            foreach (var category in categories)
            {               
                if (category.Products.Any())
                {
                    this.GenerateProducts(category);
                    this.GenerateSingleCategory(category);
                    this.GenerateMenuTemplate(category);
                    this.Builder.Append(this.templatesBuilder.ToString());
                }
                else
                {
                    foreach (var subCategory in category.Subcategories)
                    {
                        this.GenerateProducts(subCategory);
                        this.GenerateSingleCategory(subCategory);

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
            string templateId = this.GenerateTemplateId(category.NameEn);
                        
            this.templatesBuilder.AppendFormat(
                this.menuTemplate, 
                templateId, 
                category.NameBg, 
                "Short description goes here.", 
                templateId, 
                this.imageSource, 
                this.categoriesBuilder.ToString());            
        }

        private void GenerateSingleCategory(ProductCategory category)
        {
            string subCategoryName = category.IsPrimary ? "" : category.NameBg;
            this.categoriesBuilder.AppendFormat(this.menuCategory, subCategoryName, this.leftItemsBuilder, this.rightItemsBuilder);
        }

        private void GenerateMultiCategories(ProductCategory category)
        {
            throw new NotImplementedException();
        }

        private void GenerateProducts(ProductCategory category)
        {
            int halfProductsCount = GetProductsHalf(category.Products.Count);
            int index = 0;

            foreach (var product in category.Products)
            {
                index++;
                if (index <= halfProductsCount)
                    this.leftItemsBuilder.AppendFormat(this.menuItem, product.NameBg, product.Price, CurrenyBg, product.DescriptionBg);
                else
                    this.rightItemsBuilder.AppendFormat(this.menuItem, product.NameBg, product.Price, CurrenyBg, product.DescriptionBg);
            }
        }

        private int GetProductsHalf(int totalCount)
        {
            int rightHalf = totalCount / 2;
            int leftHalf = totalCount - rightHalf;

            return leftHalf;
        }

        //Generates given string to camel case
        private string GenerateTemplateId(string nameEn)
        {
            StringBuilder templateId = new StringBuilder();
            var words = nameEn.Split(' ');
            templateId.Append(words[0].ToLower());
            for (int i = 1; i < words.Length; i++)
            {
                templateId.Append(words[i][0].ToString().ToUpper());
                templateId.Append(words[i].Remove(0, 1));
            }

            return templateId.ToString();
        }

        #region Menu Template - Wide View
        //<div class="menu-modal modal fade" id="{0}" tabindex="-1">
        //    <div class="modal-content">
        //        <!-- Close Modal Arrow -->
        //
        //        <div class="close-modal" data-dismiss="modal">
        //            <div class="lr">
        //                <div class="rl"> </div>
        //            </div>
        //        </div>
        //        <!-- /.Close Modal Arrow -->
        //
        //        <div class="container">
        //            <div class="row">
        //                <div class="col-lg-10 col-lg-offset-1">
        //                    <!-- Modal Body -->
        //
        //                    <div class="modal-body">
        //                        <!-- Menu Details Follow Here -->
        //
        //                        <h2>{1}</h2>
        //                        <p class="item-intro text-muted">{2}</p>
        //                        <img alt="{3}" src="{4}"> {5}
        //                        <!-- /.Menu Details End Here -->
        //                        <button class="btn btn-primary" data-dismiss="modal" type="button"><i class="fa fa-times"></i> Close</button>
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