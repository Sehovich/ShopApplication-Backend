using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AbySalto.Mid.Application.Interfaces;

public class ExpiredBasketItemsWorker : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<ExpiredBasketItemsWorker> _logger;
    private readonly TimeSpan _interval = TimeSpan.FromMinutes(10); 

    public ExpiredBasketItemsWorker(IServiceScopeFactory scopeFactory, ILogger<ExpiredBasketItemsWorker> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _scopeFactory.CreateScope();
            var basketService = scope.ServiceProvider.GetRequiredService<IBasketItemRepository>();

            try
            {
                _logger.LogInformation("⏱ Moving expired basket items...");
                await basketService.MoveExpiredItemsToFavouritesAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "⚠️ Failed to move expired basket items.");
            }

            await Task.Delay(_interval, stoppingToken);
        }
    }
}
