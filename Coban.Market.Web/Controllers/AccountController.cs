using System;
using Coban.Market.Entities;
using Coban.Market.Entities.ValueObjects;
using Coban.Market.Web.Models.ViewModels;
using System.Web.Mvc;
using Coban.Market.BL;
using Coban.Market.BL.Results;
using Coban.Market.Common.Helpers;
using Coban.Market.Web.Models;

namespace Coban.Market.Web.Controllers
{
    public class AccountController : Controller
    {
        private MarketUserManager mrktUserManager = new MarketUserManager();




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





        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(string email)
        {
            MarketUser mrktUser = mrktUserManager.Find(x => x.Email == email);

            if (mrktUser == null)
            {
                return View(email);
            }
            else
            {
                mrktUser.IsActive = false;
                string siteUri = ConfigHelper.Get<string>("SiteRootUri");
                string activateUri = $"{siteUri}/Account/ForgotActivate/{mrktUser.ActivateGuid}";
                string body = $"Merhaba {mrktUser.Username};<br><br>Hesabınızı aktifleştirmek için <a href='{activateUri}' target='_blank'>tıklayınız</a>.";
                MailHelper.SendMail(body, mrktUser.Email, "Coban Market Şifre Yenileme");

                return RedirectToAction("ForgotActivate", "Account");
            }
        }



        [HttpGet]
        public ActionResult ForgotActivate(Guid guid)
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotActivate(string email)
        {
            MarketUser mrktUser = mrktUserManager.Find(x => x.Email == email);

            if (mrktUser == null)
            {
                return View(email);
            }
            else
            {
                mrktUser.IsActive = false;
                string siteUri = ConfigHelper.Get<string>("SiteRootUri");
                string activateUri = $"{siteUri}/Account/ForgotActivate/{mrktUser.ActivateGuid}";
                string body = $"Merhaba {mrktUser.Username};<br><br>Hesabınızı aktifleştirmek için <a href='{activateUri}' target='_blank'>tıklayınız</a>.";
                MailHelper.SendMail(body, mrktUser.Email, "Coban Market Şifre Yenileme");

                return RedirectToAction("ForgotActivate", "Account");
            }
        }
    }
}