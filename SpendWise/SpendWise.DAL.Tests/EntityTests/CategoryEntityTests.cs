using Xunit;
using SpendWise.DAL.Entities;
using SpendWise.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using SpendWise.Common.Tests.Helpers;

namespace SpendWise.DAL.Tests.EntityTests
{
    /// <summary>
    /// Contains tests for the <see cref="CategoryEntity"/> entity.
    /// </summary>
    public class CategoryEntityTests : DbContextTestsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryEntityTests"/> class.
        /// </summary>
        /// <param name="output">The output helper instance.</param>
        public CategoryEntityTests(ITestOutputHelper output) : base(output)
        {
        }

        #region CRUD Operations Tests

        /// <summary>
        /// Tests the CRUD (Create, Read, Update, Delete) operations for the <see cref="CategoryEntity"/> entity.
        /// These tests verify that the database operations work as expected for categories.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that fetching a category by its ID returns the expected category.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task FetchCategoryById_ReturnsExpectedCategory()
        {
            // Arrange
            var expectedCategory = CategorySeeds.CategoryFood;
            var categoryIdToFetch = expectedCategory.Id;

            // Act
            var actualCategory = await SpendWiseDbContextSUT.Categories
                .Where(c => c.Id == categoryIdToFetch)
                .SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(actualCategory);
            DeepAssert.Equal(expectedCategory, actualCategory);
        }

        [Fact]
        /// <summary>
        /// Verifies that adding a valid category successfully persists the category in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddCategory_ValidCategory_SuccessfullyPersists()
        {
            // Arrange
            var categoryToAdd = new CategoryEntity
            {
                Id = Guid.NewGuid(),
                Name = "Entertainment",
                Description = "Movies, concerts, and other leisure activities",
                Color = "#00ff00",
                Icon = null
            };

            // Act
            SpendWiseDbContextSUT.Categories.Add(categoryToAdd);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualCategory = await dbx.Categories.FindAsync(categoryToAdd.Id);

            Assert.NotNull(actualCategory);
            DeepAssert.Equal(categoryToAdd, actualCategory);
        }

        [Fact]
        /// <summary>
        /// Verifies that updating an existing category successfully persists the changes in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateCategory_ExistingCategory_SuccessfullyPersistsChanges()
        {
            // Arrange
            var existingCategory = CategorySeeds.CategoryFood;

            var updatedCategory = new CategoryEntity
            {
                Id = existingCategory.Id,
                Name = existingCategory.Name + " Updated",
                Description = existingCategory.Description + " Updated",
                Color = "#00ff01",
                Icon = existingCategory.Icon
            };

            // Act
            SpendWiseDbContextSUT.Categories.Update(updatedCategory);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualCategory = await dbx.Categories
                .FirstOrDefaultAsync(c => c.Id == existingCategory.Id);

            Assert.NotNull(actualCategory);
            DeepAssert.Equal(updatedCategory, actualCategory);
        }

        [Fact]
        /// <summary>
        /// Verifies that deleting an existing category successfully removes it from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteCategory_ExistingCategory_SuccessfullyRemovesCategory()
        {
            // Arrange
            var categoryToDelete = await SpendWiseDbContextSUT.Categories
                .AsNoTracking()
                .FirstAsync(c => c.Id == CategorySeeds.CategoryFood.Id);

            Assert.NotNull(categoryToDelete);
            Assert.True(await SpendWiseDbContextSUT.Categories.AnyAsync(c => c.Id == categoryToDelete.Id));

            // Act
            SpendWiseDbContextSUT.Categories.Remove(categoryToDelete);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var isCategoryDeleted = await dbx.Categories
                .AsNoTracking()
                .AnyAsync(c => c.Id == categoryToDelete.Id);

            Assert.False(isCategoryDeleted);
        }

        #endregion

        #region Error Handling Tests

        /// <summary>
        /// Tests the error handling scenarios for the <see cref="CategoryEntity"/> entity.
        /// This region verifies that the application behaves as expected when invalid data is provided.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that attempting to add a category with invalid data (e.g., invalid color) throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddCategory_InvalidData_ThrowsDbUpdateException()
        {
            // Arrange
            var invalidCategory = new CategoryEntity
            {
                Id = Guid.NewGuid(),
                Name = "Valid Name",
                Description = "Valid Description",
                Color = "#00ff0000", // Invalid Color
                Icon = null
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                SpendWiseDbContextSUT.Categories.Add(invalidCategory);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });

