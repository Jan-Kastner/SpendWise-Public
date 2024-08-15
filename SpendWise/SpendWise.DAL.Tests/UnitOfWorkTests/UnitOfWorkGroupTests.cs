using Xunit.Abstractions;
using SpendWise.DAL.DTOs;
using Microsoft.EntityFrameworkCore;
using SpendWise.Common.Tests.Seeds;
using SpendWise.Common.Tests.Helpers;

namespace SpendWise.DAL.Tests
{
    /// <summary>
    /// Contains tests for operations related to groups using the 
    /// Unit of Work pattern.
    /// </summary>
    public class UnitOfWorkGroupTests : UnitOfWorkTestsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkGroupTests"/> class.
        /// </summary>
        /// <param name="output">The output helper instance.</param>
        public UnitOfWorkGroupTests(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// Tests if inserting a new group with valid data correctly adds the group to the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task InsertGroup_AddsGroupToDatabase()
        {
            // Arrange
            var newGroup = new GroupDto
            {
                Id = Guid.NewGuid(),
                Name = "Test Group",
                Description = "Test group description"
            };

            // Act
            await _unitOfWork.Groups.InsertAsync(newGroup);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var groupInDb = await _unitOfWork.Groups.GetByIdAsync(newGroup.Id);
            Assert.NotNull(groupInDb);
            DeepAssert.Equal(newGroup, groupInDb);
        }

        /// <summary>
        /// Tests if fetching a group by an existing ID returns the correct group.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetGroupById_ReturnsCorrectGroup()
        {
            // Arrange
            var expectedGroupDto = _mapper.Map<GroupDto>(GroupSeeds.GroupFamily);

            // Act
            var fetchedGroupDto = await _unitOfWork.Groups.GetByIdAsync(expectedGroupDto.Id);

            // Assert
            Assert.NotNull(fetchedGroupDto);
            DeepAssert.Equal(expectedGroupDto, fetchedGroupDto);
        }

        /// <summary>
        /// Tests if updating a group with valid data correctly updates the group in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateGroup_UpdatesGroupInDatabase()
        {
            // Arrange
            var existingGroupDto = _mapper.Map<GroupDto>(GroupSeeds.GroupFamily);

            var updatedGroupDto = new GroupDto
            {
                Id = existingGroupDto.Id,
                Name = "Updated Group",
                Description = "Updated description"
            };

            // Act
            await _unitOfWork.Groups.UpdateAsync(updatedGroupDto);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var resultGroupDto = await _unitOfWork.Groups.GetByIdAsync(updatedGroupDto.Id);
            Assert.NotNull(resultGroupDto);
            DeepAssert.Equal(updatedGroupDto, resultGroupDto);
        }

        /// <summary>
        /// Tests if deleting a group by an existing ID correctly removes the group from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteGroup_RemovesGroupFromDatabase()
        {
            // Arrange
            var groupDto = _mapper.Map<GroupDto>(GroupSeeds.GroupFamily);

            // Act
            await _unitOfWork.Groups.DeleteAsync(groupDto.Id);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var deletedGroup = await _unitOfWork.Groups.GetByIdAsync(groupDto.Id);
            Assert.Null(deletedGroup);
        }

        /// <summary>
        /// Tests if updating a non-existent group fails as expected.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateGroup_NonExistentGroup_ShouldFail()
        {
            // Arrange
            var nonExistentGroupId = Guid.NewGuid();
            var groupToUpdate = new GroupDto
            {
                Id = nonExistentGroupId,
                Name = "Non Existent Group",
                Description = "This group does not exist"
            };

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await _unitOfWork.Groups.UpdateAsync(groupToUpdate);
                await _unitOfWork.SaveChangesAsync();
            });
        }

        /// <summary>
        /// Tests if deleting a non-existent group fails as expected.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteGroup_NonExistentGroup_ShouldFail()
        {
            // Arrange
            var nonExistentGroupId = Guid.NewGuid();

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await _unitOfWork.Groups.DeleteAsync(nonExistentGroupId);
                await _unitOfWork.SaveChangesAsync();
            });
        }

        /// <summary>
        /// Tests if fetching all groups returns the correct number of groups and includes all seeded groups.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetAllGroups_ShouldReturnAllGroups()
        {
            // Arrange
            var expectedGroupCount = 3; // Number of groups seeded without relationships

            // Act
            var allGroups = await _unitOfWork.Groups.Get().ToListAsync();

            // Assert
            Assert.NotNull(allGroups);
            Assert.Equal(expectedGroupCount, allGroups.Count);

            // Verify that all seeded groups are present in the database
            Assert.Contains(allGroups, g => g.Id == GroupSeeds.GroupFamily.Id && g.Name == GroupSeeds.GroupFamily.Name);
            Assert.Contains(allGroups, g => g.Id == GroupSeeds.GroupFriends.Id && g.Name == GroupSeeds.GroupFriends.Name);
            Assert.Contains(allGroups, g => g.Id == GroupSeeds.GroupWork.Id && g.Name == GroupSeeds.GroupWork.Name);
        }

        /// <summary>
        /// Tests if fetching a group by its name returns the correct group.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetGroupByName_ReturnsCorrectGroup()
        {
            // Arrange
            var expectedGroupDto = _mapper.Map<GroupDto>(GroupSeeds.GroupFamily);

            // Act
            var fetchedGroupDto = await _unitOfWork.Groups.Get(g => g.Name == expectedGroupDto.Name).FirstOrDefaultAsync();

            // Assert
            Assert.NotNull(fetchedGroupDto);
            DeepAssert.Equal(expectedGroupDto, fetchedGroupDto);
        }

        /// <summary>
        /// Tests if updating a group with new name and description correctly updates both fields in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateGroup_ChangeNameAndDescription_ShouldUpdateBoth()
        {
            // Arrange
            var existingGroupDto = _mapper.Map<GroupDto>(GroupSeeds.GroupFamily);

            var updatedGroupDto = new GroupDto
            {
                Id = existingGroupDto.Id,
                Name = "Updated Group",
                Description = "Updated description"
            };

            // Act
            await _unitOfWork.Groups.UpdateAsync(updatedGroupDto);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var resultGroupDto = await _unitOfWork.Groups.GetByIdAsync(updatedGroupDto.Id);
            Assert.NotNull(resultGroupDto);
            DeepAssert.Equal(updatedGroupDto, resultGroupDto);
        }

        /// <summary>
        /// Tests if updating a group with an empty description is allowed and correctly updates the description to empty.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateGroup_WithEmptyDescription_ShouldBeAllowed()
        {
            // Arrange
            var existingGroupDto = _mapper.Map<GroupDto>(GroupSeeds.GroupFamily);

            var updatedGroupDto = new GroupDto
            {
                Id = existingGroupDto.Id,
                Name = "Group with Empty Description",
                Description = string.Empty
            };

            // Act
            await _unitOfWork.Groups.UpdateAsync(updatedGroupDto);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var resultGroupDto = await _unitOfWork.Groups.GetByIdAsync(updatedGroupDto.Id);
            Assert.NotNull(resultGroupDto);
            DeepAssert.Equal(updatedGroupDto, resultGroupDto);
        }

        /// <summary>
        /// Tests if creating a group with special characters in the name is successfully handled.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task CreateGroup_WithSpecialCharactersInName_ShouldSucceed()
        {
            // Arrange
            var newGroup = new GroupDto
            {
                Id = Guid.NewGuid(),
                Name = "Test Group!@#$%^&*()_+",
                Description = "Group with special characters in the name"
            };

            // Act
            await _unitOfWork.Groups.InsertAsync(newGroup);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var groupInDb = await _unitOfWork.Groups.GetByIdAsync(newGroup.Id);
            Assert.NotNull(groupInDb);
            DeepAssert.Equal(newGroup, groupInDb);
        }

        /// <summary>
        /// Tests if deleting a group with active invitations is handled properly by removing the group and its related invitations.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteGroup_WithActiveInvitations_ShouldHandleProperly()
        {
            // Arrange
            var groupId = GroupSeeds.GroupFamilyWithRelations.Id;

            // Verify the invitation exists before deletion
            var initialInvitation = await _unitOfWork.Invitations.Get(i => i.GroupId == groupId).FirstOrDefaultAsync();
            Assert.NotNull(initialInvitation);

            // Act
            await _unitOfWork.Groups.DeleteAsync(groupId);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var deletedGroup = await _unitOfWork.Groups.GetByIdAsync(groupId);
            Assert.Null(deletedGroup);

            var deletedInvitation = await _unitOfWork.Invitations.Get(i => i.GroupId == groupId).FirstOrDefaultAsync();
            Assert.Null(deletedInvitation);
        }

        /// <summary>
        /// Tests if deleting a group with active users correctly removes all associated users from the group.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteGroup_WithActiveUsers_ShouldRemoveAllAssociatedUsers()
        {
            // Arrange
            var groupId = GroupSeeds.GroupFamilyWithRelations.Id;

            var initialGroupUsers = await _unitOfWork.GroupUsers.Get(gu => gu.GroupId == groupId).ToListAsync();
            Assert.NotEmpty(initialGroupUsers);

            // Act
            await _unitOfWork.Groups.DeleteAsync(groupId);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var deletedGroup = await _unitOfWork.Groups.GetByIdAsync(groupId);
            Assert.Null(deletedGroup);

            var deletedGroupUsers = await _unitOfWork.GroupUsers.Get(gu => gu.GroupId == groupId).ToListAsync();
            Assert.Empty(deletedGroupUsers);
        }

        /// <summary>
        /// Tests if fetching a group by its description returns the correct group.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetGroupByDescription_ReturnsCorrectGroup()
        {
            // Arrange
            var descriptionToSearch = "Family group"; // Use the description from your seed data

            // Assuming that the seed data is already applied to your test database
            var expectedGroupDto = _mapper.Map<GroupDto>(GroupSeeds.GroupFamily);

            // Act
            var fetchedGroupDto = await _unitOfWork.Groups
                .Get(g => g.Description != null && g.Description.Contains(descriptionToSearch))
                .FirstOrDefaultAsync();

            // Assert
            Assert.NotNull(fetchedGroupDto);
            DeepAssert.Equal(expectedGroupDto, fetchedGroupDto);
        }

        /// <summary>
        /// Tests if a group remains consistent after multiple updates.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateGroup_ConsistencyAfterMultipleUpdates()
        {
            // Arrange
            var existingGroupDto = _mapper.Map<GroupDto>(GroupSeeds.GroupFamily);

            // First update
            var firstUpdateDto = new GroupDto
            {
                Id = existingGroupDto.Id,
                Name = "First Update",
                Description = "First update description"
            };

            // Second update
            var secondUpdateDto = new GroupDto
            {
                Id = existingGroupDto.Id,
                Name = "Second Update",
                Description = "Second update description"
            };

            // Act
            await _unitOfWork.Groups.UpdateAsync(firstUpdateDto);
            await _unitOfWork.SaveChangesAsync();

            await _unitOfWork.Groups.UpdateAsync(secondUpdateDto);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var resultGroupDto = await _unitOfWork.Groups.GetByIdAsync(secondUpdateDto.Id);
            Assert.NotNull(resultGroupDto);
            DeepAssert.Equal(secondUpdateDto, resultGroupDto);
        }
    }
}
