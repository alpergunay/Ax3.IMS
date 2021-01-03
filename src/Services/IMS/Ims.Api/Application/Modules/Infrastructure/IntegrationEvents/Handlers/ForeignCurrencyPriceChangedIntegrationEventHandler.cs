using System.Linq;
using Ax3.IMS.Infrastructure.EventBus.Abstractions;
using Ims.Api.Application.Modules.Infrastructure.IntegrationEvents.Events;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Ax3.IMS.Infrastructure.Core.Exception;
using Ims.Domain.DomainModels;

namespace Ims.Api.Application.Modules.Infrastructure.IntegrationEvents.Handlers
{
    public class ForeignCurrencyPriceChangedIntegrationEventHandler : IIntegrationEventHandler<ForeignCurrencyPriceChangedIntegrationEvent>
    {
        private readonly ILogger<ForeignCurrencyPriceChangedIntegrationEventHandler> _logger;
        private readonly IInvestmentToolPriceRepository _investmentToolPriceRepository;
        private readonly IInvestmentToolRepository _investmentToolRepository;

        public ForeignCurrencyPriceChangedIntegrationEventHandler(
            ILogger<ForeignCurrencyPriceChangedIntegrationEventHandler> logger,
            IInvestmentToolPriceRepository investmentToolPriceRepository,
            IInvestmentToolRepository investmentToolRepository)
        {
            _logger = logger;
            _investmentToolPriceRepository = investmentToolPriceRepository;
            _investmentToolRepository = investmentToolRepository;
        }
        public async Task Handle(ForeignCurrencyPriceChangedIntegrationEvent @event)
        {
            _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", @event.Id, Program.AppName, @event);

            var price = (await _investmentToolPriceRepository
                .FindAsync(p => p.InvestmentTool.Code == @event.CurrencyCode &&
                                p.PriceDate.Date == @event.PriceDate.Date)).FirstOrDefault();

            if (price != null)
            {
                price.UpdatePrices(@event.SalesPrice, @event.BuyingPrice);
                _investmentToolPriceRepository.Update(price);
            }
            else
            {
                var investmentToolId = (await _investmentToolRepository.FindByCodeAsync(@event.CurrencyCode))?.Id;
                if (investmentToolId != null)
                {
                    price = new InvestmentToolPrice(@event.PriceDate.Date, investmentToolId.Value, @event.SalesPrice,
                        @event.BuyingPrice);
                    _investmentToolPriceRepository.Add(price);
                }
                else
                {
                    _logger.LogError("Could not found Currency Code {@currencyCode}. Prices will not insert to database.",
                        @event.CurrencyCode);
                }
            }

            if (price != null)
            {
                await _investmentToolPriceRepository.UnitOfWork.SaveEntitiesAsync();
                _logger.LogInformation("Prices for the Currency {currencyCode} successfully updated...", @event.CurrencyCode);
            }
        }
    }
}
