using System;

namespace PriceProviders.Shared.Extensions
{
    public static class DynamoDbExtensions
    {
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
