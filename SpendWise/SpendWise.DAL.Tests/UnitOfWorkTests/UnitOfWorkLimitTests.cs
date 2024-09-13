using Xunit.Abstractions;
using SpendWise.DAL.DTOs;
using Microsoft.EntityFrameworkCore;
using SpendWise.Common.Tests.Seeds;
using SpendWise.Common.Tests.Helpers;
using SpendWise.DAL.Entities;
using SpendWise.Common.Enums;

namespace SpendWise.DAL.Tests.UnitOfWorkTests
{
    /// <summary>
    /// Unit tests for CRUD operations on the Limit entity using the Unit of Work pattern.
    /// </summary>
    public class UnitOfWorkLimitTests : UnitOfWorkTestsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkLimitTests"/> class.
        /// </summary>
        /// <param name="output">The test output helper.</param>
        public UnitOfWorkLimitTests(ITestOutputHelper output) : base(output)
        {
        }

        #region CRUD Operations Tests

        /// <summary>
        /// Tests that a limit with valid data is added and persisted successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddLimit_ValidData_SuccessfullyPersists()
        {
            // Arrange
            var limitToAdd = new LimitDto
            {
                Id = Guid.NewGuid(),
                GroupUserId = GroupUserSeeds.GroupUserJohnInFamily.Id,
                Amount = 1500m,
                NoticeType = NoticeType.SMS,
            };

            // Act
            await _unitOfWork.Repository<LimitEntity, LimitDto>().InsertAsync(limitToAdd);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var actualLimit = await _unitOfWork.Repository<LimitEntity, LimitDto>().GetByIdAsync(limitToAdd.Id);
            Assert.NotNull(actualLimit);
            DeepAssert.Equal(limitToAdd, actualLimit);
        }

        /// <summary>
        /// Tests that fetching a limit by its ID returns the expected limit.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchLimitById_ExistingId_ReturnsExpectedLimit()
        {
            // Arrange
            var expectedLimit = _mapper.Map<LimitDto>(LimitSeeds.LimitCharlieFamily);

            // Act
            var actualLimit = await _unitOfWork.Repository<LimitEntity, LimitDto>().GetByIdAsync(expectedLimit.Id);

            // Assert
            Assert.NotNull(actualLimit);
            DeepAssert.Equal(expectedLimit, actualLimit);
        }

        /// <summary>
        /// Tests that updating a limit with valid data persists the changes successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateLimit_ValidData_SuccessfullyPersistsChanges()
        {
            // Arrange
            var existingLimit = _mapper.Map<LimitDto>(LimitSeeds.LimitCharlieFamily);
            var updatedLimit = existingLimit with
            {
                Amount = 2000m,
                NoticeType = NoticeType.SMS,
            };

            // Act
            await _unitOfWork.Repository<LimitEntity, LimitDto>().UpdateAsync(updatedLimit);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var actualLimit = await _unitOfWork.Repository<LimitEntity, LimitDto>().GetByIdAsync(updatedLimit.Id);
            Assert.NotNull(actualLimit);
            DeepAssert.Equal(updatedLimit, actualLimit);
        }

        /// <summary>
        /// Tests that deleting a limit with an existing ID removes the limit successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteLimit_ExistingId_SuccessfullyRemovesLimit()
        {
            // Arrange
            var limitToDelete = _mapper.Map<LimitDto>(LimitSeeds.LimitCharlieFamily);

            // Act
            await _unitOfWork.Repository<LimitEntity, LimitDto>().DeleteAsync(limitToDelete.Id);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var deletedLimit = await _unitOfWork.Repository<LimitEntity, LimitDto>().GetByIdAsync(limitToDelete.Id);
            Assert.Null(deletedLimit);
        }

        #endregion

        #region Error Handling Tests

