using Microsoft.Extensions.DependencyInjection;
using SpendWise.BLL.Services;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Handlers;
using SpendWise.BLL.Handlers.Interfaces;

namespace SpendWise.Common.Tests.Helpers
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
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
        }
    }
}