using Xunit;
using Xunit.Abstractions;
using SpendWise.DAL.DTOs;
using Microsoft.EntityFrameworkCore;
using SpendWise.Common.Tests.Seeds;
using SpendWise.Common.Tests.Helpers;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;
using Xunit.Sdk;

namespace SpendWise.DAL.Tests.UnitOfWorkTests
{
    public class UnitOfWorkCategoryTests : UnitOfWorkTestsBase
    {
        public UnitOfWorkCategoryTests(ITestOutputHelper output) : base(output)
        {
        }

        #region CRUD Operations Tests

        /// <summary>
        /// Unit tests for CRUD (Create, Read, Update, Delete) operations on the Category entity using the Unit of Work pattern.
        /// These tests ensure that basic data manipulation tasks are correctly implemented and persist changes in the database as expected.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that a new category with valid data is successfully added to the database and persists correctly.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddCategory_ValidData_SuccessfullyPersists()
        {
            // Arrange
            var categoryToAdd = new CategoryDto
            {
                Id = Guid.NewGuid(),
                Name = "New Category",
                Description = "Test Description",
                Color = "#0000ff",
                Icon = Array.Empty<byte>()
            };

            // Act
            await _unitOfWork.Repository<CategoryEntity, CategoryDto>().InsertAsync(categoryToAdd);
            await _unitOfWork.SaveChangesAsync(); // Persist changes

            // Assert
            var actualCategory = await _unitOfWork.Repository<CategoryEntity, CategoryDto>().GetByIdAsync(categoryToAdd.Id);
            Assert.NotNull(actualCategory); // Ensure the category was added
            DeepAssert.Equal(categoryToAdd, actualCategory); // Verify that the added category matches the input data
        }

        [Fact]
        /// <summary>
        /// Verifies that fetching a category by its ID returns the expected category if it exists in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task FetchCategoryById_ExistingId_ReturnsExpectedCategory()
        {
            // Arrange
            var expectedCategory = _mapper.Map<CategoryDto>(CategorySeeds.CategoryFood);

            // Act
            var actualCategory = await _unitOfWork.Repository<CategoryEntity, CategoryDto>().GetByIdAsync(expectedCategory.Id);

            // Assert
            Assert.NotNull(actualCategory); // Ensure the category was found
            DeepAssert.Equal(expectedCategory, actualCategory); // Verify that the fetched category matches the expected category
        }

        [Fact]
        /// <summary>
        /// Verifies that updating an existing category with valid data successfully persists the changes in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateCategory_ValidData_SuccessfullyPersistsChanges()
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

            // Act
            await _unitOfWork.Repository<CategoryEntity, CategoryDto>().UpdateAsync(updatedCategory);
            await _unitOfWork.SaveChangesAsync(); // Persist changes

            // Assert
            var actualCategory = await _unitOfWork.Repository<CategoryEntity, CategoryDto>().GetByIdAsync(updatedCategory.Id);
            Assert.NotNull(actualCategory); // Ensure the category was updated
            DeepAssert.Equal(updatedCategory, actualCategory); // Verify that the updated category matches the new data
        }

        [Fact]
        /// <summary>
        /// Verifies that deleting an existing category by its ID successfully removes the category from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteCategory_ExistingId_SuccessfullyRemovesCategory()
        {
            // Arrange
            var categoryToDelete = _mapper.Map<CategoryDto>(CategorySeeds.CategoryFood);

            // Act
            await _unitOfWork.Repository<CategoryEntity, CategoryDto>().DeleteAsync(categoryToDelete.Id);
            await _unitOfWork.SaveChangesAsync(); // Persist changes

            // Assert
            var deletedCategory = await _unitOfWork.Repository<CategoryEntity, CategoryDto>().GetByIdAsync(categoryToDelete.Id);
            Assert.Null(deletedCategory); // Ensure the category was removed
        }

        #endregion

        #region Error Handling Tests

