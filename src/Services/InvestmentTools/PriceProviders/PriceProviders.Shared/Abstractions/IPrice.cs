using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceProviders.Shared.Abstractions
{
    public interface IPrice<T>
    {
        Task<List<T>> GetHistoricalPrices(string investmentToolCode,
            DateTime startDate,
            DateTime endDate);
        Task<T> GetCurrentPrice(string investmentToolCode, string url);
    }
}
