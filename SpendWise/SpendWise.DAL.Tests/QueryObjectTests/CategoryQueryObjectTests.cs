using Xunit.Abstractions;
using SpendWise.DAL.DTOs;
using SpendWise.Common.Tests.Seeds;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;
using SpendWise.Common.Tests.Helpers;

namespace SpendWise.DAL.Tests.QueryObjectTests
{
    public class CategoryQueryObjectTests : UnitOfWorkTestsBase
    {
        public CategoryQueryObjectTests(ITestOutputHelper output) : base(output)
        {
        }

        #region IdQuery Tests

        /// <summary>
        /// Verifies that querying a category by its ID 
        /// returns the correct entry from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithId_ShouldReturnCorrectCategory()
        {
            // Arrange
            var categoryId = CategorySeeds.CategoryFood.Id;
            var queryObject = new CategoryQueryObject().WithId(categoryId);

            // Act
            var categories = await _unitOfWork.CategoryRepository.ListAsync(queryObject);

            // Assert
            Assert.NotNull(categories);
            Assert.Single(categories);
            Assert.Equal(categoryId, categories.First().Id);
        }

        /// <summary>
        /// Verifies that querying categories by ID using an OR condition 
        /// returns entries matching either of the specified IDs.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithId_ShouldReturnCorrectCategories()
        {
            // Arrange
            var categoryId1 = CategorySeeds.CategoryFood.Id;
            var categoryId2 = CategorySeeds.CategoryTransport.Id;
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.OrWithId(categoryId1).OrWithId(categoryId2));

            // Assert
            Assert.NotNull(categories);
            Assert.All(categories, c => Assert.True(c.Id == categoryId1 || c.Id == categoryId2));
        }

        /// <summary>
        /// Verifies that querying categories with a NOT condition by ID 
        /// excludes the category with the specified ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithId_ShouldExcludeCategory()
        {
            // Arrange
            var categoryId = CategorySeeds.CategoryFood.Id;
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.NotWithId(categoryId));

