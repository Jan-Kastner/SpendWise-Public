using SpendWise.DAL.Entities;
using SpendWise.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using SpendWise.Common.Tests.Helpers;

namespace SpendWise.DAL.Tests
{
    /// <summary>
    /// Contains unit tests for the <see cref="TransactionGroupUserEntity"/> entity.
    /// </summary>
    public class TransactionGroupUserEntityTests : DbContextTestsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionGroupUserEntityTests"/> class.
        /// </summary>
        /// <param name="output">The output helper used to log test results.</param>
        public TransactionGroupUserEntityTests(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// Tests that no transaction group users are returned for a non-existing user.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetTransactionGroupUsers_ForNonExistingUser_ReturnsEmptyList()
        {
            // Arrange
            var nonExistingUserId = Guid.NewGuid();

            // Act
            var transactionGroupUsers = await SpendWiseDbContextSUT.TransactionGroupUsers
                .Where(tgu => tgu.GroupUserId == nonExistingUserId)
                .ToListAsync();

            // Assert
            Assert.Empty(transactionGroupUsers); // Ensure that the result is an empty list
        }

        /// <summary>
        /// Tests that a valid transaction group user is added to the database and persisted correctly.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddTransactionGroupUser_WhenValidTransactionGroupUserIsAdded_TransactionGroupUserIsPersisted()
        {
            // Arrange
            var entity = new TransactionGroupUserEntity
            {
                Id = Guid.NewGuid(),
                TransactionId = TransactionSeeds.TransactionMinus30Hours.Id,
                GroupUserId = GroupUserSeeds.GroupUserJohnDoeInFriends.Id,
                Transaction = null!,
                GroupUser = null!
            };

            // Act
            SpendWiseDbContextSUT.TransactionGroupUsers.Add(entity);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualEntity = await dbx.TransactionGroupUsers.SingleOrDefaultAsync(tgu => tgu.Id == entity.Id);

            Assert.NotNull(actualEntity);
            DeepAssert.Equal(entity, actualEntity);
        }

        /// <summary>
        /// Tests that changes to an existing transaction group user are persisted correctly.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateTransactionGroupUser_WhenExistingTransactionGroupUserIsUpdated_ChangesArePersisted()
        {
            // Arrange
            var existingTransactionGroupUser = TransactionGroupUserSeeds.TransactionGroupUserJohnDoeInFamilyForMinus26Hours;
            var newTransactionId = TransactionSeeds.TransactionMinus26Hours.Id;
            var newGroupUserId = GroupUserSeeds.GroupUserJohnDoeInFriends.Id;

            var updatedTransactionGroupUser = new TransactionGroupUserEntity
            {
                Id = existingTransactionGroupUser.Id,
                TransactionId = newTransactionId,
                GroupUserId = newGroupUserId,
                Transaction = null!,
                GroupUser = null!
            };

            // Act
            SpendWiseDbContextSUT.TransactionGroupUsers.Update(updatedTransactionGroupUser);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualTransactionGroupUser = await dbx.TransactionGroupUsers
                .FirstOrDefaultAsync(tgu => tgu.Id == existingTransactionGroupUser.Id);

            Assert.NotNull(actualTransactionGroupUser); // Ensure that the entity is not null
            Assert.Equal(newTransactionId, actualTransactionGroupUser.TransactionId); // Check the updated transaction ID
            Assert.Equal(newGroupUserId, actualTransactionGroupUser.GroupUserId); // Check the updated group user ID
        }

        /// <summary>
        /// Tests that a transaction group user is removed from the database when deleted.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteTransactionGroupUser_WhenTransactionGroupUserIsDeleted_TransactionGroupUserIsRemoved()
        {
            // Arrange
            var baseEntity = TransactionGroupUserSeeds.TransactionGroupUserJohnDoeInFamilyForJohnDoeTransport;

            Assert.True(await SpendWiseDbContextSUT.TransactionGroupUsers.AnyAsync(tgu => tgu.Id == baseEntity.Id)); // Ensure that the entity exists before deletion

            // Act
            SpendWiseDbContextSUT.TransactionGroupUsers.Remove(baseEntity);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            Assert.False(await SpendWiseDbContextSUT.TransactionGroupUsers.AnyAsync(tgu => tgu.Id == baseEntity.Id)); // Ensure that the entity has been removed

            var transactionExists = await SpendWiseDbContextSUT.Transactions.AnyAsync(t => t.Id == baseEntity.TransactionId);
            var groupUserExists = await SpendWiseDbContextSUT.GroupUsers.AnyAsync(g => g.Id == baseEntity.GroupUserId);

            Assert.True(transactionExists); // Ensure that the transaction still exists
            Assert.True(groupUserExists); // Ensure that the group user still exists
        }

        /// <summary>
        /// Tests that transaction group users are retrieved correctly based on the group ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetTransactionGroupUsers_ByGroupId_ReturnsCorrectTransactionGroupUsers()
        {
            // Arrange
            var groupId = GroupSeeds.GroupFamily.Id;
            var expectedGroupUsers = new List<GroupUserEntity>
            {
                GroupUserSeeds.GroupUserAdminInFamily,
                GroupUserSeeds.GroupUserJohnDoeInFamily
            };

            var expectedTransactionGroupUsers = new List<TransactionGroupUserEntity>
            {
                TransactionGroupUserSeeds.TransactionGroupUserAdminInFamilyForMinus22Hours,
                TransactionGroupUserSeeds.TransactionGroupUserAdminInFamilyForMinus24Hours,
                TransactionGroupUserSeeds.TransactionGroupUserAdminInFamilyForAdminFood,
                TransactionGroupUserSeeds.TransactionGroupUserAdminInFamilyForDelete,

                TransactionGroupUserSeeds.TransactionGroupUserJohnDoeInFamilyForMinus26Hours,
                TransactionGroupUserSeeds.TransactionGroupUserJohnDoeInFamilyForMinus28Hours,
                TransactionGroupUserSeeds.TransactionGroupUserJohnDoeInFamilyForMinus30Hours,
                TransactionGroupUserSeeds.TransactionGroupUserJohnDoeInFamilyForJohnDoeTransport
            };

            // Act
            var groupUsers = await SpendWiseDbContextSUT.GroupUsers
                .Where(gu => gu.GroupId == groupId)
                .ToListAsync();

            var groupUserIds = groupUsers.Select(gu => gu.Id).ToList();

            var transactionGroupUsers = await SpendWiseDbContextSUT.TransactionGroupUsers
                .Where(tgu => groupUserIds.Contains(tgu.GroupUserId))
                .ToListAsync();

            // Assert
            Assert.Equal(expectedTransactionGroupUsers.Count, transactionGroupUsers.Count); // Ensure that the number of retrieved users matches expected
            foreach (var expectedTgu in expectedTransactionGroupUsers)
            {
                Assert.Contains(transactionGroupUsers, tgu => tgu.Id == expectedTgu.Id); // Ensure that each expected user is in the result
            }
        }

        /// <summary>
        /// Tests that transaction group users are retrieved correctly based on the transaction ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetTransactionGroupUsers_ByTransactionId_ReturnsCorrectTransactionGroupUsers()
        {
            // Arrange
            var transactionId = TransactionSeeds.TransactionJohnDoeTransport.Id;
            var expectedTransactionGroupUsers = new List<TransactionGroupUserEntity>
            {
                TransactionGroupUserSeeds.TransactionGroupUserJohnDoeInFamilyForJohnDoeTransport,
                TransactionGroupUserSeeds.TransactionGroupUserJohnDoeInFriendsForJohnDoeTransport
            };

            // Act
            var transactionGroupUsers = await SpendWiseDbContextSUT.TransactionGroupUsers
                .Where(tgu => tgu.TransactionId == transactionId)
                .ToListAsync();

            // Assert
            Assert.Equal(expectedTransactionGroupUsers.Count, transactionGroupUsers.Count); // Ensure that the number of retrieved users matches expected
            foreach (var expectedTgu in expectedTransactionGroupUsers)
            {
                Assert.Contains(transactionGroupUsers, tgu => tgu.Id == expectedTgu.Id); // Ensure that each expected user is in the result
            }
        }

        /// <summary>
        /// Verifies that when a transaction group user is fetched, its relationships with transaction and group user are loaded correctly.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task VerifyTransactionGroupUserRelationships_WhenTransactionGroupUsersAreFetched_RelationshipsAreLoaded()
        {
            // Arrange
            var existingTransactionGroupUser = TransactionGroupUserSeeds.TransactionGroupUserJohnDoeInFamilyForMinus26HoursWithRelations;
            var expectedGroupUser = existingTransactionGroupUser.GroupUser;
            var expectedTransaction = existingTransactionGroupUser.Transaction;

            // Act
            var transactionGroupUser = await SpendWiseDbContextSUT.TransactionGroupUsers
                .Include(tgu => tgu.Transaction)
                .Include(tgu => tgu.GroupUser)
                .FirstOrDefaultAsync(tgu => tgu.Id == existingTransactionGroupUser.Id);

            // Assert
            Assert.NotNull(transactionGroupUser);
            Assert.NotNull(transactionGroupUser.Transaction);
            Assert.NotNull(transactionGroupUser.GroupUser);
            DeepAssert.Equal(existingTransactionGroupUser.Transaction, transactionGroupUser.Transaction, propertiesToIgnore: new[] { "TransactionGroupUsers", "Category" });
            DeepAssert.Equal(existingTransactionGroupUser.GroupUser, transactionGroupUser.GroupUser, propertiesToIgnore: new[] { "Limit", "Group", "TransactionGroupUsers", "User" });
        }

        /// <summary>
        /// Tests that transaction group users are returned in the correct order when ordered by transaction ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetTransactionGroupUsers_OrderedByTransactionId_ReturnsTransactionGroupUsersInCorrectOrder()
        {
            // Arrange
            var groupId = GroupSeeds.GroupFamily.Id;

            // Act
            var actualTransactionGroupUsers = await SpendWiseDbContextSUT.TransactionGroupUsers
                .Where(tgu => tgu.GroupUser != null && tgu.GroupUser.GroupId == groupId)
                .OrderBy(tgu => tgu.TransactionId)
                .ToListAsync();

            // Assert
            var previousTransactionId = Guid.Empty;

            foreach (var tgu in actualTransactionGroupUsers)
            {
                Assert.True(tgu.TransactionId.CompareTo(previousTransactionId) >= 0, "TransactionGroupUsers are not ordered by TransactionId.");
                previousTransactionId = tgu.TransactionId;
            }
        }

        /// <summary>
        /// Tests that adding a transaction group user with a duplicate transaction ID and group user ID throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddTransactionGroupUser_WithDuplicateTransactionIdAndGroupUserId_ThrowsException()
        {
            // Arrange
            var existingTransactionGroupUser = TransactionGroupUserSeeds.TransactionGroupUserJohnDoeInFamilyForMinus26Hours;
            var duplicateTransactionGroupUser = new TransactionGroupUserEntity
            {
                Id = Guid.NewGuid(),
                TransactionId = existingTransactionGroupUser.TransactionId,
                GroupUserId = existingTransactionGroupUser.GroupUserId,
                Transaction = null!,
                GroupUser = null!
            };

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                SpendWiseDbContextSUT.TransactionGroupUsers.Add(duplicateTransactionGroupUser);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });
        }

        /// <summary>
        /// Tests that adding a transaction group user with a non-existing group user ID throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddTransactionGroupUser_WithNonExistingGroupUser_ThrowsException()
        {
            // Arrange
            var nonExistingGroupUserId = Guid.NewGuid();
            var transactionId = TransactionSeeds.TransactionJohnDoeTransport.Id;

            var invalidTransactionGroupUser = new TransactionGroupUserEntity
            {
                Id = Guid.NewGuid(),
                TransactionId = transactionId,
                GroupUserId = nonExistingGroupUserId,
                Transaction = null!,
                GroupUser = null!
            };

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                SpendWiseDbContextSUT.TransactionGroupUsers.Add(invalidTransactionGroupUser);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });
        }

        /// <summary>
        /// Tests that adding a transaction group user with a non-existing transaction ID throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddTransactionGroupUser_WithNonExistingTransaction_ThrowsException()
        {
            // Arrange
            var groupUserId = GroupUserSeeds.GroupUserJohnDoeInFriends.Id;
            var nonExistingTransactionId = Guid.NewGuid();

            var invalidTransactionGroupUser = new TransactionGroupUserEntity
            {
                Id = Guid.NewGuid(),
                TransactionId = nonExistingTransactionId,
                GroupUserId = groupUserId,
                Transaction = null!,
                GroupUser = null!
            };

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                SpendWiseDbContextSUT.TransactionGroupUsers.Add(invalidTransactionGroupUser);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });
        }

        /// <summary>
        /// Tests that a transaction group user entity remains unchanged after being saved to the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddTransactionGroupUser_WhenSaved_EntityStateIsUnchanged()
        {
            // Arrange
            var entity = new TransactionGroupUserEntity
            {
                Id = Guid.NewGuid(),
                TransactionId = TransactionSeeds.TransactionMinus30Hours.Id,
                GroupUserId = GroupUserSeeds.GroupUserJohnDoeInFriends.Id,
                Transaction = null!,
                GroupUser = null!
            };

            SpendWiseDbContextSUT.TransactionGroupUsers.Add(entity);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Act
            var entityEntry = SpendWiseDbContextSUT.Entry(entity);

            // Assert
            Assert.Equal(EntityState.Unchanged, entityEntry.State);
        }

        /// <summary>
        /// Tests that transaction group users are correctly filtered based on group user ID and transaction ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetTransactionGroupUsers_WithFilters_ReturnsCorrectResults()
        {
            // Arrange
            var groupUserId = GroupUserSeeds.GroupUserJohnDoeInFriends.Id;
            var transactionId = TransactionSeeds.TransactionJohnDoeTransport.Id;

            // Act
            var filteredTransactionGroupUsers = await SpendWiseDbContextSUT.TransactionGroupUsers
                .Where(tgu => tgu.GroupUserId == groupUserId && tgu.TransactionId == transactionId)
                .ToListAsync();

            // Assert
            foreach (var tgu in filteredTransactionGroupUsers)
            {
                Assert.Equal(groupUserId, tgu.GroupUserId);
                Assert.Equal(transactionId, tgu.TransactionId);
            }
        }

        /// <summary>
        /// Tests that updating a transaction group user with a non-existent group user ID throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateTransactionGroupUser_WithNonExistentGroupUser_ThrowsException()
        {
            // Arrange
            var existingTransactionGroupUser = TransactionGroupUserSeeds.TransactionGroupUserJohnDoeInFamilyForMinus26Hours;
            var nonExistentGroupUserId = Guid.NewGuid();

            var updatedTransactionGroupUser = existingTransactionGroupUser with
            {
                GroupUserId = nonExistentGroupUserId
            };

            // Act
            SpendWiseDbContextSUT.TransactionGroupUsers.Update(updatedTransactionGroupUser);

            // Assert
            await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });
        }

        /// <summary>
        /// Tests that updating a transaction group user with a non-existent transaction ID throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateTransactionGroupUser_WithNonExistentTransaction_ThrowsException()
        {
            // Arrange
            var existingTransactionGroupUser = TransactionGroupUserSeeds.TransactionGroupUserJohnDoeInFamilyForMinus26Hours;
            var nonExistentTransactionId = Guid.NewGuid();

            var updatedTransactionGroupUser = existingTransactionGroupUser with
            {
                TransactionId = nonExistentTransactionId
            };

            // Act
            SpendWiseDbContextSUT.TransactionGroupUsers.Update(updatedTransactionGroupUser);

            // Assert
            await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });
        }


    }
}
