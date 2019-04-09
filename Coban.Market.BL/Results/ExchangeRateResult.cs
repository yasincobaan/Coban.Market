using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
