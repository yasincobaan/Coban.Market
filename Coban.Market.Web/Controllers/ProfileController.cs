﻿using System.Web;
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
        
        [HttpPost]
        public ActionResult EditProfile(MarketUser model, HttpPostedFileBase Image)
        {
            ModelState.Remove("ModifiedUsername");

            if (ModelState.IsValid)
            {
                if (Image != null &&
                    (Image.ContentType == "image/jpeg" || Image.ContentType == "image/jpg" || Image.ContentType == "image/png"))
                {
                    string filename = $"user_{model.Id}.{Image.ContentType.Split('/')[1]}";
                    Image.SaveAs(Server.MapPath($"~/images/{filename}"));
                    model.ProfileImageFilename = filename;
                }

                BusinessLayerResult<MarketUser> res = mrktUserManager.UpdateProfile(model);

                if (res.Errors.Count > 0)
                {
                    ErrorViewModel errorNotifyObj = new ErrorViewModel()
                    {
                        Items = res.Errors,
                        Title = "Profil Güncellenemedi.",
                        RedirectingUrl = "/Profile/EditProfile"
                    };

                    return View("Error", errorNotifyObj);
                }
                CurrentSession.Set<MarketUser>("login", res.Result);

                return RedirectToAction("ShowProfile");
            }

            return View(model);
        }
    }
}