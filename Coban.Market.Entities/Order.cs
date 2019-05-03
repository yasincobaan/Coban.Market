using System;
using System.Collections.Generic;
using Coban.Market.Entities.Enums;

namespace Coban.Market.Entities
{
    public class Order : MyEntityBase
    {
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }
        public string Username { get; set; }


        public string AddressTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighborhood { get; set; }
        public string PostCode { get; set; }
 


        public virtual List<OrderLine> Orderlines { get; set; }
    }
    public class OrderLine : MyEntityBase
    {

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
