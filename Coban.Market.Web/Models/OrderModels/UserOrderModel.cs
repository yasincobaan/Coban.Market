using System;
using Coban.Market.Entities.Enums;

namespace Coban.Market.Web.Models.OrderModels
{
    public class UserOrderModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public EnumOrderState OrderState { get; set; }
        public DateTime OrderDate { get; set; }
    }
}