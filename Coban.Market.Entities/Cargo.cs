using System.ComponentModel.DataAnnotations.Schema;

namespace Coban.Market.Entities
{
    [Table("CargoCompanies")]
    public class Cargo : MyEntityBase
    {
        public string CargoName { get; set; }
        public string CargoPhone { get; set; }
        public string CargoDescription { get; set; }
    }
}
