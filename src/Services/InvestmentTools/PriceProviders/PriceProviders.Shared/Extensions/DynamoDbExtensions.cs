using System;
using System.Collections.Generic;
using System.Text;
using PriceProviders.Shared.Models;

namespace PriceProviders.Shared.Extensions
{
    public static class DynamoDbExtensions
    {
        public static string ToDynamoDbDateId(this InvestmentToolPrice itp)
        {
            return itp.PriceDate.ToString("yyyyMMdd") + "#" + itp.InvestmentTool?.Code;
        }
        public static string ToDynamoDbTimeId(this InvestmentToolPrice itp)
        {
            return itp.PriceDate.ToDynamoDbDateTime() + "#" + itp.InvestmentTool?.Code;
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
