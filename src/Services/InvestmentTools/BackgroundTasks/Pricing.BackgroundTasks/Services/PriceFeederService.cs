using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Ax3.IMS.Infrastructure.Cache.Redis;
using Ax3.IMS.Infrastructure.EventBus.Abstractions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PriceProviders.Shared.Abstractions;
using PriceProviders.Shared.Models;
using Pricing.BackgroundServices.Events;
using Timer = System.Timers.Timer;

namespace Pricing.BackgroundServices.Services
{
    public class PriceFeederService : BackgroundService
    {
        private readonly ILogger<PriceFeederService> _logger;
        private readonly IEventBus _eventBus;
        private readonly ClientWebSocket _socket;
        private const string PING_MESSAGE = "X";
        private const string PONG_MESSAGE = "1|H";
        private readonly IRepository<InvestmentTool> _repository;
        private readonly ICacheManager _cacheManager;
        public PriceFeederService(ILogger<PriceFeederService> logger, IEventBus eventBus, ClientWebSocket socket,
            IRepository<InvestmentTool> repository, ICacheManager cacheManager)
        {
            _eventBus = eventBus;
            _logger = logger;
            _socket = socket;
            _repository = repository;
            _cacheManager = cacheManager;

            var timer = new Timer
            {
                Interval = 20000,
                AutoReset = true,
                Enabled = true
            };
            timer.Elapsed += SendPingMessage;
        }

        private async void SendPingMessage(object sender, System.Timers.ElapsedEventArgs e)
        {
            await Send(PING_MESSAGE);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("PriceFeederService is starting...");

            stoppingToken.Register(() => _logger.LogDebug("#1 PriceFeederService background task is stopping."));
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogDebug("PriceFeederService background task is started");
                try
                {
                    if (_socket.State == WebSocketState.CloseReceived)
                        await _socket.CloseAsync(WebSocketCloseStatus.InvalidMessageType, "Connection closed", CancellationToken.None);

                    if (_socket.State != WebSocketState.Open)
                    {
                        await _socket.ConnectAsync(
                            new Uri(
                                "wss://web-paragaranti-pubsub.foreks.com/pubsub/broadcaster?X-Atmosphere-tracking-id=0&X-Atmosphere-Framework=2.3.2-javascript&X-Atmosphere-Transport=websocket&X-Atmosphere-TrackMessageSize=true&X-atmo-protocol=true&profile=paragaranti"),
                            CancellationToken.None);
                        await Task.Delay(5000, stoppingToken);
                        await Send(File.ReadAllLines("subscribe.txt")[0]);
                        await Receive();

                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"ERROR - {ex.Message}");
                }
            }

            _logger.LogDebug("GracePeriodManagerService background task is stopping.");

            await Task.CompletedTask;
        }
        private async Task Send(string data)
        {
            _logger.LogInformation(data);
            await _socket.SendAsync(Encoding.UTF8.GetBytes(data), WebSocketMessageType.Text, true, CancellationToken.None);
        }
        private async Task Receive()
        {
            var buffer = new ArraySegment<byte>(new byte[2048]);
            do
            {
                await using (var ms = new MemoryStream())
                {
                    WebSocketReceiveResult result;
                    do
                    {
                        result = await _socket.ReceiveAsync(buffer, CancellationToken.None);
                        ms.Write(buffer.Array, buffer.Offset, result.Count);
                    } while (!result.EndOfMessage);

                    if (result.MessageType == WebSocketMessageType.Close)
                        break;

                    ms.Seek(0, SeekOrigin.Begin);
                    using (var reader = new StreamReader(ms, Encoding.UTF8))
                    {
                        var priceLine = await reader.ReadToEndAsync();
                        try
                        {
                            if (priceLine == PONG_MESSAGE)
                            {
                                _logger.LogInformation(priceLine);
                                continue;
                            }

                            var priceDictionary = JsonConvert.DeserializeObject<Dictionary<string, Price>>(priceLine.Substring(priceLine.IndexOf('|') + 1));
                            if (priceDictionary.Count > 0)
                            {
                                var priceElement = priceDictionary.ElementAt(0);
                                //Redis
                                var investmentTool = await _cacheManager.GetAsync<InvestmentTool>(new CacheKey(priceElement.Key),
                                    () => _repository.ScanWithKey("Key", priceElement.Key));
                                if (investmentTool != null)
                                {
                                    var investmentToolPriceChangedEvent =
                                        new InvestmentToolPriceChangedIntegrationEvent(investmentTool, DateTime.Now, 
                                            priceElement.Value.bid, priceElement.Value.ask);

                                    _logger.LogInformation($"Publishing event {nameof(InvestmentToolPriceChangedIntegrationEvent)} for {investmentTool.Code}...");
                                    _eventBus.Publish(investmentToolPriceChangedEvent);
                                }
                                else
                                {
                                    _logger.LogError("Investment tool could not be found in Redis Cache");
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            _logger.LogError($"Exception occured while converting price line...{e.Message}");
                        }
                        _logger.LogInformation(priceLine);
                    }
                }
            } while (true);
        }
    }
}
