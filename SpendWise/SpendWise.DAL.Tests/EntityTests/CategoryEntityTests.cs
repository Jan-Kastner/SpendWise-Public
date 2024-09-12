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
        /// Verifies that fetching a category by its ID returns the expected category.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchCategoryById_ShouldReturnExpectedCategory()
        {
            // Arrange
            var expectedCategory = CategorySeeds.CategoryFood;
            var categoryId = expectedCategory.Id;

            // Act
            var actualCategory = await SpendWiseDbContextSUT.Categories
                .SingleOrDefaultAsync(c => c.Id == categoryId);

            // Assert
            Assert.NotNull(actualCategory);
            DeepAssert.Equal(expectedCategory, actualCategory);
        }

        /// <summary>
        /// Verifies that adding a valid category successfully persists the category in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddCategory_ShouldPersistValidCategory()
        {
            // Arrange
            var newCategory = new CategoryEntity
            {
                Id = Guid.NewGuid(),
                Name = "Entertainment",
                Description = "Movies, concerts, and other leisure activities",
                Color = "#00ff00",
                Icon = Array.Empty<byte>()
            };

            // Act
            SpendWiseDbContextSUT.Categories.Add(newCategory);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualCategory = await dbx.Categories.FindAsync(newCategory.Id);

            Assert.NotNull(actualCategory);
            DeepAssert.Equal(newCategory, actualCategory);
        }

        /// <summary>
        /// Verifies that updating an existing category successfully persists the changes in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateCategory_ShouldPersistChanges()
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

        /// <summary>
        /// Verifies that deleting an existing category successfully removes it from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteCategory_ShouldRemoveCategory()
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
        /// Verifies that attempting to add a category with invalid data (e.g., invalid color) throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddCategory_WithInvalidData_ShouldThrowDbUpdateException()
        {
            // Arrange
            var invalidCategory = new CategoryEntity
            {
                Id = Guid.NewGuid(),
                Name = "Valid Name",
                Description = "Valid Description",
                Color = "#00ff0000", // Invalid Color
                Icon = Array.Empty<byte>()
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
        /// Verifies that fetching a category by its name returns the expected category.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchCategoryByName_ShouldReturnExpectedCategory()
        {
            // Arrange
            var expectedCategory = CategorySeeds.CategoryFood;
            var categoryName = expectedCategory.Name;

            // Act
            var actualCategory = await SpendWiseDbContextSUT.Categories
                .SingleOrDefaultAsync(c => c.Name == categoryName);

            // Assert
            Assert.NotNull(actualCategory);
            DeepAssert.Equal(expectedCategory, actualCategory);
        }

        /// <summary>
        /// Verifies that fetching categories by their color returns the expected category.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchCategoriesByColor_ShouldReturnExpectedCategories()
        {
            // Arrange
            var expectedCategory = CategorySeeds.CategoryFood;
            var categoryColor = expectedCategory.Color;

            // Act
            var actualCategory = await SpendWiseDbContextSUT.Categories
                .SingleOrDefaultAsync(c => c.Color == categoryColor);

            // Assert
            Assert.NotNull(actualCategory);
            DeepAssert.Equal(expectedCategory, actualCategory);
        }

        #endregion

        #region Update and Special Cases Tests

        /// <summary>
        /// Verifies that adding a category with maximum field lengths stores the data correctly in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddCategory_WithMaxFieldLength_ShouldStoreDataCorrectly()
        {
            // Arrange
            var newCategory = new CategoryEntity
            {
                Id = Guid.NewGuid(),
                Name = new string('A', 100),
                Description = new string('B', 200),
                Color = "#123456",
                Icon = Array.Empty<byte>()
            };

            // Act
            await SpendWiseDbContextSUT.Categories.AddAsync(newCategory);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualCategory = await dbx.Categories
                .SingleOrDefaultAsync(c => c.Id == newCategory.Id);

            // Assert
            Assert.NotNull(actualCategory);
            Assert.Equal(newCategory.Name, actualCategory.Name);
            Assert.Equal(newCategory.Description, actualCategory.Description);
        }

        /// <summary>
        /// Verifies that concurrent additions of categories successfully persist all categories in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddCategories_Concurrently_ShouldPersistAllCategories()
        {
            // Arrange
            var categoriesToAdd = Enumerable.Range(0, 10).Select(i => new CategoryEntity
            {
                Id = Guid.NewGuid(),
                Name = $"Category{i}",
                Description = $"Description{i}",
                Color = $"#ff000{i}",
                Icon = Array.Empty<byte>()
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
        /// Verifies that fetching a category correctly loads its navigation properties, particularly the associated transactions.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchCategory_ShouldLoadNavigationProperties()
        {
            // Arrange
            var expectedCategory = CategorySeeds.CategoryTransport;
            var categoryId = expectedCategory.Id;
            var expectedTransactions = expectedCategory.Transactions;

            // Act
            var actualCategory = await SpendWiseDbContextSUT.Categories
                .Where(c => c.Id == categoryId)
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
        /// Verifies that after deleting a category, the associated transactions have their CategoryId set to null,
        /// ensuring referential integrity is maintained.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteCategory_ShouldMaintainIntegrityConstraints()
        {
            // Arrange
            var categoryId = CategorySeeds.CategoryTransport.Id;
            var expectedTransactions = CategorySeeds.CategoryTransport.Transactions;

            // Act
            var categoryToDelete = await SpendWiseDbContextSUT.Categories
                .Where(c => c.Id == categoryId)
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