using Coban.Market.Entities;
using Coban.Market.Entities.ValueObjects;
using Coban.Market.Web.Models.ViewModels;
using System.Web.Mvc;
using Coban.Market.BL;
using Coban.Market.BL.Results;
using Coban.Market.Web.Models;

namespace Coban.Market.Web.Controllers
{
    public class AccountController : Controller
    {
        private  MarketUserManager mrktUserManager = new MarketUserManager();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                BusinessLayerResult<MarketUser> res = mrktUserManager.LoginUser(model);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(model);
                }

                CurrentSession.Set<MarketUser>("login", res.Result);
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}