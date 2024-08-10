using SpendWise.DAL.Entities;
using SpendWise.DAL.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using SpendWise.DAL.Tests.Helpers;

namespace SpendWise.DAL.Tests
{
    /// <summary>
    /// Unit tests for operations related to the <see cref="GroupEntity"/> class.
    /// This class inherits from <see cref="DbContextTestsBase"/> to leverage common database context setup and teardown functionality.
    /// </summary>
    public class GroupEntityTests : DbContextTestsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupEntityTests"/> class.
        /// </summary>
        /// <param name="output">An <see cref="ITestOutputHelper"/> instance for capturing test output.</param>
        public GroupEntityTests(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// Tests that retrieving a group by its ID returns the correct <see cref="GroupEntity"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetGroup_ById_ReturnsCorrectGroup()
        {
            // Arrange
            var expectedGroup = GroupSeeds.GroupFamily;
            var existingGroupId = GroupSeeds.GroupFamily.Id;

            // Act
            var group = await SpendWiseDbContextSUT.Groups
                .FirstOrDefaultAsync(g => g.Id == existingGroupId);

            // Assert
            Assert.NotNull(group);
            DeepAssert.Equal(expectedGroup, group, propertiesToIgnore: new[] { "GroupUsers", "Invitations" });
        }

        /// <summary>
        /// Tests that adding a new group to the database persists the <see cref="GroupEntity"/> correctly.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddGroup_WhenValidGroupIsAdded_GroupIsPersisted()
        {
            // Arrange
            var newGroup = new GroupEntity
            {
                Id = Guid.NewGuid(),
                Name = "New Group",
                Description = "Description of the new group"
            };

            // Act
            SpendWiseDbContextSUT.Groups.Add(newGroup);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            var actualGroup = await SpendWiseDbContextSUT.Groups.FindAsync(newGroup.Id);
            Assert.NotNull(actualGroup);
            DeepAssert.Equal(newGroup, actualGroup, propertiesToIgnore: new[] { "GroupUsers", "Invitations" });
        }

        /// <summary>
        /// Tests that updating an existing group correctly persists changes to the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateGroup_WhenExistingGroupIsUpdated_ChangesArePersisted()
        {
            // Arrange
            var existingGroup = GroupSeeds.GroupFamily;
            var updatedGroup = new GroupEntity
            {
                Id = existingGroup.Id,
                Name = "Updated Family Group",
                Description = "Updated description"
            };

            // Act
            SpendWiseDbContextSUT.Groups.Update(updatedGroup);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            var actualGroup = await SpendWiseDbContextSUT.Groups.FindAsync(existingGroup.Id);
            Assert.NotNull(actualGroup);
            Assert.Equal("Updated Family Group", actualGroup.Name);
            Assert.Equal("Updated description", actualGroup.Description);
        }

        /// <summary>
        /// Tests that deleting a group from the database removes the <see cref="GroupEntity"/> correctly.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteGroup_WhenGroupIsDeleted_GroupIsRemoved()
        {
            // Arrange
            var groupToDelete = GroupSeeds.GroupWork;

            // Act
            SpendWiseDbContextSUT.Groups.Remove(groupToDelete);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            var deletedGroup = await SpendWiseDbContextSUT.Groups.FindAsync(groupToDelete.Id);
            Assert.Null(deletedGroup);
        }

        /// <summary>
        /// Tests that when a <see cref="GroupEntity"/> is fetched, its navigation properties are loaded correctly.
        /// This includes loading associated <see cref="GroupUserEntity"/> and <see cref="InvitationEntity"/> entities.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task VerifyGroupNavigationProperties_WhenGroupIsFetched_NavigationPropertiesAreLoaded()
        {
            // Arrange
            var groupId = GroupSeeds.GroupFamily.Id;

            // Act
            var fetchedGroup = await SpendWiseDbContextSUT.Groups
                .Include(g => g.GroupUsers)
                .Include(g => g.Invitations)
                .FirstOrDefaultAsync(g => g.Id == groupId);

            // Assert
            Assert.NotNull(fetchedGroup);
            Assert.NotNull(fetchedGroup.GroupUsers);
            Assert.NotNull(fetchedGroup.Invitations);
            
            // Verify the count of related entities
            Assert.True(fetchedGroup.GroupUsers.Count > 0);
            Assert.True(fetchedGroup.Invitations.Count > 0);

            // Verify the content of the navigation properties
            DeepAssert.Contains(GroupUserSeeds.GroupUserAdminInFamily, fetchedGroup.GroupUsers, propertiesToIgnore: new[] { "User", "Group", "Limit", "Transactions"});
            DeepAssert.Contains(GroupUserSeeds.GroupUserJohnDoeInFamily, fetchedGroup.GroupUsers, propertiesToIgnore: new[] { "User", "Group", "Limit", "Transactions"});
            DeepAssert.Contains(InvitationSeeds.InvitationAdminToJohnDoeIntoFamily, fetchedGroup.Invitations, propertiesToIgnore: new[] { "Sender", "Reciever", "Group"});
        }
        /// <summary>
        /// Tests that adding a group with the maximum allowed field lengths correctly stores the <see cref="GroupEntity"/> in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddGroup_WithMaximumFieldLength_StoresCorrectly()
        {
            // Arrange
            var group = new GroupEntity
            {
                Id = Guid.NewGuid(),
                Name = new string('A', 100), // Assuming 100 is the maximum length for Name
                Description = new string('B', 200) // Assuming 200 is the maximum length for Description
            };

            // Act
            SpendWiseDbContextSUT.Groups.Add(group);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            var actualGroup = await SpendWiseDbContextSUT.Groups.FindAsync(group.Id);
            Assert.NotNull(actualGroup);
            Assert.Equal(group.Name, actualGroup.Name);
            Assert.Equal(group.Description, actualGroup.Description);
        }

        /// <summary>
        /// Tests that adding multiple groups concurrently correctly persists all <see cref="GroupEntity"/> records in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddGroups_Concurrently_GroupsArePersistedCorrectly()
        {
            // Arrange
            var groups = new List<GroupEntity>
            {
                new GroupEntity { Id = Guid.NewGuid(), Name = "Group1", Description = "Description1" },
                new GroupEntity { Id = Guid.NewGuid(), Name = "Group2", Description = "Description2" },
                new GroupEntity { Id = Guid.NewGuid(), Name = "Group3", Description = "Description3" }
            };

            // Act
            await SpendWiseDbContextSUT.Groups.AddRangeAsync(groups);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            foreach (var group in groups)
            {
                var actualGroup = await dbx.Groups.FindAsync(group.Id);
                Assert.NotNull(actualGroup);
                Assert.Equal(group.Name, actualGroup.Name);
                Assert.Equal(group.Description, actualGroup.Description);
            }
        }

        /// <summary>
        /// Tests that updating a group with invalid data throws a <see cref="DbUpdateException"/> as expected.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateGroup_WithInvalidData_ShouldThrowException()
        {
            // Arrange
            var existingGroup = GroupSeeds.GroupFriends; // Assuming this seed exists
            var invalidGroup = new GroupEntity
            {
                Id = existingGroup.Id,
                Name = new string('A', 101), // Assuming 100 is the maximum length for Name
                Description = existingGroup.Description
            };

            // Act & Assert
            SpendWiseDbContextSUT.Groups.Update(invalidGroup);
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () => await SpendWiseDbContextSUT.SaveChangesAsync());
            Assert.NotNull(exception);
        }

