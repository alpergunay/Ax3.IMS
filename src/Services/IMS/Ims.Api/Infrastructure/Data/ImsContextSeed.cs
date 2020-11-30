using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ax3.IMS.Domain.Types;
using Ax3.IMS.Infrastructure.Configuration.Settings;
using Ims.Domain.DomainModels;
using Ims.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql;
using Polly;

namespace Ims.Api.Infrastructure.Data
{
    public class ImsContextSeed
    {
        private ILogger<ImsContextSeed> _logger;

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
                }
            });
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
    }
}
