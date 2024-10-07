using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpendWise.DAL.Mappers;
using SpendWise.DAL.Repositories;
using SpendWise.DAL.UnitOfWork;
using SpendWise.Common.Tests.Factories;
using SpendWise.DAL.dbContext;
using SpendWise.BLL.Services;
using SpendWise.BLL.Mappers;
using SpendWise.BLL.Handlers;
using SpendWise.BLL.Handlers.Categories;
using SpendWise.BLL.DTOs;
using SpendWise.DAL.Entities;
using SpendWise.DAL.DTOs;

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
            services.AddAutoMapper(typeof(MappingProfile), typeof(CategoryMappingProfile), typeof(TransactionMappingProfile));

            // Register the generic repository.
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            // Register the UnitOfWork and all its dependencies automatically.
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Register a logger for UnitOfWork.
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole(); // Configure console logging
            });

            // Register services for Categories
            services.AddScoped<IService<CategoryCreateDto, CategoryUpdateDto>, CategoryService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IGetAllCategoriesHandler<CategoryDetailDto>, GetAllCategoriesHandler<CategoryDetailDto>>();
            services.AddScoped<IGetAllCategoriesHandler<CategoryListDto>, GetAllCategoriesHandler<CategoryListDto>>();
            services.AddScoped<IGetAllCategoriesHandler<CategorySummaryDto>, GetAllCategoriesHandler<CategorySummaryDto>>();

            services.AddScoped<IGetCategoryByIdHandler<CategoryDetailDto>, GetCategoryByIdHandler<CategoryDetailDto>>();
            services.AddScoped<IGetCategoryByIdHandler<CategoryListDto>, GetCategoryByIdHandler<CategoryListDto>>();
            services.AddScoped<IGetCategoryByIdHandler<CategorySummaryDto>, GetCategoryByIdHandler<CategorySummaryDto>>();

            services.AddScoped<ICreateCommandHandler<CategoryCreateDto>, CreateCommandHandler<CategoryCreateDto, CategoryUpdateDto>>();
            services.AddScoped<IUpdateCommandHandler<CategoryUpdateDto>, UpdateCommandHandler<CategoryCreateDto, CategoryUpdateDto>>();

            return services.BuildServiceProvider();
        }
    }
}