        /// <summary>
        /// Tests that retrieving groups by a name containing a specific substring returns the correct <see cref="GroupEntity"/> records.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetGroups_ByNameContaining_ReturnsCorrectGroups()
        {
            // Arrange
            var substring = "Friends";

            // Act
            var groups = await SpendWiseDbContextSUT.Groups
                .Where(g => g.Name.Contains(substring))
                .ToListAsync();

            // Assert
            Assert.NotNull(groups);
            Assert.All(groups, group => Assert.Contains(substring, group.Name));
        }
        /// <summary>
        /// Tests that retrieving groups by a description containing a specific substring returns the correct <see cref="GroupEntity"/> records.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetGroups_ByDescriptionContaining_ReturnsCorrectGroups()
        {
            // Arrange
            var substring = "Work";

            // Act
            var groups = await SpendWiseDbContextSUT.Groups
                .Where(g => g.Description != null && g.Description.Contains(substring))
                .ToListAsync();

            // Assert
            Assert.NotNull(groups);
            Assert.All(groups, group => Assert.Contains(substring, group.Description));
        }

        /// <summary>
        /// Tests that fetching a group with its related users correctly sets up the relationship between the group and its users.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task VerifyGroupUserRelationship_WhenGroupIsFetched_RelationshipIsCorrect()
        {
            // Arrange
            var groupId = GroupSeeds.GroupFamily.Id; // Use an existing group with related users

            // Act
            var group = await SpendWiseDbContextSUT.Groups
                .Include(g => g.GroupUsers)
                .FirstOrDefaultAsync(g => g.Id == groupId);

            // Assert
            Assert.NotNull(group);
            Assert.NotEmpty(group.GroupUsers);
            Assert.All(group.GroupUsers, gu => Assert.Equal(groupId, gu.GroupId));
        }

        /// <summary>
        /// Tests that deleting a group from the database correctly removes associated <see cref="GroupUserEntity"/> and <see cref="InvitationEntity"/> records.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task RemoveGroup_WhenGroupIsDeleted_GroupUsersAndInvitationsAreRemoved()
        {
            // Arrange
            var existingGroup = GroupSeeds.GroupFamily;

            // Fetch and verify related GroupUsers and Invitations
            var groupUsers = await SpendWiseDbContextSUT.GroupUsers
                .Where(gu => gu.GroupId == existingGroup.Id)
                .ToListAsync();
            var invitations = await SpendWiseDbContextSUT.Invitations
                .Where(i => i.GroupId == existingGroup.Id)
                .ToListAsync();

            Assert.NotEmpty(groupUsers);
            Assert.NotEmpty(invitations);

            // Act
            SpendWiseDbContextSUT.Groups.Remove(existingGroup);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert: Verify GroupUsers have been removed
            var remainingGroupUsers = await SpendWiseDbContextSUT.GroupUsers
                .Where(gu => gu.GroupId == existingGroup.Id)
                .ToListAsync();
            Assert.Empty(remainingGroupUsers);

            // Assert: Verify Invitations have been removed
            var remainingInvitations = await SpendWiseDbContextSUT.Invitations
                .Where(i => i.GroupId == existingGroup.Id)
                .ToListAsync();
            Assert.Empty(remainingInvitations);
        }    
    }
}