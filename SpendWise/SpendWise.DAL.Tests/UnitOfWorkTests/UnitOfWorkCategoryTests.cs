using Xunit.Abstractions;
using SpendWise.DAL.DTOs;
using Microsoft.EntityFrameworkCore;
using SpendWise.Common.Tests.Seeds;
using SpendWise.Common.Tests.Helpers;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;

namespace SpendWise.DAL.Tests.UnitOfWorkTests
{
    /// <summary>
    /// Unit tests for CRUD operations on the Category entity using the Unit of Work pattern.
    /// </summary>
    public class UnitOfWorkCategoryTests : UnitOfWorkTestsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkCategoryTests"/> class.
        /// </summary>
        /// <param name="output">The test output helper.</param>
        public UnitOfWorkCategoryTests(ITestOutputHelper output) : base(output)
        {
        }

        #region CRUD Operations Tests

        /// <summary>
        /// Tests that a category with valid data is added and persisted successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddCategory_WithValidData_ShouldPersistSuccessfully()
        {
            // Arrange
            var newCategory = new CategoryDto
            {
                Id = Guid.NewGuid(),
                Name = "New Category",
                Description = "Test Description",
                Color = "#0000ff",
                Icon = Array.Empty<byte>()
            };

            // Act
            await _unitOfWork.CategoryRepository.InsertAsync(newCategory);
            await _unitOfWork.SaveChangesAsync();
            var queryObject = new CategoryQueryObject().WithId(newCategory.Id);

            // Assert
            var persistedCategory = await _unitOfWork.CategoryRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(persistedCategory);
            DeepAssert.Equal(newCategory, persistedCategory);
        }

        /// <summary>
        /// Tests that fetching a category by its ID returns the expected category.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchCategoryById_WithExistingId_ShouldReturnExpectedCategory()
        {
            // Arrange
            var expectedCategory = _mapper.Map<CategoryDto>(CategorySeeds.CategoryFood);
            var queryObject = new CategoryQueryObject().WithId(expectedCategory.Id);

            // Act
            var fetchedCategory = await _unitOfWork.CategoryRepository.SingleOrDefaultAsync(queryObject);

            // Assert
            Assert.NotNull(fetchedCategory);
            DeepAssert.Equal(expectedCategory, fetchedCategory);
        }

        /// <summary>
        /// Tests that updating a category with valid data persists the changes successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateCategory_WithValidData_ShouldPersistChangesSuccessfully()
        {
            // Arrange
            var existingCategory = _mapper.Map<CategoryDto>(CategorySeeds.CategoryFood);
            var updatedCategory = new CategoryDto
            {
                Id = existingCategory.Id,
                Name = "Updated Category",
                Color = "#00ff00",
                Description = "Updated Description",
                Icon = Array.Empty<byte>()
            };
            var queryObject = new CategoryQueryObject().WithId(updatedCategory.Id);

            // Act
            await _unitOfWork.CategoryRepository.UpdateAsync(updatedCategory);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var persistedCategory = await _unitOfWork.CategoryRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(persistedCategory);
            DeepAssert.Equal(updatedCategory, persistedCategory);
        }

        /// <summary>
        /// Tests that deleting a category with an existing ID removes the category successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteCategory_WithExistingId_ShouldRemoveCategorySuccessfully()
        {
            // Arrange
            var categoryToDelete = _mapper.Map<CategoryDto>(CategorySeeds.CategoryFood);
            var queryObject = new CategoryQueryObject().WithId(categoryToDelete.Id);

            // Act
            await _unitOfWork.CategoryRepository.DeleteAsync(categoryToDelete.Id);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var deletedCategory = await _unitOfWork.CategoryRepository.SingleOrDefaultAsync(queryObject);
            Assert.Null(deletedCategory);
        }

        #endregion

        #region Error Handling Tests

