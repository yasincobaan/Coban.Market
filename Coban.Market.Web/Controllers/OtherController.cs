using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Coban.Market.BL;

namespace Coban.Market.Web.Controllers
{
    public class OtherController : Controller
    {
        CategoryManager catManager = new CategoryManager();
        ProductManager prdManager = new ProductManager();


        public ActionResult AboutUs()
        {
          
            return View();
        }
       
    }
}