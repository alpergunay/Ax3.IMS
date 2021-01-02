using CurrencyPriceProvider.Abstractions;
using CurrencyPriceProvider.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using CurrencyPriceProvider.Models.PgDtos;
using AutoMapper;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CurrencyPriceProvider.Implementations
{
    public class PriceFromPgp<T> : IPrice<T> where T:InvestmentToolPrice
    {
        private static HttpClient _client;
        private readonly IMapper _mapper;
        public PriceFromPgp(IMapper mapper)
        {
            _client = new HttpClient();
            _mapper = mapper;
        }

        public Task<List<T>> GetHistoricalPrices(string investmentToolCode, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public List<string> GetInvestmentToolCodes()
        {
            //TODO: Get list with API Call
            var list = new List<string> {"USD", "EUR"};
            return list;
        }

        public async Task<T> GetCurrentPrice(string investmentToolCode, string url)
        {
            LambdaLogger.Log("Url is : " + url);
            if (string.IsNullOrEmpty(url))
            {
                LambdaLogger.Log("Could not find Paragaranti Url to retrieve current foreign currency price");
                throw new ArgumentNullException(nameof(url));
            }
            T pgPrice = null;
            try
            {
                LambdaLogger.Log("Calling provider's endpoint...");
                HttpResponseMessage response = await _client.GetAsync(url + investmentToolCode);
                if (response.IsSuccessStatusCode)
                {
                    LambdaLogger.Log("Succesfully took prices from provider...");
                    var pgForeignCurrencyStream = response.Content.ReadAsStreamAsync();
                    LambdaLogger.Log("Serializing prices...");
                    var pgPriceDto = await JsonSerializer.DeserializeAsync<PgForeignCurrencyCurrentPriceDto>(await pgForeignCurrencyStream);
                    LambdaLogger.Log("Mapping prices...");
                    pgPrice = _mapper.Map<T>(pgPriceDto, o => o.Items["CurrencyCode"] = investmentToolCode);
                    var obj = JsonConvert.SerializeObject(pgPrice);
                    LambdaLogger.Log(obj);
                }
            }
            catch (Exception ex)
            {
                LambdaLogger.Log($"Unexpected error occured while getting {investmentToolCode} price." + ex.Message);
            }
            LambdaLogger.Log("Completed.");
            return pgPrice;
        }
    }
}
