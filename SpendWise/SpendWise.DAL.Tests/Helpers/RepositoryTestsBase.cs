using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using SpendWise.DAL;
using SpendWise.DAL.Tests.Helpers;

namespace SpendWise.DAL.Tests.Helpers
{
    public class RepositoryTestsBase : IAsyncLifetime
    {
        protected readonly IServiceProvider serviceProvider;

        public RepositoryTestsBase(ITestOutputHelper output)
        {
            Output = output;

            serviceProvider = TestServiceProvider.CreateServiceProvider();
            DbContextFactory = serviceProvider.GetRequiredService<IDbContextFactory<SpendWiseDbContext>>();
        }

        protected ITestOutputHelper Output { get; }

        protected IDbContextFactory<SpendWiseDbContext> DbContextFactory { get; }

        public async Task InitializeAsync()
        {
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            await dbx.Database.EnsureDeletedAsync();
            await dbx.Database.EnsureCreatedAsync();
        }

        public async Task DisposeAsync()
        {
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            await dbx.Database.EnsureDeletedAsync();
        }
    }

}
