using System.ComponentModel.DataAnnotations;
using Coban.Market.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Coban.Market.Entities
{
    public class ProductStock : MyEntityBase
    {
       
        public ProductStockEnum Stat { get; set; }

        public int StockNumber { get; set; }
        public virtual List<Product> Products { get; set; }

        public ProductStock()
        {
            Products = new List<Product>();
        }


    }
}