        /// <summary>
        /// Tests that adding a category with an invalid color format throws a Exception.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddCategory_WithInvalidColorFormat_ShouldThrowException()
        {
            // Arrange
            var invalidCategory = new CategoryDto
            {
                Id = Guid.NewGuid(),
                Name = "Invalid Color Category",
                Description = "Test Description",
                Color = "InvalidColor",
                Icon = Array.Empty<byte>()
            };

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () =>
            {
                await _unitOfWork.CategoryRepository.InsertAsync(invalidCategory);
                await _unitOfWork.SaveChangesAsync();
            });
        }

        /// <summary>
        /// Tests that updating a non-existent category throws an Exception.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateCategory_WithNonExistentCategory_ShouldThrowException()
        {
            // Arrange
            var nonExistentCategory = new CategoryDto
            {
                Id = Guid.NewGuid(),
                Name = "Non-Existent Category",
                Description = "Should fail",
                Color = "#0000ff",
                Icon = Array.Empty<byte>()
            };

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () =>
            {
                await _unitOfWork.CategoryRepository.UpdateAsync(nonExistentCategory);
                await _unitOfWork.SaveChangesAsync();
            });
        }

        /// <summary>
        /// Tests that deleting a non-existent category throws a Exception.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteCategory_WithNonExistentCategory_ShouldThrowException()
        {
            // Arrange
            var nonExistentCategoryId = Guid.NewGuid();

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () =>
            {
                await _unitOfWork.CategoryRepository.DeleteAsync(nonExistentCategoryId);
                await _unitOfWork.SaveChangesAsync();
            });
        }

        #endregion

        #region Update and Special Cases Tests

        /// <summary>
        /// Tests that adding a category with an icon persists the category with the icon data successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddCategory_WithIcon_ShouldPersistCategoryWithIconSuccessfully()
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
            var queryObject = new CategoryQueryObject().WithId(newCategory.Id);

            // Act
            await _unitOfWork.CategoryRepository.InsertAsync(newCategory);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var persistedCategory = await _unitOfWork.CategoryRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(persistedCategory);
            Assert.NotNull(persistedCategory.Icon);
            Assert.Equal(newCategory.Icon, persistedCategory.Icon);
        }

        /// <summary>
        /// Tests that updating a category's icon updates the icon data successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateCategory_ChangeIcon_ShouldUpdateIconSuccessfully()
        {
            // Arrange
            var existingCategory = _mapper.Map<CategoryDto>(CategorySeeds.CategoryFood);
            var updatedCategory = existingCategory with
            {
                Icon = new byte[] { 0x02, 0x03 }
            };
            var queryObject = new CategoryQueryObject().WithId(updatedCategory.Id);

            // Act
            await _unitOfWork.CategoryRepository.UpdateAsync(updatedCategory);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var persistedCategory = await _unitOfWork.CategoryRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(persistedCategory);
            Assert.Equal(updatedCategory.Icon, persistedCategory.Icon);
        }

        /// <summary>
        /// Tests that setting a category's description to null updates the description to null successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateCategory_SetNullDescription_ShouldUpdateDescriptionToNullSuccessfully()
        {
            // Arrange
            var existingCategory = _mapper.Map<CategoryDto>(CategorySeeds.CategoryFood);
            var queryObject = new CategoryQueryObject().WithId(existingCategory.Id);
            var updatedCategory = new CategoryDto
            {
                Id = existingCategory.Id,
                Name = existingCategory.Name,
                Description = null,
                Color = existingCategory.Color,
                Icon = existingCategory.Icon
            };

            // Act
            await _unitOfWork.CategoryRepository.UpdateAsync(updatedCategory);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var persistedCategory = await _unitOfWork.CategoryRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(persistedCategory);
            Assert.Null(persistedCategory.Description);
        }

        /// <summary>
        /// Tests that changing a category's name updates the name successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateCategory_ChangeName_ShouldUpdateNameSuccessfully()
        {
            // Arrange
            var existingCategory = _mapper.Map<CategoryDto>(CategorySeeds.CategoryFood);
            var queryObject = new CategoryQueryObject().WithId(existingCategory.Id);
            var newName = "Updated Food Category";
            var updatedCategory = new CategoryDto
            {
                Id = existingCategory.Id,
                Name = newName,
                Description = existingCategory.Description,
                Color = existingCategory.Color,
                Icon = existingCategory.Icon
            };

            // Act
            await _unitOfWork.CategoryRepository.UpdateAsync(updatedCategory);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var persistedCategory = await _unitOfWork.CategoryRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(persistedCategory);
            Assert.Equal(newName, persistedCategory.Name);
        }

        #endregion

        #region Related Entities Handling Tests

        /// <summary>
        /// Tests that deleting a category maintains integrity constraints by ensuring associated transactions are updated.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteCategory_ShouldMaintainIntegrityConstraints()
        {
            // Arrange
            var categoryToDelete = CategorySeeds.CategoryFood;
            var categoryId = categoryToDelete.Id;

            // Act
            await _unitOfWork.CategoryRepository.DeleteAsync(categoryId);
            await _unitOfWork.SaveChangesAsync();

            var queryObject = new TransactionQueryObject();
            var transactionsAfterDelete = await _unitOfWork.TransactionRepository
                .ListAsync(queryObject.WithoutCategory());

            // Assert
            foreach (var transaction in categoryToDelete.Transactions)
            {
                Assert.Contains(transactionsAfterDelete, t => t.Id == transaction.Id);
            }
        }

        #endregion

        #region Consistency Tests

        /// <summary>
        /// Tests that after multiple category operations (insert, update, delete), the final state is consistent.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task TransactionalConsistency_AfterMultipleOperations_ShouldMaintainConsistency()
        {
            // Arrange
            var newCategory = new CategoryDto
            {
                Id = Guid.NewGuid(),
                Name = "New Category",
                Description = "Test Description",
                Color = "#ff0000",
                Icon = new byte[] { 0x01, 0x02 }
            };

            var updatedCategory = new CategoryDto
            {
                Id = newCategory.Id,
                Name = "Updated Category",
                Description = "Updated Description",
                Color = "#00ff00",
                Icon = new byte[] { 0x03, 0x04 }
            };

            try
            {
                // Act
                await _unitOfWork.CategoryRepository.InsertAsync(newCategory);
                await _unitOfWork.SaveChangesAsync();

                await _unitOfWork.CategoryRepository.UpdateAsync(updatedCategory);
                await _unitOfWork.SaveChangesAsync();

                await _unitOfWork.CategoryRepository.DeleteAsync(newCategory.Id);
                await _unitOfWork.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            // Assert
            var queryObject = new CategoryQueryObject().WithId(newCategory.Id);
            var deletedCategory = await _unitOfWork.CategoryRepository.SingleOrDefaultAsync(queryObject);
            Assert.Null(deletedCategory);
        }

        #endregion
    }
}