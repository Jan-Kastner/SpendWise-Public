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
    /// Base class for repository tests that handles the initialization and disposal
    /// of the database context for testing.
    /// </summary>
    public class RepositoryTestsBase : IAsyncLifetime
    {
        /// <summary>
        /// Gets the service provider for dependency injection.
        /// </summary>
        protected readonly IServiceProvider serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryTestsBase"/> class.
        /// </summary>
        /// <param name="output">An instance of <see cref="ITestOutputHelper"/> used for logging test output.</param>
        public RepositoryTestsBase(ITestOutputHelper output)
        {
            Output = output ?? throw new ArgumentNullException(nameof(output));

            serviceProvider = TestServiceProvider.CreateServiceProvider();
            DbContextFactory = serviceProvider.GetRequiredService<IDbContextFactory<SpendWiseDbContext>>();
        }

        /// <summary>
        /// Gets the test output helper used for logging test output.
        /// </summary>
        protected ITestOutputHelper Output { get; }

        /// <summary>
        /// Gets the factory used to create instances of <see cref="SpendWiseDbContext"/>.
        /// </summary>
        protected IDbContextFactory<SpendWiseDbContext> DbContextFactory { get; }

        /// <summary>
        /// Initializes the database for testing by ensuring it is deleted and then created.
        /// This method is called before each test is run.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task InitializeAsync()
        {
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            await dbx.Database.EnsureDeletedAsync();
            await dbx.Database.EnsureCreatedAsync();
        }

        /// <summary>
        /// Disposes of the database context after tests have run by ensuring the database is deleted.
        /// This method is called after each test has completed.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DisposeAsync()
        {
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            await dbx.Database.EnsureDeletedAsync();
        }
    }
}
