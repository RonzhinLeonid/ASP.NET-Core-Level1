using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace migrations
{
    internal class Worker : IHostedService
    {
        private readonly IDbContextFactory<ApplicationDataContext> _context;

        public Worker(IDbContextFactory<ApplicationDataContext> context)
        {
            _context = context;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await using var context = _context.CreateDbContext();
            if ((await context.Database.GetPendingMigrationsAsync(cancellationToken)).Any())
            {
                await context.Database.MigrateAsync(cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
