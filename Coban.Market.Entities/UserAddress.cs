using Coban.Market.Entities.Enums;

namespace Coban.Market.Entities
{
    public class UserAddress : MyEntityBase
    {
        public AddressTypes AddressType { get; set; }
        public string AddressTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighborhood { get; set; }
        public string PostCode { get; set; }
        public int MarketUserId { get; set; }
        public virtual MarketUser User { get; set; }


    }
}
