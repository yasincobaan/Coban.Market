using System.Web.Optimization;

namespace Coban.Market.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Jquery and Popper Js
            bundles.Add(new ScriptBundle("~/jquery").Include(
                "~/ContentAdmin/Theme/js/jquery.js",
                "~/ContentAdmin/Theme/js/popper.js"

            ));
            #endregion

            #region Layout Admin
            //Layout Css
            bundles.Add(new StyleBundle("~/main/css").Include(
                "~/ContentAdmin/Theme/css/bootstrap.css",
                "~/ContentAdmin/Theme/css/sb-admin-2.css",
                "~/ContentAdmin/Theme/css/font.css",
                "~/ContentAdmin/Theme/css/custom.css",
                "~/font/css/all.css"
            ));

            //Layout Js
            bundles.Add(new ScriptBundle("~/main/js").Include(
                "~/ContentAdmin/Theme/js/bootstrap.js",
                "~/ContentAdmin/Theme/js/sb-admin-2.js",
                "~/ContentAdmin/Theme/js/popper.js",
                "~/ContentAdmin/Theme/js/moment.js",
                "~/ContentAdmin/Theme/js/custom.js",
                "~/ContentAdmin/Other/SweetAlert/js/sweetalert.js",
                "~/ContentAdmin/Other/jquery.easing.js",
                "~/font/css/all.js"

            ));
            #endregion

            #region Datatable
            //Datatable Css
            bundles.Add(new StyleBundle("~/datatable/css").Include(
                "~/ContentAdmin/Other/DataTable/css/button-bootstrap.css",
                "~/ContentAdmin/Other/DataTable/css/buttons.dataTables.min.css",
                "~/ContentAdmin/Other/DataTable/css/dataTables.bootstrap.min.css",
                "~/ContentAdmin/Other/DataTable/css/custom.css"
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
            #endregion

            #region Date Range Picker
            // DateRangePicker - Css
            bundles.Add(new StyleBundle("~/daterangepicker/css").Include(
                "~/ContentAdmin/Other/DateRangePicker/css/daterangepicker.css"
            ));

            // DateRangePicker  - Js
            bundles.Add(new ScriptBundle("~/daterangepicker/js").Include(
                "~/ContentAdmin/Other/DateRangePicker/js/moment.min.js",
                "~/ContentAdmin/Other/DateRangePicker/js/daterangepicker.min.js"


            ));

            // DateRangePicker  - Start
            bundles.Add(new ScriptBundle("~/dateRangeStart/js").Include(
                "~/ContentAdmin/Other/DateRangePicker/js/daterangestart.js"
            ));
            #endregion

            #region SearchBox

            bundles.Add(new ScriptBundle("~/searchBox/js").Include(
                "~/ContentAdmin/Other/SearchBox/js/searchBox.js"
            ));

            #endregion

            #region MarketUser

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

            #endregion

            #region Product

            // Product - Index - Css
            bundles.Add(new StyleBundle("~/product/index/css").Include(
                "~/ContentAdmin/Page/Product/Index/css/index.css"
            ));

            // Product - Index - Js
            bundles.Add(new ScriptBundle("~/product/index/js").Include(
                "~/ContentAdmin/Page/Product/Index/js/index.js"
            ));

            #endregion

            #region Category

            // Category - Index - Css
            bundles.Add(new StyleBundle("~/category/index/css").Include(
                "~/ContentAdmin/Page/Category/Index/css/index.css"
            ));

            // Category - Index - Js
            bundles.Add(new ScriptBundle("~/category/index/js").Include(
                "~/ContentAdmin/Page/Category/Index/js/index.js"
            ));

            #endregion

            #region Layout Customer Js
            // Layout Customer js
            bundles.Add(new ScriptBundle("~/layoutCustomer/js").Include(
                "~/ContentCustomer/Theme/js/modernizr.min.js",
                "~/ContentCustomer/Theme/js/jquery.min.js",
                "~/ContentCustomer/Theme/js/popper.min.js",
                "~/ContentCustomer/Theme/js/bootstrap.min.js",
                "~/ContentCustomer/Theme/js/count.min.js",
                "~/ContentCustomer/Theme/js/gmap.min.js",
                "~/ContentCustomer/Theme/js/imageloader.min.js",
                "~/ContentCustomer/Theme/js/isotope.min.js",
                "~/ContentCustomer/Theme/js/nouislider.min.js",
                "~/ContentCustomer/Theme/js/owl.carousel.min.js",
                "~/ContentCustomer/Theme/js/photoswipe-ui-default.min.js",
                "~/ContentCustomer/Theme/js/photoswipe.min.js",
                "~/ContentCustomer/Theme/js/velocity.min.js",
                "~/ContentCustomer/Theme/js/script.js",
                "~/ContentCustomer/Theme/js/custom.js"
            ));



            // Layout Customer Css
            bundles.Add(new StyleBundle("~/layoutCustomer/css").Include(
                "~/ContentCustomer/Theme/css/bootstrap.min.css",
                "~/ContentCustomer/Theme/css/font-awesome.min.css",
                "~/ContentCustomer/Theme/css/feather-icons.css",
                "~/ContentCustomer/Theme/css/pixeden.css",
                "~/ContentCustomer/Theme/css/socicon.css",
                "~/ContentCustomer/Theme/css/photoswipe.css",
                "~/ContentCustomer/Theme/css/izitoast.css",
                "~/ContentCustomer/Theme/css/style.css"
            ));

            #endregion



            #region FancyBox
            // FancyBox
            bundles.Add(new StyleBundle("~/fancybox/css").Include(
                "~/ContentAdmin/Other/FancyBox/jquery.fancybox.min.css"
            ));

            // FancyBox
            bundles.Add(new ScriptBundle("~/fancybox/js").Include(
                "~/ContentAdmin/Other/FancyBox/jquery.fancybox.min.js"
            ));
            #endregion
        }
    }
}
