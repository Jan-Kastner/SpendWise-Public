using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using SpendWise.DAL.dbContext;

namespace SpendWise.Common.Tests.Helpers
{
    /// <summary>
    /// Base class for tests that involve <see cref="SpendWiseDbContext"/>.
    /// Handles the initialization and disposal of the database context for testing.
    /// </summary>
    public class DbContextTestsBase : IAsyncLifetime
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbContextTestsBase"/> class.
        /// </summary>
        /// <param name="output">An instance of <see cref="ITestOutputHelper"/> used for logging test output.</param>
        public DbContextTestsBase(ITestOutputHelper output)
        {
            Output = output ?? throw new ArgumentNullException(nameof(output));

            _serviceProvider = TestServiceProvider.CreateServiceProvider();
            DbContextFactory = _serviceProvider.GetRequiredService<IDbContextFactory<SpendWiseTestDbContext>>();
            SpendWiseDbContextSUT = _serviceProvider.GetRequiredService<IDbContext>();
        }

        protected ITestOutputHelper Output { get; }

        protected IDbContextFactory<SpendWiseTestDbContext> DbContextFactory { get; }

        protected IDbContext SpendWiseDbContextSUT { get; }

        /// <summary>
        /// Initializes the database for testing by ensuring it is deleted and then created.
        /// This method is called before each test is run.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task InitializeAsync()
        {
            await SpendWiseDbContextSUT.Database.EnsureDeletedAsync();
            await SpendWiseDbContextSUT.Database.EnsureCreatedAsync();
        }

        /// <summary>
        /// Disposes of the database context after tests have run by ensuring the database is deleted.
        /// This method is called after each test has completed.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DisposeAsync()
        {
            await SpendWiseDbContextSUT.Database.EnsureDeletedAsync();
            await SpendWiseDbContextSUT.DisposeAsync();
        }
    }
}
