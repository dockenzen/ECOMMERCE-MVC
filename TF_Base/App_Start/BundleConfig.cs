using System.Web;
using System.Web.Optimization;

namespace TF_Base
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;
            //STYLES
            bundles.Add(new StyleBundle("~/bundles/.css")
                .Include(
                "~/Content/vendor/bootstrap/css/bootstrap.min.css",
                "~/Content/vendor/font-awesome/css/font-awesome.min.css",
                "~/Content/vendor/font-awesome/css/sarasa.css",
                "~/Content/vendor/bootstrap-select/css/bootstrap-select.min.css",
                "~/Content/vendor/owl.carousel/assets/owl.carousel.css",
                "~/Content/vendor/owl.carousel/assets/owl.theme.default.css",
                "~/Content/css/style.default.css",
                "~/Content/css/custom.css"));

            //SCRIPTS
            bundles.Add(new ScriptBundle("~/bundles/.js")
                .Include(
                "~/Content/vendor/jquery/jquery.min.js",
                "~/Content/vendor/popper.js/umd/popper.min.js",
                "~/Content/vendor/bootstrap/js/bootstrap.min.js",
                "~/Content/vendor/jquery.cookie/jquery.cookie.js",
                "~/Content/vendor/waypoints/lib/jquery.waypoints.min.js",
                "~/Content/vendor/jquery.counterup/jquery.counterup.min.js",
                "~/Content/vendor/owl.carousel/owl.carousel.min.js",
                "~/Content/vendor/owl.carousel2.thumbs/owl.carousel2.thumbs.min.js",
                "~/Content/js/jquery.parallax-1.1.3.js",
                "~/Content/vendor/bootstrap-select/js/bootstrap-select.min.js",
                "~/Content/vendor/jquery.scrollto/jquery.scrollTo.min.js",
                "~/Content/js/front.js"));
        }
    }
}