using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using SpendWise.DAL;
using SpendWise.DAL.Tests.Helpers;

namespace SpendWise.DAL.Tests.Helpers
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
