using System;
using System.Collections.Generic;
using System.Text;
using CurrencyPriceProvider.Models;

namespace CurrencyPriceProvider.Extensions
{
    public static class DynamoDbExtensions
    {
        public static string ToDynamoDbId(this InvestmentToolPrice itp)
        {
            return itp.PriceDate.ToString("yyyyMMdd") + "#" + itp.InvestmentTool?.Code;
        }
        public static string ToDynamoDbDate(this DateTime date)
        {
            return date.ToString("yyyyMMdd");
        }
        public static string ToDynamoDbDateTime(this DateTime date)
        {
            return date.ToString("yyyyMMddHHmmss");
        }
    }
}
