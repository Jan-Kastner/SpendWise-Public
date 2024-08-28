using SpendWise.DAL.Entities;
using SpendWise.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using SpendWise.Common.Tests.Helpers;

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
        /// Tests the CRUD (Create, Read, Update, Delete) operations for the <see cref="GroupUserEntity"/> entity.
        /// These tests verify that the database operations work as expected for categories.
        /// </summary>

        /// <summary>
        /// Verifies that fetching a group user by its ID returns the expected group user.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchGroupUserById_ReturnsExpectedGroupUser()
        {
            // Arrange
            var expectedGroupUser = GroupUserSeeds.GroupUserBobInFamily;
            var groupUserIdToFetch = expectedGroupUser.Id;

            // Act
            var actualGroupUser = await SpendWiseDbContextSUT.GroupUsers
                .Where(gu => gu.Id == groupUserIdToFetch)
                .SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(actualGroupUser);
            DeepAssert.Equal(expectedGroupUser, actualGroupUser);
        }

        /// <summary>
        /// Verifies that adding a valid group user successfully persists the group user in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddGroupUser_ValidGroupUser_SuccessfullyPersists()
        {
            // Arrange
            var groupUserToAdd = new GroupUserEntity
            {
                Id = Guid.NewGuid(),
                UserId = UserSeeds.UserAliceSmith.Id,
                GroupId = GroupSeeds.GroupFriends.Id,
                User = null!,
                Group = null!
            };

            // Act
            SpendWiseDbContextSUT.GroupUsers.Add(groupUserToAdd);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualGroupUser = await dbx.GroupUsers.FindAsync(groupUserToAdd.Id);

            Assert.NotNull(actualGroupUser);
            DeepAssert.Equal(groupUserToAdd, actualGroupUser);
        }

        /// <summary>
        /// Verifies that updating an existing group user successfully persists the changes in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateGroupUser_ExistingGroupUser_SuccessfullyPersistsChanges()
        {
            // Arrange
            var existingGroupUser = GroupUserSeeds.GroupUserBobInFamily;

            var updatedGroupUser = new GroupUserEntity
            {
                Id = existingGroupUser.Id,
                UserId = UserSeeds.UserAliceSmith.Id,
                GroupId = GroupSeeds.GroupWork.Id,
                User = null!,
                Group = null!
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
        public async Task DeleteGroupUser_ExistingGroupUser_SuccessfullyRemovesGroupUser()
        {
            // Arrange
            var groupUserToDelete = await SpendWiseDbContextSUT.GroupUsers
                .AsNoTracking()
                .FirstAsync(gu => gu.Id == GroupUserSeeds.GroupUserBobInFamily.Id);

            Assert.NotNull(groupUserToDelete);
            Assert.True(await SpendWiseDbContextSUT.GroupUsers.AnyAsync(c => c.Id == groupUserToDelete.Id));

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
        /// Tests the error handling scenarios for the <see cref="GroupUserEntity"/> entity.
        /// This region verifies that the application behaves as expected when invalid data is provided.
        /// </summary>

        /// <summary>
        /// Verifies that updating a group user with an invalid user ID throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateGroupUser_InvalidUserId_ThrowsDbUpdateException()
        {
            // Arrange
            var groupUserToUpdate = GroupUserSeeds.GroupUserBobInFamily;
            var updatedGroupUser = new GroupUserEntity
            {
                Id = groupUserToUpdate.Id,
                UserId = Guid.NewGuid(),  // Assuming this ID does not exist in the User table
                GroupId = groupUserToUpdate.GroupId,
                User = null!,
                Group = null!
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
        public async Task UpdateGroupUser_InvalidGroupId_ThrowsDbUpdateException()
        {
            // Arrange
            var groupUserToUpdate = GroupUserSeeds.GroupUserBobInFamily;
            var updatedGroupUser = new GroupUserEntity
            {
                Id = groupUserToUpdate.Id,
                UserId = groupUserToUpdate.UserId,
                GroupId = Guid.NewGuid(),  // Assuming this ID does not exist in the Group table
                User = null!,
                Group = null!
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
        /// Tests for retrieving category data from the database.
        /// This region verifies that data retrieval methods function correctly and return the expected results.
        /// </summary>

        /// <summary>
        /// Verifies that fetching group users by group ID returns the expected group users.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchGroupUsersByGroupId_ReturnsExpectedGroupUsers()
        {
            // Arrange
            var groupIdToFetch = GroupSeeds.GroupFriends.Id;

            // Act
            var actualGroupUsers = await SpendWiseDbContextSUT.GroupUsers
                .Where(gu => gu.GroupId == groupIdToFetch)
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
        public async Task FetchGroupUsersByUserId_ReturnsExpectedGroupUsers()
        {
            // Arrange
            var userIdToFetch = UserSeeds.UserJohnDoe.Id;
            var expectedGroupUsers = new[]
            {
                GroupUserSeeds.GroupUserJohnInFamily,
                GroupUserSeeds.GroupUserJohnInWork,
                GroupUserSeeds.GroupUserJohnInFriends
            };

            // Act
            var actualGroupUsers = await SpendWiseDbContextSUT.GroupUsers
                .Where(gu => gu.UserId == userIdToFetch)
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
        public async Task FetchGroupUser_MembershipCount_ReturnsCorrectCount()
        {
            // Arrange
            var groupId = GroupSeeds.GroupFamily.Id;
            var expectedGroupUserCount = 4;

            // Act
            var actualGroupUserCount = await SpendWiseDbContextSUT.GroupUsers
                .CountAsync(gu => gu.GroupId == groupId);

            // Assert
            Assert.Equal(expectedGroupUserCount, actualGroupUserCount);
        }

        #endregion

        #region Update and Special Cases Tests

        /// <summary>
        /// Tests for various update scenarios and edge cases for the <see cref="GroupUserEntity"/> entity.
        /// This region verifies that updates work correctly, including concurrent additions of group users.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that concurrent additions of group users successfully persist all group users in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddGroupUsers_ConcurrentAdditions_SuccessfullyPersistAllUsers()
        {
            // Arrange
            var groupUsersToAdd = Enumerable.Range(0, 3).Select(i => new GroupUserEntity
            {
                Id = Guid.NewGuid(),
                UserId = UserSeeds.UserAliceSmith.Id,
                GroupId = i switch
                {
                    0 => GroupSeeds.GroupWork.Id,
                    1 => GroupSeeds.GroupFriends.Id,
                    2 => GroupSeeds.GroupFamily.Id,
                    _ => throw new InvalidOperationException("Unexpected index.")
                },
                User = null!,
                Group = null!
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
        /// Tests for handling related entities, specifically navigation properties for the <see cref="GroupUserEntity"/>.
        /// This region ensures that related data, such as transactions, is correctly loaded and accessible.
        /// </summary>

        /// <summary>
        /// Verifies that fetching a group user with its navigation properties correctly loads related entities.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchGroupUser_NavigationPropertiesAreCorrectlyLoaded()
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
        /// Tests to ensure the integrity of data and constraints after operations on the <see cref="GroupUserEntity"/>.
        /// This region verifies that relationships and data integrity remain consistent after deletions and modifications.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that after deleting a group user, the associated group, user, and other related entities maintain integrity constraints.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteGroupUser_VerifyIntegrityConstraints_AfterDeletion()
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