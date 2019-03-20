using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Coban.Market.Entities.ValueObjects
{
    public class LoginViewModel
    {
        [DisplayName("E-posta"), Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(150, ErrorMessage = "{0} max. {1} karakter olmalı."), EmailAddress(ErrorMessage = "{0} alanı için geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [DisplayName("Şifre"), Required(ErrorMessage = "{0} alanı boş geçilemez."), DataType(DataType.Password), StringLength(25, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string Password { get; set; }
    }
}