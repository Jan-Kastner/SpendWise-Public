using SpendWise.DAL.Entities;
using SpendWise.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using SpendWise.Common.Tests.Helpers;

namespace SpendWise.DAL.Tests.EntityTests
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

        #region CRUD Operations Tests

        /// <summary>
        /// Verifies that adding a valid transaction group user successfully persists the user in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddTransactionGroupUser_ShouldPersistValidUser()
        {
            // Arrange
            var transactionGroupUserToAdd = new TransactionGroupUserEntity
            {
                Id = Guid.NewGuid(),
                IsRead = false,
                TransactionId = TransactionSeeds.TransactionJohnTaxi.Id,
                GroupUserId = GroupUserSeeds.GroupUserJohnInWork.Id,
                Transaction = null!,
                GroupUser = null!
            };

            // Act
            SpendWiseDbContextSUT.TransactionGroupUsers.Add(transactionGroupUserToAdd);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualTransactionGroupUser = await dbx.TransactionGroupUsers.SingleOrDefaultAsync(tgu => tgu.Id == transactionGroupUserToAdd.Id);

            Assert.NotNull(actualTransactionGroupUser);
            DeepAssert.Equal(transactionGroupUserToAdd, actualTransactionGroupUser);
        }

        /// <summary>
        /// Verifies that updating an existing transaction group user successfully persists the changes in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateTransactionGroupUser_ShouldPersistChanges()
        {
            // Arrange
            var existingTransactionGroupUser = TransactionGroupUserSeeds.TransactionGroupUserTransportWorkJohn;
            var newTransactionId = TransactionSeeds.TransactionJohnTaxi.Id;
            var newGroupUserId = GroupUserSeeds.GroupUserJohnInWork.Id;

            var updatedTransactionGroupUser = new TransactionGroupUserEntity
            {
                Id = existingTransactionGroupUser.Id,
                IsRead = false,
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

            Assert.NotNull(actualTransactionGroupUser);
            Assert.Equal(newTransactionId, actualTransactionGroupUser.TransactionId);
            Assert.Equal(newGroupUserId, actualTransactionGroupUser.GroupUserId);
        }

        /// <summary>
        /// Verifies that deleting an existing transaction group user successfully removes it from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteTransactionGroupUser_ShouldRemoveUser()
        {
            // Arrange
            var transactionGroupUserToRemove = await SpendWiseDbContextSUT.TransactionGroupUsers
                .AsNoTracking()
                .FirstAsync(l => l.Id == TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana.Id);

            Assert.NotNull(transactionGroupUserToRemove);

            // Act
            SpendWiseDbContextSUT.TransactionGroupUsers.Remove(transactionGroupUserToRemove);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            Assert.False(await SpendWiseDbContextSUT.TransactionGroupUsers.AnyAsync(tgu => tgu.Id == transactionGroupUserToRemove.Id));
        }

        #endregion

        #region Error Handling Tests

        /// <summary>
        /// Verifies that adding a transaction group user with a duplicate TransactionId and GroupUserId throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddTransactionGroupUser_WithDuplicateTransactionIdAndGroupUserId_ShouldThrowDbUpdateException()
        {
            // Arrange
            var existingTransactionGroupUser = TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana;
            var duplicateTransactionGroupUser = new TransactionGroupUserEntity
            {
                Id = Guid.NewGuid(),
                IsRead = false,
                TransactionId = existingTransactionGroupUser.TransactionId,
                GroupUserId = existingTransactionGroupUser.GroupUserId,
                Transaction = null!,
                GroupUser = null!
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                SpendWiseDbContextSUT.TransactionGroupUsers.Add(duplicateTransactionGroupUser);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });

            Assert.NotNull(exception);
        }

        /// <summary>
        /// Verifies that adding a transaction group user with a non-existing GroupUserId throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddTransactionGroupUser_WithNonExistingGroupUser_ShouldThrowDbUpdateException()
        {
            // Arrange
            var nonExistingGroupUserId = Guid.NewGuid();
            var transactionId = TransactionSeeds.TransactionDianaDinner.Id;

            var invalidTransactionGroupUser = new TransactionGroupUserEntity
            {
                Id = Guid.NewGuid(),
                IsRead = false,
                TransactionId = transactionId,
                GroupUserId = nonExistingGroupUserId,
                Transaction = null!,
                GroupUser = null!
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                SpendWiseDbContextSUT.TransactionGroupUsers.Add(invalidTransactionGroupUser);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });

            Assert.NotNull(exception);
        }

        /// <summary>
        /// Verifies that adding a transaction group user with a non-existing TransactionId throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddTransactionGroupUser_WithNonExistingTransaction_ShouldThrowDbUpdateException()
        {
            // Arrange
            var groupUserId = GroupUserSeeds.GroupUserBobInFamily.Id;
            var nonExistingTransactionId = Guid.NewGuid();

            var invalidTransactionGroupUser = new TransactionGroupUserEntity
            {
                Id = Guid.NewGuid(),
                IsRead = false,
                TransactionId = nonExistingTransactionId,
                GroupUserId = groupUserId,
                Transaction = null!,
                GroupUser = null!
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                SpendWiseDbContextSUT.TransactionGroupUsers.Add(invalidTransactionGroupUser);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });

            Assert.NotNull(exception);
        }

        /// <summary>
        /// Verifies that updating a transaction group user with a non-existing GroupUserId throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateTransactionGroupUser_WithNonExistentGroupUser_ShouldThrowDbUpdateException()
        {
            // Arrange
            var existingTransactionGroupUser = await SpendWiseDbContextSUT.TransactionGroupUsers
                .AsNoTracking()
                .FirstAsync(l => l.Id == TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana.Id);

            var nonExistentGroupUserId = Guid.NewGuid();

            var updatedTransactionGroupUser = existingTransactionGroupUser with
            {
                GroupUserId = nonExistentGroupUserId
            };

            // Act
            SpendWiseDbContextSUT.TransactionGroupUsers.Update(updatedTransactionGroupUser);

            // Assert
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });

            Assert.NotNull(exception);
        }

        /// <summary>
        /// Verifies that updating a transaction group user with a non-existing TransactionId throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateTransactionGroupUser_WithNonExistentTransaction_ShouldThrowDbUpdateException()
        {
            // Arrange
            var existingTransactionGroupUser = await SpendWiseDbContextSUT.TransactionGroupUsers
                .AsNoTracking()
                .FirstAsync(l => l.Id == TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana.Id);

            var nonExistentTransactionId = Guid.NewGuid();

            var updatedTransactionGroupUser = existingTransactionGroupUser with
            {
                TransactionId = nonExistentTransactionId
            };

            // Act
            SpendWiseDbContextSUT.TransactionGroupUsers.Update(updatedTransactionGroupUser);

            // Assert
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });

            Assert.NotNull(exception);
        }

        #endregion

        #region Data Retrieval Tests

        /// <summary>
        /// Verifies that fetching transaction group users by a specific group ID returns the correct data.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchTransactionGroupUsers_ByGroupId_ShouldReturnCorrectData()
        {
            // Arrange
            var groupId = GroupSeeds.GroupFamily.Id;
            var expectedTransactionGroupUsers = new List<TransactionGroupUserEntity>
            {
                TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana,
                TransactionGroupUserSeeds.TransactionGroupUserFoodFamilyJohn
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
            Assert.Equal(expectedTransactionGroupUsers.Count, transactionGroupUsers.Count);
            foreach (var expectedTgu in expectedTransactionGroupUsers)
            {
                Assert.Contains(transactionGroupUsers, tgu => tgu.Id == expectedTgu.Id);
            }
        }

        /// <summary>
        /// Verifies that fetching transaction group users by a specific transaction ID returns the correct data.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchTransactionGroupUsers_ByTransactionId_ShouldReturnCorrectData()
        {
            // Arrange
            var transactionId = TransactionSeeds.TransactionJohnTransport.Id;
            var expectedTransactionGroupUsers = new List<TransactionGroupUserEntity>
            {
                TransactionGroupUserSeeds.TransactionGroupUserTransportFriendsJohn,
                TransactionGroupUserSeeds.TransactionGroupUserTransportWorkJohn
            };

            // Act
            var actualTransactionGroupUsers = await SpendWiseDbContextSUT.TransactionGroupUsers
                .Where(tgu => tgu.TransactionId == transactionId)
                .ToListAsync();

            // Assert
            Assert.Equal(expectedTransactionGroupUsers.Count, actualTransactionGroupUsers.Count);
            foreach (var expectedTgu in expectedTransactionGroupUsers)
            {
                Assert.Contains(actualTransactionGroupUsers, tgu => tgu.Id == expectedTgu.Id);
            }
        }

        /// <summary>
        /// Verifies that fetching transaction group users ordered by transaction ID returns them in the correct order.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchTransactionGroupUsers_OrderedByTransactionId_ShouldReturnInCorrectOrder()
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
        /// Verifies that fetching transaction group users with specific filters returns the expected results.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchTransactionGroupUsers_WithFilters_ShouldReturnExpectedResults()
        {
            // Arrange
            var groupUserId = GroupUserSeeds.GroupUserDianaInFamily.Id;
            var transactionId = TransactionSeeds.TransactionDianaDinner.Id;

            // Act
            var actualTransactionGroupUsers = await SpendWiseDbContextSUT.TransactionGroupUsers
                .Where(tgu => tgu.GroupUserId == groupUserId && tgu.TransactionId == transactionId)
                .ToListAsync();

            // Assert
            foreach (var tgu in actualTransactionGroupUsers)
            {
                Assert.Equal(groupUserId, tgu.GroupUserId);
                Assert.Equal(transactionId, tgu.TransactionId);
            }
        }

        #endregion

        #region Update and Special Cases Tests

        /// <summary>
        /// Verifies that when a <see cref="TransactionGroupUserEntity"/> is added and saved, its entity state is set to Unchanged.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddTransactionGroupUser_WhenSaved_ShouldSetEntityStateToUnchanged()
        {
            // Arrange
            var newTransactionGroupUser = new TransactionGroupUserEntity
            {
                Id = Guid.NewGuid(),
                IsRead = false,
                TransactionId = TransactionSeeds.TransactionJohnTaxi.Id,
                GroupUserId = GroupUserSeeds.GroupUserJohnInWork.Id,
                Transaction = null!,
                GroupUser = null!
            };

            // Act
            SpendWiseDbContextSUT.TransactionGroupUsers.Add(newTransactionGroupUser);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            var entry = SpendWiseDbContextSUT.Entry(newTransactionGroupUser);
            Assert.Equal(EntityState.Unchanged, entry.State);
        }

        /// <summary>
        /// Verifies that updating a <see cref="TransactionGroupUserEntity"/> with a non-existing ID throws a <see cref="DbUpdateConcurrencyException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateTransactionGroupUser_WithNonExistingId_ShouldThrowDbUpdateConcurrencyException()
        {
            // Arrange
            var nonExistingId = Guid.NewGuid();
            var updatedTransactionGroupUser = new TransactionGroupUserEntity
            {
                Id = nonExistingId,
                IsRead = false,
                TransactionId = TransactionSeeds.TransactionJohnTaxi.Id,
                GroupUserId = GroupUserSeeds.GroupUserJohnInWork.Id,
                Transaction = null!,
                GroupUser = null!
            };

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateConcurrencyException>(async () =>
            {
                SpendWiseDbContextSUT.TransactionGroupUsers.Update(updatedTransactionGroupUser);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });
        }

        #endregion

        #region Related Entities Handling Tests

        /// <summary>
        /// Verifies that fetching a <see cref="TransactionGroupUserEntity"/> with an included <see cref="TransactionEntity"/> returns the correct transaction.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchTransactionGroupUser_WithTransaction_ShouldReturnCorrectTransaction()
        {
            // Arrange
            var transactionGroupUserId = TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana.Id;

            // Act
            var transactionGroupUser = await SpendWiseDbContextSUT.TransactionGroupUsers
                .Include(tgu => tgu.Transaction)
                .FirstOrDefaultAsync(tgu => tgu.Id == transactionGroupUserId);

            // Assert
            Assert.NotNull(transactionGroupUser);
            Assert.NotNull(transactionGroupUser.Transaction);
        }

        /// <summary>
        /// Verifies that fetching a <see cref="TransactionGroupUserEntity"/> with an included <see cref="GroupUserEntity"/> returns the correct group user.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchTransactionGroupUser_WithGroupUser_ShouldReturnCorrectGroupUser()
        {
            // Arrange
            var transactionGroupUserId = TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana.Id;

            // Act
            var transactionGroupUser = await SpendWiseDbContextSUT.TransactionGroupUsers
                .Include(tgu => tgu.GroupUser)
                .FirstOrDefaultAsync(tgu => tgu.Id == transactionGroupUserId);

            // Assert
            Assert.NotNull(transactionGroupUser);
            Assert.NotNull(transactionGroupUser.GroupUser);
        }

        /// <summary>
        /// Verifies that navigation properties in a <see cref="TransactionGroupUserEntity"/> are correctly loaded, including both <see cref="TransactionEntity"/> and <see cref="GroupUserEntity"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchTransactionGroupUser_NavigationProperties_ShouldBeCorrectlyLoaded()
        {
            // Arrange
            var existingTransactionGroupUser = TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana;
            var expectedGroupUser = GroupUserSeeds.GroupUserDianaInFamily;
            var expectedTransaction = TransactionSeeds.TransactionDianaDinner;

            // Act
            var transactionGroupUser = await SpendWiseDbContextSUT.TransactionGroupUsers
                .Include(tgu => tgu.Transaction)
                .Include(tgu => tgu.GroupUser)
                .FirstOrDefaultAsync(tgu => tgu.Id == existingTransactionGroupUser.Id);

            // Assert
            Assert.NotNull(transactionGroupUser);
            Assert.NotNull(transactionGroupUser.Transaction);
            Assert.NotNull(transactionGroupUser.GroupUser);
            DeepAssert.Equal(expectedTransaction, transactionGroupUser.Transaction);
            DeepAssert.Equal(expectedGroupUser, transactionGroupUser.GroupUser);
        }

        #endregion

        #region Consistency Tests

        /// <summary>
        /// Verifies that deleting an existing transaction group user successfully removes it from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteTransactionGroupUser_ShouldMaintainIntegrityConstraints()
        {
            // Arrange
            var transactionGroupUserToRemove = await SpendWiseDbContextSUT.TransactionGroupUsers
                .AsNoTracking()
                .FirstAsync(l => l.Id == TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana.Id);

            Assert.NotNull(transactionGroupUserToRemove);

            // Act
            SpendWiseDbContextSUT.TransactionGroupUsers.Remove(transactionGroupUserToRemove);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            Assert.False(await SpendWiseDbContextSUT.TransactionGroupUsers.AnyAsync(tgu => tgu.Id == transactionGroupUserToRemove.Id));

            var transactionExists = await SpendWiseDbContextSUT.Transactions.AnyAsync(t => t.Id == transactionGroupUserToRemove.TransactionId);
            var groupUserExists = await SpendWiseDbContextSUT.GroupUsers.AnyAsync(g => g.Id == transactionGroupUserToRemove.GroupUserId);

            Assert.True(transactionExists);
            Assert.True(groupUserExists);
        }

        #endregion
    }
}
