using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coban.Market.Entities
{
    [Table("Products")]
    public class Product : MyEntityBase
    {
        [DisplayName("Ürün Adı")]
        public string Name { get; set; }

        [DisplayName("Ürün Açıklaması")]
        public string Description { get; set; }

        [DisplayName("Fiyatı")]
        public double Price { get; set; }


        [DisplayName("Ürüm Resmi")]
        public string Image { get; set; }
        

        [DisplayName("Beğenilme")]
        public int LikeCount { get; set; }

        [DisplayName("Kategori")]
        public int CategoryId { get; set; }

        [DisplayName("Ürün Stok")]
        public int ProductStockId { get; set; }

        public virtual ProductStock ProductStocks { get; set; }

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
