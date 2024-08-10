using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SpendWise.DAL;
using SpendWise.DAL.Tests.Factories;
using SpendWise.DAL.Mappers;
using SpendWise.DAL.Repositories;
public static class TestServiceProvider
{
    public static IServiceProvider CreateServiceProvider()
    {
        var services = new ServiceCollection();

        services.AddScoped<IDbContextFactory<SpendWiseDbContext>>(provider =>
            new DbContextPostgresTestingFactory($"TestDatabase_{Guid.NewGuid()}", seedTestingData: true));
        
        services.AddScoped<SpendWiseDbContext>(provider =>
        {
            var factory = provider.GetRequiredService<IDbContextFactory<SpendWiseDbContext>>();
            return factory.CreateDbContext();
        });

        services.AddAutoMapper(typeof(MappingProfile));

        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

        return services.BuildServiceProvider();
    }
}
