using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using SpendWise.DAL;
using SpendWise.DAL.Tests.Helpers;

namespace SpendWise.DAL.Tests.Helpers
{
    public class DbContextTestsBase : IAsyncLifetime
    {
        private readonly IServiceProvider _serviceProvider;

        public DbContextTestsBase(ITestOutputHelper output)
        {
            Output = output;

            _serviceProvider = TestServiceProvider.CreateServiceProvider();
            DbContextFactory = _serviceProvider.GetRequiredService<IDbContextFactory<SpendWiseDbContext>>();
            SpendWiseDbContextSUT = DbContextFactory.CreateDbContext();
        }

        /// <summary>
        /// Gets the output helper used for logging test results.
        /// </summary>
        protected ITestOutputHelper Output { get; }

        /// <summary>
        /// Gets the factory used to create instances of <see cref="SpendWiseDbContext"/>.
        /// </summary>
        protected IDbContextFactory<SpendWiseDbContext> DbContextFactory { get; }

        /// <summary>
        /// Gets the instance of <see cref="SpendWiseDbContext"/> used in tests.
        /// </summary>
        protected SpendWiseDbContext SpendWiseDbContextSUT { get; }

        public async Task InitializeAsync()
        {
            await SpendWiseDbContextSUT.Database.EnsureDeletedAsync();
            await SpendWiseDbContextSUT.Database.EnsureCreatedAsync();
        }

        public async Task DisposeAsync()
        {
            await SpendWiseDbContextSUT.Database.EnsureDeletedAsync();
            await SpendWiseDbContextSUT.DisposeAsync();
        }
    }
}
