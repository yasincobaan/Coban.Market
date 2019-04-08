﻿using System;
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

        #region Login-Register
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
                    return View("Account", model);
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
        #endregion

        #region Forgot Password

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(AccountViewModel model)
        {
            ModelState.Remove("FirstName");
            ModelState.Remove("LastName");
            ModelState.Remove("Username");
            ModelState.Remove("Password");
            ModelState.Remove("RePassword");
            ModelState.Remove("Phone");

            if (ModelState.IsValid)
            {
                BusinessLayerResult<MarketUser> res = mrktUserManager.ForgotPass(model);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View("ForgotPassword", model);
                }
                OkViewModel notifyObj = new OkViewModel()
                {
                    Title = "Kayıt Başarılı",
                    RedirectingUrl = "/Account/Account",
                };

                notifyObj.Items.Add("Lütfen e-posta adresinize gönderdiğimiz şifre yenileme linkine tıklayınız. Güvenlik sebepleriyle şifrenizi yenileyene kadar hesabınız devre dışı bırakılmıştır.");

                return View("Ok", notifyObj);
            }

            return View("ForgotPassword", model);
        }



        #endregion

        #region Forgot Password Recovery and Active
        [HttpGet]
        public ActionResult ForgotActivate(Guid id)
        {
            MarketUser mrktUser = mrktUserManager.Find(x => x.ActivateGuid == id);
            if (mrktUser != null)
            {
                return View(mrktUser);
            }
            //404
            return View();
        }
        [HttpPost]
        public ActionResult ForgotActivate(Guid Id, string Password)
        {
            BusinessLayerResult<MarketUser> res = mrktUserManager.ForgotActive(Id, Password);

            if (res.Errors.Count > 0)
            {
                res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
            }
            return RedirectToAction("Account");
        }


        #endregion

    }
}