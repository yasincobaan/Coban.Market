using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Coban.Market.Entities.Enums;

namespace Coban.Market.Entities
{
    [Table("MarketUsers")]
    public class MarketUser : MyEntityBase
    {
        [Required(ErrorMessage = "The name field required."),StringLength(50, MinimumLength = 3, ErrorMessage = "The name field must contain max 50 min 3 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The surname field required."),
         StringLength(50, MinimumLength = 3, ErrorMessage = "The surname field must contain max 50 min 3 characters.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "The username field required."),
         StringLength(50, MinimumLength = 3, ErrorMessage = "The username field must contain max 50 min 3 characters.")]
        public string Username { get; set; }


        [Required(ErrorMessage = "The email field required."),
         StringLength(150, MinimumLength = 3, ErrorMessage = "The email field must contain max 150 min 3 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The password field required."),
         StringLength(50, MinimumLength = 3, ErrorMessage = "The password field must contain max 50 min 3 characters.")]
        public string Password { get; set; }

        [StringLength(30), ScaffoldColumn(false)]
        public string ProfileImageFilename { get; set; }

        public MarketUserRole Role { get; set; }
        public bool IsActive { get; set; }
        public string Job { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        [Required(ErrorMessage = "The phone field required.")]
        public string Phone { get; set; }
        public int? RewardScore { get; set; }
        [Required, ScaffoldColumn(false)]
        public Guid ActivateGuid { get; set; }

        public virtual List<ProductWishlist> Wishlists { get; set; }
        public virtual List<Blog> Blogs { get; set; }
        public virtual List<UserAddress> Address { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Liked> Likes { get; set; }
    }
}
