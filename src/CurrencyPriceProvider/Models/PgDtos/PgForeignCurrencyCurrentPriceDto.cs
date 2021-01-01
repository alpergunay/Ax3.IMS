using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyPriceProvider.Models.PgDtos
{
    public class PgForeignCurrencyCurrentPriceDto
    {
        public double totEffectBuyRate { get; set; }
        public double excBuyRate { get; set; }
        public double totExcParity { get; set; }
        public double totExcBuyRate { get; set; }
        public int sortNumber { get; set; }
        public string multDivideType { get; set; }
        public string currApproval { get; set; }
        public int totalDays { get; set; }
        public double effectBuyRate { get; set; }
        public double excParity { get; set; }
        public double effectSellRate { get; set; }
        public double totExcSellRate { get; set; }
        public double unitAmount { get; set; }
        public double totEffectSellRate { get; set; }
        public int currTime { get; set; }
        public int currId { get; set; }
        public double excSellRate { get; set; }
        public int currDate { get; set; }
    }
}
