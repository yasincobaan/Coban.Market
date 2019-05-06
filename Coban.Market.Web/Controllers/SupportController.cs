using System.Linq;
using System.Web.Mvc;
using Coban.Market.BL;
using Coban.Market.BL.Results;
using Coban.Market.Entities;
using Coban.Market.Entities.Enums;

namespace Coban.Market.Web.Controllers
{
    public class SupportController : Controller
    {
        private MarketUserManager mrktUserManager = new MarketUserManager();


        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult OurTeam()
        {
            return View(mrktUserManager.ListQueryable()
                .Where(x => x.Role == MarketUserRole.FullAdmin || x.Role == MarketUserRole.Admin));
        }
        public ActionResult OurCompany()
        {
            return View();
        }

        public ActionResult Faq()
        {
            return View();
        }
       
    }
}