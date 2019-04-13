using System.Web;
using System.Web.Mvc;
using Coban.Market.BL;
using Coban.Market.BL.Results;
using Coban.Market.Entities;
using Coban.Market.Web.Filters;
using Coban.Market.Web.Models;
using Coban.Market.Web.Models.ViewModels;

namespace Coban.Market.Web.Controllers
{
    public class ProfileController : Controller
    {
        MarketUserManager mrktUserManager = new MarketUserManager();



        public ActionResult ShowProfile()
        {
            BusinessLayerResult<MarketUser> res = mrktUserManager.GetUserById(CurrentSession.User.Id);

            if (res.Errors.Count > 0)
            {
                ErrorViewModel errorNotifyObj = new ErrorViewModel()
                {
                    Title = "Hata Oluştu",
                    Items = res.Errors
                };

                return View("Error", errorNotifyObj);
            }

            return View(res.Result);
        }
        
        public ActionResult EditProfile()
        {
            BusinessLayerResult<MarketUser> res = mrktUserManager.GetUserById(CurrentSession.User.Id);

            if (res.Errors.Count > 0)
            {
                ErrorViewModel errorNotifyObj = new ErrorViewModel()
                {
                    Title = "Hata Oluştu",
                    Items = res.Errors
                };

                return View("Error", errorNotifyObj);
            }

            return View(res.Result);
        }
        
       
        public ActionResult ActivityLog()
        {
            return View();
        }
        public ActionResult Settings()
        {
            return View();
        }
    }
}