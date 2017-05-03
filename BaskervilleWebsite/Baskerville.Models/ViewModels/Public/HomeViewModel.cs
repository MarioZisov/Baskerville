namespace Baskerville.Models.ViewModels.Public
{
    using System.Web;

    public class HomeViewModel
    {
        public SubscribeViewModelEn SubscribeModelEn { get; set; }

        public SubscribeViewModelBg SubscribeModelBg { get; set; }

        public ContactViewModelEn ContactModelEn { get; set; }

        public ContactViewModelBg ContactModelBg { get; set; }

        public HtmlString Promotions { get; set; }

        public HtmlString Events { get; set; }

        public HtmlString News { get; set; }
    }
}
