using Xunit;
using Xunit.Abstractions;
using SpendWise.DAL.DTOs;
using Microsoft.EntityFrameworkCore;
using SpendWise.Common.Tests.Seeds;
using SpendWise.Common.Tests.Helpers;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;

namespace SpendWise.DAL.Tests.UnitOfWorkTests
{
    public class UnitOfWorkGroupUserTests : UnitOfWorkTestsBase
    {
        public UnitOfWorkGroupUserTests(ITestOutputHelper output) : base(output)
        {
        }

        #region CRUD Operations Tests

        /// <summary>
        /// Unit tests for basic CRUD (Create, Read, Update, Delete) operations on GroupUser entities.
        /// These tests verify that GroupUser entities can be successfully added and removed from the database.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that adding a GroupUser with valid data is successful and persists the GroupUser entity.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddGroupUser_ValidData_SuccessfullyPersists()
        {
            // Arrange
            var groupUserToAdd = new GroupUserDto
            {
                Id = Guid.NewGuid(),
                UserId = UserSeeds.UserAliceSmith.Id,
                GroupId = GroupSeeds.GroupFamily.Id
            };

            // Act
            await _unitOfWork.Repository<GroupUserEntity, GroupUserDto>().InsertAsync(groupUserToAdd);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var actualGroupUser = await _unitOfWork.Repository<GroupUserEntity, GroupUserDto>().GetByIdAsync(groupUserToAdd.Id);
            Assert.NotNull(actualGroupUser);
            DeepAssert.Equal(groupUserToAdd, actualGroupUser);
        }

        [Fact]
        /// <summary>
        /// Verifies that deleting an existing GroupUser by its ID is successful and removes the GroupUser from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteGroupUser_ExistingId_SuccessfullyRemoves()
        {
            // Arrange
            var groupUserToDelete = _mapper.Map<GroupUserDto>(GroupUserSeeds.GroupUserBobInFamily);

            // Act
            await _unitOfWork.Repository<GroupUserEntity, GroupUserDto>().DeleteAsync(groupUserToDelete.Id);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var deletedGroupUser = await _unitOfWork.Repository<GroupUserEntity, GroupUserDto>().GetByIdAsync(groupUserToDelete.Id);
            Assert.Null(deletedGroupUser);
        }

        [Fact]
        /// <summary>
        /// Verifies that fetching a GroupUser by an existing ID returns the expected GroupUser entity.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task FetchGroupUserById_ExistingId_ReturnsExpectedGroupUser()
        {
            // Arrange
            var expectedGroupUser = _mapper.Map<GroupUserDto>(GroupUserSeeds.GroupUserBobInFamily);

            // Act
            var actualGroupUser = await _unitOfWork.Repository<GroupUserEntity, GroupUserDto>().GetByIdAsync(expectedGroupUser.Id);

            // Assert
            Assert.NotNull(actualGroupUser);
            DeepAssert.Equal(expectedGroupUser, actualGroupUser);
        }

        #endregion

        #region Error Handling Tests

