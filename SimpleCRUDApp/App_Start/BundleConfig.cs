using System.Web;
using System.Web.Optimization;

namespace SimpleCRUDApp
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
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

           //CSS page
            bundles.Add(new StyleBundle("~/Assets/css").Include(
          "~/Assets/bootstrap/css/bootstrap.min.css",
          "~/Assets/metisMenu/metisMenu.min.css",
          "~/Assets/datatables-plugins/dataTables.bootstrap.css",
          "~/Assets/datatables-responsive/dataTables.responsive.css",
          "~/Assets/dist/css/sb-admin-2.min.css",
          "~/Assets/font-awesome/css/font-awesome.min.css",
          "~/Content/css/index.css",
          "~/Assets/loading/jquery.mloading.css"));

            //JS page
            bundles.Add(new ScriptBundle("~/Assets/jquery").Include(
            "~/Assets/jquery/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/Assets/js").Include(
            "~/Scripts/jquery.unobtrusive-ajax.min.js",
            "~/Assets/bootstrap/js/bootstrap.min.js",
            "~/Assets/metisMenu/metisMenu.min.js",            
            "~/Assets/datatables/js/jquery.dataTables.min.js",
            "~/Assets/datatables-plugins/dataTables.bootstrap.min.js",
            "~/Assets/datatables-responsive/dataTables.responsive.js",
            "~/Assets/dist/js/sb-admin-2.min.js",
            "~/Assets/loading/jquery.mloading.js",
            "~/Assets/bootbox/bootbox.min.js"));            
        }
    }
}
