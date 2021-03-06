﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Coban.Market.Entities.ValueObjects
{
    public class AccountViewModel
    {
        [DisplayName("İsim"),
         Required(ErrorMessage = "{0} alanı boş geçilemez."),
         StringLength(25, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string FirstName { get; set; }

        [DisplayName("Soyisim"),
         Required(ErrorMessage = "{0} alanı boş geçilemez."),
         StringLength(25, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string LastName { get; set; }


        [DisplayName("Kullanıcı adı"), 
         Required(ErrorMessage = "{0} alanı boş geçilemez."),
         StringLength(25, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string Username { get; set; }

        [DisplayName("E-posta"), 
         Required(ErrorMessage = "{0} alanı boş geçilemez."), 
         StringLength(150, ErrorMessage = "{0} max. {1} karakter olmalı."), 
         EmailAddress(ErrorMessage = "{0} alanı için geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [DisplayName("Şifre"),
         Required(ErrorMessage = "{0} alanı boş geçilemez."), 
         DataType(DataType.Password), 
         StringLength(25, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string Password { get; set; }

        [DisplayName("Şifre Tekrar"), 
         Required(ErrorMessage = "{0} alanı boş geçilemez."),
         DataType(DataType.Password), 
         StringLength(25, ErrorMessage = "{0} max. {1} karakter olmalı."), 
         Compare("Password", ErrorMessage = "{0} ile {1} uyuşmuyor.")]
        public string RePassword { get; set; }


        [DisplayName("Telefon Numarası"),
         Required(ErrorMessage = "{0} alanı boş geçilemez."),
         StringLength(25, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string Phone { get; set; }
    }
}