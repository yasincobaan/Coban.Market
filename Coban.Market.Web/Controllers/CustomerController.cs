using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Coban.Market.BL;
using Coban.Market.BL.Results;
using Coban.Market.Entities;

namespace Coban.Market.Web.Controllers
{
    public class CustomerController : Controller
    {
        private ProductManager prdManager = new ProductManager();
        private CategoryManager catManager = new CategoryManager();

        public ActionResult AllProducts()
        {
            return View(prdManager.ListQueryable());
        }

        public ActionResult SingleProduct(int? id)
        {
            return View(prdManager.Find(x => x.Id == id));
        }
        public ActionResult ByCategory(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("AllProducts");
            }
            IQueryable<Product> prdsFilterCat = prdManager.ListQueryable().Where(x => x.CategoryId == id);
            return RedirectToAction("AllProducts",prdsFilterCat);
        }

        [HttpPost]
        public JsonResult ExchangeRate()
        {
            ExchangeRateResult rate = new ExchangeRateResult();

            XmlDocument xmlExchange = new XmlDocument();
            xmlExchange.Load("http://www.tcmb.gov.tr/kurlar/today.xml");
            decimal dolar = Convert.ToDecimal(xmlExchange.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "USD")).InnerText.Replace('.', ','));
            decimal Euro = Convert.ToDecimal(xmlExchange.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "EUR")).InnerText.Replace('.', ','));

            rate.Result = true;
            rate.Dollar = dolar;
            rate.Euro = Euro;

            return Json(rate, JsonRequestBehavior.AllowGet);
        }
    }
}