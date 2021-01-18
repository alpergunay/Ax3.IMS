using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ax3.IMS.Domain.Types;
using Ax3.IMS.Infrastructure.Configuration.Settings;
using Ims.Api.Infrastructure.Data.Import;
using Ims.Domain.DomainModels;
using Ims.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Npgsql;
using Polly;

namespace Ims.Api.Infrastructure.Data
{
    public class ImsContextSeed
    {
        private ILogger<ImsContextSeed> _logger;
        private string _contentRootPath = Directory.GetCurrentDirectory();

        public async Task SeedAsync(ImsContext context, IOptions<ApplicationSettings> settings,
            ILogger<ImsContextSeed> logger)
        {
            _logger = logger;
            var contentRootPath = Directory.GetCurrentDirectory();

            var policy = CreatePolicy(logger, nameof(ImsContextSeed));
            await policy.ExecuteAsync(async () =>
            {
                var useCustomizationData = settings.Value.UseCustomizationData;

                using (context)
                {
                    context.Database.Migrate();
                    foreach (var storeType in Enumeration.GetAll<StoreType>())
                    {
                        if (!context.StoreTypes.Any(x => x.EnumId == storeType.EnumId))
                        {
                            await context.StoreTypes.AddAsync(storeType);
                            await context.SaveChangesAsync();
                        }
                    }
                    foreach (var accountType in Enumeration.GetAll<AccountType>())
                    {
                        if (!context.AccountTypes.Any(x => x.EnumId == accountType.EnumId))
                        {
                            await context.AccountTypes.AddAsync(accountType);
                            await context.SaveChangesAsync();
                        }
                    }

                    foreach (var directionType in Enumeration.GetAll<DirectionType>())
                    {
                        if (!context.DirectionTypes.Any(x => x.EnumId == directionType.EnumId))
                        {
                            await context.DirectionTypes.AddAsync(directionType);
                            await context.SaveChangesAsync();
                        }
                    }
                    foreach (var investmentToolType in Enumeration.GetAll<InvestmentToolType>())
                    {
                        if (!context.InvestmentToolTypes.Any(x => x.EnumId == investmentToolType.EnumId))
                        {
                            await context.InvestmentToolTypes.AddAsync(investmentToolType);
                            await context.SaveChangesAsync();
                        }
                    }
                    foreach (var transactionType in Enumeration.GetAll<TransactionType>())
                    {
                        if (!context.TransactionTypes.Any(x => x.EnumId == transactionType.EnumId))
                        {
                            await context.TransactionTypes.AddAsync(transactionType);
                            await context.SaveChangesAsync();
                        }
                    }

                    //ImportCurrencies(context);
                    //ImportCountries(context);
                    //ImportStocks(context);
                    //ImportGolds(context);
                    //ImportEmtias(context);
                }
            });
        }

        private void ImportEmtias(ImsContext context)
        {
            var emtias = GetJson<List<GoldSeed>>(Path.Combine(_contentRootPath, "Infrastructure", "Data", "Import",
                "emtias.json"));

            foreach (var emtia in emtias)
            {
                var country = context.Set<Country>().FirstOrDefault(c => c.Code == "TR");
                var investmentTool = new InvestmentTool(emtia.Name, emtia.Title, "", InvestmentToolType.Emtia.EnumId);
                context.Set<InvestmentTool>().Add(investmentTool);
            }
            context.SaveChanges();
        }

        private void ImportGolds(ImsContext context)
        {
            var golds = GetJson<List<GoldSeed>>(Path.Combine(_contentRootPath, "Infrastructure", "Data", "Import",
                "golds.json"));

            foreach (var gold in golds)
            {
                var country = context.Set<Country>().FirstOrDefault(c => c.Code == "TR");
                var investmentTool = new InvestmentTool(gold.Name, gold.Title, "", InvestmentToolType.Gold.EnumId);
                context.Set<InvestmentTool>().Add(investmentTool);
            }
            context.SaveChanges();
        }

        private void ImportStocks(ImsContext context)
        {
            var stocks = GetJson<List<StockSeed>>(Path.Combine(_contentRootPath, "Infrastructure", "Data", "Import",
                "stocks.json"));

            foreach (var stock in stocks)
            {
                var country = context.Set<Country>().FirstOrDefault(c => c.Code == "TR");
                var investmentTool = new InvestmentTool(stock.Code, stock.Name,"", InvestmentToolType.Stock.EnumId);
                context.Set<InvestmentTool>().Add(investmentTool);
            }
            context.SaveChanges();
        }

        private void ImportCountries(ImsContext context)
        {
            var countries = GetJson<List<CountrySeed>>(Path.Combine(_contentRootPath, "Infrastructure", "Data", "Import",
                "countries.json"));

            foreach (var country in countries)
            {
                var currency = context.Set<InvestmentTool>().FirstOrDefault(i =>
                    i.InvestmentToolTypeId == InvestmentToolType.Currency.EnumId && i.Code == country.CurrencyCode);

                context.Set<Country>().Add(new Country(country.CountryCode, country.CountryName, currency?.Id));
            }
            context.SaveChanges();
        }

        private void ImportCurrencies(ImsContext context)
        {
            var currencies = GetJson<Dictionary<string, string>>(Path.Combine(_contentRootPath, "Infrastructure", "Data", "Import",
                "currencies.json"));
            foreach (var currency in currencies)
            {
                context.Set<InvestmentTool>().Add(new InvestmentTool(currency.Key, currency.Value, string.Empty,
                    InvestmentToolType.Currency.EnumId));

            }
            context.SaveChanges();
        }

        private AsyncPolicy CreatePolicy(ILogger<ImsContextSeed> logger, string prefix, int retries = 3)
        {
            return Policy.Handle<NpgsqlException>().
                WaitAndRetryAsync(
                    retryCount: retries,
                    sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                    onRetry: (exception, timeSpan, retry, ctx) =>
                    {
                        logger.LogWarning(exception, "[{prefix}] Exception {ExceptionType} with message {Message} detected on attempt {retry} of {retries}", prefix, exception.GetType().Name, exception.Message, retry, retries);
                    }
                );
        }
        private T GetJson<T>(string path)
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
