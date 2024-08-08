using SpendWise.DAL.Entities;
using SpendWise.DAL.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;
using System.Linq;
using System;
using System.Collections.Generic;
using SpendWise.DAL.Tests.Helpers;

namespace SpendWise.DAL.Tests
{
    /// <summary>
    /// Unit tests for operations related to the <see cref="GroupUserEntity"/> class.
    /// This class inherits from <see cref="DbContextTestsBase"/> to utilize shared database context setup and teardown functionality.
    /// </summary>
    public class GroupUserEntityTests : DbContextTestsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupUserEntityTests"/> class.
        /// </summary>
        /// <param name="output">An <see cref="ITestOutputHelper"/> instance for capturing and displaying test output.</param>
        public GroupUserEntityTests(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// Tests that retrieving a group user by its ID returns the correct group user entity.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetGroupUser_ById_ReturnsCorrectGroupUser()
        {
            // Arrange
            var expectedGroupUser = GroupUserSeeds.GroupUserAdminInFamily;
            var existingGroupUserId = GroupUserSeeds.GroupUserAdminInFamily.Id;

            // Act
            var groupUser = await SpendWiseDbContextSUT.GroupUsers
                .Where(gu => gu.Id == existingGroupUserId)
                .SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(groupUser);
            DeepAssert.Equal(expectedGroupUser, groupUser, propertiesToIgnore: new[] { "Group", "User", "Limit"});
        }

        /// <summary>
        /// Tests that adding a valid group user to the database persists the group user entity correctly.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddGroupUser_WhenValidGroupUserIsAdded_GroupUserIsPersisted()
        {
            // Arrange
            var groupUser = new GroupUserEntity
            {
                Id = Guid.NewGuid(),
                UserId = UserSeeds.UserAdmin.Id,
                GroupId = GroupSeeds.GroupFriends.Id,
                User = null!,
                Group = null!
            };

            // Act
            SpendWiseDbContextSUT.GroupUsers.Add(groupUser);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualGroupUser = await dbx.GroupUsers.FindAsync(groupUser.Id);
            Assert.NotNull(actualGroupUser);
            DeepAssert.Equal(groupUser, actualGroupUser, propertiesToIgnore: new[] { "User", "Group" });
        }
        
        /// <summary>
        /// Tests that updating an existing group user entity with new values persists the changes correctly.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateGroupUser_WhenExistingGroupUserIsUpdated_ChangesArePersisted()
        {
            // Arrange
            var existingGroupUser = GroupUserSeeds.GroupUserJohnDoeInFriends;
            var newUserId = UserSeeds.UserBobJohnson.Id;
            var newGroupId = GroupSeeds.GroupWork.Id;

            var updatedGroupUser = new GroupUserEntity
            {
                Id = existingGroupUser.Id,
                UserId = newUserId,
                GroupId = newGroupId,
                User = null!,
                Group = null!
            };

            // Act
            SpendWiseDbContextSUT.GroupUsers.Update(updatedGroupUser);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualGroupUser = await dbx.GroupUsers
                .FirstOrDefaultAsync(tgu => tgu.Id == existingGroupUser.Id);

            Assert.NotNull(actualGroupUser);
            Assert.Equal(newGroupId, actualGroupUser.GroupId);
            Assert.Equal(newUserId, actualGroupUser.UserId);
        }

        /// <summary>
        /// Tests that adding a limit to a group user persists the limit correctly and associates it with the group user.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddLimitToGroupUser_WhenLimitIsAdded_ChangesArePersisted()
        {
            // Arrange
            var newLimit = new LimitEntity
            {
                Id = Guid.NewGuid(),
                Amount = 11500m,
                NoticeType = 1,
                GroupUserId = GroupUserSeeds.GroupUserAliceBrownInWork.Id,
                GroupUser = null!
            };

            // Act
            await SpendWiseDbContextSUT.Limits.AddAsync(newLimit);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualGroupUser = await dbx.GroupUsers
                .Include(gu => gu.Limit)
                .FirstOrDefaultAsync(tgu => tgu.Id == GroupUserSeeds.GroupUserAliceBrownInWork.Id);

            Assert.NotNull(actualGroupUser);
            Assert.NotNull(actualGroupUser.Limit);
        }

        /// <summary>
        /// Tests that deleting an existing group user entity removes it from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteGroupUser_WhenGroupUserIsDeleted_GroupUserIsRemoved()
        {
            // Arrange
            var groupUser = GroupUserSeeds.GroupUserJohnDoeInFriends;

            // Act
            SpendWiseDbContextSUT.GroupUsers.Remove(groupUser);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var deletedGroupUser = await dbx.GroupUsers.FindAsync(groupUser.Id);
            Assert.Null(deletedGroupUser); // Verify that the entity is not found
        }

        /// <summary>
        /// Tests that when a group user is fetched, its navigation properties are correctly loaded.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task VerifyGroupUserNavigationProperties_WhenGroupUserIsFetched_NavigationPropertiesAreLoaded()
        {
            // Arrange
            var groupUser = GroupUserSeeds.GroupUserAdminInFamilyWithRelations;

            // Act
            var fetchedGroupUser = await SpendWiseDbContextSUT.GroupUsers
                .Include(gu => gu.User) 
                .Include(gu => gu.Group) 
                .Include(gu => gu.Limit) 
                .FirstOrDefaultAsync(gu => gu.Id == groupUser.Id);

            // Assert
            Assert.NotNull(fetchedGroupUser);
            Assert.NotNull(fetchedGroupUser.User);
            Assert.NotNull(fetchedGroupUser.Group); 
            Assert.NotNull(fetchedGroupUser.Limit); 
            Assert.NotNull(groupUser.Limit); 
            DeepAssert.Equal(groupUser.User, fetchedGroupUser.User, propertiesToIgnore: new[] { "SentInvitations", "ReceivedInvitations", "GroupUsers" });
            DeepAssert.Equal(groupUser.Group, fetchedGroupUser.Group, propertiesToIgnore: new[] { "GroupUsers", "Invitations" });
            Assert.Equal(groupUser.Limit.Id, fetchedGroupUser.Limit.Id); 
        }

        /// <summary>
        /// Tests that retrieving group users by a specific group ID returns the correct group users.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetGroupUsers_ByGroupId_ReturnsCorrectGroupUsers()
        {
            // Arrange
            var groupId = GroupSeeds.GroupFriends.Id;

            // Act
            var groupUsers = await SpendWiseDbContextSUT.GroupUsers
                .Where(gu => gu.GroupId == groupId)
                .ToListAsync();

            // Assert
            Assert.NotNull(groupUsers);
            DeepAssert.Contains(GroupUserSeeds.GroupUserJohnDoeInFriendsWithRelations, groupUsers, propertiesToIgnore: new[] { "User", "Group" });
            DeepAssert.DoesNotContain(GroupUserSeeds.GroupUserAliceBrownInWorkWithRelations, groupUsers, propertiesToIgnore: new[] { "User", "Group" });
        }

        /// <summary>
        /// Tests that retrieving group users by a specific user ID returns the correct group users.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetGroupUsers_ByUserId_ReturnsCorrectGroupUsers()
        {
            // Arrange
            var userId = UserSeeds.UserJohnDoe.Id;

            // Act
            var groupUsers = await SpendWiseDbContextSUT.GroupUsers
                .Where(gu => gu.UserId == userId)
                .ToListAsync();

            // Assert
            Assert.NotNull(groupUsers);
            DeepAssert.Contains(GroupUserSeeds.GroupUserJohnDoeInFriendsWithRelations, groupUsers, propertiesToIgnore: new[] { "User", "Group" });
            DeepAssert.Contains(GroupUserSeeds.GroupUserJohnDoeInFamilyWithRelations, groupUsers, propertiesToIgnore: new[] { "User", "Group" });
            DeepAssert.DoesNotContain(GroupUserSeeds.GroupUserAliceBrownInWorkWithRelations, groupUsers, propertiesToIgnore: new[] { "User", "Group" });
        }

        /// <summary>
        /// Tests that concurrent addition of multiple group users persists them correctly in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddGroupUsers_Concurrently_GroupUsersArePersistedCorrectly()
        {
            // Arrange
            var groupUsers = new List<GroupUserEntity>
            {
                new GroupUserEntity { Id = Guid.NewGuid(), UserId = UserSeeds.UserAdmin.Id, GroupId = GroupSeeds.GroupWork.Id, User = null!, Group = null! },
                new GroupUserEntity { Id = Guid.NewGuid(), UserId = UserSeeds.UserAdmin.Id, GroupId = GroupSeeds.GroupFriends.Id, User = null!, Group = null! },
                new GroupUserEntity { Id = Guid.NewGuid(), UserId = UserSeeds.UserAliceBrown.Id, GroupId = GroupSeeds.GroupFamily.Id, User = null!, Group = null! },
            };

            // Act
            await SpendWiseDbContextSUT.GroupUsers.AddRangeAsync(groupUsers);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            foreach (var groupUser in groupUsers)
            {
                var actualGroupUser = await dbx.GroupUsers.FindAsync(groupUser.Id);
                Assert.NotNull(actualGroupUser);
                DeepAssert.Equal(groupUser, actualGroupUser, propertiesToIgnore: new[] { "User", "Group" });
            }
        }

        /// <summary>
        /// Tests that updating a group user entity with an invalid user ID throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateGroupUser_WithInvalidUserId_ShouldThrowException()
        {
            // Arrange
            var existingGroupUser = GroupUserSeeds.GroupUserJohnDoeInFriends;
            var invalidGroupUser = new GroupUserEntity
            {
                Id = existingGroupUser.Id,
                UserId = Guid.NewGuid(),  // Assuming this ID does not exist in the User table
                GroupId = existingGroupUser.GroupId,
                User = null!,
                Group = null!
            };

            // Act & Assert
            SpendWiseDbContextSUT.GroupUsers.Update(invalidGroupUser);
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () => await SpendWiseDbContextSUT.SaveChangesAsync());
            Assert.NotNull(exception);
        }

