using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyPriceProvider.Abstractions
{
    public interface IPrice<T>
    {
        Task<List<T>> GetHistoricalPrices(string investmentToolCode,
            DateTime startDate,
            DateTime endDate);
        List<string> GetInvestmentToolCodes();
        Task<T> GetCurrentPrice(string investmentToolCode, string url);
    }
}
