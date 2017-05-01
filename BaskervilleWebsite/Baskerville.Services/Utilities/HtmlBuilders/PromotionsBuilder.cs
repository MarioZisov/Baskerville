namespace Baskerville.Services.Utilities.HtmlBuilders
{
    using Models.DataModels;
    using Enums;
    using System.Collections.Generic;
    using System.Web;
    public class PromotionsBuilder : HtmlBuilder
    {
        //Representatation of promotion template
        //Place holders:
        //{0}: Promotion name.
        //{1}: Promotion description.
        private string promotionTemplate = "<strong class=\"title orange-accent\">{0}</strong><br> {1}<br><br>";

        private ICollection<Promotion> promotions;
        private DisplayLanguage lang;

        public PromotionsBuilder(ICollection<Promotion> promotions, DisplayLanguage language)
        {
            this.promotions = promotions;
            this.lang = language;
        }

        public override HtmlString Render()
        {
            this.GeneratePromotions();
            this.Html = new HtmlString(this.Builder.ToString());
            
            return this.Html;
        }

        private void GeneratePromotions()
        {
            foreach (var promotion in this.promotions)
            {
                string promoName = this.lang == DisplayLanguage.BG ? promotion.NameBg : promotion.NameEn;
                string promoDescription = this.lang == DisplayLanguage.BG ? promotion.DescriptionBg : promotion.DescriptionEn;

                this.Builder.AppendFormat(this.promotionTemplate, promoName, promoDescription);
            }
        }
    }
}