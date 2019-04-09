using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using Coban.Market.Entities.Enums;

namespace Coban.Market.Entities
{
    [Table("Products")]
    public class Product : MyEntityBase
    {
        [DisplayName("Ürün Adı")]
        public string ProductName { get; set; }
        [DisplayName("Ürün Markası")]
        public string ProductBrand { get; set; }
        [DisplayName("Döviz Kuru")]
        public PriceExchangeRate ExchangeRate { get; set; }
        [DisplayName("KDV'siz ürün fiyatı")]
        public double Price { get; set; }
        [DisplayName("KDV'siz ürünün indirimli fiyatı")]
        public double DiscountedPrice { get; set; }
        [DisplayName("KDV Yüzdesi")]
        public byte KdvPercent { get; set; }



        [DisplayName("Ürün Resim 1")]
        public string Image1 { get; set; }
        [DisplayName("Ürün Resim 2")]
        public string Image2 { get; set; }
        [DisplayName("Ürün Resim 3")]
        public string Image3 { get; set; }
        [DisplayName("Ürün Resim 4")]
        public string Image4 { get; set; }

        [DisplayName("Açıklama")]
        [AllowHtml]
        public string Description { get; set; }
        [DisplayName("Kısa Açıklama")]
        [AllowHtml]
        public string LittleDescription { get; set; }

        [DisplayName("Satışta mı ?")]
        public bool IsSale { get; set; }
        [DisplayName("Barkod Kodu")]
        public string BarCode { get; set; }
        [DisplayName("Stok Kodu")]
        public int StockCode { get; set; }
        [DisplayName("Stok Adeti")]
        public int Stock { get; set; }

        [DisplayName("Beğenilme Sayısı")]
        public int LikeCount { get; set; }

        [DisplayName("Kategori")]
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
