using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Coban.Market.BL;
using Coban.Market.DAL;
using Coban.Market.Entities.Enums;
using Coban.Market.Web.Models.OrderModels;

namespace Coban.Market.Web.Controllers
{
    public class OrderController : Controller
    {
        private OrderManager orderManager = new OrderManager();

        // GET: Order
        public ActionResult Index()
        {
            var orders = orderManager.ListQueryable().Select(i => new AdminOrderModel()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,
                Count = i.Orderlines.Count
            }).OrderByDescending(i => i.OrderDate);

            return View(orders);
        }

        public ActionResult Details(int id)
        {
            var entity = orderManager.ListQueryable().Where(i => i.Id == id)
                .Select(i => new OrderDetailsModel()
                {
                    OrderId = i.Id,
                    UserName = i.Username,
                    OrderNumber = i.OrderNumber,
                    Total = i.Total,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    AdresBasligi = i.AddressTitle,
                    Adres = i.Address,
                    Sehir = i.City,
                    Semt = i.District,
                    Mahalle = i.Neighborhood,
                    PostaKodu = i.PostCode,
                    Orderlines = i.Orderlines.Select(a => new OrderLineModel()
                    {
                        ProductId = a.ProductId,
                        ProductName = a.Product.ProductName.Length > 50 ? a.Product.ProductName.Substring(0, 47) + "..." : a.Product.ProductName,
                        Image = a.Product.Image1,
                        Quantity = a.Quantity,
                        Price = a.Price
                    }).ToList()
                }).FirstOrDefault();

            return View(entity);
        }

        public ActionResult UpdateOrderState(int OrderId, EnumOrderState OrderState)
        {
            var order = orderManager.Find(i => i.Id == OrderId);

            if (order != null)
            {
                order.OrderState = OrderState;
                orderManager.Update(order);

                TempData["message"] = "Bilgileriniz Kayıt Edildi";

                return RedirectToAction("Details", new { id = OrderId });
            }

            return RedirectToAction("Index");
        }
    }
}