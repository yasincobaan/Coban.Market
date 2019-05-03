using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Coban.Market.BL;
using Coban.Market.Entities;
using Coban.Market.Entities.Enums;
using Coban.Market.Web.Models;
using Coban.Market.Web.Models.OrderModels;

namespace Coban.Market.Web.Controllers
{
    public class CartController : Controller
    {
        #region Variables
        private ProductManager prdManager = new ProductManager();
        private OrderManager orderManager = new OrderManager();
        #endregion


        public ActionResult Index()
        {
            return View(GetCart());
        }

        public ActionResult AddToCart(int id)
        {
            var prd = prdManager.Find(i => i.Id == id);

            if (prd != null)
            {
                GetCart().AddProduct(prd, 1);
            }

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int id)
        {
            var product = prdManager.Find(i => i.Id == id);

            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }
            if (GetCart().CartLines.Count == 0)
            {
                return RedirectToAction("AllProduct", "Customer");
            }
            return RedirectToAction("Index");
        }

        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }

        public ActionResult Checkout()
        {
            if (CurrentSession.User != null)
            {
                return View(new ShippingDetails());
            }
            else
            {
                return RedirectToAction("Account", "Account");
            }
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetails entity)
        {
            var cart = GetCart();

            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("UrunYokError", "Sepetinizde ürün bulunmamaktadır.");
            }

            if (ModelState.IsValid)
            {
                SaveOrder(cart, entity);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(entity);
            }
        }

        private void SaveOrder(Cart cart, ShippingDetails entity)
        {
            var order = new Order();
            order.Username = CurrentSession.User.Username;
            order.OrderNumber = "#A" + (new Random()).Next(11111, 99999).ToString();
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.OrderState = EnumOrderState.Waiting;


            order.AddressTitle = entity.AddressTitle;
            order.Address = entity.Address;
            order.City = entity.City;
            order.District = entity.District;
            order.Neighborhood = entity.Neighborhood;
            order.PostCode = entity.PostCode;
         

            order.Orderlines = new List<OrderLine>();

            foreach (var pr in cart.CartLines)
            {
                var orderline = new OrderLine();
                orderline.Quantity = pr.Quantity;
                orderline.Price = pr.Quantity * pr.Product.Price;
                orderline.ProductId = pr.Product.Id;

                orderline.CreatedOn = DateTime.Now;
                orderline.CreatedUsername = "system";
                orderline.ModifiedOn = DateTime.Now;
                orderline.ModifiedUsername = "system";

                order.Orderlines.Add(orderline);
            }
            order.CreatedOn = DateTime.Now;
            order.CreatedUsername = "system";
            order.ModifiedOn = DateTime.Now;
            order.ModifiedUsername = "system";
            orderManager.Insert(order);

        }

        public ActionResult EmptyCart()
        {

            GetCart().Clear();
            return RedirectToAction("Index");
        }


    }
}