using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using Coban.Market.Entities.Enums;

namespace Coban.Market.Entities
{
    [Table("Products")]
    public class Product : MyEntityBase
    {
        [DataType(DataType.Text),
         Required(ErrorMessage = "Product name field required."),
         StringLength(200, MinimumLength = 2, ErrorMessage = "The title field must contain max 200 min 2 characters.")]
        public string ProductName { get; set; }
        [DataType(DataType.Text),
         Required(ErrorMessage = "Product brand field required."),
         StringLength(200, MinimumLength = 2, ErrorMessage = "The brand field must contain max 200 min 2 characters.")]
        public string ProductBrand { get; set; }
        public PriceExchangeRate ExchangeRate { get; set; }



        [DataType(DataType.Currency), Required(ErrorMessage = "The product price field required.")]
       public double Price { get; set; }
       [DataType(DataType.Currency)]
        public double? DiscountedPrice { get; set; }
      
        [Range(-1, 101, ErrorMessage = "The tax field must be between 0 to 100")]
        public byte TaxPercent { get; set; }
      
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        
        [AllowHtml]
        public string Description { get; set; }
        
        [AllowHtml]
        public string LittleDescription { get; set; }

      
        public bool IsSale { get; set; }
        public string BarCode { get; set; }
        public string StockCode { get; set; }
        public int? Stock { get; set; }

      
        public int? LikeCount { get; set; }

      
        public int CategoryId { get; set; }

        public virtual MarketUser Owner { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Liked> Likes { get; set; }

        public Product()
        {
            Comments = new List<Comment>();
            Likes = new List<Liked>();
        }
    }
}
