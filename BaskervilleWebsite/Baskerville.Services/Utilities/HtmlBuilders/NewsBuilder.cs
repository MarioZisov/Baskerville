namespace Baskerville.Services.Utilities.HtmlBuilders
{
    using Models.DataModels;
    using Enums;
    using System.Collections.Generic;
    using System.Web;

    public class NewsBuilder : HtmlBuilder
    {
        //Representatation of promotion template
        //Place holders:
        //{0}: News title.
        //{1}: News message.
        //{2}: From/Authors.
        private string NewsTemplate = "<div class=\"item\"><div class=\"row\"><div class=\"col-md-10 col-md-offset-1 col-sm-10 col-sm-offset-1  col-xs-10 col-xs-offset-1\"><h2>{0}</h2><p class=\"mrgn30-top-btm\">{1}</p><p class=\"orange-accent\">{2}</p></div></div></div>";

        private ICollection<News> news;
        private DisplayLanguage lang;

        public NewsBuilder(ICollection<News> news, DisplayLanguage language)
        {
            this.news = news;
            this.lang = language;
        }

        public override HtmlString Render()
        {
            this.GenerateNews();
            this.Html = new HtmlString(this.Builder.ToString());

            return this.Html;
        }

        private void GenerateNews()
        {
            foreach (var _news in this.news)
            {
                string title = this.lang == DisplayLanguage.BG ? _news.TitleBg : _news.TitleEn;
                string message = this.lang == DisplayLanguage.BG ? _news.MessageBg : _news.MessageEn;
                string from = this.lang == DisplayLanguage.BG ? _news.FromBg : _news.FromEn;

                this.Builder.AppendFormat(this.NewsTemplate, title, message, from);
            }
        }

        #region News Template - Expand View
        //<div class="item">
        //    <div class="row">
        //        <div class="col-md-10 col-md-offset-1 col-sm-10 col-sm-offset-1  col-xs-10 col-xs-offset-1">
        //            <h2>{0}</h2>
        //            <p class="mrgn30-top-btm">{1}</p>
        //            <p class="orange-accent">{2}</p>
        //        </div>
        //    </div>
        //</div>
        #endregion
    }
}