        /// <summary>
        /// Unit tests for error handling scenarios in the Category operations. 
        /// These tests verify that appropriate exceptions are thrown when invalid operations are attempted.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that attempting to add a category with an invalid color format throws a DbUpdateException.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddCategory_InvalidColorFormat_ThrowsDbUpdateException()
        {
            // Arrange
            var invalidCategory = new CategoryDto
            {
                Id = Guid.NewGuid(),
                Name = "Invalid Color Category",
                Description = "Test Description",
                Color = "InvalidColor", // Invalid color format
                Icon = Array.Empty<byte>()
            };

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                await _unitOfWork.Repository<CategoryEntity, CategoryDto>().InsertAsync(invalidCategory);
                await _unitOfWork.SaveChangesAsync(); // Persist changes, expecting an exception
            });
        }

        [Fact]
        /// <summary>
        /// Verifies that updating a non-existent category throws an InvalidOperationException.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateCategory_NonExistentCategory_ThrowsInvalidOperationException()
        {
            // Arrange
            var nonExistentCategory = new CategoryDto
            {
                Id = Guid.NewGuid(), // Non-existent ID
                Name = "Non-Existent Category",
                Description = "Should fail",
                Color = "#0000ff",
                Icon = Array.Empty<byte>()
            };

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await _unitOfWork.Repository<CategoryEntity, CategoryDto>().UpdateAsync(nonExistentCategory);
                await _unitOfWork.SaveChangesAsync(); // Persist changes, expecting an exception
            });
        }

        [Fact]
        /// <summary>
        /// Verifies that deleting a non-existent category throws a KeyNotFoundException.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteCategory_NonExistentCategory_ThrowsKeyNotFoundException()
        {
            // Arrange
            var nonExistentCategoryId = Guid.NewGuid(); // Non-existent ID

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await _unitOfWork.Repository<CategoryEntity, CategoryDto>().DeleteAsync(nonExistentCategoryId);
                await _unitOfWork.SaveChangesAsync(); // Persist changes, expecting an exception
            });
        }

        #endregion

        #region Update and Special Cases Tests

        /// <summary>
        /// Unit tests for updating categories and handling special cases such as icon changes.
        /// These tests verify that category updates are successfully persisted in the database.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that adding a category with an icon successfully persists the category with the icon data.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddCategory_WithIcon_SuccessfullyPersistsCategoryWithIcon()
        {
            // Arrange
            var categoryToAdd = new CategoryDto
            {
                Id = Guid.NewGuid(),
                Name = "CategoryWithIcon",
                Description = "Test Description",
                Color = "#ff00ff",
                Icon = new byte[] { 0x01, 0x02, 0x03 }
            };

            // Act
            await _unitOfWork.Repository<CategoryEntity, CategoryDto>().InsertAsync(categoryToAdd);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var actualCategory = await _unitOfWork.Repository<CategoryEntity, CategoryDto>().GetByIdAsync(categoryToAdd.Id);
            Assert.NotNull(actualCategory);
            Assert.NotNull(actualCategory.Icon);
            Assert.Equal(categoryToAdd.Icon, actualCategory.Icon);
        }

        [Fact]
        /// <summary>
        /// Verifies that changing a category's icon successfully updates the icon in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateCategory_ChangeIcon_SuccessfullyUpdatesIcon()
        {
            // Arrange
            var existingCategory = _mapper.Map<CategoryDto>(CategorySeeds.CategoryFood);
            var updatedCategory = new CategoryDto
            {
                Id = existingCategory.Id,
                Name = existingCategory.Name,
                Description = existingCategory.Description,
                Color = existingCategory.Color,
                Icon = new byte[] { 0x02, 0x03 }
            };

            // Act
            await _unitOfWork.Repository<CategoryEntity, CategoryDto>().UpdateAsync(updatedCategory);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var actualCategory = await _unitOfWork.Repository<CategoryEntity, CategoryDto>().GetByIdAsync(updatedCategory.Id);
            Assert.NotNull(actualCategory);
            Assert.Equal(updatedCategory.Icon, actualCategory.Icon);
        }

        [Fact]
        /// <summary>
        /// Verifies that setting a category's description to null successfully updates the description in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateCategory_SetNullDescription_SuccessfullyUpdatesDescriptionToNull()
        {
            // Arrange
            var existingCategory = _mapper.Map<CategoryDto>(CategorySeeds.CategoryFood);

            // Act
            existingCategory.Description = null;
            await _unitOfWork.Repository<CategoryEntity, CategoryDto>().UpdateAsync(existingCategory);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var actualCategory = await _unitOfWork.Repository<CategoryEntity, CategoryDto>().GetByIdAsync(existingCategory.Id);
            Assert.NotNull(actualCategory);
            Assert.Null(actualCategory.Description);
        }

        [Fact]
        /// <summary>
        /// Verifies that changing a category's name successfully updates the name in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateCategory_ChangeName_SuccessfullyUpdatesName()
        {
            // Arrange
            var existingCategory = _mapper.Map<CategoryDto>(CategorySeeds.CategoryFood);

            // Act
            var newName = "Updated Food Category";
            existingCategory.Name = newName;
            await _unitOfWork.Repository<CategoryEntity, CategoryDto>().UpdateAsync(existingCategory);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var actualCategory = await _unitOfWork.Repository<CategoryEntity, CategoryDto>().GetByIdAsync(existingCategory.Id);
            Assert.NotNull(actualCategory);
            Assert.Equal(newName, actualCategory.Name);
        }

        #endregion

        #region Related Entities Handling Tests

        /// <summary>
        /// Unit tests for handling related entities when performing operations on categories.
        /// These tests verify that integrity constraints are maintained after deletions.
        /// </summary>

        /// <summary>
        /// Verifies that after deleting a category, the associated transactions are updated to ensure integrity constraints are maintained.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>

        [Fact]
        public async Task DeleteCategory_CheckIntegrityConstraints_AfterDeletion()
        {
            // Arrange
            var categoryToDelete = CategorySeeds.CategoryFood; // Get the category to delete
            var categoryId = categoryToDelete.Id;

            // Act
            // Delete the category
            await _unitOfWork.Repository<CategoryEntity, CategoryDto>().DeleteAsync(categoryId);
            await _unitOfWork.SaveChangesAsync();

            // Prepare the query object to get transactions with null CategoryId
            var queryObject = new TransactionQueryObject();
            var transactionsAfterDelete = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.WithCategoryId(null));

            // Assert
            foreach (var transaction in categoryToDelete.Transactions)
            {
                Assert.Contains(transactionsAfterDelete, t => t.Id == transaction.Id);
            }
        }

        #endregion


        #region Consistency Tests

        /// <summary>
        /// Unit tests to verify transactional consistency after performing multiple category operations.
        /// These tests ensure that categories are correctly inserted, updated, and deleted while maintaining consistency.
        /// </summary>

        /// <summary>
        /// Verifies that after multiple category operations (insert, update, delete), the final state is consistent.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task TransactionalConsistency_AfterMultipleCategoryOperations()
        {
            // Arrange
            var newCategoryDto = new CategoryDto
            {
                Id = Guid.NewGuid(),
                Name = "New Category",
                Description = "Test Description",
                Color = "#ff0000",
                Icon = new byte[] { 0x01, 0x02 }
            };

            var updatedCategoryDto = new CategoryDto
            {
                Id = newCategoryDto.Id,
                Name = "Updated Category",
                Description = "Updated Description",
                Color = "#00ff00",
                Icon = new byte[] { 0x03, 0x04 }
            };

            try
            {
                // Act
                // Insert
                await _unitOfWork.Repository<CategoryEntity, CategoryDto>().InsertAsync(newCategoryDto);
                await _unitOfWork.SaveChangesAsync();

                // Update
                await _unitOfWork.Repository<CategoryEntity, CategoryDto>().UpdateAsync(updatedCategoryDto);
                await _unitOfWork.SaveChangesAsync();

                // Delete
                await _unitOfWork.Repository<CategoryEntity, CategoryDto>().DeleteAsync(newCategoryDto.Id);
                await _unitOfWork.SaveChangesAsync();
            }
            catch
            {
                throw; // Rethrow exception to indicate failure
            }

            // Assert
            var deletedCategory = await _unitOfWork.Repository<CategoryEntity, CategoryDto>().GetByIdAsync(newCategoryDto.Id);
            Assert.Null(deletedCategory); // Ensure the category was deleted
        }

        #endregion
    }
}
