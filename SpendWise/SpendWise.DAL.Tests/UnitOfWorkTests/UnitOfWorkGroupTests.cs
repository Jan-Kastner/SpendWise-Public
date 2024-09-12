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
    public class UnitOfWorkGroupTests : UnitOfWorkTestsBase
    {
        public UnitOfWorkGroupTests(ITestOutputHelper output) : base(output)
        {
        }

        #region CRUD Operations Tests

        /// <summary>
        /// Unit tests for CRUD (Create, Read, Update, Delete) operations on groups.
        /// These tests verify that groups can be successfully added, fetched, updated, and deleted from the database.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that adding a group with valid data successfully persists the group in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddGroup_ValidData_SuccessfullyPersists()
        {
            // Arrange
            var groupToAdd = new GroupDto
            {
                Id = Guid.NewGuid(),
                Name = "Test Group",
                Description = "Test group description"
            };

            // Act
            await _unitOfWork.Repository<GroupEntity, GroupDto>().InsertAsync(groupToAdd);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var actualGroup = await _unitOfWork.Repository<GroupEntity, GroupDto>().GetByIdAsync(groupToAdd.Id);
            Assert.NotNull(actualGroup);
            DeepAssert.Equal(groupToAdd, actualGroup);
        }

        [Fact]
        /// <summary>
        /// Verifies that fetching a group by an existing ID returns the expected group.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task FetchGroupById_ExistingId_ReturnsExpectedGroup()
        {
            // Arrange
            var expectedGroup = _mapper.Map<GroupDto>(GroupSeeds.GroupFamily);

            // Act
            var actualGroup = await _unitOfWork.Repository<GroupEntity, GroupDto>().GetByIdAsync(expectedGroup.Id);

            // Assert
            Assert.NotNull(actualGroup);
            DeepAssert.Equal(expectedGroup, actualGroup);
        }

        [Fact]
        /// <summary>
        /// Verifies that updating a group with valid data successfully persists the changes in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateGroup_ValidData_SuccessfullyPersistsChanges()
        {
            // Arrange
            var existingGroup = _mapper.Map<GroupDto>(GroupSeeds.GroupFamily);
            var updatedGroup = new GroupDto
            {
                Id = existingGroup.Id,
                Name = "Updated Group",
                Description = "Updated description"
            };

            // Act
            await _unitOfWork.Repository<GroupEntity, GroupDto>().UpdateAsync(updatedGroup);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var actualGroup = await _unitOfWork.Repository<GroupEntity, GroupDto>().GetByIdAsync(updatedGroup.Id);
            Assert.NotNull(actualGroup);
            DeepAssert.Equal(updatedGroup, actualGroup);
        }

        [Fact]
        /// <summary>
        /// Verifies that deleting a group with an existing ID successfully removes the group from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteGroup_ExistingId_SuccessfullyRemovesGroup()
        {
            // Arrange
            var groupToDelete = _mapper.Map<GroupDto>(GroupSeeds.GroupFamily);

            // Act
            await _unitOfWork.Repository<GroupEntity, GroupDto>().DeleteAsync(groupToDelete.Id);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var deletedGroup = await _unitOfWork.Repository<GroupEntity, GroupDto>().GetByIdAsync(groupToDelete.Id);
            Assert.Null(deletedGroup);
        }

        #endregion

        #region Error Handling Tests

        /// <summary>
        /// Unit tests for error handling during group operations.
        /// These tests verify that appropriate exceptions are thrown for invalid operations.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that attempting to update a non-existent group throws an InvalidOperationException.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateGroup_NonExistentGroup_ThrowsInvalidOperationException()
        {
            // Arrange
            var nonExistentGroup = new GroupDto
            {
                Id = Guid.NewGuid(), // Non-existent ID
                Name = "Non-Existent Group",
                Description = "This group does not exist"
            };

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await _unitOfWork.Repository<GroupEntity, GroupDto>().UpdateAsync(nonExistentGroup);
                await _unitOfWork.SaveChangesAsync();
            });
        }

        [Fact]
        /// <summary>
        /// Verifies that attempting to delete a non-existent group throws a KeyNotFoundException.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteGroup_NonExistentGroup_ThrowsKeyNotFoundException()
        {
            // Arrange
            var nonExistentGroupId = Guid.NewGuid(); // Non-existent ID

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await _unitOfWork.Repository<GroupEntity, GroupDto>().DeleteAsync(nonExistentGroupId);
                await _unitOfWork.SaveChangesAsync();
            });
        }

        #endregion

        #region Update and Special Cases Tests

        /// <summary>
        /// Unit tests for updating groups and handling special cases.
        /// These tests verify that groups can be successfully updated even with special conditions.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that updating a group with an empty description is successful and persists the changes.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateGroup_WithEmptyDescription_SuccessfullyUpdates()
        {
            // Arrange
            var existingGroup = _mapper.Map<GroupDto>(GroupSeeds.GroupFamily);
            var updatedGroup = new GroupDto
            {
                Id = existingGroup.Id,
                Name = "Group with Empty Description",
                Description = string.Empty
            };

            // Act
            await _unitOfWork.Repository<GroupEntity, GroupDto>().UpdateAsync(updatedGroup);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var actualGroup = await _unitOfWork.Repository<GroupEntity, GroupDto>().GetByIdAsync(updatedGroup.Id);
            Assert.NotNull(actualGroup);
            DeepAssert.Equal(updatedGroup, actualGroup);
        }

        [Fact]
        /// <summary>
        /// Verifies that adding a group with special characters in the name is successful and persists the group.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddGroup_WithSpecialCharactersInName_SuccessfullyPersists()
        {
            // Arrange
            var groupToAdd = new GroupDto
            {
                Id = Guid.NewGuid(),
                Name = "Test Group!@#$%^&*()_+",
                Description = "Group with special characters in the name"
            };

            // Act
            await _unitOfWork.Repository<GroupEntity, GroupDto>().InsertAsync(groupToAdd);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var actualGroup = await _unitOfWork.Repository<GroupEntity, GroupDto>().GetByIdAsync(groupToAdd.Id);
            Assert.NotNull(actualGroup);
            DeepAssert.Equal(groupToAdd, actualGroup);
        }

        #endregion

        #region Related Entities Handling Tests

        /// <summary>
        /// Unit tests for handling related entities during group operations.
        /// These tests verify that integrity constraints are maintained after group deletions.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that after deleting a group, the associated invitations and users are properly removed to ensure integrity constraints are maintained.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteGroup_CheckIntegrityConstraints_AfterDeletion()
        {
            // Arrange
            var groupId = GroupSeeds.GroupFamily.Id;

            // Verify the initial state before deletion
            var initialInvitations = await _unitOfWork.Repository<InvitationEntity, InvitationDto>()
                .GetAsync(new InvitationQueryObject().WithGroup(groupId));
            Assert.NotEmpty(initialInvitations); // Ensure there are invitations related to the group

            var initialGroupUsers = await _unitOfWork.Repository<GroupUserEntity, GroupUserDto>()
                .GetAsync(new GroupUserQueryObject().WithGroup(groupId));
            Assert.NotEmpty(initialGroupUsers); // Ensure there are users related to the group

            // Act
            await _unitOfWork.Repository<GroupEntity, GroupDto>().DeleteAsync(groupId);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var deletedGroup = await _unitOfWork.Repository<GroupEntity, GroupDto>().GetByIdAsync(groupId);
            Assert.Null(deletedGroup); // Ensure the group is deleted

            var invitationsAfterDelete = await _unitOfWork.Repository<InvitationEntity, InvitationDto>()
                .GetAsync(new InvitationQueryObject().WithGroup(groupId));
            Assert.Empty(invitationsAfterDelete); // Ensure all invitations related to the group are removed

            var usersAfterDelete = await _unitOfWork.Repository<GroupUserEntity, GroupUserDto>()
                .GetAsync(new GroupUserQueryObject().WithGroup(groupId));
            Assert.Empty(usersAfterDelete); // Ensure all users related to the group are removed
        }


        #endregion


        #region Consistency Tests

        /// <summary>
        /// Unit tests for ensuring transactional consistency after multiple group operations.
        /// These tests verify that all operations are completed successfully and the database remains in a consistent state.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that multiple group operations (insert, update, delete) maintain transactional consistency.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task TransactionalConsistency_AfterMultipleGroupOperations()
        {
            // Arrange
            var newGroupDto = new GroupDto
            {
                Id = Guid.NewGuid(),
                Name = "Test Group",
                Description = "A group for testing"
            };

            var updatedGroupDto = new GroupDto
            {
                Id = newGroupDto.Id,
                Name = "Updated Test Group",
                Description = "Updated description for testing"
            };

            try
            {
                // Act
                // Insert
                await _unitOfWork.Repository<GroupEntity, GroupDto>().InsertAsync(newGroupDto);
                await _unitOfWork.SaveChangesAsync();

                // Update
                await _unitOfWork.Repository<GroupEntity, GroupDto>().UpdateAsync(updatedGroupDto);
                await _unitOfWork.SaveChangesAsync();

                // Delete
                await _unitOfWork.Repository<GroupEntity, GroupDto>().DeleteAsync(newGroupDto.Id);
                await _unitOfWork.SaveChangesAsync();

                // Verify the group has been deleted
                var deletedGroup = await _unitOfWork.Repository<GroupEntity, GroupDto>().GetByIdAsync(newGroupDto.Id);
                Assert.Null(deletedGroup);
            }
            catch (Exception)
            {
                Assert.False(true, "Transactional consistency was broken.");
            }
        }

        #endregion
    }
}
