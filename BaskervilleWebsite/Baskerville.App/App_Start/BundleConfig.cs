using System.Web;
using System.Web.Optimization;

namespace Baskerville.App
{
    public class BundleConfig
    {       
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootbox.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/datatables/jquery.datatables.js",
                      "~/Scripts/datatables/datatables.bootstrap.js",
                      "~/Scripts/moment-with-locales.js",
                      "~/Scripts/bootstrap-datetimepicker.js",
                      "~/Scripts/Custom/datetimepicker-pick-date.js",
                      "~/Scripts/Custom/charts-loader-min.js"));

            //Online charts charts-loader-min.js https://www.gstatic.com/charts/loader.js

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-paper.css",
                      "~/Content/datatables/css/datatables.bootstrap.css",
                      "~/Content/bootstrap-datetimepicker.css",                
                      "~/Content/site.css"));

            //CUSTOMS
            bundles.Add(new StyleBundle("~/bundles/custom-styles").Include(
                        "~/CustomContent/css/bootstrap.min.css",
                        "~/CustomContent/css/full-spoon.css",
                        "~/CustomContent/animate-css/animate.css",
                        "~/CustomContent/owl-carousel/owl.carousel.css",
                        "~/CustomContent/owl-carousel/owl.theme.css"));

            bundles.Add(new StyleBundle("~/bundles/fonts").Include(
                        "~/CustomContent/font-awesome/css/font-awesome.min.css",
                        "~/CustomContent/fonts/catamaran.css",
                        "~/CustomContent/fonts/amatic.css",
                        "~/CustomContent/fonts/alice.css",
                        "~/CustomContent/owl-carousel/owl.theme.css"));

            //Online Google fonts
            //https://fonts.googleapis.com/css?family=Catamaran:400,600,300,700
            //http://fonts.googleapis.com/css?family=Amatic+SC:400,700
            //https://fonts.googleapis.com/css?family=Alice

            bundles.Add(new ScriptBundle("~/bundles/custom-jquery").Include(
                     "~/CustomContent/js/jquery.js"));


            bundles.Add(new ScriptBundle("~/bundles/custom-bootstrap").Include(
                      "~/CustomContent/js/bootstrap.min.js",
                      "~/CustomContent/js/isotope.pkgd.min.js",
                      "~/CustomContent/magnific-popup/jquery.magnific-popup.min.js",
                      "~/CustomContent/js/jquery.easing.min.js",
                      "~/CustomContent/js/classie.js",
                      "~/CustomContent/js/cbpAnimatedHeader.min.js",
                      "~/CustomContent/js/wow.min.js",
                      "~/CustomContent/owl-carousel/owl.carousel.js",
                      "~/CustomContent/js/fullspoon.js"));

            // In case local easing won't work
            //<script src="http://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.3/jquery.easing.min.js"></script>
        }
    }
}
