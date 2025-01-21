using Xunit.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using SpendWise.BLL.Queries;
using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.Common.Tests.Helpers;
using SpendWise.Common.Tests.Seeds;
using SpendWise.Common.Extensions;

namespace SpendWise.BLL.Tests.ServicesTests
{
    /// <summary>
    /// Contains tests for category-related handlers focusing on relations.
    /// </summary>
    public class CategoryServiceTests : ServicesTestsBase
    {
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryServiceTests"/> class.
        /// </summary>
        /// <param name="output">The test output helper.</param>
        public CategoryServiceTests(ITestOutputHelper output) : base(output)
        {
            _output = output;
        }

        #region List categories
        /// <summary>
        /// Tests that the handler returns the correct category list when the name is "Food".
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryList_WhenQueriedByName()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryFoodList;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryListDto>>();
            var query = new GetCategoriesByCriteriaQuery(name: "Food");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category list when queried by partial name match.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryList_WhenQueriedByNamePartialMatch()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryFoodList;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryListDto>>();
            var query = new GetCategoriesByCriteriaQuery(namePartialMatch: "Foo");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category list when queried by not matching name.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryList_WhenQueriedByNotName()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryTransportList;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryListDto>>();
            var query = new GetCategoriesByCriteriaQuery(notName: "Food");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category list when queried by partial not matching name.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryList_WhenQueriedByNotNamePartialMatch()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryTransportList;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryListDto>>();
            var query = new GetCategoriesByCriteriaQuery(notNamePartialMatch: "Foo");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category list when queried by description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryList_WhenQueriedByDescription()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryFoodList;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryListDto>>();
            var query = new GetCategoriesByCriteriaQuery(description: "Groceries and eating out");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category list when queried by partial description match.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryList_WhenQueriedByDescriptionPartialMatch()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryFoodList;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryListDto>>();
            var query = new GetCategoriesByCriteriaQuery(descriptionPartialMatch: "Groceries");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category list when queried by not matching description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryList_WhenQueriedByNotDescription()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryTransportList;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryListDto>>();
            var query = new GetCategoriesByCriteriaQuery(notDescription: "Groceries and eating out");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category list when queried by partial not matching description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryList_WhenQueriedByNotDescriptionPartialMatch()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryTransportList;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryListDto>>();
            var query = new GetCategoriesByCriteriaQuery(notDescriptionPartialMatch: "Groceries");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category list when queried by color.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryList_WhenQueriedByColor()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryFoodList;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryListDto>>();
            var query = new GetCategoriesByCriteriaQuery(color: "#ff0000");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category list when queried by not matching color.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryList_WhenQueriedByNotColor()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryTransportList;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryListDto>>();
            var query = new GetCategoriesByCriteriaQuery(notColor: "#ff0000");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category list when queried by without description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryList_WhenQueriedByWithoutDescription()
        {
            // Arrange
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryListDto>>();
            var query = new GetCategoriesByCriteriaQuery(withDescription: false);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that the handler returns the correct category list when queried by not without description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryList_WhenQueriedByNotWithoutDescription()
        {
            // Arrange
            var expectedCategories = new List<CategoryListDto>
            {
                ExpectedCategoryServiceResults.CategoryFoodList,
                ExpectedCategoryServiceResults.CategoryTransportList
            };
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryListDto>>();
            var query = new GetCategoriesByCriteriaQuery(withDescription: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedCategory in expectedCategories)
            {
                DeepAssert.Contains(expectedCategory, result);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct category list when queried by without icon.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryList_WhenQueriedByWithoutIcon()
        {
            // Arrange
            var expectedCategories = new List<CategoryListDto>
            {
                ExpectedCategoryServiceResults.CategoryFoodList,
                ExpectedCategoryServiceResults.CategoryTransportList
            };
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryListDto>>();
            var query = new GetCategoriesByCriteriaQuery(withIcon: false);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedCategory in expectedCategories)
            {
                DeepAssert.Contains(expectedCategory, result);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct category list when queried by not without icon.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryList_WhenQueriedByNotWithoutIcon()
        {
            // Arrange
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryListDto>>();
            var query = new GetCategoriesByCriteriaQuery(withIcon: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
        #endregion

        #region Summary categories

        /// <summary>
        /// Tests that the handler returns the correct category summary when the name is "Food".
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategorySummary_WhenQueriedByName()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryFoodSummary;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategorySummaryDto>>();
            var query = new GetCategoriesByCriteriaQuery(name: "Food");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category summary when queried by partial name match.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategorySummary_WhenQueriedByNamePartialMatch()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryFoodSummary;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategorySummaryDto>>();
            var query = new GetCategoriesByCriteriaQuery(namePartialMatch: "Foo");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category summary when queried by not matching name.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategorySummary_WhenQueriedByNotName()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryTransportSummary;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategorySummaryDto>>();
            var query = new GetCategoriesByCriteriaQuery(notName: "Food");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category summary when queried by partial not matching name.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategorySummary_WhenQueriedByNotNamePartialMatch()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryTransportSummary;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategorySummaryDto>>();
            var query = new GetCategoriesByCriteriaQuery(notNamePartialMatch: "Foo");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category summary when queried by description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategorySummary_WhenQueriedByDescription()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryFoodSummary;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategorySummaryDto>>();
            var query = new GetCategoriesByCriteriaQuery(description: "Groceries and eating out");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category summary when queried by partial description match.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategorySummary_WhenQueriedByDescriptionPartialMatch()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryFoodSummary;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategorySummaryDto>>();
            var query = new GetCategoriesByCriteriaQuery(descriptionPartialMatch: "Groceries");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category summary when queried by not matching description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategorySummary_WhenQueriedByNotDescription()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryTransportSummary;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategorySummaryDto>>();
            var query = new GetCategoriesByCriteriaQuery(notDescription: "Groceries and eating out");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category summary when queried by partial not matching description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategorySummary_WhenQueriedByNotDescriptionPartialMatch()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryTransportSummary;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategorySummaryDto>>();
            var query = new GetCategoriesByCriteriaQuery(notDescriptionPartialMatch: "Groceries");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category summary when queried by color.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategorySummary_WhenQueriedByColor()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryFoodSummary;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategorySummaryDto>>();
            var query = new GetCategoriesByCriteriaQuery(color: "#ff0000");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category summary when queried by not matching color.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategorySummary_WhenQueriedByNotColor()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryTransportSummary;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategorySummaryDto>>();
            var query = new GetCategoriesByCriteriaQuery(notColor: "#ff0000");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category summary when queried by without description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategorySummary_WhenQueriedByWithoutDescription()
        {
            // Arrange
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategorySummaryDto>>();
            var query = new GetCategoriesByCriteriaQuery(withDescription: false);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that the handler returns the correct category summary when queried by not without description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategorySummary_WhenQueriedByNotWithoutDescription()
        {
            // Arrange
            var expectedCategories = new List<CategorySummaryDto>
            {
                ExpectedCategoryServiceResults.CategoryFoodSummary,
                ExpectedCategoryServiceResults.CategoryTransportSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategorySummaryDto>>();
            var query = new GetCategoriesByCriteriaQuery(withDescription: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedCategory in expectedCategories)
            {
                DeepAssert.Contains(expectedCategory, result);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct category summary when queried by without icon.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategorySummary_WhenQueriedByWithoutIcon()
        {
            // Arrange
            var expectedCategories = new List<CategorySummaryDto>
            {
                ExpectedCategoryServiceResults.CategoryFoodSummary,
                ExpectedCategoryServiceResults.CategoryTransportSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategorySummaryDto>>();
            var query = new GetCategoriesByCriteriaQuery(withIcon: false);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedCategory in expectedCategories)
            {
                DeepAssert.Contains(expectedCategory, result);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct category summary when queried by not without icon.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategorySummary_WhenQueriedByNotWithoutIcon()
        {
            // Arrange
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategorySummaryDto>>();
            var query = new GetCategoriesByCriteriaQuery(withIcon: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
        #endregion

        #region Detail categories

        /// <summary>
        /// Tests that the handler returns the correct category detail when the name is "Food".
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryDetail_WhenQueriedByName()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryFoodDetail;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryDetailDto>>();
            var query = new GetCategoriesByCriteriaQuery(name: "Food");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category detail when queried by partial name match.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryDetail_WhenQueriedByNamePartialMatch()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryFoodDetail;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryDetailDto>>();
            var query = new GetCategoriesByCriteriaQuery(namePartialMatch: "Foo");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category detail when queried by not matching name.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryDetail_WhenQueriedByNotName()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryTransportDetail;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryDetailDto>>();
            var query = new GetCategoriesByCriteriaQuery(notName: "Food");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category detail when queried by partial not matching name.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryDetail_WhenQueriedByNotNamePartialMatch()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryTransportDetail;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryDetailDto>>();
            var query = new GetCategoriesByCriteriaQuery(notNamePartialMatch: "Foo");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category detail when queried by description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryDetail_WhenQueriedByDescription()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryFoodDetail;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryDetailDto>>();
            var query = new GetCategoriesByCriteriaQuery(description: "Groceries and eating out");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category detail when queried by partial description match.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryDetail_WhenQueriedByDescriptionPartialMatch()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryFoodDetail;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryDetailDto>>();
            var query = new GetCategoriesByCriteriaQuery(descriptionPartialMatch: "Groceries");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category detail when queried by not matching description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryDetail_WhenQueriedByNotDescription()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryTransportDetail;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryDetailDto>>();
            var query = new GetCategoriesByCriteriaQuery(notDescription: "Groceries and eating out");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category detail when queried by partial not matching description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryDetail_WhenQueriedByNotDescriptionPartialMatch()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryTransportDetail;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryDetailDto>>();
            var query = new GetCategoriesByCriteriaQuery(notDescriptionPartialMatch: "Groceries");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category detail when queried by color.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryDetail_WhenQueriedByColor()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryFoodDetail;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryDetailDto>>();
            var query = new GetCategoriesByCriteriaQuery(color: "#ff0000");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category detail when queried by not matching color.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryDetail_WhenQueriedByNotColor()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryTransportDetail;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryDetailDto>>();
            var query = new GetCategoriesByCriteriaQuery(notColor: "#ff0000");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category detail when queried by without description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryDetail_WhenQueriedByWithoutDescription()
        {
            // Arrange
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryDetailDto>>();
            var query = new GetCategoriesByCriteriaQuery(withDescription: false);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that the handler returns the correct category detail when queried by not without description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryDetail_WhenQueriedByNotWithoutDescription()
        {
            // Arrange
            var expectedCategories = new List<CategoryDetailDto>
            {
                ExpectedCategoryServiceResults.CategoryFoodDetail,
                ExpectedCategoryServiceResults.CategoryTransportDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryDetailDto>>();
            var query = new GetCategoriesByCriteriaQuery(withDescription: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedCategory in expectedCategories)
            {
                DeepAssert.Contains(expectedCategory, result);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct category detail when queried by without icon.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryDetail_WhenQueriedByWithoutIcon()
        {
            // Arrange
            var expectedCategories = new List<CategoryDetailDto>
            {
                ExpectedCategoryServiceResults.CategoryFoodDetail,
                ExpectedCategoryServiceResults.CategoryTransportDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryDetailDto>>();
            var query = new GetCategoriesByCriteriaQuery(withIcon: false);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedCategory in expectedCategories)
            {
                DeepAssert.Contains(expectedCategory, result);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct category detail when queried by not without icon.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryDetail_WhenQueriedByNotWithoutIcon()
        {
            // Arrange
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryDetailDto>>();
            var query = new GetCategoriesByCriteriaQuery(withIcon: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
        #endregion

        #region List categories by ID
        /// <summary>
        /// Tests that the handler returns the correct category list when queried by ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryList_WhenQueriedById()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryFoodList;
            var handler = _serviceProvider.GetRequiredService<IGetCategoryByIdQueryHandler<CategoryListDto>>();
            var query = new GetCategoryByIdQuery(CategorySeeds.CategoryFood.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            DeepAssert.Equal(expectedCategory, result);
        }
        #endregion

        #region Summary categories by ID
        /// <summary>
        /// Tests that the handler returns the correct category summary when queried by ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategorySummary_WhenQueriedById()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryFoodSummary;
            var handler = _serviceProvider.GetRequiredService<IGetCategoryByIdQueryHandler<CategorySummaryDto>>();
            var query = new GetCategoryByIdQuery(CategorySeeds.CategoryFood.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            DeepAssert.Equal(expectedCategory, result);
        }
        #endregion

        #region Detail categories by ID
        /// <summary>
        /// Tests that the handler returns the correct category detail when queried by ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryDetail_WhenQueriedById()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryFoodDetail;
            var handler = _serviceProvider.GetRequiredService<IGetCategoryByIdQueryHandler<CategoryDetailDto>>();
            var query = new GetCategoryByIdQuery(CategorySeeds.CategoryFood.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            DeepAssert.Equal(expectedCategory, result);
        }
        #endregion

        #region Detail categories by multiple queries

        /// <summary>
        /// Tests that the handler returns the correct category detail when queried by description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryDetail_WhenQueriedByDescriptionAndColor()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryFoodDetail;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryDetailDto>>();
            var query = new GetCategoriesByCriteriaQuery(description: "Groceries and eating out", color: "#ff0000");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct category detail when queried by partial description match.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryDetail_WhenQueriedByDescriptionPartialMatchAndNotName()
        {
            // Arrange
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryDetailDto>>();
            var query = new GetCategoriesByCriteriaQuery(descriptionPartialMatch: "Groceries", notName: "Food");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that the handler returns the correct category detail when queried by color.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryDetail_WhenQueriedByColorAndNotDescription()
        {
            // Arrange
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryDetailDto>>();
            var query = new GetCategoriesByCriteriaQuery(color: "#ff0000", notDescription: "Groceries and eating out");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that the handler returns the correct category detail when queried by name and color.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnCategoryDetail_WhenQueriedByNameAndColor()
        {
            // Arrange
            var expectedCategory = ExpectedCategoryServiceResults.CategoryFoodDetail;
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryDetailDto>>();
            var query = new GetCategoriesByCriteriaQuery(name: "Food", color: "#ff0000");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedCategory, result.FirstOrDefault());
        }

        #endregion 
    }
}