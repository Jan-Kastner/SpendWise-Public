using Xunit.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using SpendWise.DAL.UnitOfWork;
using SpendWise.DAL.dbContext;

namespace SpendWise.Common.Tests.Helpers
{
    /// <summary>
    /// Base class for unit tests that involve the <see cref="IDbContext"/> and 
    /// <see cref="IUnitOfWork"/> services. This class handles the setup and teardown 
    /// of the test environment by managing the database context and related services.
    /// </summary>
    public class UnitOfWorkTestsBase : IAsyncLifetime
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkTestsBase"/> class.
        /// Sets up the required services for testing, including database context, 
        /// AutoMapper, and UnitOfWork.
        /// </summary>
        /// <param name="output">
        /// An instance of <see cref="ITestOutputHelper"/> used for logging test output.
        /// This parameter is required and cannot be null.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the <paramref name="output"/> parameter is null.
        /// </exception>
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
        /// This property is used to record output during test execution.
        /// </summary>
        protected ITestOutputHelper Output { get; }

        /// <summary>
        /// Gets the instance of <see cref="IDbContext"/> used in the tests.
        /// This property provides access to the database context.
        /// </summary>
        private IDbContext _SpendWiseDbContextSUT { get; }

        /// <summary>
        /// Gets the instance of <see cref="IMapper"/> used for object mapping in the tests.
        /// This property provides access to AutoMapper functionality.
        /// </summary>
        protected IMapper _mapper { get; }

        /// <summary>
        /// Gets the instance of <see cref="IUnitOfWork"/> used in the tests.
        /// This property provides access to the UnitOfWork implementation.
        /// </summary>
        protected IUnitOfWork _unitOfWork { get; }

        /// <summary>
        /// Initializes the database for testing by ensuring it is deleted and then created.
        /// This method is called before each test is run to provide a clean state.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation of initializing the database.
        /// </returns>
        public async Task InitializeAsync()
        {
            await _SpendWiseDbContextSUT.Database.EnsureDeletedAsync();
            await _SpendWiseDbContextSUT.Database.EnsureCreatedAsync();
        }

        /// <summary>
        /// Disposes of the database context and UnitOfWork after tests have run.
        /// This method ensures that the database is deleted and any resources are 
        /// properly released. It is called after each test has completed.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation of disposing of resources.
        /// </returns>
        public async Task DisposeAsync()
        {
            await _SpendWiseDbContextSUT.Database.EnsureDeletedAsync();
            await _unitOfWork.DisposeAsync();
        }
    }
}
