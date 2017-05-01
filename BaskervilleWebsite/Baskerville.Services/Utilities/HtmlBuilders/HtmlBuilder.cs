namespace Baskerville.Services.Utilities.HtmlBuilders
{
    using System.Text;
    using System.Web;

    public abstract class HtmlBuilder
    {
        public HtmlBuilder()
        {
            this.Builder = new StringBuilder();
        }

        protected StringBuilder Builder { get; set; }

        protected HtmlString Html { get; set; }

        public abstract HtmlString Render();       
    }
}