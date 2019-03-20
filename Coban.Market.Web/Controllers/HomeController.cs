using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Coban.Market.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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
    }
}