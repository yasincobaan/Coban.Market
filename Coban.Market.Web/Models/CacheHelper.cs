﻿using Coban.Market.BL;
using Coban.Market.Entities;
using System.Collections.Generic;
using System.Web.Helpers;

namespace Coban.Market.Web.Models
{
    public class CacheHelper
    {
        public static List<Category> GetCategoriesFromCache()
        {
            var result = WebCache.Get("category-cache");

            if (result == null)
            {
                CategoryManager categoryManager = new CategoryManager();
                result = categoryManager.List();

                WebCache.Set("category-cache", result, 20, true);
            }

            return result;
        }
        public static void RemoveCategoriesFromCache()
        {
            Remove("category-cache");
        }
        public static void Remove(string key)
        {
            WebCache.Remove(key);
        }
        public static List<Product> GetProductsFromCache()
        {
            var result = WebCache.Get("products-cache");
            if (result == null)
            {
                ProductManager prdManager = new ProductManager();
                result = prdManager.List();
                WebCache.Set("products-cache", result, 20, true);
            }
            return result;
        }
        public static void RemoveProductsFromCache()
        {
            Remove("category-cache");
        }
    }
}