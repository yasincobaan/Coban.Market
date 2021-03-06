﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;
using Coban.Market.BL;
using Coban.Market.BL.Results;
using Coban.Market.Entities;
using Coban.Market.Web.Filters;
using Coban.Market.Web.Models;

namespace Coban.Market.Web.Controllers
{

    public class ProductController : Controller
    {
        #region Variables
        private ProductManager prdManager = new ProductManager();
        private CategoryManager categoryManager = new CategoryManager();
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
            var prdData = prdManager.ListQueryable();
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                prdData = prdData.OrderBy(sortColumn + " " + sortColumnDir);
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
                            prdData = prdData.Where(x => x.CreatedOn.Year == year);
                        }
                        else if (searchcount == 15 || searchcount == 16)
                        {
                            if (searchcount == 5)
                            {
                                int year = Convert.ToInt32(searchValue.Substring(10, 3));
                                int month = Convert.ToInt32(searchValue.Substring(14, 1));
                                prdData = prdData.Where(x => x.CreatedOn.Year == year && x.CreatedOn.Month == month);
                            }
                            else if (searchcount == 6)
                            {
                                int year = Convert.ToInt32(searchValue.Substring(10, 3));
                                int month = Convert.ToInt32(searchValue.Substring(14, 2));
                                prdData = prdData.Where(x => x.CreatedOn.Year == year && x.CreatedOn.Month == month);
                            }
                        }
                        else if (searchcount == 30)
                        {
                            DateTime first = Convert.ToDateTime(searchValue.Substring(10, 10));
                            DateTime last = Convert.ToDateTime(searchValue.Substring(20, 10));
                            prdData = prdData.Where(x => x.CreatedOn >= first && x.CreatedOn <= last);
                        }
                    }
                    else
                    {
                        prdData = prdData.Where(x =>
                            x.ProductName.Contains(searchValue) ||
                            x.Description.Contains(searchValue) ||
                            x.ProductBrand.Contains(searchValue) ||
                            x.LittleDescription.Contains(searchValue));
                    }
                }
                else
                {
                    prdData = prdData.Where(x =>
                        x.ProductName.Contains(searchValue) ||
                        x.Description.Contains(searchValue) ||
                        x.ProductBrand.Contains(searchValue) ||
                        x.LittleDescription.Contains(searchValue));
                }
                searchValue = null;
            }
            recordsTotal = prdData.Count();
            var data = prdData.Skip(skip).Take(pageSize).OrderByDescending(x => x.CreatedOn).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
        }
        #endregion
        #region Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(CacheHelper.GetCategoriesFromCache(), "Id", "Title");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product prd, HttpPostedFileBase Image1, HttpPostedFileBase Image2, HttpPostedFileBase Image3, HttpPostedFileBase Image4)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("CreatedUsername");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");

            if (ModelState.IsValid)
            {
                prd.Owner = CurrentSession.User;
                prdManager.Insert(prd);
                prd = prdManager.Find(x => x.Id == prd.Id);
                if (Image1 != null && (Image1.ContentType == "image/jpeg" || Image1.ContentType == "image/jpg" || Image1.ContentType == "image/png"))
                {
                    string filename = $"prd_1_{prd.Id}.{Image1.ContentType.Split('/')[1]}";
                    Image1.SaveAs(Server.MapPath($"~/Images/Product/{filename}"));
                    prd.Image1 = filename;
                }
                if (Image2 != null && (Image2.ContentType == "image/jpeg" || Image2.ContentType == "image/jpg" || Image2.ContentType == "image/png"))
                {
                    string filename = $"prd_2_{prd.Id}.{Image2.ContentType.Split('/')[1]}";
                    Image2.SaveAs(Server.MapPath($"~/Images/Product/{filename}"));
                    prd.Image2 = filename;
                }
                if (Image3 != null && (Image3.ContentType == "image/jpeg" || Image3.ContentType == "image/jpg" || Image3.ContentType == "image/png"))
                {
                    string filename = $"prd_3_{prd.Id}.{Image3.ContentType.Split('/')[1]}";
                    Image3.SaveAs(Server.MapPath($"~/Images/Product/{filename}"));
                    prd.Image3 = filename;
                }
                if (Image4 != null && (Image4.ContentType == "image/jpeg" || Image4.ContentType == "image/jpg" || Image4.ContentType == "image/png"))
                {
                    string filename = $"prd_4_{prd.Id}.{Image4.ContentType.Split('/')[1]}";
                    Image4.SaveAs(Server.MapPath($"~/Images/Product/{filename}"));
                    prd.Image4 = filename;
                }
                prdManager.Update(prd);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(CacheHelper.GetCategoriesFromCache(), "Id", "Title", prd.CategoryId);
            return View(prd);
        }
        #endregion
        #region Delete
        [HttpPost]
        public JsonResult Delete(int id)
        {
            OperationResult operation = new OperationResult();
            Product prd = prdManager.Find(x => x.Id == id);
            if (prd != null)
            {
                prdManager.Delete(prd);
                CacheHelper.RemoveCategoriesFromCache();
                operation.Result = true;
                return Json(operation, JsonRequestBehavior.AllowGet);
            }
            operation.Response += "Ürün Bulunamadı.";
            return Json(operation, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}