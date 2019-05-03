using Coban.Market.BL;
using Coban.Market.BL.Results;
using Coban.Market.Entities;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace Coban.Market.Web.Controllers
{
    public class CargoController : Controller
    {
        #region Variables
        private CargoManager cargoManager = new CargoManager();
        #endregion
        #region Index
        public ActionResult Index()
        {
            return View();
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

            var cargoData = cargoManager.ListQueryable();

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                cargoData = cargoData.OrderBy(sortColumn + " " + sortColumnDir);
            }

            if (!string.IsNullOrEmpty(searchValue))
            {
                var searchcount = searchValue.Length;
                if (searchcount >= 10)
                {
                    if (searchValue.Substring(0, 10) == "SearchDate")
                    {

                        if (searchcount == 14)
                        {
                            int year = Convert.ToInt32(searchValue.Substring(10, 4));
                            cargoData = cargoData.Where(x => x.CreatedOn.Year == year);
                        }
                        else if (searchcount == 15 || searchcount == 16)
                        {
                            if (searchcount == 5)
                            {
                                int year = Convert.ToInt32(searchValue.Substring(10, 3));
                                int month = Convert.ToInt32(searchValue.Substring(14, 1));
                                cargoData = cargoData.Where(x => x.CreatedOn.Year == year && x.CreatedOn.Month == month);
                            }
                            else if (searchcount == 6)
                            {
                                int year = Convert.ToInt32(searchValue.Substring(10, 3));
                                int month = Convert.ToInt32(searchValue.Substring(14, 2));
                                cargoData = cargoData.Where(x => x.CreatedOn.Year == year && x.CreatedOn.Month == month);
                            }
                        }
                        else if (searchcount == 30)
                        {
                            DateTime first = Convert.ToDateTime(searchValue.Substring(10, 10));
                            DateTime last = Convert.ToDateTime(searchValue.Substring(20, 10));
                            cargoData = cargoData.Where(x => x.CreatedOn >= first && x.CreatedOn <= last);
                        }
                    }
                    else
                    {
                        cargoData = cargoData.Where(x => x.CargoName.Contains(searchValue) || x.CargoDescription.Contains(searchValue));
                    }
                }
                else
                {
                    cargoData = cargoData.Where(x => x.CargoName.Contains(searchValue) || x.CargoDescription.Contains(searchValue));
                }
                searchValue = null;
            }
            recordsTotal = cargoData.Count();
            var data = cargoData.Skip(skip).Take(pageSize).OrderByDescending(x => x.CreatedOn).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
        }
        #endregion
        #region Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CargoNames cargo)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("CreatedUsername");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");

            if (ModelState.IsValid)
            {
                cargoManager.Insert(cargo);
                return RedirectToAction("Index");
            }
            return View(cargo);
        }


        #endregion
        #region Edit
        [HttpPost]
        public ActionResult Edit(CargoNames cargo)
        {
            CargoNames cargo2 = cargoManager.Find(x => x.Id == cargo.Id);
            OperationResult operation = new OperationResult();
            if (cargo2 == null)
            {
                operation.Response += "Kargo Şirketi Bulunamadı.";
                return View("Index", operation);
            }

            cargo2.CargoName = cargo.CargoName;
            cargo2.CargoDescription = cargo.CargoDescription;
            cargo2.CargoPhone = cargo.CargoPhone;
            cargoManager.Update(cargo2);
            operation.Result = true;
            return View("Index", operation);
        }
        #endregion
        #region Delete
        [HttpPost]
        public JsonResult Delete(int id)
        {
            OperationResult operation = new OperationResult();

            CargoNames category = cargoManager.Find(x => x.Id == id);
            if (category != null)
            {
                cargoManager.Delete(category);
                operation.Result = true;
                return Json(operation, JsonRequestBehavior.AllowGet);

            }
            operation.Response += "Kargo Şirketi Bulunamadı.";
            return Json(operation, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}