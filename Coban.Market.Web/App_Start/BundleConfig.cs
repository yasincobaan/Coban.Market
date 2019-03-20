using System.Web;
using System.Web.Optimization;

namespace Coban.Market.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Jquery
            bundles.Add(new ScriptBundle("~/jquery").Include(
                "~/ContentAdmin/Theme/js/jquery.js"
            ));

            //Layout Css
            bundles.Add(new StyleBundle("~/main/css").Include(
                "~/ContentAdmin/Theme/css/bootstrap.css",
                "~/ContentAdmin/Theme/css/sb-admin-2.css",
                 "~/ContentAdmin/Theme/css/font.css",
                 "~/ContentAdmin/Theme/css/custom.css"
            ));

            //Layout Js
            bundles.Add(new ScriptBundle("~/main/js").Include(
                 "~/ContentAdmin/Theme/js/bootstrap.js",
                 "~/ContentAdmin/Theme/js/sb-admin-2.js",
                 "~/ContentAdmin/Theme/js/popper.js",
                 "~/ContentAdmin/Theme/js/moment.js",
                 "~/ContentAdmin/Theme/js/custom.js"

            ));






            //Datatable Css
            bundles.Add(new StyleBundle("~/datatable/css").Include(
                "~/ContentAdmin/Other/DataTable/css/button-bootstrap.css",
                "~/ContentAdmin/Other/DataTable/css/buttons.dataTables.min.css",
                "~/ContentAdmin/Other/DataTable/css/dataTables.bootstrap.min.css"
            ));

            //Datatable Js
            bundles.Add(new ScriptBundle("~/datatable/js").Include(
                "~/ContentAdmin/Other/DataTable/js/jquery.dataTables.min.js",
                "~/ContentAdmin/Other/DataTable/js/dataTables.bootstrap4.min.js",
                "~/ContentAdmin/Other/DataTable/js/dataTables.buttons.min.js",
                "~/ContentAdmin/Other/DataTable/js/button.html5.min.js",
                "~/ContentAdmin/Other/DataTable/js/buttons.colVis.min.js",
                "~/ContentAdmin/Other/DataTable/js/buttons.flash.min.js",
                "~/ContentAdmin/Other/DataTable/js/buttons.print.min.js",
                "~/ContentAdmin/Other/DataTable/js/currencyDataTable.js",
                "~/ContentAdmin/Other/DataTable/js/jszip3.1.3.min.js",
                "~/ContentAdmin/Other/DataTable/js/pdfmake.min.js",
                "~/ContentAdmin/Other/DataTable/js/resizable.js",
                "~/ContentAdmin/Other/DataTable/js/vfs-font.js"

            ));


            // MarketUser - Index - Css
            bundles.Add(new StyleBundle("~/marketuser/index/css").Include(
                "~/ContentAdmin/Page/MarketUser/Index/css/index.css"
            ));

            // MarketUser - Index - Js
            bundles.Add(new ScriptBundle("~/marketuser/index/js").Include(
                "~/ContentAdmin/Page/MarketUser/Index/js/index.js"
              ));



            // MarketUser - Create - Css
            bundles.Add(new StyleBundle("~/marketuser/create/css").Include(
                "~/ContentAdmin/Page/MarketUser/Create/css/create.css"
            ));

            // MarketUser - Create - Js
            bundles.Add(new ScriptBundle("~/marketuser/create/js").Include(
                "~/ContentAdmin/Page/MarketUser/Create/js/create.js"
            ));

        }
    }
}
