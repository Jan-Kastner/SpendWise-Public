using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpendWise.DAL.Mappers;
using SpendWise.DAL.Repositories;
using SpendWise.DAL.UnitOfWork;
using SpendWise.Common.Tests.Factories;
using SpendWise.DAL.dbContext;
using SpendWise.BLL.Mappers;
using SpendWise.DAL.DTOs;
using SpendWise.DAL.Entities;
using AutoMapper;
using SpendWise.BLL.Handlers;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Services;

namespace SpendWise.Common.Tests.Helpers
{
    public static class TestServiceProvider
    {
        /// <summary>
        /// Creates and configures an <see cref="IServiceProvider"/> for use in unit tests.
        /// </summary>
        /// <returns>
        /// An <see cref="IServiceProvider"/> configured with the necessary services for testing.
        /// </returns>
        public static IServiceProvider CreateServiceProvider()
        {
            var services = new ServiceCollection();

            // Configure the database context factory with a test database.
            services.AddScoped<IDbContextFactory<SpendWiseTestDbContext>>(provider =>
                new DbContextPostgresTestingFactory(
                    $"TestDatabase_{Guid.NewGuid()}"));

            // Register the DbContext using the factory.
            services.AddScoped<IDbContext>(provider =>
            {
                var factory = provider.GetRequiredService<IDbContextFactory<SpendWiseTestDbContext>>();
                return factory.CreateDbContext();
            });

            // Register AutoMapper with the mapping profiles.
            services.AddAutoMapper(typeof(MappingProfile), typeof(CategoryMappingProfile), typeof(TransactionMappingProfile), typeof(GroupMappingProfile), typeof(GroupUserMappingProfile), typeof(UserMappingProfile));

            // Register the generic repository.
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            // Register the UnitOfWork and all its dependencies automatically.
            services.AddScoped<IUnitOfWork, UnitOfWork>(provider =>
            {
                var dbContext = provider.GetRequiredService<IDbContext>();
                var logger = provider.GetRequiredService<ILogger<UnitOfWork>>();
                var mapper = provider.GetRequiredService<IMapper>();

                var categoryRepository = provider.GetRequiredService<IRepository<CategoryEntity, CategoryDto>>();
                var groupRepository = provider.GetRequiredService<IRepository<GroupEntity, GroupDto>>();
                var groupUserRepository = provider.GetRequiredService<IRepository<GroupUserEntity, GroupUserDto>>();
                var invitationRepository = provider.GetRequiredService<IRepository<InvitationEntity, InvitationDto>>();
                var limitRepository = provider.GetRequiredService<IRepository<LimitEntity, LimitDto>>();
                var transactionGroupUserRepository = provider.GetRequiredService<IRepository<TransactionGroupUserEntity, TransactionGroupUserDto>>();
                var transactionRepository = provider.GetRequiredService<IRepository<TransactionEntity, TransactionDto>>();
                var userRepository = provider.GetRequiredService<IRepository<UserEntity, UserDto>>();

                return new UnitOfWork(dbContext, logger, mapper, categoryRepository, groupRepository, groupUserRepository, invitationRepository, limitRepository, transactionGroupUserRepository, transactionRepository, userRepository);
            });

            // Register a logger for UnitOfWork.
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole(); // Configure console logging
            });

            // Register the specific handlers for Category
            services.AddScoped<ICreateCategoryCommandHandler, CreateCategoryCommandHandler>();
            services.AddScoped<IDeleteCategoryCommandHandler, DeleteCategoryCommandHandler>();
            services.AddScoped(typeof(IGetCategoryByIdQueryHandler<>), typeof(GetCategoryByIdQueryHandler<>));
            services.AddScoped(typeof(IGetCategoriesByCriteriaQueryHandler<>), typeof(GetCategoriesByCriteriaQueryHandler<>));
            services.AddScoped<IUpdateCategoryCommandHandler, UpdateCategoryCommandHandler>();

            // Register the CategoryService
            services.AddScoped<ICategoryService, CategoryService>();

            return services.BuildServiceProvider();
        }
    }
}