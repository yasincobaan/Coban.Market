using Coban.Market.BL;
using Coban.Market.BL.Results;
using Coban.Market.Entities;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace Coban.Market.Web.Controllers
{

    public class MarketUserController : Controller
    {
        private MarketUserManager mrktUserManager = new MarketUserManager();


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IndexDetails()
        {

            return View(mrktUserManager.ListQueryable());
        }

        public ActionResult LoadData()
        {

            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            var userData = mrktUserManager.ListQueryable();

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                userData = userData.OrderBy(sortColumn + " " + sortColumnDir);
            }

            if (!string.IsNullOrEmpty(searchValue))
            {
                userData = userData.Where(
                    x => x.Name.Contains(searchValue) ||
                         x.Email.Contains(searchValue) ||
                         x.Surname.Contains(searchValue) ||
                         x.Username.Contains(searchValue)
                );
            }

            recordsTotal = userData.Count();

            var data = userData.Skip(skip).Take(pageSize).OrderByDescending(x => x.CreatedOn).ToList();

            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });


        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MarketUser mrktUser)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            ModelState.Remove("CreatedUsername");

            ModelState.Remove("Password");
            ModelState.Remove("ProfileImageFilename");
            ModelState.Remove("Role");
            ModelState.Remove("IsActive");
            ModelState.Remove("ActivateGuid");

            if (ModelState.IsValid)
            {
                BusinessLayerResult<MarketUser> res = mrktUserManager.Insert(mrktUser);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(mrktUser);
                }

                return RedirectToAction("Index");
            }

            return View(mrktUser);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MarketUser mrktUser = mrktUserManager.Find(x => x.Id == id);
            mrktUserManager.Delete(mrktUser);

            return RedirectToAction("Index");
        }

        public ActionResult json(object asd )
        {
            return View();
        }
    }
}