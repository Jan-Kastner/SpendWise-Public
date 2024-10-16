using SpendWise.DAL.Entities;
using SpendWise.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using SpendWise.Common.Tests.Helpers;

namespace SpendWise.DAL.Tests
{
    /// <summary>
    /// Unit tests for operations related to the <see cref="GroupEntity"/> class.
    /// This class inherits from <see cref="DbContextTestsBase"/> to leverage common database context setup and 
    /// teardown functionality.
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

        #region CRUD Operations Tests

        /// <summary>
        /// Verifies that fetching a group by its ID returns the expected group entity.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchGroupById_ShouldReturnExpectedGroup()
        {
            // Arrange
            var expectedGroup = GroupSeeds.GroupFamily;
            var groupId = expectedGroup.Id;

            // Act
            var actualGroup = await SpendWiseDbContextSUT.Groups
                .SingleOrDefaultAsync(g => g.Id == groupId);

            // Assert
            Assert.NotNull(actualGroup);
            DeepAssert.Equal(expectedGroup, actualGroup);
        }

        /// <summary>
        /// Verifies that a valid group entity can be added to the database and persists successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddGroup_ShouldPersistValidGroup()
        {
            // Arrange
            var newGroup = new GroupEntity
            {
                Id = Guid.NewGuid(),
                Name = "New Group",
                Description = "Description of the new group",
                GroupUsers = new List<GroupUserEntity>(),
                Invitations = new List<InvitationEntity>()
            };

            // Act
            SpendWiseDbContextSUT.Groups.Add(newGroup);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualGroup = await dbx.Groups.FindAsync(newGroup.Id);

            Assert.NotNull(actualGroup);
            DeepAssert.Equal(newGroup, actualGroup);
        }

        /// <summary>
        /// Verifies that an existing group entity can be updated in the database and the changes persist correctly.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateGroup_ShouldPersistChanges()
        {
            // Arrange
            var existingGroup = GroupSeeds.GroupFamily;

            var updatedGroup = new GroupEntity
            {
                Id = existingGroup.Id,
                Name = existingGroup.Name + " Updated",
                Description = existingGroup.Description + " Updated",
                GroupUsers = new List<GroupUserEntity>(),
                Invitations = new List<InvitationEntity>()
            };

            // Act
            SpendWiseDbContextSUT.Groups.Update(updatedGroup);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualGroup = await dbx.Groups
                .FirstOrDefaultAsync(g => g.Id == existingGroup.Id);

            Assert.NotNull(actualGroup);
            DeepAssert.Equal(updatedGroup, actualGroup);
        }

        /// <summary>
        /// Verifies that an existing group entity can be deleted from the database, and the deletion is successful.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteGroup_ShouldRemoveGroup()
        {
            // Arrange
            var groupToDelete = await SpendWiseDbContextSUT.Groups
                .AsNoTracking()
                .FirstAsync(g => g.Id == GroupSeeds.GroupWork.Id);

            Assert.NotNull(groupToDelete);
            Assert.True(await SpendWiseDbContextSUT.Groups.AnyAsync(g => g.Id == groupToDelete.Id));

            // Act
            SpendWiseDbContextSUT.Groups.Remove(groupToDelete);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var isGroupDeleted = await dbx.Groups
                .AsNoTracking()
                .AnyAsync(g => g.Id == groupToDelete.Id);

            Assert.False(isGroupDeleted);
        }

        #endregion

        #region Error Handling Tests

        /// <summary>
        /// Verifies that adding a group entity with invalid data (e.g., exceeding name length) throws a DbUpdateException.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddGroup_WithInvalidData_ShouldThrowDbUpdateException()
        {
            // Arrange
            var existingGroup = GroupSeeds.GroupFriends;
            var invalidGroup = new GroupEntity
            {
                Id = existingGroup.Id,
                Name = new string('A', 101), // Invalid Name length
                Description = existingGroup.Description,
                GroupUsers = new List<GroupUserEntity>(),
                Invitations = new List<InvitationEntity>()
            };

            // Act
            SpendWiseDbContextSUT.Groups.Update(invalidGroup);

            // Assert
            var exception = await Assert.ThrowsAsync<DbUpdateException>(
                async () => await SpendWiseDbContextSUT.SaveChangesAsync()
            );

            Assert.NotNull(exception);
        }

        #endregion

        #region Data Retrieval Tests

        /// <summary>
        /// Verifies that groups can be fetched by a partial name, returning all matching groups.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchGroupsByPartialName_ShouldReturnMatchingGroups()
        {
            // Arrange
            var searchNamePart = "Friends";

            // Act
            var actualGroups = await SpendWiseDbContextSUT.Groups
                .Where(g => g.Name.Contains(searchNamePart))
                .ToListAsync();

            // Assert
            Assert.NotNull(actualGroups);
            Assert.All(actualGroups, group => Assert.Contains(searchNamePart, group.Name));
        }

