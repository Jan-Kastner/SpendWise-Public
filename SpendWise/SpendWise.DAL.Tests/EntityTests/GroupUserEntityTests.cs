using SpendWise.DAL.Entities;
using SpendWise.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using SpendWise.Common.Tests.Helpers;
using SpendWise.Common.Enums;

namespace SpendWise.DAL.Tests
{
    /// <summary>
    /// Contains tests for the <see cref="GroupUserEntity"/> entity.
    /// </summary>
    public class GroupUserEntityTests : DbContextTestsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupUserEntityTests"/> class.
        /// </summary>
        /// <param name="output">The output helper instance.</param>
        public GroupUserEntityTests(ITestOutputHelper output) : base(output)
        {
        }

        #region CRUD Operations Tests

        /// <summary>
        /// Verifies that fetching a group user by its ID returns the expected group user.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchGroupUserById_ShouldReturnExpectedGroupUser()
        {
            // Arrange
            var expectedGroupUser = GroupUserSeeds.GroupUserBobInFamily;
            var groupUserId = expectedGroupUser.Id;

            // Act
            var actualGroupUser = await SpendWiseDbContextSUT.GroupUsers
                .SingleOrDefaultAsync(gu => gu.Id == groupUserId);

            // Assert
            Assert.NotNull(actualGroupUser);
            DeepAssert.Equal(expectedGroupUser, actualGroupUser);
        }

        /// <summary>
        /// Verifies that adding a valid group user successfully persists the group user in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddGroupUser_ShouldPersistValidGroupUser()
        {
            // Arrange
            var newGroupUser = new GroupUserEntity
            {
                Id = Guid.NewGuid(),
                Role = UserRole.GroupParticipant,
                UserId = UserSeeds.UserAliceSmith.Id,
                GroupId = GroupSeeds.GroupFriends.Id,
                LimitId = null,
                User = null!,
                Group = null!,
                Limit = null!,
                TransactionGroupUsers = null!
            };

            // Act
            SpendWiseDbContextSUT.GroupUsers.Add(newGroupUser);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualGroupUser = await dbx.GroupUsers.FindAsync(newGroupUser.Id);

            Assert.NotNull(actualGroupUser);
            DeepAssert.Equal(newGroupUser, actualGroupUser);
        }

        /// <summary>
        /// Verifies that updating an existing group user successfully persists the changes in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateGroupUser_ShouldPersistChanges()
        {
            // Arrange
            var existingGroupUser = GroupUserSeeds.GroupUserBobInFamily;

            var updatedGroupUser = new GroupUserEntity
            {
                Id = existingGroupUser.Id,
                Role = UserRole.GroupParticipant,
                UserId = UserSeeds.UserAliceSmith.Id,
                GroupId = GroupSeeds.GroupWork.Id,
                LimitId = null,
                User = null!,
                Group = null!,
                Limit = null!,
                TransactionGroupUsers = null!
            };

            // Act
            SpendWiseDbContextSUT.GroupUsers.Update(updatedGroupUser);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualGroupUser = await dbx.GroupUsers
                .FirstOrDefaultAsync(gu => gu.Id == existingGroupUser.Id);

            Assert.NotNull(actualGroupUser);
            Assert.Equal(updatedGroupUser.GroupId, actualGroupUser.GroupId);
            Assert.Equal(updatedGroupUser.UserId, actualGroupUser.UserId);
        }

        /// <summary>
        /// Verifies that deleting an existing group user successfully removes it from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteGroupUser_ShouldRemoveGroupUser()
        {
            // Arrange
            var groupUserToDelete = await SpendWiseDbContextSUT.GroupUsers
                .AsNoTracking()
                .FirstAsync(gu => gu.Id == GroupUserSeeds.GroupUserBobInFamily.Id);

            Assert.NotNull(groupUserToDelete);
            Assert.True(await SpendWiseDbContextSUT.GroupUsers.AnyAsync(gu => gu.Id == groupUserToDelete.Id));

            // Act
            SpendWiseDbContextSUT.GroupUsers.Remove(groupUserToDelete);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var isGroupUserDeleted = await dbx.GroupUsers
                .AsNoTracking()
                .AnyAsync(gu => gu.Id == groupUserToDelete.Id);

            Assert.False(isGroupUserDeleted);
        }

        #endregion

        #region Error Handling Tests

