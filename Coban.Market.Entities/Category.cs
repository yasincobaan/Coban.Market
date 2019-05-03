using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Coban.Market.Entities
{
    [Table("Categories")]
    public class Category : MyEntityBase
    {
        public Category()
        {
            Products = new List<Product>();
       
        }

        [DataType(DataType.Text), Required(ErrorMessage = "Title field required."), StringLength(50, MinimumLength = 3, ErrorMessage = "The title field must contain max 50 min 3 characters.")]
        public string Title { get; set; }

        [DataType(DataType.Text), Required(ErrorMessage = "Description field required."), StringLength(50, MinimumLength = 3, ErrorMessage = "The description field must contain max 50 min 3 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Image field required.")]
        public string Image { get; set; }

        public int? ParentCategoryId { get; set; }

        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> ChildCategories { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
