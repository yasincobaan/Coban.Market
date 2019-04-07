using System;
using System.Linq;
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

        CategoryManager catManager = new CategoryManager();
        ProductManager prdManager = new ProductManager();


        public ActionResult Account()
        {
            ViewData["catList"] = catManager.ListQueryable();
            ViewData["prdList"] = prdManager.List().OrderByDescending(x => x.Id);
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountViewModel model)
        {
            ModelState.Remove("FirstName");
            ModelState.Remove("LastName");
            ModelState.Remove("Username");
            ModelState.Remove("FirstName");
            ModelState.Remove("RePassword");
            ModelState.Remove("Phone");
            if (ModelState.IsValid)
            {
                BusinessLayerResult<MarketUser> res = mrktUserManager.LoginUser(model);
                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View("Account");
                }
                CurrentSession.Set<MarketUser>("login", res.Result);
                return RedirectToAction("Index", "Home");
            }

            return View("Account", model);
        }

        [HttpPost]
        public ActionResult Register(AccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                BusinessLayerResult<MarketUser> res = mrktUserManager.RegisterUser(model);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View("Account",model);
                }
                OkViewModel notifyObj = new OkViewModel()
                {
                    Title = "Kayıt Başarılı",
                    RedirectingUrl = "/Account/Account",
                };

                notifyObj.Items.Add("Lütfen e-posta adresinize gönderdiğimiz aktivasyon link'ine tıklayarak hesabınızı aktive ediniz. Hesabınızı aktive etmeden ürün satın alamaz ve beğenme yapamazsınız.");

                return View("Ok", notifyObj);
            }

            return View("Account", model);
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