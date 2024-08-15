using Xunit.Abstractions;
using SpendWise.DAL.DTOs;
using Microsoft.EntityFrameworkCore;
using SpendWise.Common.Tests.Seeds;
using SpendWise.Common.Tests.Helpers;

namespace SpendWise.DAL.Tests
{
    /// <summary>
    /// Contains tests for operations related to categories using the 
    /// Unit of Work pattern.
    /// </summary>
    public class UnitOfWorkCategoryTests : UnitOfWorkTestsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkCategoryTests"/> class.
        /// </summary>
        /// <param name="output">The output helper instance.</param>
        public UnitOfWorkCategoryTests(ITestOutputHelper output) : base(output)
        {
        }

        // ====================================
        // CRUD Operations Tests
        // ====================================

        /// <summary>
        /// Tests if creating a category with valid data correctly adds the category to the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task CreateCategory_ValidData_ShouldCreateNewCategory()
        {
            // Arrange
            var newCategoryDto = new CategoryDto
            {
                Id = Guid.NewGuid(),
                Name = "New Category",
                Description = "Test Description",
                Color = "#0000ff",
                Icon = new byte[] { }
            };

            // Act
            await _unitOfWork.Categories.InsertAsync(newCategoryDto);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var categoryInDb = await _unitOfWork.Categories.GetByIdAsync(newCategoryDto.Id);
            Assert.NotNull(categoryInDb);
            DeepAssert.Equal(newCategoryDto, categoryInDb);
        }

        /// <summary>
        /// Tests if fetching a category by an existing ID returns the correct category.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetCategoryById_ExistingId_ShouldReturnCorrectCategory()
        {
            // Arrange
            var expectedCategoryDto = _mapper.Map<CategoryDto>(CategorySeeds.CategoryFood);

            // Act
            var fetchedCategoryDto = await _unitOfWork.Categories.GetByIdAsync(expectedCategoryDto.Id);

            // Assert
            Assert.NotNull(fetchedCategoryDto);
            DeepAssert.Equal(expectedCategoryDto, fetchedCategoryDto);
        }

        /// <summary>
        /// Tests if updating a category with valid data correctly updates the category in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateCategory_ValidData_ShouldUpdateCategoryInDatabase()
        {
            // Arrange
            var existingCategoryDto = _mapper.Map<CategoryDto>(CategorySeeds.CategoryFood);

            var updatedCategoryDto = new CategoryDto
            {
                Id = existingCategoryDto.Id,
                Name = "Updated Category",
                Color = "#00ff00",
                Description = "Updated Description",
                Icon = new byte[] { }
            };

            // Act
            await _unitOfWork.Categories.UpdateAsync(updatedCategoryDto);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var resultCategoryDto = await _unitOfWork.Categories.GetByIdAsync(updatedCategoryDto.Id);
            Assert.NotNull(resultCategoryDto);
            DeepAssert.Equal(updatedCategoryDto, resultCategoryDto);
        }

        /// <summary>
        /// Tests if deleting a category by an existing ID correctly removes the category from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteCategory_ExistingId_ShouldRemoveCategoryFromDatabase()
        {
            // Arrange
            var categoryDto = _mapper.Map<CategoryDto>(CategorySeeds.CategoryFood);

            // Act
            await _unitOfWork.Categories.DeleteAsync(categoryDto.Id);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var deletedCategory = await _unitOfWork.Categories.GetByIdAsync(categoryDto.Id);
            Assert.Null(deletedCategory);
        }

        // ====================================
        // Error Handling Tests
        // ====================================

