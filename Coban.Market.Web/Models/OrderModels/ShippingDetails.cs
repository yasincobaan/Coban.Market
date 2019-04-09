using System.ComponentModel.DataAnnotations;

namespace Coban.Market.Web.Models.OrderModels
{
    public class ShippingDetails
    {
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen adres tanımını giriniz.")]
        public string AddressTitle { get; set; }

        [Required(ErrorMessage = "Lütfen bir adres giriniz.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Lütfen şehir giriniz.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Lütfen semt giriniz.")]
        public string District { get; set; }

        [Required(ErrorMessage = "Lütfen mahalle giriniz.")]
        public string Neighborhood { get; set; }

        public string PostCode { get; set; }
    }
}