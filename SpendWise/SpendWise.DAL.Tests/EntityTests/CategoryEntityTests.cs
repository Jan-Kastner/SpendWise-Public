using SpendWise.DAL.Entities;
using SpendWise.DAL.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using SpendWise.DAL.Tests.Helpers;

namespace SpendWise.DAL.Tests
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

        /// <summary>
        /// Tests if fetching a category by its ID returns the correct category.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetCategory_ById_ReturnsCorrectCategory()
        {
            // Arrange
            var expectedCategory = CategorySeeds.CategoryFood;
            var existingCategoryId = CategorySeeds.CategoryFood.Id;

            // Act
            var category = await SpendWiseDbContextSUT.Categories
                .Where(c => c.Id == existingCategoryId)
                .SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(category);
            DeepAssert.Equal(expectedCategory, category);
        }

        /// <summary>
        /// Tests if adding a valid category persists it in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddCategory_WhenValidCategoryIsAdded_CategoryIsPersisted()
        {
            // Arrange
            var category = new CategoryEntity
            {
                Id = Guid.NewGuid(),
                Name = "Entertainment",
                Description = "Movies, concerts, and other leisure activities",
                Color = "#00ff00",
                Icon = null
            };

            // Act
            SpendWiseDbContextSUT.Categories.Add(category);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualCategory = await dbx.Categories.FindAsync(category.Id);
            Assert.NotNull(actualCategory);
            DeepAssert.Equal(category, actualCategory, propertiesToIgnore: new[] { "Transactions" });
        }

        /// <summary>
        /// Tests if updating an existing category persists the changes.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateCategory_WhenExistingCategoryIsUpdated_ChangesArePersisted()
        {
            // Arrange
            var existingCategory = await SpendWiseDbContextSUT.Categories
                .AsNoTracking()
                .FirstAsync(c => c.Id == CategorySeeds.CategoryFood.Id);

            var updatedCategory = new CategoryEntity
            {
                Id = existingCategory.Id,
                Name = existingCategory.Name + "Updated",
                Description = existingCategory.Description + "Updated",
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
            DeepAssert.Equal(updatedCategory, actualCategory, propertiesToIgnore: new[] { "Transactions" });
        }

        /// <summary>
        /// Tests if deleting a category removes it from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteCategory_WhenCategoryIsDeleted_CategoryIsRemoved()
        {
            // Arrange
            var existingCategory = await SpendWiseDbContextSUT.Categories
                .AsNoTracking()
                .FirstAsync(c => c.Id == CategorySeeds.CategoryFood.Id);

            Assert.NotNull(existingCategory);
            Assert.True(await SpendWiseDbContextSUT.Categories.AnyAsync(c => c.Id == existingCategory.Id));

            // Act
            SpendWiseDbContextSUT.Categories.Remove(existingCategory);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var isCategoryDeleted = await dbx.Categories
                .AsNoTracking()
                .AnyAsync(c => c.Id == existingCategory.Id);

            Assert.False(isCategoryDeleted);
        }

        /// <summary>
        /// Tests if fetching a category by its name returns the correct category.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetCategory_ByName_ReturnsCorrectCategory()
        {
            // Arrange
            var expectedCategory = CategorySeeds.CategoryFood;
            var existingCategoryName = CategorySeeds.CategoryFood.Name;

            // Act
            var category = await SpendWiseDbContextSUT.Categories
                .Where(c => c.Name == existingCategoryName)
                .SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(category);
            DeepAssert.Equal(expectedCategory, category);
        }

        /// <summary>
        /// Tests if fetching categories by their color returns the correct categories.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetCategories_ByColor_ReturnsCorrectCategories()
        {
            // Arrange
            var expectedCategory = CategorySeeds.CategoryFood;
            var existingCategoryColor = CategorySeeds.CategoryFood.Color;

            // Act
            var category = await SpendWiseDbContextSUT.Categories
                .Where(c => c.Color == existingCategoryColor)
                .SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(category);
            DeepAssert.Equal(expectedCategory, category);
        }

        /// <summary>
        /// Verifies that the navigation properties (Transactions) are properly loaded when querying a category.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task VerifyCategoryNavigationProperties_WhenCategoriesAreFetched_NavigationPropertiesAreLoaded()
        {
            // Arrange
            var expectedCategory = CategorySeeds.CategoryFood;
            var expectedTransactions = CategorySeeds.CategoryFood.Transactions;
            var existingCategoryId = CategorySeeds.CategoryFood.Id;

            // Act
            var category = await SpendWiseDbContextSUT.Categories
                .Where(c => c.Id == existingCategoryId)
                .Include(c => c.Transactions) // Include the Transactions navigation property
                .SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(category); // Ensure the category is not null

            // Deep assert to compare category properties, ignoring the Transactions navigation property
            DeepAssert.Equal(expectedCategory, category, propertiesToIgnore: new[] { "Transactions" });

            // Ensure the Transactions navigation property is not empty
            Assert.NotEmpty(category.Transactions);

            // Deep assert to compare each expected transaction within the Transactions navigation property
            foreach (var expectedTransaction in expectedTransactions)
            {
                DeepAssert.Contains(expectedTransaction, category.Transactions, propertiesToIgnore: new[] { "Category", "TransactionGroupUsers" });
            }
        }
        /// <summary>
        /// Tests that adding multiple categories concurrently persists all categories correctly in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddCategories_Concurrently_CategoriesArePersistedCorrectly()
        {
            // Arrange
            var categories = new List<CategoryEntity>();

            for (int i = 1; i <= 10; i++)
            {
                categories.Add(new CategoryEntity
                {
                    Id = Guid.NewGuid(),
                    Name = $"Category{i}",
                    Description = $"Description for Category{i}",
                    Color = i % 2 == 0 ? "#ff0000" : "#00ff00",
                    Icon = null
                });
            }

            var tasks = categories.Select(async category =>
            {
                await using var dbContext = await DbContextFactory.CreateDbContextAsync();
                dbContext.Categories.Add(category);
                await dbContext.SaveChangesAsync();
            }).ToArray();

            // Act
            await Task.WhenAll(tasks);

            // Assert
            await using var dbContextAssert = await DbContextFactory.CreateDbContextAsync();
            var categoryIds = categories.Select(c => c.Id).ToList();
            var persistedCategories = await dbContextAssert.Categories
                .Where(c => categoryIds.Contains(c.Id))
                .ToListAsync();

            foreach (var category in categories)
            {
                var actualCategory = persistedCategories.SingleOrDefault(c => c.Id == category.Id);
                Assert.NotNull(actualCategory);
                DeepAssert.Equal(category, actualCategory, propertiesToIgnore: new[] { "Transactions" });
            }
        }

        /// <summary>
        /// Tests that adding a category with invalid data (e.g., an invalid color format) throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddCategory_WithInvalidData_ThrowsException()
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

        /// <summary>
        /// Tests that the total number of categories is correctly counted after adding new categories.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetTotalCategories_ReturnsCorrectCount()
        {
            // Arrange
            var initialCount = await SpendWiseDbContextSUT.Categories.CountAsync();
            
            var newCategories = new[]
            {
                new CategoryEntity { Id = Guid.NewGuid(), Name = "CategoryA", Description = "Desc A", Color = "#ff0000", Icon = null },
                new CategoryEntity { Id = Guid.NewGuid(), Name = "CategoryB", Description = "Desc B", Color = "#00ff00", Icon = null }
            };

            // Act
            SpendWiseDbContextSUT.Categories.AddRange(newCategories);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var totalCount = await dbx.Categories.CountAsync();

            // Assert
            Assert.Equal(initialCount + newCategories.Length, totalCount);
        }

        /// <summary>
        /// Tests that categories are returned in the correct order when ordered by name.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetCategories_OrderedByName_ReturnsCategoriesInCorrectOrder()
        {
            // Arrange
            var seededCategories = new[]
            {
                CategorySeeds.CategoryFood,
                CategorySeeds.CategoryTransport
            };

            var testCategories = new[]
            {
                new CategoryEntity 
                { 
                    Id = Guid.NewGuid(), 
                    Name = "B Category", 
                    Description = "Desc B", 
                    Color = "#ff0000", 
                    Icon = null 
                },
                new CategoryEntity 
                { 
                    Id = Guid.NewGuid(), 
                    Name = "A Category", 
                    Description = "Desc A", 
                    Color = "#00ff00", 
                    Icon = null 
                }
            };

            var expectedCategories = seededCategories.Concat(testCategories);

            // Add seed data and test categories
            SpendWiseDbContextSUT.Categories.AddRange(testCategories);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Act
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var orderedCategories = await dbx.Categories
                .OrderBy(c => c.Name)
                .ToListAsync();

            // Assert
            var expectedOrder = expectedCategories.OrderBy(c => c.Name).Select(c => c.Name).ToList();
            var actualOrder = orderedCategories.Select(c => c.Name).ToList();

            Assert.Equal(expectedOrder, actualOrder);
        }

        /// <summary>
        /// Tests that categories are returned in the correct order when ordered by color.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetCategories_OrderedByColor_ReturnsCategoriesInCorrectOrder()
        {
            // Arrange
            var seededCategories = new[]
            {
                CategorySeeds.CategoryFood,
                CategorySeeds.CategoryTransport
            };

            var testCategories = new[]
            {
                new CategoryEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Category1",
                    Description = "Desc 1",
                    Color = "#00ff00", // Green
                    Icon = null
                },
                new CategoryEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Category2",
                    Description = "Desc 2",
                    Color = "#ff0000", // Red
                    Icon = null
                },
                new CategoryEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Category3",
                    Description = "Desc 3",
                    Color = "#0000ff", // Blue
                    Icon = null
                }
            };

            // Combine the seeded categories with the test categories
            var expectedCategories = seededCategories.Concat(testCategories);

            // Add test categories to the context
            SpendWiseDbContextSUT.Categories.AddRange(testCategories);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Act
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var orderedCategories = await dbx.Categories
                .OrderBy(c => c.Color)
                .ToListAsync();

            // Assert
            var expectedOrder = expectedCategories
                .OrderBy(c => c.Color) // Sort by color to match the expected order
                .Select(c => c.Color)
                .ToList();

            var actualOrder = orderedCategories
                .Select(c => c.Color)
                .ToList();

            Assert.Equal(expectedOrder, actualOrder);
        }
        /// <summary>
        /// Tests that deleting a category properly maintains database integrity by verifying that associated transactions are handled correctly.
        /// Specifically, it ensures that the category is removed, transactions previously linked to the deleted category have their CategoryId set to null, and no transactions still reference the deleted category's ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task CategoryDeletion_IntegrityConstraints()
        {
            // Arrange
            var existingCategoryId = CategorySeeds.CategoryFood.Id;
            var expectedTransactions = CategorySeeds.CategoryFood.Transactions;

            // Act
            var categoryToDelete = await SpendWiseDbContextSUT.Categories
                .Where(c => c.Id == existingCategoryId)
                .Include(c => c.Transactions)
                .SingleOrDefaultAsync();
            
            // Check if the category exists before deleting
            Assert.NotNull(categoryToDelete);

            // Get transactions associated with the category before deletion
            var transactionsToCheck = categoryToDelete.Transactions;

            // Remove the category
            SpendWiseDbContextSUT.Categories.Remove(categoryToDelete);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Verify the category no longer exists
            var deletedCategory = await SpendWiseDbContextSUT.Categories
                .Where(c => c.Id == existingCategoryId)
                .SingleOrDefaultAsync();
            Assert.Null(deletedCategory);

            // Verify that transactions previously associated with the deleted category have their CategoryId set to null
            var transactionsWithOldCategoryId = await SpendWiseDbContextSUT.Transactions
                .Where(t => t.CategoryId == existingCategoryId)
                .ToListAsync();

            Assert.Empty(transactionsWithOldCategoryId); // Ensure there are no transactions with the old category ID

            // Verify that all expected transactions are now having CategoryId set to null
            foreach (var transaction in transactionsToCheck)
            {
                var transactionInDb = await SpendWiseDbContextSUT.Transactions
                    .Where(t => t.Id == transaction.Id)
                    .SingleOrDefaultAsync();
                Assert.NotNull(transactionInDb); // Ensure the transaction still exists
                Assert.Null(transactionInDb.CategoryId); // Ensure the CategoryId is set to null
            }
        }

        /// <summary>
        /// Tests that categories with descriptions containing a specific substring are returned correctly.
        /// Verifies that categories with descriptions matching the search substring are included in the results, while others are not.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetCategories_ByDescriptionContaining_ReturnsCorrectCategories()
        {
            // Arrange
            var searchDescriptionPart = "Groceries";

            var categoryFood = CategorySeeds.CategoryFood;
            var categoryTransport = CategorySeeds.CategoryTransport;

            var additionalCategory = new CategoryEntity
            {
                Id = Guid.NewGuid(),
                Name = "Additional Category",
                Description = "Food and Groceries",
                Color = "#ff00ff",
                Icon = null
            };

            await SpendWiseDbContextSUT.Categories.AddRangeAsync(new[] { additionalCategory });
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Act
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var result = await dbx.Categories
                .Where(c => c.Description != null && c.Description.Contains(searchDescriptionPart))
                .ToListAsync();

            // Assert
            Assert.Contains(result, c => c.Id == categoryFood.Id && c.Description?.Contains(searchDescriptionPart) == true); 
            Assert.Contains(result, c => c.Id == additionalCategory.Id && c.Description?.Contains(searchDescriptionPart) == true);
            Assert.DoesNotContain(result, c => c.Id == categoryTransport.Id && c.Description?.Contains(searchDescriptionPart) == true);

            Assert.Equal(2, result.Count);
        }

        /// <summary>
        /// Tests that adding a category with the maximum allowed length for fields correctly stores the data in the database.
        /// Verifies that categories with maximum field lengths are stored correctly and can be retrieved with the correct values.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddCategory_WithMaximumFieldLength_StoresCorrectly()
        {
            // Arrange
            var category = new CategoryEntity
            {
                Id = Guid.NewGuid(),
                Name = new string('A', 100),
                Description = new string('B', 200),
                Color = "#123456",
                Icon = null
            };

            // Act
            await SpendWiseDbContextSUT.Categories.AddAsync(category);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var retrievedCategory = await dbx.Categories
                .Where(c => c.Id == category.Id)
                .SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(retrievedCategory);
            Assert.Equal(category.Name, retrievedCategory.Name);
            Assert.Equal(category.Description, retrievedCategory.Description);
        }

        /// <summary>
        /// Tests that categories are returned correctly when searching by a partial name.
        /// Verifies that categories whose names contain the search substring are included in the results, while those that do not are excluded.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetCategories_ByPartialName_ReturnsCorrectCategories()
        {
            // Arrange
            var searchNamePart = "Cat";

            var additionalCategory1 = new CategoryEntity
            {
                Id = Guid.NewGuid(),
                Name = "Catering",
                Description = "Description3",
                Color = "#abcdef",
                Icon = null
            };

            var additionalCategory2 = new CategoryEntity
            {
                Id = Guid.NewGuid(),
                Name = "Cathedral Services",
                Description = "Description4",
                Color = "#123456",
                Icon = null
            };

            await SpendWiseDbContextSUT.Categories.AddRangeAsync(new[] { additionalCategory1, additionalCategory2 });
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Act
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var result = await dbx.Categories
                .Where(c => c.Name != null && c.Name.Contains(searchNamePart))
                .ToListAsync();

            // Assert
            Assert.Contains(result, c => c.Id == additionalCategory1.Id); // "Catering"
            Assert.Contains(result, c => c.Id == additionalCategory2.Id); // "Cathedral Services"
            Assert.DoesNotContain(result, c => c.Id == CategorySeeds.CategoryFood.Id); // "Food" should not match
            Assert.DoesNotContain(result, c => c.Id == CategorySeeds.CategoryTransport.Id); // "Transport" should not match
        }

        /// <summary>
        /// Tests that categories are returned correctly when searching by a range of colors.
        /// Verifies that categories whose colors fall within the specified range are included in the results, while others are excluded.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetCategories_ForColorRange_ReturnsCorrectCategories()
        {
            // Arrange
            var colorStart = "#00ff01";
            var colorEnd = "#ffffff";

            // Seed additional categories
            var category1 = new CategoryEntity
            {
                Id = Guid.NewGuid(),
                Name = "Category1",
                Description = "Description1",
                Color = "#123456",
                Icon = null
            };

            var category2 = new CategoryEntity
            {
                Id = Guid.NewGuid(),
                Name = "Category2",
                Description = "Description2",
                Color = "#abcabc",
                Icon = null
            };

            await SpendWiseDbContextSUT.Categories.AddRangeAsync(new[] { category1, category2});
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Act
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var result = await dbx.Categories
                .Where(c => string.Compare(c.Color, colorStart) >= 0 && string.Compare(c.Color, colorEnd) <= 0)
                .ToListAsync();

            // Assert
            Assert.Contains(result, c => c.Id == CategorySeeds.CategoryFood.Id);
            Assert.Contains(result, c => c.Id == category1.Id);
            Assert.Contains(result, c => c.Id == category2.Id);
            Assert.DoesNotContain(result, c => c.Id == CategorySeeds.CategoryTransport.Id);
        }
    }
}