        /// <summary>
        /// Unit tests for error handling during GroupUser operations.
        /// These tests verify that the appropriate exceptions are thrown for invalid operations.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that adding a GroupUser with a duplicate UserId and GroupId throws a DbUpdateException.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddGroupUser_DuplicateUserIdAndGroupId_ThrowsDbUpdateException()
        {
            // Arrange
            var existingGroupUser = _mapper.Map<GroupUserDto>(GroupUserSeeds.GroupUserBobInFamily);
            var duplicateGroupUser = new GroupUserDto
            {
                Id = Guid.NewGuid(),
                UserId = existingGroupUser.UserId, // Duplicate UserId
                GroupId = existingGroupUser.GroupId // Duplicate GroupId
            };

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                await _unitOfWork.Repository<GroupUserEntity, GroupUserDto>().InsertAsync(duplicateGroupUser);
                await _unitOfWork.SaveChangesAsync();
            });
        }

        [Fact]
        /// <summary>
        /// Verifies that fetching a GroupUser by an invalid ID returns null.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task FetchGroupUserById_InvalidId_ReturnsNull()
        {
            // Arrange
            var invalidId = Guid.NewGuid();

            // Act
            var actualGroupUser = await _unitOfWork.Repository<GroupUserEntity, GroupUserDto>().GetByIdAsync(invalidId);

            // Assert
            Assert.Null(actualGroupUser);
        }

        [Fact]
        /// <summary>
        /// Verifies that deleting a GroupUser with a non-existent ID throws a KeyNotFoundException.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteGroupUser_NonExistentId_ThrowsKeyNotFoundException()
        {
            // Arrange
            var nonExistentId = Guid.NewGuid();

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await _unitOfWork.Repository<GroupUserEntity, GroupUserDto>().DeleteAsync(nonExistentId);
                await _unitOfWork.SaveChangesAsync();
            });
        }

        [Fact]
        /// <summary>
        /// Verifies that adding a GroupUser with invalid data throws a DbUpdateException.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddGroupUser_InvalidData_ThrowsDbUpdateException()
        {
            // Arrange
            var invalidGroupUser = new GroupUserDto
            {
                Id = Guid.NewGuid(),
                UserId = Guid.Empty, // Invalid UserId
                GroupId = Guid.Empty // Invalid GroupId
            };

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                await _unitOfWork.Repository<GroupUserEntity, GroupUserDto>().InsertAsync(invalidGroupUser);
                await _unitOfWork.SaveChangesAsync();
            });
        }

        #endregion

        #region Update and Special Cases Tests

        /// <summary>
        /// Unit tests for updating GroupUser entities and handling special cases.
        /// These tests verify that updates to certain properties are restricted and that the system behaves as expected in special scenarios.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that attempting to change the UserId or GroupId of an existing GroupUser does not change those properties.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateGroupUser_ChangeUserIdOrGroupId_ShouldNotChange()
        {
            // Arrange
            var existingGroupUser = _mapper.Map<GroupUserDto>(GroupUserSeeds.GroupUserBobInFamily);

            var updatedGroupUser = new GroupUserDto
            {
                Id = existingGroupUser.Id,
                UserId = Guid.NewGuid(), // Attempt to change UserId
                GroupId = Guid.NewGuid() // Attempt to change GroupId
            };

            // Act
            await _unitOfWork.Repository<GroupUserEntity, GroupUserDto>().UpdateAsync(updatedGroupUser);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var actualGroupUser = await _unitOfWork.Repository<GroupUserEntity, GroupUserDto>().GetByIdAsync(existingGroupUser.Id);
            Assert.NotNull(actualGroupUser);
            Assert.Equal(existingGroupUser.UserId, actualGroupUser.UserId); // UserId should remain unchanged
            Assert.Equal(existingGroupUser.GroupId, actualGroupUser.GroupId); // GroupId should remain unchanged
        }

        #endregion

        #region Related Entities Handling Tests

        /// <summary>
        /// Unit tests for handling related entities when performing operations on GroupUser entities.
        /// These tests verify that related entities are correctly affected or not affected by GroupUser operations.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that deleting a GroupUser with an associated limit removes the limit entity from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteGroupUser_WithLimit_RemovesLimit()
        {
            // Arrange
            var groupUserId = GroupUserSeeds.GroupUserCharlieInFamily.Id;
            var associatedLimitId = LimitSeeds.LimitCharlieFamily.Id;

            // Verify that the LimitEntity exists before deletion
            var initialLimit = await _unitOfWork.Repository<LimitEntity, LimitDto>().GetByIdAsync(associatedLimitId);
            Assert.NotNull(initialLimit);

            // Act
            await _unitOfWork.Repository<GroupUserEntity, GroupUserDto>().DeleteAsync(groupUserId);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var deletedGroupUser = await _unitOfWork.Repository<GroupUserEntity, GroupUserDto>().GetByIdAsync(groupUserId);
            Assert.Null(deletedGroupUser);

            var deletedLimit = await _unitOfWork.Repository<LimitEntity, LimitDto>().GetByIdAsync(associatedLimitId);
            Assert.Null(deletedLimit);
        }

        [Fact]
        /// <summary>
        /// Verifies that deleting a GroupUser without associated limits does not affect related entities (User and Group).
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteGroupUser_CheckIntegrityConstraints_AfterDeletion()
        {
            // Arrange
            var groupUserId = GroupUserSeeds.GroupUserBobInFamily.Id;
            var expectedUserId = GroupUserSeeds.GroupUserBobInFamily.UserId;
            var expectedGroupId = GroupUserSeeds.GroupUserBobInFamily.GroupId;

            // Act
            await _unitOfWork.Repository<GroupUserEntity, GroupUserDto>().DeleteAsync(groupUserId);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var deletedGroupUser = await _unitOfWork.Repository<GroupUserEntity, GroupUserDto>().GetByIdAsync(groupUserId);
            Assert.Null(deletedGroupUser);

            var relatedUser = await _unitOfWork.Repository<UserEntity, UserDto>().GetByIdAsync(expectedUserId);
            Assert.NotNull(relatedUser);

            var relatedGroup = await _unitOfWork.Repository<GroupEntity, GroupDto>().GetByIdAsync(expectedGroupId);
            Assert.NotNull(relatedGroup);
        }

        #endregion

        #region Consistency and Integrity Tests

        /// <summary>
        /// Unit tests for checking consistency and integrity of GroupUser entities.
        /// These tests verify that operations on GroupUser entities maintain expected counts and transactional integrity.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies the transactional consistency after performing multiple operations (insert, update, delete) on GroupUser entities.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task TransactionalConsistency_AfterMultipleGroupUserOperations()
        {
            // Arrange
            var newGroupUserDto = new GroupUserDto
            {
                Id = Guid.NewGuid(),
                UserId = UserSeeds.UserAliceSmith.Id,
                GroupId = GroupSeeds.GroupWork.Id
            };

            var updatedGroupUserDto = new GroupUserDto
            {
                Id = newGroupUserDto.Id,
                UserId = newGroupUserDto.UserId,
                GroupId = GroupSeeds.GroupFamily.Id
            };

            try
            {
                // Act
                // Insert
                await _unitOfWork.Repository<GroupUserEntity, GroupUserDto>().InsertAsync(newGroupUserDto);
                await _unitOfWork.SaveChangesAsync();

                // Update
                await _unitOfWork.Repository<GroupUserEntity, GroupUserDto>().UpdateAsync(updatedGroupUserDto);
                await _unitOfWork.SaveChangesAsync();

                // Delete
                await _unitOfWork.Repository<GroupUserEntity, GroupUserDto>().DeleteAsync(newGroupUserDto.Id);
                await _unitOfWork.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            // Assert
            var deletedGroupUser = await _unitOfWork.Repository<GroupUserEntity, GroupUserDto>().GetByIdAsync(newGroupUserDto.Id);
            Assert.Null(deletedGroupUser);
        }

        #endregion
    }
}