            // Assert
            Assert.NotNull(categories);
            Assert.DoesNotContain(categories, c => c.Id == categoryId);
        }

        #endregion

        #region NameQuery Tests

        /// <summary>
        /// Verifies that querying categories by name 
        /// returns all correct entries associated with that name.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithName_ShouldReturnCorrectCategories()
        {
            // Arrange
            var categoryName = CategorySeeds.CategoryFood.Name;
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.WithName(categoryName));

            // Assert
            Assert.NotNull(categories);
            Assert.All(categories, c => Assert.Contains(categoryName, c.Name));
        }

        /// <summary>
        /// Verifies that querying categories by partial name match 
        /// returns all correct entries that contain the specified text in the name.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithNamePartialMatch_ShouldReturnCorrectCategories()
        {
            // Arrange
            var partialName = "Food";
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.WithNamePartialMatch(partialName));

            // Assert
            Assert.NotNull(categories);
            Assert.All(categories, c => Assert.Contains(partialName, c.Name));
        }

        /// <summary>
        /// Verifies that querying categories by name using an OR condition 
        /// returns all correct entries that match either of the specified names.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithName_ShouldReturnCorrectCategories()
        {
            // Arrange
            var categoryName1 = CategorySeeds.CategoryFood.Name;
            var categoryName2 = CategorySeeds.CategoryTransport.Name;
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.OrWithName(categoryName1).OrWithName(categoryName2));

            // Assert
            Assert.NotNull(categories);
            Assert.All(categories, c => Assert.True(c.Name == categoryName1 || c.Name == categoryName2));
        }

        /// <summary>
        /// Verifies that querying categories by partial name match using an OR condition 
        /// returns all correct entries that contain either of the specified texts in the name.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithNamePartialMatch_ShouldReturnCorrectCategories()
        {
            // Arrange
            var partialName1 = "Food";
            var partialName2 = "Transport";
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.OrWithNamePartialMatch(partialName1).OrWithNamePartialMatch(partialName2));

            // Assert
            Assert.NotNull(categories);
            Assert.All(categories, c => Assert.True(c.Name.Contains(partialName1) || c.Name.Contains(partialName2)));
        }

        /// <summary>
        /// Verifies that querying categories with a NOT condition by partial name match 
        /// excludes all categories containing the specified text in the name.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithNamePartialMatch_ShouldExcludeCategories()
        {
            // Arrange
            var excludedText = "Food";
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.NotWithNamePartialMatch(excludedText));

            // Assert
            Assert.NotNull(categories);
            Assert.All(categories, c => Assert.DoesNotContain(excludedText, c.Name));
        }

        /// <summary>
        /// Verifies that querying categories with a NOT condition by name 
        /// excludes all categories containing the specified name.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithName_ShouldExcludeCategories()
        {
            // Arrange
            var categoryName = CategorySeeds.CategoryFood.Name;
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.NotWithName(categoryName));

            // Assert
            Assert.NotNull(categories);
            Assert.All(categories, c => Assert.DoesNotContain(categoryName, c.Name));
        }

        #endregion

        #region DescriptionQuery Tests

        /// <summary>
        /// Verifies that querying categories by description 
        /// returns all correct entries associated with that description.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithDescription_ShouldReturnCorrectCategories()
        {
            // Arrange
            var categoryDescription = CategorySeeds.CategoryFood.Description;
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.WithDescription(categoryDescription));

            // Assert
            Assert.NotNull(categories);
            Assert.All(categories, c =>
            {
                Assert.NotNull(c.Description);
                Assert.NotNull(categoryDescription);
                Assert.Contains(categoryDescription, c.Description);
            });
        }

        /// <summary>
        /// Verifies that querying categories by description using an OR condition 
        /// returns all correct entries that contain either of the specified descriptions.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithDescription_ShouldReturnCorrectCategories()
        {
            // Arrange
            var categoryDescription1 = CategorySeeds.CategoryFood.Description;
            var categoryDescription2 = "Transportation expenses";
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.OrWithDescription(categoryDescription1).OrWithDescription(categoryDescription2));

            // Assert
            Assert.NotNull(categories);
            Assert.All(categories, c =>
            {
                Assert.NotNull(c.Description);
                Assert.NotNull(categoryDescription1);
                Assert.NotNull(categoryDescription2);
                Assert.True(c.Description.Contains(categoryDescription1) || c.Description.Contains(categoryDescription2));
            });
        }

        /// <summary>
        /// Verifies that querying categories by partial description match 
        /// returns all correct entries that contain the specified text in the description.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithDescriptionPartialMatch_ShouldReturnCorrectCategories()
        {
            // Arrange
            var partialDescription = "Groceries";
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.WithDescriptionPartialMatch(partialDescription));

            // Assert
            Assert.NotNull(categories);
            Assert.All(categories, c =>
            {
                Assert.NotNull(c.Description);
                Assert.Contains(partialDescription, c.Description);
            });
        }

        /// <summary>
        /// Verifies that querying categories by partial description match using an OR condition 
        /// returns all correct entries that contain either of the specified texts in the description.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithDescriptionPartialMatch_ShouldReturnCorrectCategories()
        {
            // Arrange
            var partialDescription1 = "Groceries";
            var partialDescription2 = "Transportation";
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.OrWithDescriptionPartialMatch(partialDescription1).OrWithDescriptionPartialMatch(partialDescription2));

            // Assert
            Assert.NotNull(categories);
            Assert.All(categories, c =>
            {
                Assert.NotNull(c.Description);
                Assert.True(c.Description.Contains(partialDescription1) || c.Description.Contains(partialDescription2));
            });
        }

        /// <summary>
        /// Verifies that querying categories with a NOT condition by description 
        /// excludes all categories containing the specified description.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithDescription_ShouldExcludeCategories()
        {
            // Arrange
            var categoryDescription = CategorySeeds.CategoryFood.Description;
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.NotWithDescription(categoryDescription));

            // Assert
            Assert.NotNull(categories);
            Assert.All(categories, c =>
            {
                Assert.NotNull(categoryDescription);
                Assert.DoesNotContain(categoryDescription, c.Description);
            });
        }

        /// <summary>
        /// Verifies that querying categories with a NOT condition by partial description match 
        /// excludes all categories containing the specified text in the description.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithDescriptionPartialMatch_ShouldExcludeCategories()
        {
            // Arrange
            var excludedText = "Groceries"; // Adjust as needed for testing
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.NotWithDescriptionPartialMatch(excludedText));

            // Assert
            Assert.NotNull(categories);
            Assert.All(categories, c =>
            {
                Assert.NotNull(c.Description);
                Assert.DoesNotContain(excludedText, c.Description);
            });
        }

        /// <summary>
        /// Verifies that querying categories without a description 
        /// returns all categories that have a null description.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithoutDescription_ShouldReturnCategoriesWithNullDescription()
        {
            // Arrange
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.WithoutDescription());

            // Assert
            Assert.NotNull(categories);
            Assert.All(categories, c =>
            {
                Assert.Null(c.Description);
            });
        }

        /// <summary>
        /// Verifies that querying categories without a description using an OR condition 
        /// returns all categories that have a null description.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithoutDescription_ShouldReturnCategoriesWithNullDescription()
        {
            // Arrange
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.OrWithoutDescription());

            // Assert
            Assert.NotNull(categories);
            Assert.All(categories, c =>
            {
                Assert.Null(c.Description);
            });
        }

        /// <summary>
        /// Verifies that querying categories with a NOT condition for null description 
        /// excludes all categories that have a null description.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithoutDescription_ShouldExcludeCategoriesWithNullDescription()
        {
            // Arrange
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.NotWithoutDescription());

            // Assert
            Assert.NotNull(categories);
            Assert.All(categories, c =>
            {
                Assert.NotNull(c.Description);
            });
        }

        #endregion

        #region ColorQuery Tests

        /// <summary>
        /// Verifies that querying categories by color 
        /// returns all correct entries associated with that color.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithColor_ShouldReturnCorrectCategories()
        {
            // Arrange
            var categoryColor = CategorySeeds.CategoryFood.Color;
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.WithColor(categoryColor));

            // Assert
            Assert.NotNull(categories);
            Assert.All(categories, c => Assert.Equal(categoryColor, c.Color));
        }

        /// <summary>
        /// Verifies that querying categories by color using an OR condition 
        /// returns all correct entries that match either of the specified colors.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithColor_ShouldReturnCorrectCategories()
        {
            // Arrange
            var categoryColor1 = CategorySeeds.CategoryFood.Color;
            var categoryColor2 = CategorySeeds.CategoryTransport.Color;
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.OrWithColor(categoryColor1).OrWithColor(categoryColor2));

            // Assert
            Assert.NotNull(categories);
            Assert.All(categories, c => Assert.True(c.Color == categoryColor1 || c.Color == categoryColor2));
        }

        /// <summary>
        /// Verifies that querying categories with a NOT condition by color 
        /// excludes all categories with the specified color.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithColor_ShouldExcludeCategories()
        {
            // Arrange
            var categoryColor = CategorySeeds.CategoryFood.Color;
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.NotWithColor(categoryColor));

            // Assert
            Assert.NotNull(categories);
            Assert.All(categories, c => Assert.NotEqual(categoryColor, c.Color));
        }

        #endregion

        #region IconQuery Tests

        /// <summary>
        /// Verifies that querying categories with an icon 
        /// returns all entries that have an icon.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithIcon_ShouldReturnCategoriesWithIcon()
        {
            // Arrange
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.WithIcon());

            // Assert
            Assert.NotNull(categories);
            Assert.All(categories, c => Assert.True(c.Icon.Length > 0));
        }

        /// <summary>
        /// Verifies that querying categories with an icon using an OR condition 
        /// returns all entries that have an icon.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithIcon_ShouldReturnCategoriesWithIcon()
        {
            // Arrange
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.OrWithIcon());

            // Assert
            Assert.NotNull(categories);
            Assert.All(categories, c => Assert.True(c.Icon.Length > 0));
        }

        /// <summary>
        /// Verifies that querying categories with a NOT condition excludes categories 
        /// that have an icon.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithIcon_ShouldExcludeCategoriesWithIcon()
        {
            // Arrange
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.NotWithIcon());

            // Assert
            Assert.NotNull(categories);
            Assert.All(categories, c => Assert.True(c.Icon.Length == 0));
        }

        /// <summary>
        /// Verifies that querying categories without an icon 
        /// returns all entries that do not have an icon.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithoutIcon_ShouldReturnCategoriesWithoutIcon()
        {
            // Arrange
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.WithoutIcon());

            // Assert
            Assert.NotNull(categories);
            Assert.All(categories, c => Assert.True(c.Icon.Length == 0));
        }

        /// <summary>
        /// Verifies that querying categories without an icon using an OR condition 
        /// returns all entries that do not have an icon.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithoutIcon_ShouldReturnCategoriesWithoutIcon()
        {
            // Arrange
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.OrWithoutIcon());

            // Assert
            Assert.NotNull(categories);
            Assert.All(categories, c => Assert.True(c.Icon.Length == 0));
        }

        /// <summary>
        /// Verifies that querying categories with a NOT condition excludes categories 
        /// that do not have an icon.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithoutIcon_ShouldExcludeCategoriesWithoutIcon()
        {
            // Arrange
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.NotWithoutIcon());

            // Assert
            Assert.NotNull(categories);
            Assert.All(categories, c => Assert.True(c.Icon.Length > 0));
        }

        #endregion

        #region Complex Tests

        /// <summary>
        /// Verifies that querying categories by ID and Name using AND condition
        /// returns entries that match both criteria.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithIdAndName_ShouldReturnCorrectEntry()
        {
            // Arrange
            var categoryId = CategorySeeds.CategoryFood.Id;
            var categoryName = CategorySeeds.CategoryFood.Name;
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.WithId(categoryId).WithName(categoryName));

            // Assert
            Assert.NotNull(categories);
            Assert.Single(categories);
            Assert.Equal(categoryId, categories.First().Id);
            Assert.Equal(categoryName, categories.First().Name);
        }

        /// <summary>
        /// Verifies that querying categories by Color and Description using AND condition
        /// returns entries that match both criteria.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithColorAndDescription_ShouldReturnCorrectEntries()
        {
            // Arrange
            var categoryColor = CategorySeeds.CategoryFood.Color;
            var categoryDescription = CategorySeeds.CategoryFood.Description;
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.WithColor(categoryColor).WithDescription(categoryDescription!));

            // Assert
            Assert.NotNull(categories);
            Assert.Single(categories);
            Assert.Equal(categoryColor, categories.First().Color);
            Assert.Equal(categoryDescription, categories.First().Description);
        }

        /// <summary>
        /// Verifies that querying categories by Name or Color using OR condition
        /// returns entries that match either criterion.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithNameOrColor_ShouldReturnCorrectEntries()
        {
            // Arrange
            var categoryName = CategorySeeds.CategoryFood.Name;
            var categoryColor = CategorySeeds.CategoryFood.Color;
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.OrWithName(categoryName).OrWithColor(categoryColor));

            // Assert
            Assert.NotNull(categories);
            Assert.NotEmpty(categories);
            Assert.All(categories, c => Assert.True(c.Name == categoryName || c.Color == categoryColor));
        }

        /// <summary>
        /// Verifies that querying categories by Name and Description using AND 
        /// and excluding a specific color using NOT condition works together.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithNameAndDescriptionNotWithColor_ShouldReturnCorrectEntries()
        {
            // Arrange
            var categoryName = CategorySeeds.CategoryFood.Name;
            var categoryDescription = CategorySeeds.CategoryFood.Description;
            var excludedColor = CategorySeeds.CategoryTransport.Color;
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.WithName(categoryName)
                                     .WithDescription(categoryDescription!)
                                     .NotWithColor(excludedColor));

            // Assert
            Assert.NotNull(categories);
            Assert.All(categories, c =>
            {
                bool isNameMatch = c.Name == categoryName;
                bool isDescriptionMatch = c.Description == categoryDescription;
                bool isColorMatch = c.Color == excludedColor;

                Assert.True(isNameMatch && isDescriptionMatch && !isColorMatch);
            });
        }

        /// <summary>
        /// Verifies that querying categories by partial Name or Description using OR condition
        /// and excluding a specific ID using NOT condition works together.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithNamePartialMatchNotWithId_ShouldReturnCorrectEntries()
        {
            // Arrange
            var excludedCategoryId = CategorySeeds.CategoryFood.Id;
            var queryObject = new CategoryQueryObject();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.OrWithNamePartialMatch("Foo").NotWithId(excludedCategoryId));

            // Assert
            Assert.NotNull(categories);
            Assert.All(categories, c =>
            {
                Assert.Contains("Foo", c.Name);
                Assert.NotEqual(excludedCategoryId, c.Id);
            });
        }

        #endregion

        #region RelationsQuery Tests

        /// <summary>
        /// Verifies that querying a category with transactions by its ID 
        /// returns the correct entry from the database, including the associated transactions.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithIdIncludingTransactions_ShouldReturnCorrectCategoryWithTransactions()
        {
            // Arrange
            var expectedCategory = CategorySeeds.CategoryFood;
            var queryObject = new CategoryQueryObject();

            queryObject.Relations.IncludeTransactions();

            // Act
            var categories = await _unitOfWork.CategoryRepository
                .ListAsync(queryObject.WithId(expectedCategory.Id));

            // Assert
            Assert.NotNull(categories);
            Assert.Single(categories);
            Assert.Equal(expectedCategory.Id, categories.First().Id);
            Assert.NotNull(categories.First().Transactions);
            Assert.All(categories.First().Transactions, t => Assert.Equal(expectedCategory.Id, t.CategoryId));
        }

        #endregion
    }
}