        /// <summary>
        /// Tests that adding a limit with an invalid GroupUserId throws a DbUpdateException.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddLimit_WithInvalidGroupUserId_ThrowsDbUpdateException()
        {
            // Arrange
            var invalidLimit = new LimitDto
            {
                Id = Guid.NewGuid(),
                GroupUserId = Guid.NewGuid(), // Invalid GroupUserId
                Amount = 1500m,
                NoticeType = NoticeType.SMS,
            };

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                await _unitOfWork.Repository<LimitEntity, LimitDto>().InsertAsync(invalidLimit);
                await _unitOfWork.SaveChangesAsync();
            });
        }

        /// <summary>
        /// Tests that updating a non-existent limit throws an InvalidOperationException.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateLimit_NonExistentLimit_ThrowsInvalidOperationException()
        {
            // Arrange
            var nonExistentLimit = new LimitDto
            {
                Id = Guid.NewGuid(), // Non-existent ID
                GroupUserId = GroupUserSeeds.GroupUserJohnInFamily.Id,
                Amount = 1500m,
                NoticeType = NoticeType.SMS,
            };

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await _unitOfWork.Repository<LimitEntity, LimitDto>().UpdateAsync(nonExistentLimit);
                await _unitOfWork.SaveChangesAsync();
            });
        }

        /// <summary>
        /// Tests that deleting a non-existent limit throws a KeyNotFoundException.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteLimit_NonExistentLimit_ThrowsKeyNotFoundException()
        {
            // Arrange
            var nonExistentLimitId = Guid.NewGuid(); // Non-existent ID

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await _unitOfWork.Repository<LimitEntity, LimitDto>().DeleteAsync(nonExistentLimitId);
                await _unitOfWork.SaveChangesAsync();
            });
        }

        #endregion

        #region Update and Special Cases Tests

        /// <summary>
        /// Tests that changing a limit's amount updates the amount successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateLimit_ChangeAmount_SuccessfullyUpdates()
        {
            // Arrange
            var existingLimit = _mapper.Map<LimitDto>(LimitSeeds.LimitCharlieFamily);
            var updatedLimit = existingLimit with
            {
                Amount = 2500m, // Change amount
            };

            // Act
            await _unitOfWork.Repository<LimitEntity, LimitDto>().UpdateAsync(updatedLimit);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var actualLimit = await _unitOfWork.Repository<LimitEntity, LimitDto>().GetByIdAsync(updatedLimit.Id);
            Assert.NotNull(actualLimit);
            Assert.Equal(updatedLimit.Amount, actualLimit.Amount);
        }

        /// <summary>
        /// Tests that attempting to change a limit's GroupUserId does not change the GroupUserId.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateLimit_ChangeGroupUserId_ShouldNotChange()
        {
            // Arrange
            var existingLimit = _mapper.Map<LimitDto>(LimitSeeds.LimitCharlieFamily);

            var updatedLimit = existingLimit with
            {
                GroupUserId = Guid.NewGuid(), // Attempt to change GroupUserId
            };

            // Act
            await _unitOfWork.Repository<LimitEntity, LimitDto>().UpdateAsync(updatedLimit);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var actualLimit = await _unitOfWork.Repository<LimitEntity, LimitDto>().GetByIdAsync(existingLimit.Id);
            Assert.NotNull(actualLimit);
            Assert.Equal(existingLimit.GroupUserId, actualLimit.GroupUserId); // GroupUserId should remain unchanged
        }

        #endregion

        #region Related Entities Handling Tests

        /// <summary>
        /// Tests that deleting a limit with an associated GroupUser keeps the GroupUser intact.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteLimit_WithAssociatedGroupUser_KeepsGroupUserIntact()
        {
            // Arrange
            var limitToDelete = LimitSeeds.LimitCharlieFamily;

            // Act
            await _unitOfWork.Repository<LimitEntity, LimitDto>().DeleteAsync(limitToDelete.Id);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var groupUser = await _unitOfWork.Repository<GroupUserEntity, GroupUserDto>().GetByIdAsync(limitToDelete.GroupUserId);
            Assert.NotNull(groupUser);
            Assert.Equal(limitToDelete.GroupUserId, groupUser.Id);
        }

        #endregion

        #region Consistency Tests

        /// <summary>
        /// Tests that after multiple limit operations (insert, update, delete), the final state is consistent.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task TransactionalConsistency_AfterMultipleLimitOperations()
        {
            // Arrange
            var newLimitDto = new LimitDto
            {
                Id = Guid.NewGuid(),
                GroupUserId = GroupUserSeeds.GroupUserJohnInFamily.Id,
                Amount = 1500m,
                NoticeType = NoticeType.SMS,
            };

            var updatedLimitDto = new LimitDto
            {
                Id = newLimitDto.Id,
                GroupUserId = newLimitDto.GroupUserId,
                Amount = 2000m,
                NoticeType = NoticeType.InApp,
            };

            try
            {
                // Act
                // Insert
                await _unitOfWork.Repository<LimitEntity, LimitDto>().InsertAsync(newLimitDto);
                await _unitOfWork.SaveChangesAsync();

                // Update
                await _unitOfWork.Repository<LimitEntity, LimitDto>().UpdateAsync(updatedLimitDto);
                await _unitOfWork.SaveChangesAsync();

                // Delete
                await _unitOfWork.Repository<LimitEntity, LimitDto>().DeleteAsync(newLimitDto.Id);
                await _unitOfWork.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            // Assert
            var deletedLimit = await _unitOfWork.Repository<LimitEntity, LimitDto>().GetByIdAsync(newLimitDto.Id);
            Assert.Null(deletedLimit);
        }

        #endregion
    }
}