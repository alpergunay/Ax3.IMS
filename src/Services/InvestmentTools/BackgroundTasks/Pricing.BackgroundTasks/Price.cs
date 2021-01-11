using System;
using System.Collections.Generic;
using System.Text;

namespace Pricing.BackgroundServices
{
    public class Price
    {
        public double last { get; set; }
        public double bid { get; set; }
        public double ask { get; set; }
        public double dailyChangePercentage { get; set; }
    }
}
