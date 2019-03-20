using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Coban.Market.Entities
{
    [Table("Comments")]
    public class Comment : MyEntityBase
    {
        [Required, StringLength(300)]
        public string Text { get; set; }

        public virtual Product Products { get; set; }
        public virtual MarketUser Owner { get; set; }
    }
}
