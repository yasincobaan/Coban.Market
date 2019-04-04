using System.ComponentModel.DataAnnotations;

namespace Coban.Market.Entities.Enums
{
    public enum MarketUserRole
    {
        NewUser = 0,
        [Display(Name = "Full Admin")]
        FullAdmin = 100,
        Admin = 101,
        Editör = 102
    }
}
