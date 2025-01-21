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
    /// Base class for unit tests that involve the <see cref="IDbContext"/> and 
    /// <see cref="IDbContextFactory{TContext}"/>. This class handles the initialization 
    /// and disposal of the database context for testing.
    /// </summary>
    public class DbContextTestsBase : IAsyncLifetime
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbContextTestsBase"/> class.
        /// Sets up the required services for testing, including the database context 
        /// factory and the database context itself.
        /// </summary>
        /// <param name="output">
        /// An instance of <see cref="ITestOutputHelper"/> used for logging test output.
        /// This parameter is required and cannot be null.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the <paramref name="output"/> parameter is null.
        /// </exception>
        public DbContextTestsBase(ITestOutputHelper output)
        {
            Output = output ?? throw new ArgumentNullException(nameof(output));

            _serviceProvider = TestServiceProvider.CreateServiceProvider();

            DbContextFactory = _serviceProvider
                .GetRequiredService<IDbContextFactory<SpendWiseTestDbContext>>();
            SpendWiseDbContextSUT = _serviceProvider.GetRequiredService<IDbContext>();
        }

        /// <summary>
        /// Gets the output helper used for logging test results.
        /// This property is used to record output during test execution.
        /// </summary>
        protected ITestOutputHelper Output { get; }

        /// <summary>
        /// Gets the factory for creating instances of <see cref="SpendWiseTestDbContext"/>.
        /// This property provides access to the database context factory used in the tests.
        /// </summary>
        protected IDbContextFactory<SpendWiseTestDbContext> DbContextFactory { get; }

        /// <summary>
        /// Gets the instance of <see cref="IDbContext"/> used in the tests.
        /// This property provides access to the database context being tested.
        /// </summary>
        protected IDbContext SpendWiseDbContextSUT { get; }

        /// <summary>
        /// Initializes the database for testing by ensuring it is deleted and then created.
        /// This method is called before each test is run to provide a clean state.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation of initializing the database.
        /// </returns>
        public async Task InitializeAsync()
        {
            await SpendWiseDbContextSUT.Database.EnsureDeletedAsync();
            await SpendWiseDbContextSUT.Database.EnsureCreatedAsync();
        }

        /// <summary>
        /// Disposes of the database context after tests have run by ensuring the database 
        /// is deleted and the context is properly disposed of. This method is called 
        /// after each test has completed.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation of disposing of the database context.
        /// </returns>
        public async Task DisposeAsync()
        {
            await SpendWiseDbContextSUT.Database.EnsureDeletedAsync();
            await SpendWiseDbContextSUT.DisposeAsync();
        }
    }
}
