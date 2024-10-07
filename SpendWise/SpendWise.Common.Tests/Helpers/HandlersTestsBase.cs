using Xunit.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using SpendWise.DAL.UnitOfWork;
using SpendWise.DAL.dbContext;
using SpendWise.BLL.Services;
using SpendWise.BLL.DTOs;

namespace SpendWise.Common.Tests.Helpers
{
    public class HandlersTestsBase : IAsyncLifetime
    {
        protected readonly IServiceProvider _serviceProvider;

        public HandlersTestsBase(ITestOutputHelper output)
        {
            Output = output ?? throw new ArgumentNullException(nameof(output));

            _serviceProvider = TestServiceProvider.CreateServiceProvider();

            _SpendWiseDbContextSUT = _serviceProvider.GetRequiredService<IDbContext>();
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
            _unitOfWork = _serviceProvider.GetRequiredService<IUnitOfWork>();
        }

        protected ITestOutputHelper Output { get; }

        private IDbContext _SpendWiseDbContextSUT { get; }

        protected IMapper _mapper { get; }

        private IUnitOfWork _unitOfWork { get; }

        public async Task InitializeAsync()
        {
            await _SpendWiseDbContextSUT.Database.EnsureDeletedAsync();
            await _SpendWiseDbContextSUT.Database.EnsureCreatedAsync();
        }

        public async Task DisposeAsync()
        {
            await _SpendWiseDbContextSUT.Database.EnsureDeletedAsync();
            await _unitOfWork.DisposeAsync();
        }
    }
}