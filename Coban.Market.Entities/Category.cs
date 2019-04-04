﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coban.Market.Entities
{
    [Table("Categories")]
    public class Category : MyEntityBase
    {
        [DisplayName("Kategori"), Required(ErrorMessage = "{0} alanı gereklidir."), StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter içermeli.")]
        public string Title { get; set; }

        [DisplayName("Açıklama"), StringLength(150, ErrorMessage = "{0} alanı max. {1} karakter içermeli.")]
        public string Description { get; set; }

        [DisplayName("Kategori Resmi")]
        public string Image { get; set; }

        public int? CategoryId { get; set; }
        public virtual List<Category> Categories { get; set; }
        
        public virtual List<Product> Products { get; set; }

        public Category()
        {
            Products = new List<Product>();
        }
    }
}
