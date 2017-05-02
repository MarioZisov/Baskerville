using System.Web.Mvc;

namespace Baskerville.App.Areas.English
{
    public class EnglishAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "English";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "English_default",
                "en/{controller}/{action}/{id}",
                new { controller = "home", action = "index", id = UrlParameter.Optional },
                namespaces: new[] { "Baskerville.App.Areas.English.Controllers" }
            );
        }
    }
}