        /// <summary>
        /// Verifies that groups can be fetched by a description substring, returning all matching groups.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchGroupsByDescriptionSubstring_ShouldReturnMatchingGroups()
        {
            // Arrange
            var searchDescriptionPart = "Work";

            // Act
            var actualGroups = await SpendWiseDbContextSUT.Groups
                .Where(g => g.Description != null && g.Description.Contains(searchDescriptionPart))
                .ToListAsync();

            // Assert
            Assert.NotNull(actualGroups);
            Assert.All(actualGroups, group => Assert.Contains(searchDescriptionPart, group.Description));
        }

        /// <summary>
        /// Verifies that fetching a group entity loads its navigation properties correctly.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchGroup_ShouldLoadNavigationProperties()
        {
            // Arrange
            var expectedGroup = GroupSeeds.GroupFamily;
            var groupId = expectedGroup.Id;

            // Act
            var actualGroup = await SpendWiseDbContextSUT.Groups
                .Where(g => g.Id == groupId)
                .Include(g => g.GroupUsers)
                .Include(g => g.Invitations)
                .SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(actualGroup);
            DeepAssert.Equal(expectedGroup, actualGroup);
            Assert.NotEmpty(actualGroup.GroupUsers);
            Assert.NotEmpty(actualGroup.Invitations);
        }

        #endregion

        #region Update and Special Cases Tests

        /// <summary>
        /// Verifies that adding a group entity with maximum field lengths stores the data correctly.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddGroup_WithMaxFieldLength_ShouldStoreDataCorrectly()
        {
            // Arrange
            var newGroup = new GroupEntity
            {
                Id = Guid.NewGuid(),
                Name = new string('A', 100), // Assuming 100 is the maximum length for Name
                Description = new string('B', 200), // Assuming 200 is the maximum length for Description
                GroupUsers = new List<GroupUserEntity>(),
                Invitations = new List<InvitationEntity>()
            };

            // Act
            SpendWiseDbContextSUT.Groups.Add(newGroup);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualGroup = await dbx.Groups.FindAsync(newGroup.Id);

            Assert.NotNull(actualGroup);
            Assert.Equal(newGroup.Name, actualGroup.Name);
            Assert.Equal(newGroup.Description, actualGroup.Description);
        }

        /// <summary>
        /// Verifies that concurrent additions of group entities are handled correctly, persisting all groups successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddGroups_Concurrently_ShouldPersistAllGroups()
        {
            // Arrange
            var groupsToAdd = Enumerable.Range(0, 10).Select(i => new GroupEntity
            {
                Id = Guid.NewGuid(),
                Name = $"Group{i}",
                Description = $"Description{i}",
                GroupUsers = new List<GroupUserEntity>(),
                Invitations = new List<InvitationEntity>()
            }).ToList();

            // Act
            var tasks = groupsToAdd.Select(async group =>
            {
                await using var dbx = await DbContextFactory.CreateDbContextAsync();
                dbx.Groups.Add(group);
                await dbx.SaveChangesAsync();
            });

            await Task.WhenAll(tasks);

            // Assert
            var verificationTasks = groupsToAdd.Select(async group =>
            {
                await using var dbx = await DbContextFactory.CreateDbContextAsync();
                var actualGroup = await dbx.Groups.FindAsync(group.Id);
                Assert.NotNull(actualGroup);
                DeepAssert.Equal(group, actualGroup);
            });

            await Task.WhenAll(verificationTasks);
        }

        #endregion

        #region Related Entities Handling Tests

        /// <summary>
        /// Verifies that when a group is fetched, the relationship with group users is correctly established.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchGroup_ShouldEstablishUserRelationship()
        {
            // Arrange
            var groupId = GroupSeeds.GroupFamily.Id;

            // Act
            var actualGroup = await SpendWiseDbContextSUT.Groups
                .Include(g => g.GroupUsers)
                .FirstOrDefaultAsync(g => g.Id == groupId);

            // Assert
            Assert.NotNull(actualGroup);
            Assert.NotEmpty(actualGroup.GroupUsers);
            Assert.All(actualGroup.GroupUsers, gu => Assert.Equal(groupId, gu.GroupId));
        }

        #endregion

        #region Consistency Tests

        /// <summary>
        /// Verifies that after a group is deleted, all related entities are also correctly removed or updated.
        /// This includes checking for the absence of group users and invitations related to the deleted group.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteGroup_ShouldMaintainIntegrityConstraints()
        {
            // Arrange
            var groupId = GroupSeeds.GroupFamily.Id;

            var groupToDelete = await SpendWiseDbContextSUT.Groups
                .Where(g => g.Id == groupId)
                .Include(g => g.GroupUsers)
                .Include(g => g.Invitations)
                .SingleOrDefaultAsync();

            Assert.NotNull(groupToDelete);

            var groupUsersToCheck = groupToDelete.GroupUsers;
            var invitationsToCheck = groupToDelete.Invitations;

            // Act
            SpendWiseDbContextSUT.Groups.Remove(groupToDelete);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            Assert.False(await dbx.Groups.AnyAsync(g => g.Id == groupId));

            foreach (var gu in groupUsersToCheck)
            {
                Assert.False(await dbx.GroupUsers.AnyAsync(g => g.GroupId == gu.GroupId));
            }

            foreach (var inv in invitationsToCheck)
            {
                Assert.False(await dbx.Invitations.AnyAsync(i => i.GroupId == inv.GroupId));
            }
        }

        #endregion
    }
}