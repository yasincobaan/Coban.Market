using System.Web;
using System.Web.Mvc;
using Coban.Market.BL;
using Coban.Market.BL.Results;
using Coban.Market.Entities;
using Coban.Market.Web.Models;
using Coban.Market.Web.Models.ViewModels;

namespace Coban.Market.Web.Controllers
{
    public class ProfileController : Controller
    {
        private MarketUserManager mrktUserManager = new MarketUserManager();



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
        public ActionResult EditProfile(MarketUser model, HttpPostedFileBase ProfileImage)
        {
            ModelState.Remove("ModifiedUsername");
            ModelState.Remove("ModifiedOn");
            if (ModelState.IsValid)
            {
                if (ProfileImage != null &&
                    (ProfileImage.ContentType == "image/jpeg" ||
                    ProfileImage.ContentType == "image/jpg" ||
                    ProfileImage.ContentType == "image/png"))
                {
                    string filename = $"user_{model.Id}.{ProfileImage.ContentType.Split('/')[1]}";

                    ProfileImage.SaveAs(Server.MapPath($"~/Images/MarketUser/{filename}"));
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



        public ActionResult ActivityLog()
        {
            return View();
        }
        public ActionResult Settings()
        {
            return View();
        }

        public ActionResult ShowCustomer(string username)
        {
            MarketUser mrktUser = mrktUserManager.Find(x => x.Username == username);

            return View(mrktUser);
        }
    }
}