using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using SpendWise.DAL.Factories;
using System;
using System.Threading.Tasks;

namespace SpendWise.DAL.Tests.Helpers
{
    /// <summary>
    /// Provides a base class for database context tests, handling initialization and disposal of the database context.
    /// </summary>
    public class DbContextTestsBase : IAsyncLifetime
    {
        private readonly string _uniqueDbName;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbContextTestsBase"/> class.
        /// </summary>
        /// <param name="output">The output helper for logging test results.</param>
        public DbContextTestsBase(ITestOutputHelper output)
        {
            Output = output;
            _uniqueDbName = $"TestDatabase_{Guid.NewGuid()}"; // Unique database name for each test
            DbContextFactory = new DbContextPostgresTestingFactory(_uniqueDbName, seedTestingData: true);
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
        /// Initializes the database context for tests by ensuring it is created.
        /// </summary>
        public async Task InitializeAsync()
        {
            await SpendWiseDbContextSUT.Database.EnsureDeletedAsync();
            await SpendWiseDbContextSUT.Database.EnsureCreatedAsync();
        }

        /// <summary>
        /// Disposes of the database context and ensures it is deleted after tests are completed.
        /// </summary>
        public async Task DisposeAsync()
        {
            await SpendWiseDbContextSUT.Database.EnsureDeletedAsync();
            await SpendWiseDbContextSUT.DisposeAsync();
        }
    }
}
