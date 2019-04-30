﻿using Coban.Market.BL;
using Coban.Market.Entities;
using Coban.Market.Web.Models;
using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;
using Coban.Market.BL.Results;
using Coban.Market.Web.Filters;

namespace Coban.Market.Web.Controllers
{
    [Exc]
    [Auth]
    public class CategoryController : Controller
    {
        #region Variables
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

            var catData = categoryManager.ListQueryable();

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                catData = catData.OrderBy(sortColumn + " " + sortColumnDir);
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
                            catData = catData.Where(x => x.CreatedOn.Year == year);
                        }
                        else if (searchcount == 15 || searchcount == 16)
                        {
                            if (searchcount == 5)
                            {
                                int year = Convert.ToInt32(searchValue.Substring(10, 3));
                                int month = Convert.ToInt32(searchValue.Substring(14, 1));
                                catData = catData.Where(x => x.CreatedOn.Year == year && x.CreatedOn.Month == month);
                            }
                            else if (searchcount == 6)
                            {
                                int year = Convert.ToInt32(searchValue.Substring(10, 3));
                                int month = Convert.ToInt32(searchValue.Substring(14, 2));
                                catData = catData.Where(x => x.CreatedOn.Year == year && x.CreatedOn.Month == month);
                            }
                        }
                        else if (searchcount == 30)
                        {
                            DateTime first = Convert.ToDateTime(searchValue.Substring(10, 10));
                            DateTime last = Convert.ToDateTime(searchValue.Substring(20, 10));
                            catData = catData.Where(x => x.CreatedOn >= first && x.CreatedOn <= last);
                        }
                    }
                    else
                    {
                        catData = catData.Where(x => x.Title.Contains(searchValue) || x.Description.Contains(searchValue));
                    }
                }
                else
                {
                    catData = catData.Where(x => x.Title.Contains(searchValue) || x.Description.Contains(searchValue));
                }
                searchValue = null;
            }
            recordsTotal = catData.Count();
            var data = catData.Skip(skip).Take(pageSize).OrderByDescending(x => x.CreatedOn).ToList();
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
        public ActionResult Create(Category category, HttpPostedFileBase Image)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("CreatedUsername");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");

            if (ModelState.IsValid)
            {
                categoryManager.Insert(category);
                CacheHelper.RemoveCategoriesFromCache();
                category = categoryManager.Find(x => x.Id == category.Id);
                if (Image != null && (Image.ContentType == "image/jpeg" || Image.ContentType == "image/jpg" || Image.ContentType == "image/png"))
                {
                    string filename = $"cat_{category.Id}.{Image.ContentType.Split('/')[1]}";
                    Image.SaveAs(Server.MapPath($"~/Images/Category/{filename}"));
                    category.Image = filename;
                }
                categoryManager.Update(category);
                ViewBag.CategoryId = new SelectList(CacheHelper.GetCategoriesFromCache(), "Id", "Title", category.CategoryId);
                return RedirectToAction("Index");
            }
            return View(category);
        }


        #endregion
        #region Edit
        [HttpPost]
        public ActionResult Edit(Category category, HttpPostedFileBase Image2)
        {
            Category cat = categoryManager.Find(x => x.Id == category.Id);
            OperationResult operation = new OperationResult();
            if (cat == null)
            {
                operation.Response += "Kategori Bulunamadı.";
                return View("Index", operation);
            }
            if (Image2 != null && (Image2.ContentType == "image/jpeg" || Image2.ContentType == "image/jpg" || Image2.ContentType == "image/png"))
            {
                string filename = $"cat_{category.Id}.{Image2.ContentType.Split('/')[1]}";
                Image2.SaveAs(Server.MapPath($"~/Images/Category/{filename}"));
                cat.Image = filename;
            }
            cat.Title = category.Title;
            cat.Description = category.Description;
            categoryManager.Update(cat);
            CacheHelper.RemoveCategoriesFromCache();
            operation.Result = true;
            return View("Index", operation);
        }
        #endregion
        #region Delete
        [HttpPost]
        public JsonResult Delete(int id)
        {
            OperationResult operation = new OperationResult();

            Category category = categoryManager.Find(x => x.Id == id);
            if (category != null)
            {
                categoryManager.Delete(category);
                CacheHelper.RemoveCategoriesFromCache();
                operation.Result = true;
                return Json(operation, JsonRequestBehavior.AllowGet);

            }
            operation.Response += "Kategori Bulunamadı.";
            return Json(operation, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}