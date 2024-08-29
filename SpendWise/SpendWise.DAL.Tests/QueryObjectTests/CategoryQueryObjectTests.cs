using Xunit;
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

        #region AND Tests

        /// <summary>
        /// Verifies that querying a category by its ID 
        /// returns the correct entry from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task QueryObject_WithId_ReturnsCorrectEntry()
        {
            // Arrange
            var existingEntry = CategorySeeds.CategoryFood;
            var queryObject = new CategoryQueryObject();

            // Act
            var result = await _unitOfWork.Repository<CategoryEntity, CategoryDto>()
                .GetAsync(queryObject.WithId(existingEntry.Id));

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(existingEntry.Id, result.First().Id);
        }

        /// <summary>
        /// Verifies that querying categories by name 
        /// returns all correct entries associated with that name.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task QueryObject_WithName_ReturnsCorrectEntries()
        {
            // Arrange
            var name = CategorySeeds.CategoryFood.Name;
            var queryObject = new CategoryQueryObject();

            // Act
            var result = await _unitOfWork.Repository<CategoryEntity, CategoryDto>()
                .GetAsync(queryObject.WithName(name));

            // Assert
            Assert.NotNull(result);
            Assert.All(result, entry => Assert.Contains(name, entry.Name));
        }

        /// <summary>
        /// Verifies that querying categories by color 
        /// returns all correct entries associated with that color.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task QueryObject_WithColor_ReturnsCorrectEntries()
        {
            // Arrange
            var color = CategorySeeds.CategoryFood.Color;
            var queryObject = new CategoryQueryObject();

            // Act
            var result = await _unitOfWork.Repository<CategoryEntity, CategoryDto>()
                .GetAsync(queryObject.WithColor(color));

            // Assert
            Assert.NotNull(result);
            Assert.All(result, entry => Assert.Equal(color, entry.Color));
        }

        /// <summary>
        /// Verifies that querying categories by description 
        /// returns all correct entries associated with that description.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task QueryObject_WithDescription_ReturnsCorrectEntries()
        {
            // Arrange
            var description = CategorySeeds.CategoryFood.Description;
            var queryObject = new CategoryQueryObject();

            // Act
            var result = await _unitOfWork.Repository<CategoryEntity, CategoryDto>()
                .GetAsync(queryObject.WithDescription(description));

            // Assert
            Assert.NotNull(result);
            Assert.All(result, entry =>
            {
                Assert.NotNull(entry.Description);
                Assert.NotNull(description);
                Assert.Contains(description, entry.Description);
            });
        }

        /// <summary>
        /// Verifies that querying categories with a null description 
        /// returns all entries that have a null description.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task QueryObject_WithNullDescription_ReturnsEntriesWithNullDescription()
        {
            // Arrange
            var queryObject = new CategoryQueryObject();

            // Act
            var result = await _unitOfWork.Repository<CategoryEntity, CategoryDto>()
                .GetAsync(queryObject.WithNullDescription());

            // Assert
            Assert.NotNull(result);
            Assert.All(result, entry => Assert.Null(entry.Description));
        }

        /// <summary>
        /// Verifies that querying categories with an icon 
        /// returns all entries that have an icon.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task QueryObject_WithIcon_ReturnsEntriesWithIcon()
        {
            // Arrange
            var queryObject = new CategoryQueryObject();

            // Act
            var result = await _unitOfWork.Repository<CategoryEntity, CategoryDto>()
                .GetAsync(queryObject.WithIcon());

            // Assert
            Assert.NotNull(result);
            Assert.All(result, entry => Assert.NotNull(entry.Icon));
        }

        /// <summary>
        /// Verifies that querying categories without an icon 
        /// returns all entries that do not have an icon.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task QueryObject_WithoutIcon_ReturnsEntriesWithoutIcon()
        {
            // Arrange
            var queryObject = new CategoryQueryObject();

            // Act
            var result = await _unitOfWork.Repository<CategoryEntity, CategoryDto>()
                .GetAsync(queryObject.WithoutIcon());

            // Assert
            Assert.NotNull(result);
            Assert.All(result, entry =>
            {
                // Check that Icon is either null or an empty byte array
                Assert.True(entry.Icon.Length == 0);
            });
        }


        /// <summary>
        /// Verifies that querying categories by partial name match 
        /// returns all correct entries that contain the specified text in the name.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task QueryObject_WithNamePartialMatch_ReturnsCorrectEntries()
        {
            // Arrange
            var partialName = "Food";
            var queryObject = new CategoryQueryObject();

            // Act
            var result = await _unitOfWork.Repository<CategoryEntity, CategoryDto>()
                .GetAsync(queryObject.WithNamePartialMatch(partialName));

            // Assert
            Assert.NotNull(result);
            Assert.All(result, entry => Assert.Contains(partialName, entry.Name));
        }

        /// <summary>
        /// Verifies that querying categories by partial description match 
        /// returns all correct entries that contain the specified text in the description.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task QueryObject_WithDescriptionPartialMatch_ReturnsCorrectEntries()
        {
            // Arrange
            var partialDescription = "Groceries"; // Adjust as needed for testing
            var queryObject = new CategoryQueryObject();

            // Act
            var result = await _unitOfWork.Repository<CategoryEntity, CategoryDto>()
                .GetAsync(queryObject.WithDescriptionPartialMatch(partialDescription));

            // Assert
            Assert.NotNull(result);
            Assert.All(result, entry =>
            {
                Assert.NotNull(entry.Description);
                Assert.Contains(partialDescription, entry.Description);
            });
        }

        #endregion
    }
}
