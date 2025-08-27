using Gradiscent.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Gradiscent.Infrastructure.Services.ScheduledServices
{
    public class RefreshTokenCleanUpService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<RefreshTokenCleanUpService> _logger;

        public RefreshTokenCleanUpService(IServiceProvider serviceProvider, ILogger<RefreshTokenCleanUpService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();
                    var repo = scope.ServiceProvider.GetRequiredService<IRefreshTokenRepository>();

                    await repo.RemoveExpiredTokensAsync();
                }
                catch (Exception ex) 
                {
                    _logger.LogError(ex, "Error Cleaning up expired refresh tokens");
                }

                await Task.Delay(TimeSpan.FromDays(7),stoppingToken);
            }
        }
    }
}