        /// <summary>
        /// Verifies that updating a group user with an invalid user ID throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateGroupUser_WithInvalidUserId_ShouldThrowDbUpdateException()
        {
            // Arrange
            var groupUserToUpdate = GroupUserSeeds.GroupUserBobInFamily;
            var updatedGroupUser = new GroupUserEntity
            {
                Id = groupUserToUpdate.Id,
                Role = UserRole.GroupParticipant,
                UserId = Guid.NewGuid(),  // Assuming this ID does not exist in the User table
                GroupId = groupUserToUpdate.GroupId,
                LimitId = null,
                User = null!,
                Group = null!,
                Limit = null!,
                TransactionGroupUsers = null!
            };

            // Act & Assert
            SpendWiseDbContextSUT.GroupUsers.Update(updatedGroupUser);
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
                await SpendWiseDbContextSUT.SaveChangesAsync());

            Assert.NotNull(exception);
        }

        /// <summary>
        /// Verifies that updating a group user with an invalid group ID throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateGroupUser_WithInvalidGroupId_ShouldThrowDbUpdateException()
        {
            // Arrange
            var groupUserToUpdate = GroupUserSeeds.GroupUserBobInFamily;
            var updatedGroupUser = new GroupUserEntity
            {
                Id = groupUserToUpdate.Id,
                Role = UserRole.GroupParticipant,
                UserId = groupUserToUpdate.UserId,
                GroupId = Guid.NewGuid(),
                LimitId = null,
                User = null!,
                Group = null!,
                Limit = null!,
                TransactionGroupUsers = null!
            };

            // Act & Assert
            SpendWiseDbContextSUT.GroupUsers.Update(updatedGroupUser);
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
                await SpendWiseDbContextSUT.SaveChangesAsync());

            Assert.NotNull(exception);
        }

        #endregion

        #region Data Retrieval Tests

        /// <summary>
        /// Verifies that fetching group users by group ID returns the expected group users.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchGroupUsersByGroupId_ShouldReturnExpectedGroupUsers()
        {
            // Arrange
            var groupId = GroupSeeds.GroupFriends.Id;

            // Act
            var actualGroupUsers = await SpendWiseDbContextSUT.GroupUsers
                .Where(gu => gu.GroupId == groupId)
                .ToListAsync();

            // Assert
            Assert.NotNull(actualGroupUsers);
            DeepAssert.Contains(GroupUserSeeds.GroupUserJohnInFriends, actualGroupUsers);
            DeepAssert.DoesNotContain(GroupUserSeeds.GroupUserJohnInFamily, actualGroupUsers);
        }

        /// <summary>
        /// Verifies that fetching group users by user ID returns the expected group users.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchGroupUsersByUserId_ShouldReturnExpectedGroupUsers()
        {
            // Arrange
            var userId = UserSeeds.UserJohnDoe.Id;
            var expectedGroupUsers = new[]
            {
                GroupUserSeeds.GroupUserJohnInFamily,
                GroupUserSeeds.GroupUserJohnInWork,
                GroupUserSeeds.GroupUserJohnInFriends
            };

            // Act
            var actualGroupUsers = await SpendWiseDbContextSUT.GroupUsers
                .Where(gu => gu.UserId == userId)
                .ToListAsync();

            // Assert
            Assert.NotNull(actualGroupUsers);
            Assert.Equal(expectedGroupUsers.Count(), actualGroupUsers.Count());
            foreach (var expectedGroupUser in expectedGroupUsers)
            {
                DeepAssert.Contains(expectedGroupUser, actualGroupUsers);
            }
        }

        /// <summary>
        /// Verifies that fetching group users by group ID returns the correct count of group users.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchGroupUserCountByGroupId_ShouldReturnCorrectCount()
        {
            // Arrange
            var groupId = GroupSeeds.GroupFamily.Id;
            var expectedCount = 4;

            // Act
            var actualCount = await SpendWiseDbContextSUT.GroupUsers
                .CountAsync(gu => gu.GroupId == groupId);

            // Assert
            Assert.Equal(expectedCount, actualCount);
        }

        #endregion

        #region Update and Special Cases Tests

        /// <summary>
        /// Verifies that concurrent additions of group users successfully persist all group users in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddGroupUsers_Concurrently_ShouldPersistAllUsers()
        {
            // Arrange
            var groupUsersToAdd = Enumerable.Range(0, 3).Select(i => new GroupUserEntity
            {
                Id = Guid.NewGuid(),
                Role = UserRole.GroupParticipant,
                UserId = UserSeeds.UserAliceSmith.Id,
                GroupId = i switch
                {
                    0 => GroupSeeds.GroupWork.Id,
                    1 => GroupSeeds.GroupFriends.Id,
                    2 => GroupSeeds.GroupFamily.Id,
                    _ => throw new InvalidOperationException("Unexpected index.")
                },
                LimitId = null,
                User = null!,
                Group = null!,
                Limit = null!,
                TransactionGroupUsers = null!
            }).ToList();

            // Act
            var tasks = groupUsersToAdd.Select(async groupUser =>
            {
                await using var dbx = await DbContextFactory.CreateDbContextAsync();
                dbx.GroupUsers.Add(groupUser);
                await dbx.SaveChangesAsync();
            });

            await Task.WhenAll(tasks);

            // Assert
            var verificationTasks = groupUsersToAdd.Select(async groupUser =>
            {
                await using var dbx = await DbContextFactory.CreateDbContextAsync();
                var actualGroupUser = await dbx.GroupUsers.FindAsync(groupUser.Id);
                Assert.NotNull(actualGroupUser);
                DeepAssert.Equal(groupUser, actualGroupUser);
            });

            await Task.WhenAll(verificationTasks);
        }

        #endregion

        #region Related Entities Handling Tests

        /// <summary>
        /// Verifies that fetching a group user with its navigation properties correctly loads related entities.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchGroupUser_WithNavigationProperties_ShouldLoadRelatedEntities()
        {
            // Arrange
            var expectedGroupUser = GroupUserSeeds.GroupUserDianaInFamily;

            // Act
            var actualGroupUser = await SpendWiseDbContextSUT.GroupUsers
                .Include(gu => gu.User)
                .Include(gu => gu.Group)
                .Include(gu => gu.Limit)
                .Include(gu => gu.TransactionGroupUsers)
                .FirstOrDefaultAsync(gu => gu.Id == expectedGroupUser.Id);

            // Assert
            Assert.NotNull(actualGroupUser);
            Assert.NotNull(actualGroupUser.User);
            Assert.NotNull(actualGroupUser.Group);
            Assert.NotNull(actualGroupUser.Limit);
            Assert.NotNull(actualGroupUser.TransactionGroupUsers);

            // Deep assertions for navigation properties
            DeepAssert.Equal(expectedGroupUser.User, actualGroupUser.User);
            DeepAssert.Equal(expectedGroupUser.Group, actualGroupUser.Group);
            DeepAssert.Equal(expectedGroupUser.Limit, actualGroupUser.Limit);

            // Additional checks for the TransactionGroupUsers collection
            Assert.Equal(expectedGroupUser.TransactionGroupUsers.Count(), actualGroupUser.TransactionGroupUsers.Count());
            foreach (var expectedTransactionGroupUser in expectedGroupUser.TransactionGroupUsers)
            {
                DeepAssert.Contains(expectedTransactionGroupUser, actualGroupUser.TransactionGroupUsers);
            }
        }

        #endregion

        #region Consistency Tests

        /// <summary>
        /// Verifies that after deleting a group user, the associated group, user, and other related entities maintain integrity constraints.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteGroupUser_ShouldMaintainIntegrityConstraints()
        {
            // Arrange
            var groupUserToDelete = await SpendWiseDbContextSUT.GroupUsers
                .AsNoTracking()
                .FirstAsync(gu => gu.Id == GroupUserSeeds.GroupUserDianaInFamily.Id);

            var associatedGroup = await SpendWiseDbContextSUT.Groups
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.Id == groupUserToDelete.GroupId);

            var associatedUser = await SpendWiseDbContextSUT.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == groupUserToDelete.UserId);

            var associatedLimit = await SpendWiseDbContextSUT.Limits
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.GroupUserId == groupUserToDelete.Id);

            Assert.NotNull(associatedGroup);
            Assert.NotNull(associatedUser);
            Assert.NotNull(associatedLimit);

            // Act
            SpendWiseDbContextSUT.GroupUsers.Remove(groupUserToDelete);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();

            var deletedGroupUser = await dbx.GroupUsers.FindAsync(groupUserToDelete.Id);
            Assert.Null(deletedGroupUser);

            var remainingAssociatedGroup = await dbx.Groups
                .FirstOrDefaultAsync(g => g.Id == groupUserToDelete.GroupId);
            Assert.NotNull(remainingAssociatedGroup);

            var remainingAssociatedUser = await dbx.Users
                .FirstOrDefaultAsync(u => u.Id == groupUserToDelete.UserId);
            Assert.NotNull(remainingAssociatedUser);

            var removedLimit = await dbx.Limits
                .FirstOrDefaultAsync(l => l.GroupUserId == groupUserToDelete.Id);
            Assert.Null(removedLimit);

            var relatedTransactionGroupUsers = await dbx.TransactionGroupUsers
                .Where(tgu => tgu.GroupUserId == groupUserToDelete.Id)
                .ToListAsync();
            Assert.Empty(relatedTransactionGroupUsers);
        }

        #endregion
    }
}