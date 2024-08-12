using Xunit.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using SpendWise.DAL.UnitOfWork;
using SpendWise.DAL.dbContext;

namespace SpendWise.Common.Tests.Helpers
{
    public class UnitOfWorkTestsBase : IAsyncLifetime
    {

        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbContextTestsBase"/> class.
        /// </summary>
        /// <param name="output">An instance of <see cref="ITestOutputHelper"/> used for logging test output.</param>
        public UnitOfWorkTestsBase(ITestOutputHelper output)
        {
            Output = output ?? throw new ArgumentNullException(nameof(output));

            _serviceProvider = TestServiceProvider.CreateServiceProvider();

            _SpendWiseDbContextSUT = _serviceProvider.GetRequiredService<IDbContext>();

            _mapper = _serviceProvider.GetRequiredService<IMapper>();

            _unitOfWork = _serviceProvider.GetRequiredService<IUnitOfWork>();
        }

        /// <summary>
        /// Gets the output helper used for logging test results.
        /// </summary>
        protected ITestOutputHelper Output { get; }
        private IDbContext _SpendWiseDbContextSUT { get; }

        protected IMapper _mapper {get; }
        protected IUnitOfWork _unitOfWork {get; }

        /// <summary>
        /// Initializes the database for testing by ensuring it is deleted and then created.
        /// This method is called before each test is run.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task InitializeAsync()
        {
            await _SpendWiseDbContextSUT.Database.EnsureDeletedAsync();
            await _SpendWiseDbContextSUT.Database.EnsureCreatedAsync();
        }

        /// <summary>
        /// Disposes of the database context after tests have run by ensuring the database is deleted.
        /// This method is called after each test has completed.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DisposeAsync()
        {
            await _SpendWiseDbContextSUT.Database.EnsureDeletedAsync();
            await _unitOfWork.DisposeAsync();
        }
    }
}