        /// <summary>
        /// Tests if creating a category with an invalid color format fails as expected.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task CreateCategory_InvalidColorFormat_ShouldFail()
        {
            // Arrange
            var newCategory = new CategoryDto
            {
                Id = Guid.NewGuid(),
                Name = "Invalid Color Category",
                Description = "Test Description",
                Color = "InvalidColor", // Invalid color format
                Icon = new byte[] { }
            };

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                await _unitOfWork.Categories.InsertAsync(newCategory);
                await _unitOfWork.SaveChangesAsync();
            });
        }

        /// <summary>
        /// Tests if updating a non-existent category fails as expected.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateCategory_NonExistentCategory_ShouldFail()
        {
            // Arrange
            var nonExistentCategoryDto = new CategoryDto
            {
                Id = Guid.NewGuid(), // Non-existent ID
                Name = "Non-Existent Category",
                Description = "Should fail",
                Color = "#0000ff",
                Icon = new byte[] { }
            };

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await _unitOfWork.Categories.UpdateAsync(nonExistentCategoryDto);
                await _unitOfWork.SaveChangesAsync();
            });
        }

        /// <summary>
        /// Tests if deleting a non-existent category fails as expected.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteCategory_NonExistentCategory_ShouldFail()
        {
            // Arrange
            var nonExistentCategoryId = Guid.NewGuid(); // Non-existent ID

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await _unitOfWork.Categories.DeleteAsync(nonExistentCategoryId);
                await _unitOfWork.SaveChangesAsync();
            });
        }

        // ====================================
        // Data Retrieval Tests
        // ====================================

        /// <summary>
        /// Tests if fetching all categories returns the correct number and content of categories.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetAllCategories_ShouldReturnAllCategories()
        {
            // Arrange
            var seedCategories = new List<CategoryDto>
            {
                _mapper.Map<CategoryDto>(CategorySeeds.CategoryFood),
                _mapper.Map<CategoryDto>(CategorySeeds.CategoryTransport)
            };

            // Act
            var allCategories = await _unitOfWork.Categories.Get().ToListAsync();

            // Assert
            Assert.NotNull(allCategories);
            Assert.Equal(seedCategories.Count, allCategories.Count);
            foreach (var category in seedCategories)
            {
                Assert.Contains(allCategories, c => c.Id == category.Id);
            }
        }

        /// <summary>
        /// Tests if fetching a category by its name returns the correct category.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetCategoryByName_ReturnsCorrectCategory()
        {
            // Arrange
            var seedCategoryDto = _mapper.Map<CategoryDto>(CategorySeeds.CategoryFood);

            // Act
            var fetchedCategoryDto = await _unitOfWork.Categories.Get(c => c.Name == seedCategoryDto.Name).SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(fetchedCategoryDto);
            DeepAssert.Equal(seedCategoryDto, fetchedCategoryDto);
        }

        // ====================================
        // Update and Special Cases Tests
        // ====================================

        /// <summary>
        /// Tests if creating a category with an icon correctly saves the icon in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task CreateCategory_WithIcon_ShouldCreateCategoryWithIcon()
        {
            // Arrange
            var newCategory = new CategoryDto
            {
                Id = Guid.NewGuid(),
                Name = "CategoryWithIcon",
                Description = "Test Description",
                Color = "#ff00ff",
                Icon = new byte[] { 0x01, 0x02, 0x03 }
            };

            // Act
            await _unitOfWork.Categories.InsertAsync(newCategory);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var categoryInDb = await _unitOfWork.Categories.GetByIdAsync(newCategory.Id);
            Assert.NotNull(categoryInDb);
            Assert.NotNull(categoryInDb.Icon);
            Assert.Equal(newCategory.Icon, categoryInDb.Icon);
        }

        /// <summary>
        /// Tests if updating the icon of a category correctly updates it in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateCategory_ChangeIcon_ShouldUpdateIcon()
        {
            // Arrange
            var existingCategoryDto = _mapper.Map<CategoryDto>(CategorySeeds.CategoryFood);

            var updatedCategoryDto = new CategoryDto
            {
                Id = existingCategoryDto.Id,
                Name = existingCategoryDto.Name,
                Description = existingCategoryDto.Description,
                Color = existingCategoryDto.Color,
                Icon = new byte[] { 0x02, 0x03 }
            };

            // Act
            await _unitOfWork.Categories.UpdateAsync(updatedCategoryDto);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var resultCategoryDto = await _unitOfWork.Categories.GetByIdAsync(updatedCategoryDto.Id);
            Assert.NotNull(resultCategoryDto);
            Assert.Equal(updatedCategoryDto.Icon, resultCategoryDto.Icon);
        }

        /// <summary>
        /// Tests if deleting a category that has related transactions sets the CategoryId to null in those transactions.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteCategory_WithRelations_ShouldSetCategoryToNullInTransactions()
        {
            // Arrange
            var categoryWithRelations = CategorySeeds.CategoryFoodWithRelations;
            var categoryId = categoryWithRelations.Id;

            // Act
            await _unitOfWork.Categories.DeleteAsync(categoryId);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var transactionsAfterDelete = await _unitOfWork.Transactions.Get(t => t.CategoryId == null).ToListAsync();

            foreach (var transaction in categoryWithRelations.Transactions)
            {
                Assert.Contains(transactionsAfterDelete, t => t.Id == transaction.Id);
            }
        }

        /// <summary>
        /// Tests if updating a category with a null description correctly updates the description to null in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateCategory_SetNullDescription_ShouldUpdateToNull()
        {
            // Arrange
            var existingCategoryDto = _mapper.Map<CategoryDto>(CategorySeeds.CategoryFood);

            // Act
            existingCategoryDto.Description = null;
            await _unitOfWork.Categories.UpdateAsync(existingCategoryDto);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var resultCategoryDto = await _unitOfWork.Categories.GetByIdAsync(existingCategoryDto.Id);
            Assert.NotNull(resultCategoryDto);
            Assert.Null(resultCategoryDto.Description);
        }

        /// <summary>
        /// Tests if updating the name of an existing category correctly updates the name in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateCategory_ChangeName_ShouldUpdateNameCorrectly()
        {
            // Arrange
            var existingCategoryDto = _mapper.Map<CategoryDto>(CategorySeeds.CategoryFood);

            // Act
            var newName = "Updated Food Category";
            existingCategoryDto.Name = newName;
            await _unitOfWork.Categories.UpdateAsync(existingCategoryDto);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var resultCategoryDto = await _unitOfWork.Categories.GetByIdAsync(existingCategoryDto.Id);
            Assert.NotNull(resultCategoryDto);
            Assert.Equal(newName, resultCategoryDto.Name);
        }
    }
}
