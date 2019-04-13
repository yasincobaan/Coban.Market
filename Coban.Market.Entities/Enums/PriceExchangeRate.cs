using System.ComponentModel.DataAnnotations;

namespace Coban.Market.Entities.Enums
{
    public enum PriceExchangeRate
    {
        TurkishLira = 1,
        Dollar = 100,
        Euro = 101,
        Pound = 102,
        [Display(Name = "Japanese Yen")]
        JapaneseYen = 103
    }
}