            Assert.NotNull(exception);
        }

        #endregion

        #region Data Retrieval Tests

        /// <summary>
        /// Tests for retrieving category data from the database.
        /// This region verifies that data retrieval methods function correctly and return the expected results.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that fetching a category by its name returns the expected category.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task FetchCategoryByName_ReturnsExpectedCategory()
        {
            // Arrange
            var expectedCategory = CategorySeeds.CategoryFood;
            var categoryNameToFetch = expectedCategory.Name;

            // Act
            var actualCategory = await SpendWiseDbContextSUT.Categories
                .Where(c => c.Name == categoryNameToFetch)
                .SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(actualCategory);
            DeepAssert.Equal(expectedCategory, actualCategory);
        }

        [Fact]
        /// <summary>
        /// Verifies that fetching categories by their color returns the expected category.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task FetchCategoriesByColor_ReturnsExpectedCategories()
        {
            // Arrange
            var expectedCategory = CategorySeeds.CategoryFood;
            var categoryColorToFetch = expectedCategory.Color;

            // Act
            var actualCategory = await SpendWiseDbContextSUT.Categories
                .Where(c => c.Color == categoryColorToFetch)
                .SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(actualCategory);
            DeepAssert.Equal(expectedCategory, actualCategory);
        }

        #endregion

        #region Update and Special Cases Tests

        /// <summary>
        /// Tests for various update scenarios and edge cases for the <see cref="CategoryEntity"/> entity.
        /// This region verifies that updates work correctly, including maximum field lengths and concurrent additions.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that adding a category with maximum field lengths stores the data correctly in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddCategory_MaxFieldLength_StoresDataCorrectly()
        {
            // Arrange
            var categoryToAdd = new CategoryEntity
            {
                Id = Guid.NewGuid(),
                Name = new string('A', 100),
                Description = new string('B', 200),
                Color = "#123456",
                Icon = null
            };

            // Act
            await SpendWiseDbContextSUT.Categories.AddAsync(categoryToAdd);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualCategory = await dbx.Categories
                .Where(c => c.Id == categoryToAdd.Id)
                .SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(actualCategory);
            Assert.Equal(categoryToAdd.Name, actualCategory.Name);
            Assert.Equal(categoryToAdd.Description, actualCategory.Description);
        }

        [Fact]
        /// <summary>
        /// Verifies that concurrent additions of categories successfully persist all categories in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddCategories_ConcurrentAdditions_SuccessfullyPersistAllCategories()
        {
            // Arrange
            var categoriesToAdd = Enumerable.Range(0, 10).Select(i => new CategoryEntity
            {
                Id = Guid.NewGuid(),
                Name = $"Category{i}",
                Description = $"Description{i}",
                Color = $"#ff000{i}",
                Icon = null
            }).ToList();

            // Act
            var tasks = categoriesToAdd.Select(async category =>
            {
                await using var dbx = await DbContextFactory.CreateDbContextAsync();
                dbx.Categories.Add(category);
                await dbx.SaveChangesAsync();
            });

            await Task.WhenAll(tasks);

            // Assert
            var verificationTasks = categoriesToAdd.Select(async category =>
            {
                await using var dbx = await DbContextFactory.CreateDbContextAsync();
                var actualCategory = await dbx.Categories.FindAsync(category.Id);
                Assert.NotNull(actualCategory);
                DeepAssert.Equal(category, actualCategory);
            });

            await Task.WhenAll(verificationTasks);
        }

        #endregion

        #region Related Entities Handling Tests

        /// <summary>
        /// Tests for handling related entities, specifically navigation properties for the <see cref="CategoryEntity"/>.
        /// This region ensures that related data, such as transactions, is correctly loaded and accessible.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that fetching a category correctly loads its navigation properties, particularly the associated transactions.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task FetchCategory_NavigationPropertiesAreCorrectlyLoaded()
        {
            // Arrange
            var expectedCategory = CategorySeeds.CategoryTransport;
            var categoryIdToFetch = expectedCategory.Id;
            var expectedTransactions = expectedCategory.Transactions;

            // Act
            var actualCategory = await SpendWiseDbContextSUT.Categories
                .Where(c => c.Id == categoryIdToFetch)
                .Include(c => c.Transactions) // Include the Transactions navigation property
                .SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(actualCategory);
            DeepAssert.Equal(expectedCategory, actualCategory);
            Assert.NotEmpty(actualCategory.Transactions);

            foreach (var expectedTransaction in expectedTransactions)
            {
                DeepAssert.Contains(expectedTransaction, actualCategory.Transactions);
            }
        }

        #endregion

        #region Consistency Tests

        /// <summary>
        /// Tests to ensure the integrity of data and constraints after operations on the <see cref="CategoryEntity"/>.
        /// This region verifies that relationships and data integrity remain consistent after deletions and modifications.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that after deleting a category, the associated transactions have their CategoryId set to null,
        /// ensuring referential integrity is maintained.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteCategory_CheckIntegrityConstraints_AfterDeletion()
        {
            // Arrange
            var existingCategoryId = CategorySeeds.CategoryTransport.Id;
            var expectedTransactions = CategorySeeds.CategoryTransport.Transactions;

            // Act
            var categoryToDelete = await SpendWiseDbContextSUT.Categories
                .Where(c => c.Id == existingCategoryId)
                .Include(c => c.Transactions)
                .SingleOrDefaultAsync();

            Assert.NotNull(categoryToDelete);

            var transactionsToCheck = categoryToDelete.Transactions;

            SpendWiseDbContextSUT.Categories.Remove(categoryToDelete);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualTransactions = await dbx.Transactions
                .Where(t => transactionsToCheck.Select(tr => tr.Id).Contains(t.Id))
                .ToListAsync();

            Assert.All(actualTransactions, t =>
            {
                Assert.Null(t.CategoryId);  // Verify that CategoryId is null after Category deletion
            });
        }

        #endregion
    }
}