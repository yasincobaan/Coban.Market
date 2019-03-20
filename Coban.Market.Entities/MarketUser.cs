using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Coban.Market.Entities.Enums;

namespace Coban.Market.Entities
{
    [Table("MarketUsers")]
    public class MarketUser : MyEntityBase
    {
        [DisplayName("İsim"), StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Name { get; set; }

        [DisplayName("Soyad"), StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Surname { get; set; }

        [DisplayName("Kullanıcı Adı"), Required(ErrorMessage = "{0} alanı gereklidir."), StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Username { get; set; }

        [DisplayName("E-Posta"), Required(ErrorMessage = "{0} alanı gereklidir."), StringLength(70, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Email { get; set; }

        [DisplayName("Şifre"), Required(ErrorMessage = "{0} alanı gereklidir."), StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Password { get; set; }

        [StringLength(30), ScaffoldColumn(false)]
        public string ProfileImageFilename { get; set; }

        [DisplayName("Rolü")]
        public MarketUserRole Role { get; set; }

        [DisplayName("Aktif")]
        public bool IsActive { get; set; }

       

        [Required, ScaffoldColumn(false)]
        public Guid ActivateGuid { get; set; }


        public virtual List<Product> Products { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Liked> Likes { get; set; }
    }
}
