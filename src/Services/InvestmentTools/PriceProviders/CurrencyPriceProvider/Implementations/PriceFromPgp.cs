using Amazon.Lambda.Core;
using AutoMapper;
using CurrencyPriceProvider.Models.PgDtos;
using Newtonsoft.Json;
using PriceProviders.Shared.Abstractions;
using PriceProviders.Shared.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CurrencyPriceProvider.Implementations
{
    public class PriceFromPgp<T> : IPrice<T> where T:InvestmentToolPrice
    {
        private static HttpClient _client;
        private readonly IMapper _mapper;
        private readonly ILogger<T> _logger;
        public PriceFromPgp(IMapper mapper, ILogger<T> logger)
        {
            _client = new HttpClient();
            _mapper = mapper;
            _logger = logger;
        }

        public Task<List<T>> GetHistoricalPrices(string investmentToolCode, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetCurrentPrice(string investmentToolCode, string url)
        {
            _logger.LogInformation("Url is : " + url);
            if (string.IsNullOrEmpty(url))
            {
                _logger.LogInformation("Could not find Paragaranti Url to retrieve current foreign currency price");
                throw new ArgumentNullException(nameof(url));
            }
            T pgPrice = null;
            try
            {
                _logger.LogInformation("Calling provider's endpoint...");
                HttpResponseMessage response = await _client.GetAsync(url + investmentToolCode);
                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Succesfully took prices from provider...");
                    var pgForeignCurrencyStream = response.Content.ReadAsStreamAsync();
                    _logger.LogInformation("Serializing prices...");
                    var pgPriceDto = await JsonSerializer.DeserializeAsync<PgForeignCurrencyCurrentPriceDto>(await pgForeignCurrencyStream);
                    _logger.LogInformation("Mapping prices...");
                    pgPrice = _mapper.Map<T>(pgPriceDto, o => o.Items["CurrencyCode"] = investmentToolCode);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error occured while getting {investmentToolCode} price." + ex.Message);
            }
            _logger.LogInformation("Completed.");
            return pgPrice;
        }
    }
}
