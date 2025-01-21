using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SpendWise.Common.Tests.Factories;
using SpendWise.DAL.dbContext;

namespace SpendWise.Common.Tests.Helpers
{
    public static class DatabaseConfiguration
    {
        public static void ConfigureDatabase(IServiceCollection services)
        {
            services.AddScoped<IDbContextFactory<SpendWiseTestDbContext>>(provider =>
                new DbContextPostgresTestingFactory(
                    $"TestDatabase_{Guid.NewGuid()}"));

            services.AddScoped<IDbContext>(provider =>
            {
                var factory = provider.GetRequiredService<IDbContextFactory<SpendWiseTestDbContext>>();
                return factory.CreateDbContext();
            });
        }
    }
}