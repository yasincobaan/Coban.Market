using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Coban.Market.Entities
{
    [Table("Products")]
    public class Product : MyEntityBase
    {
        [DisplayName("Satışta mı ?")]
        public bool isSale { get; set; }

        [DisplayName("Barkod Kodu")]
        public string BarCode { get; set; }

        [DisplayName("Ürün Adı")]
        public string ProductName { get; set; }

        [DisplayName("Ürün Markası")]
        public string ProductBrand { get; set; }


        [DisplayName("KDV'siz ürün fiyatı")]
        public int Price { get; set; }

        [DisplayName("KDV'siz ürünün indirimli fiyatı")]
        public string DiscountedPrice { get; set; }

        [DisplayName("KDV Varmı")]
        public bool isKdv { get; set; }

        [DisplayName("KDV Yüzdesi")]
        public bool KdvPercent { get; set; }

        [DisplayName("Açıklama")]
        [AllowHtml]
        public string Description { get; set; }

        [DisplayName("Kısa Açıklama")]
        [AllowHtml]
        public string LittleDescription { get; set; }

        [DisplayName("Stokta mı?")]
        public bool IsStock { get; set; }

        [DisplayName("Stok Adeti")]
        public int Stock { get; set; }

        [DisplayName("Stok Kodu")]
        public string StockCode { get; set; }

        [DisplayName("Beğenilme Sayısı")]
        public int LikeCount { get; set; }


        [DisplayName("Ürün Resim 1")]
        public string Image1 { get; set; }

        [DisplayName("Ürün Resim 2")]
        public string Image2 { get; set; }

        [DisplayName("Ürün Resim 3")]
        public string Image3 { get; set; }

        [DisplayName("Ürün Resim 4")]
        public string Image4 { get; set; }

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
