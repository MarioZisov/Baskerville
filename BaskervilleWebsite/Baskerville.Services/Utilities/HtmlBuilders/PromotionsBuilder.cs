using Baskerville.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Baskerville.Services.Utilities.HtmlBuilders
{
    public class PromotionsBuilder : HtmlBuilder
    {
        //Representatation of promotion template
        //Place holders:
        //{0}: Promotion name.
        //{1}: Promotion description.
        private string promotionTemplate = "<strong class=\"title orange-accent\">{0}</strong><br> {1}<br><br>";

        private ICollection<Promotion> promotions;
        private bool isLangBg;

        public PromotionsBuilder(ICollection<Promotion> promotions, bool isLangBg)
        {
            this.promotions = promotions;
            this.isLangBg = isLangBg;
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
                string promoName = this.isLangBg ? promotion.NameBg : promotion.NameEn;
                string promoDescription = this.isLangBg ? promotion.DescriptionBg : promotion.DescriptionEn;

                this.Builder.AppendFormat(this.promotionTemplate, promoName, promoDescription);
            }
        }
    }
}