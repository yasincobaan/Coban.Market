namespace Coban.Market.BL.Results
{
    public class ExchangeRateResult
    {
        public ExchangeRateResult()
        {
            Result = false;
        }

        public bool Result { get; set; }
        public decimal Dollar { get; set; }
        public decimal Euro { get; set; }
    }
}