        /// <summary>
        /// Tests that updating a group user entity with an invalid group ID throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateGroupUser_WithInvalidGroupId_ShouldThrowException()
        {
            // Arrange
            var existingGroupUser = GroupUserSeeds.GroupUserJohnDoeInFriends;
            var invalidGroupUser = new GroupUserEntity
            {
                Id = existingGroupUser.Id,
                UserId = existingGroupUser.UserId,
                GroupId = Guid.NewGuid(), // Assuming this ID does not exist in the Group table
                User = null!,
                Group = null!
            };

            // Act & Assert
            SpendWiseDbContextSUT.GroupUsers.Update(invalidGroupUser);
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () => await SpendWiseDbContextSUT.SaveChangesAsync());
            Assert.NotNull(exception);
        }

        /// <summary>
        /// Tests that the count of group users for a specific group ID is correct.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task VerifyGroupUser_MembershipCount_IsCorrect()
        {
            // Arrange
            var groupId = GroupSeeds.GroupFamily.Id;
            var expectedMemberCount = 2;

            // Act
            var actualMemberCount = await SpendWiseDbContextSUT.GroupUsers
                .CountAsync(gu => gu.GroupId == groupId);

            // Assert
            Assert.Equal(expectedMemberCount, actualMemberCount);
        }

        /// <summary>
        /// Tests the removal of a group user and verifies that related entities are properly cleaned up.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task RemoveGroupUser_VerifyIntegrityAndCleanup()
        {
            // Arrange
            var existingGroupUser = GroupUserSeeds.GroupUserAdminInFamily;

            // Ensure that the related entities are present before removal
            var group = await SpendWiseDbContextSUT.Groups
                .FirstOrDefaultAsync(g => g.Id == existingGroupUser.GroupId);

            var user = await SpendWiseDbContextSUT.Users
                .FirstOrDefaultAsync(u => u.Id == existingGroupUser.UserId);

            var limit = await SpendWiseDbContextSUT.Limits
                .FirstOrDefaultAsync(l => l.GroupUserId == existingGroupUser.Id);

            Assert.NotNull(group);
            Assert.NotNull(user);
            Assert.NotNull(limit);

            // Act: Remove the GroupUserEntity
            SpendWiseDbContextSUT.GroupUsers.Remove(existingGroupUser);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert: Check that the GroupUserEntity has been removed
            using (var dbx = await DbContextFactory.CreateDbContextAsync())
            {
                var removedGroupUser = await dbx.GroupUsers.FindAsync(existingGroupUser.Id);
                Assert.Null(removedGroupUser);

                // Assert: Verify the group and user still exist
                var remainingGroup = await dbx.Groups
                    .Include(g => g.GroupUsers)
                    .FirstOrDefaultAsync(g => g.Id == existingGroupUser.GroupId);
                Assert.NotNull(remainingGroup);
                Assert.Single(remainingGroup.GroupUsers); // Ensure only one user left

                var remainingUser = await dbx.Users
                    .FirstOrDefaultAsync(u => u.Id == existingGroupUser.UserId);
                Assert.NotNull(remainingUser);

                // Assert: Verify the limit has been removed
                var removedLimit = await dbx.Limits
                    .FirstOrDefaultAsync(l => l.GroupUserId == existingGroupUser.Id);
                Assert.Null(removedLimit);

                // Assert: Verify all related TransactionGroupUserEntities are removed
                var transactionGroupUsers = await dbx.TransactionGroupUsers
                    .Where(tgu => tgu.GroupUserId == existingGroupUser.Id)
                    .ToListAsync();
                Assert.Empty(transactionGroupUsers); // All should be removed
            }
        }
    }
}

