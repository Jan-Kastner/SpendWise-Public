using SpendWise.BLL.Queries;
using Xunit.Abstractions;
using SpendWise.Common.Tests.Helpers;
using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Categories;
using SpendWise.Common.Tests.Seeds;
using Microsoft.Extensions.DependencyInjection;

namespace SpendWise.BLL.Tests.Handlers
{
    /// <summary>
    /// Contains tests for category-related handlers.
    /// </summary>
    public class CategoryHandlersTests : HandlersTestsBase
    {
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryHandlersTests"/> class.
        /// </summary>
        /// <param name="output">The test output helper.</param>
        public CategoryHandlersTests(ITestOutputHelper output) : base(output)
        {
            _output = output;
        }

        /// <summary>
        /// Tests that the handler returns all category details.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnAllCategoryDetails()
        {
            // Arrange
            var handler = _serviceProvider.GetRequiredService<IGetAllCategoriesHandler<CategoryDetailDto>>();

            // Act
            var result = await handler.Handle(new GetAllItemsQuery());

            // Assert
            Assert.NotNull(result);
            Assert.Contains(result, category => category.Name == CategorySeeds.CategoryFood.Name && category.Color == CategorySeeds.CategoryFood.Color);
            Assert.Contains(result, category => category.Name == CategorySeeds.CategoryTransport.Name && category.Color == CategorySeeds.CategoryTransport.Color);
            Assert.All(result, category =>
            {
                Assert.NotNull(category.Name);
                Assert.NotNull(category.Color);
                Assert.All(category.Transactions, transaction =>
                {
                    Assert.NotEqual(Guid.Empty, transaction.Id);
                    Assert.True(transaction.Amount > 0);
                });
            });
        }

        /// <summary>
        /// Tests that the handler returns all category list DTOs.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnAllCategoryListDtos()
        {
            // Arrange
            var handler = _serviceProvider.GetRequiredService<IGetAllCategoriesHandler<CategoryListDto>>();

            // Act
            var result = await handler.Handle(new GetAllItemsQuery());

            // Assert
            Assert.NotNull(result);
            Assert.Contains(result, category => category.Name == CategorySeeds.CategoryFood.Name && category.Color == CategorySeeds.CategoryFood.Color);
            Assert.Contains(result, category => category.Name == CategorySeeds.CategoryTransport.Name && category.Color == CategorySeeds.CategoryTransport.Color);
            Assert.All(result, category =>
            {
                Assert.NotNull(category.Name);
                Assert.NotNull(category.Color);
            });
        }

        /// <summary>
        /// Tests that the handler returns category summary DTOs.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategorySummaryDtos()
        {
            // Arrange
            var handler = _serviceProvider.GetRequiredService<IGetAllCategoriesHandler<CategorySummaryDto>>();

            // Act
            var result = await handler.Handle(new GetAllItemsQuery());

            // Assert
            Assert.NotNull(result);
            Assert.Contains(result, summary => summary.Name == CategorySeeds.CategoryFood.Name);
            Assert.Contains(result, summary => summary.Name == CategorySeeds.CategoryTransport.Name);
            Assert.All(result, summary =>
            {
                Assert.NotNull(summary.Name);
            });
        }

        /// <summary>
        /// Tests that the handler returns category details by ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryDetailById()
        {
            // Arrange
            var handler = _serviceProvider.GetRequiredService<IGetCategoryByIdHandler<CategoryDetailDto>>();
            var categoryId = CategorySeeds.CategoryFood.Id;

            // Act
            var result = await handler.Handle(new GetItemByIdQuery(categoryId));

            // Assert
            Assert.NotNull(result);
            Assert.Equal(CategorySeeds.CategoryFood.Name, result.Name);
            Assert.Equal(CategorySeeds.CategoryFood.Color, result.Color);
            Assert.All(result.Transactions, transaction =>
            {
                Assert.NotEqual(Guid.Empty, transaction.Id);
                Assert.True(transaction.Amount > 0);
            });
        }

        /// <summary>
        /// Tests that the handler returns category list by ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryListById()
        {
            // Arrange
            var handler = _serviceProvider.GetRequiredService<IGetCategoryByIdHandler<CategoryListDto>>();
            var categoryId = CategorySeeds.CategoryFood.Id;

            // Act
            var result = await handler.Handle(new GetItemByIdQuery(categoryId));

            // Assert
            Assert.NotNull(result);
            Assert.Equal(CategorySeeds.CategoryFood.Name, result.Name);
            Assert.Equal(CategorySeeds.CategoryFood.Color, result.Color);
        }

        /// <summary>
        /// Tests that the handler returns category summary by ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategorySummaryById()
        {
            // Arrange
            var handler = _serviceProvider.GetRequiredService<IGetCategoryByIdHandler<CategorySummaryDto>>();
            var categoryId = CategorySeeds.CategoryFood.Id;

            // Act
            var result = await handler.Handle(new GetItemByIdQuery(categoryId));

            // Assert
            Assert.NotNull(result);
            Assert.Equal(CategorySeeds.CategoryFood.Name, result.Name);
        }
    }
}