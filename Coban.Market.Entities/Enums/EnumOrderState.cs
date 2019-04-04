using System.ComponentModel.DataAnnotations;

namespace Coban.Market.Entities.Enums
{
    public enum EnumOrderState
    {
        [Display(Name = "Onay Bekleniyor")]
        Waiting,
        [Display(Name = "Tamamlandı")]
        Completed
    }
}
