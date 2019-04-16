using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coban.Market.Entities
{
    public class ProductWishlist : MyEntityBase
    {

        public int ProductId { get; set; }
        public int MarketUserId { get; set; }
        public virtual MarketUser Owner { get; set; }
        public virtual Product Products { get; set; }
    }
}
