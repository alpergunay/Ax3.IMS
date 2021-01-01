using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyPriceProvider.Models.PgDtos
{
    public class DataSet
    {
        public double close { get; set; }
        public long date { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double open { get; set; }
        public double value { get; set; }
        public double volume { get; set; }
    }
}
