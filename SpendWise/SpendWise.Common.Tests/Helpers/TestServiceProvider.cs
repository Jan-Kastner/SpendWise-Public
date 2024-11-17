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
            services.AddAutoMapper(
                typeof(MappingProfile),
                typeof(CategoryMappingProfile),
                typeof(TransactionMappingProfile),
                typeof(GroupMappingProfile),
                typeof(UserMappingProfile),
                typeof(InvitationMappingProfile));

            // Register the generic repository.
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            // Register the UnitOfWork and all its dependencies automatically.
            services.AddScoped<IUnitOfWork, UnitOfWork>();

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

            // Register the specific handlers for Group
            services.AddScoped<ICreateGroupCommandHandler, CreateGroupCommandHandler>();
            services.AddScoped<IDeleteGroupCommandHandler, DeleteGroupCommandHandler>();
            services.AddScoped(typeof(IGetGroupByIdQueryHandler<>), typeof(GetGroupByIdQueryHandler<>));
            services.AddScoped(typeof(IGetGroupsByCriteriaQueryHandler<>), typeof(GetGroupsByCriteriaQueryHandler<>));
            services.AddScoped<IUpdateGroupCommandHandler, UpdateGroupCommandHandler>();

            // Register the GroupService
            services.AddScoped<IGroupService, GroupService>();

            // Register the specific handlers for Invitation
            services.AddScoped<ICreateInvitationCommandHandler, CreateInvitationCommandHandler>();
            services.AddScoped<IDeleteInvitationCommandHandler, DeleteInvitationCommandHandler>();
            services.AddScoped(typeof(IGetInvitationByIdQueryHandler<>), typeof(GetInvitationByIdQueryHandler<>));
            services.AddScoped(typeof(IGetInvitationsByCriteriaQueryHandler<>), typeof(GetInvitationsByCriteriaQueryHandler<>));
            services.AddScoped<IUpdateInvitationCommandHandler, UpdateInvitationCommandHandler>();

            // Register the InvitationService
            services.AddScoped<IInvitationService, InvitationService>();

            // Register the specific handlers for Limit
            services.AddScoped<ICreateLimitCommandHandler, CreateLimitCommandHandler>();
            services.AddScoped<IDeleteLimitCommandHandler, DeleteLimitCommandHandler>();
            services.AddScoped(typeof(IGetLimitByIdQueryHandler<>), typeof(GetLimitByIdQueryHandler<>));
            services.AddScoped(typeof(IGetLimitsByCriteriaQueryHandler<>), typeof(GetLimitsByCriteriaQueryHandler<>));
            services.AddScoped<IUpdateLimitCommandHandler, UpdateLimitCommandHandler>();

            // Register the LimitService
            services.AddScoped<ILimitService, LimitService>();

            // Register the specific handlers for Transaction
            services.AddScoped<ICreateTransactionCommandHandler, CreateTransactionCommandHandler>();
            services.AddScoped<IDeleteTransactionCommandHandler, DeleteTransactionCommandHandler>();
            services.AddScoped(typeof(IGetTransactionByIdQueryHandler<>), typeof(GetTransactionByIdQueryHandler<>));
            services.AddScoped(typeof(IGetTransactionsByCriteriaQueryHandler<>), typeof(GetTransactionsByCriteriaQueryHandler<>));
            services.AddScoped<IUpdateTransactionCommandHandler, UpdateTransactionCommandHandler>();

            // Register the TransactionService
            services.AddScoped<ITransactionService, TransactionService>();

            // Register the specific handlers for User
            services.AddScoped<ICreateUserCommandHandler, CreateUserCommandHandler>();
            services.AddScoped<IDeleteUserCommandHandler, DeleteUserCommandHandler>();
            services.AddScoped(typeof(IGetUserByIdQueryHandler<>), typeof(GetUserByIdQueryHandler<>));
            services.AddScoped(typeof(IGetUsersByCriteriaQueryHandler<>), typeof(GetUsersByCriteriaQueryHandler<>));
            services.AddScoped<IUpdateUserCommandHandler, UpdateUserCommandHandler>();

            // Register the UserService
            services.AddScoped<IUserService, UserService>();

            return services.BuildServiceProvider();
        }
    }
}