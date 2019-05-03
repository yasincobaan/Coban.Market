using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Coban.Market.BL;
using Coban.Market.Entities;

namespace Coban.Market.Web.Controllers
{
    public class HomeController : Controller
    {

        #region Variables
        private CategoryManager catManager = new CategoryManager();
        private ProductManager prdManager = new ProductManager();
        #endregion




        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminIndex()
        {
            return View();
        }










        public ActionResult Change(String languageSelect)
        {
            if (languageSelect != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(languageSelect);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(languageSelect);
            }

            HttpCookie cookie = new HttpCookie("language");
            cookie.Value = languageSelect;
            Response.Cookies.Add(cookie);

            return View("Index");
        }




        public ActionResult Search(string site_search)
        {
            //to do arama 
            return View("Index");
        }

        public ActionResult ShopCategory(int? id)
        {
            //kategoriye göre filtrele
            return View("Index");
        }

        public ActionResult SingleProduct(int? id)
        {
            Product mrktUser = prdManager.Find(x => x.Id == id);
            return View(mrktUser);
        }

    }
}