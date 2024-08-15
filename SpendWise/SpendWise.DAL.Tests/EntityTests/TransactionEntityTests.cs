using SpendWise.DAL.Entities;
using SpendWise.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using SpendWise.Common.Tests.Helpers;

namespace SpendWise.DAL.Tests
{
    /// <summary>
    /// Test class to verify the functionality of the TransactionEntity within the DbContext.
    /// </summary>
    public class TransactionEntityTests : DbContextTestsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionEntityTests"/> class.
        /// </summary>
        /// <param name="output">Instance of <see cref="ITestOutputHelper"/> for logging test output.</param>
        public TransactionEntityTests(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// Verifies that adding a valid transaction to the database is successfully persisted.
        /// </summary>
        /// <returns>An asynchronous task representing the test operation.</returns>
        [Fact]
        public async Task AddTransaction_WhenValidTransactionIsAdded_TransactionIsPersisted()
        {
            // Arrange
            var baseTime = DateTime.UtcNow;
            baseTime = new DateTime(
                baseTime.Ticks - (baseTime.Ticks % TimeSpan.TicksPerMillisecond),
                DateTimeKind.Utc
            );

            var transaction = new TransactionEntity
            {
                Id = Guid.NewGuid(),
                Amount = 150.0m,
                Date = baseTime,
                Description = "Utilities",
                Type = 2,
                CategoryId = CategorySeeds.CategoryTransport.Id,
            };

            var transactionGroupUser = new TransactionGroupUserEntity
            {
                Id = Guid.NewGuid(),
                TransactionId = transaction.Id,
                GroupUserId = GroupUserSeeds.GroupUserJohnDoeInFriends.Id,
                Transaction = null!,
                GroupUser = null!
            };

            var expectedCategory = CategorySeeds.CategoryTransport;

            // Act
            SpendWiseDbContextSUT.Transactions.Add(transaction);
            SpendWiseDbContextSUT.TransactionGroupUsers.Add(transactionGroupUser);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualTransaction = await dbx.Transactions
                .Include(t => t.Category)
                .Include(t => t.TransactionGroupUsers)
                .SingleAsync(t => t.Id == transaction.Id);

            // Verify all properties except Category if necessary
            DeepAssert.Equal(transaction, actualTransaction, propertiesToIgnore: new[] { "Category", "TransactionGroupUsers" });
            Assert.NotEmpty(actualTransaction.TransactionGroupUsers);
            DeepAssert.Contains(transactionGroupUser, actualTransaction.TransactionGroupUsers, propertiesToIgnore: new[] { "Transaction", "GroupUser" });
            Assert.NotNull(actualTransaction.Category);
            DeepAssert.Equal(CategorySeeds.CategoryTransport, actualTransaction.Category, propertiesToIgnore: new[] { "Transactions" });
        }

        /// <summary>
        /// Verifies that deleting a transaction from the system correctly removes the transaction and related entities.
        /// </summary>
        /// <returns>An asynchronous task representing the test operation.</returns>
        [Fact]
        public async Task DeleteTransaction_WhenTransactionIsDeleted_TransactionAndRelatedEntitiesAreRemoved()
        {
            // Arrange
            var baseEntity = TransactionSeeds.TransactionDelete;

            // Ensure the transaction exists before deletion
            Assert.True(await SpendWiseDbContextSUT.Transactions.AnyAsync(i => i.Id == baseEntity.Id));

            // Ensure that TransactionGroupUserEntities associated with the transaction exist
            var relatedTransactionGroupUsers = await SpendWiseDbContextSUT.TransactionGroupUsers
                .Where(tgu => tgu.TransactionId == baseEntity.Id)
                .ToListAsync();

            Assert.NotEmpty(relatedTransactionGroupUsers);

            // Act
            SpendWiseDbContextSUT.Transactions.Remove(baseEntity);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            // Verify that the transaction has been removed
            Assert.False(await SpendWiseDbContextSUT.Transactions.AnyAsync(i => i.Id == baseEntity.Id));

            // Verify that all associated TransactionGroupUserEntities have been removed
            var deletedTransactionGroupUsers = await SpendWiseDbContextSUT.TransactionGroupUsers
                .Where(tgu => tgu.TransactionId == baseEntity.Id)
                .ToListAsync();

            Assert.Empty(deletedTransactionGroupUsers);
        }

        /// <summary>
        /// Tests that the method for retrieving transactions by category returns the correct transactions.
        /// </summary>
        /// <returns>An asynchronous task representing the test operation.</returns>
        [Fact]
        public async Task GetTransactions_ByCategory_ReturnsCorrectTransactions()
        {
            // Arrange
            var testCategoryId = CategorySeeds.CategoryTransport.Id;
            var expectedTransactions = new[]
            {
                TransactionSeeds.TransactionJohnDoeTransport,
                TransactionSeeds.TransactionDelete
            };

            // Act
            var transactions = await SpendWiseDbContextSUT.Transactions
                .Where(t => t.CategoryId == testCategoryId)
                .ToArrayAsync();

            // Assert
            Assert.NotEmpty(transactions);
            Assert.Equal(expectedTransactions.Length, transactions.Length);
            foreach (var expectedTransaction in expectedTransactions)
            {
                DeepAssert.Contains(expectedTransaction, transactions, propertiesToIgnore: new[] { "Category", "TransactionGroupUsers" });
            }
        }

        /// <summary>
        /// Tests that the method for retrieving transactions by date range returns transactions within the specified range.
        /// </summary>
        /// <returns>An asynchronous task representing the test operation.</returns>
        [Fact]
        public async Task GetTransactions_ByDateRange_ReturnsTransactionsWithinRange()
        {
            // Arrange
            var expectedTransactions = new[]
            {
                TransactionSeeds.TransactionMinus28Hours,
                TransactionSeeds.TransactionMinus26Hours,
                TransactionSeeds.TransactionMinus24Hours
            };

            var startDate = TransactionSeeds.TransactionMinus28Hours.Date;
            var endDate = TransactionSeeds.TransactionMinus24Hours.Date;

            // Act
            var transactions = await SpendWiseDbContextSUT.Transactions
                .Where(t => t.Date >= startDate && t.Date <= endDate)
                .ToArrayAsync();

            // Assert
            Assert.NotEmpty(transactions);
            Assert.Equal(expectedTransactions.Length, transactions.Length);
            foreach (var expectedTransaction in expectedTransactions)
            {
                DeepAssert.Contains(expectedTransaction, transactions, propertiesToIgnore: new[] { "Category", "TransactionGroupUsers" });
            }
        }

        /// <summary>
        /// Tests that the method for retrieving transactions verifies the correctness of transaction amounts within the specified date range.
        /// </summary>
        /// <returns>An asynchronous task representing the test operation.</returns>
        [Fact]
        public async Task VerifyTransactionAmounts_WhenTransactionsExist_AmountsAreCorrect()
        {
            // Arrange
            var expectedAmounts = new[]
            {
                TransactionSeeds.TransactionMinus30Hours.Amount,
                TransactionSeeds.TransactionMinus28Hours.Amount,
                TransactionSeeds.TransactionMinus26Hours.Amount,
                TransactionSeeds.TransactionMinus24Hours.Amount,
                TransactionSeeds.TransactionMinus22Hours.Amount
            };

            var startDate = TransactionSeeds.TransactionMinus30Hours.Date;
            var endDate = TransactionSeeds.TransactionMinus22Hours.Date;

            // Act
            var transactions = await SpendWiseDbContextSUT.Transactions
                .Where(t => t.Date >= startDate && t.Date <= endDate)
                .ToArrayAsync();

            var actualAmounts = transactions.Select(t => t.Amount).ToArray();

            // Assert
            Assert.NotEmpty(transactions);
            Assert.Equal(expectedAmounts.Length, actualAmounts.Length);
            foreach (var expectedAmount in expectedAmounts)
            {
                DeepAssert.Contains(expectedAmount, actualAmounts, propertiesToIgnore: new[] { "Category", "TransactionGroupUsers" });
            }
        }

        /// <summary>
        /// Tests that the method for retrieving transactions verifies the correctness of transaction descriptions within the specified date range.
        /// </summary>
        /// <returns>An asynchronous task representing the test operation.</returns>
        [Fact]
        public async Task VerifyTransactionDescriptions_WhenTransactionsExist_DescriptionsAreCorrect()
        {
            // Arrange
            var expectedDescriptions = new[]
            {
                TransactionSeeds.TransactionMinus30Hours.Description,
                TransactionSeeds.TransactionMinus28Hours.Description,
                TransactionSeeds.TransactionMinus26Hours.Description,
                TransactionSeeds.TransactionMinus24Hours.Description,
                TransactionSeeds.TransactionMinus22Hours.Description
            };

            var startDate = TransactionSeeds.TransactionMinus22Hours.Date;
            var endDate = TransactionSeeds.TransactionMinus30Hours.Date;

            // Act
            var transactions = await SpendWiseDbContextSUT.Transactions
                .Where(t => t.Date >= endDate && t.Date <= startDate)
                .ToArrayAsync();

            var actualDescriptions = transactions.Select(t => t.Description).ToArray();

            // Assert
            Assert.Equal(expectedDescriptions.Length, actualDescriptions.Length);
            foreach (var expectedDescription in expectedDescriptions)
            {
                Assert.Contains(expectedDescription, actualDescriptions);
            }
        }

        /// <summary>
        /// Tests that when adding transactions and assigning them to user groups concurrently, transactions and groups are correctly persisted.
        /// </summary>
        /// <returns>An asynchronous task representing the test operation.</returns>
        [Fact]
        public async Task AddTransactions_Concurrently_TransactionsAndGroupsArePersistedCorrectly()
        {
            // Arrange
            var userId = UserSeeds.UserJohnDoe.Id;
            var categoryId = CategorySeeds.CategoryTransport.Id;
            var groupUserId = GroupUserSeeds.GroupUserJohnDoeInFriends.Id;

            var baseTime = DateTime.UtcNow.AddSeconds(-10);
            baseTime = new DateTime(baseTime.Ticks - (baseTime.Ticks % TimeSpan.TicksPerMillisecond), DateTimeKind.Utc);

            var transactionsToCreate = Enumerable.Range(0, 10).Select(i =>
            {
                var transactionId = Guid.NewGuid();
                var transaction = new TransactionEntity
                {
                    Id = transactionId,
                    Amount = 100.0m + i,
                    Date = baseTime.AddSeconds(i),
                    Description = $"Transaction {i}",
                    Type = 2,
                    CategoryId = categoryId
                };

                var transactionGroupUser = new TransactionGroupUserEntity
                {
                    Id = Guid.NewGuid(),
                    TransactionId = transactionId,
                    GroupUserId = groupUserId,
                    Transaction = null!,
                    GroupUser = null!
                };

                return (transaction, transactionGroupUser);
            }).ToList();

            // Act
            var tasks = transactionsToCreate.Select(async pair =>
            {
                await using var dbx = await DbContextFactory.CreateDbContextAsync();
                dbx.Transactions.Add(pair.transaction);
                dbx.TransactionGroupUsers.Add(pair.transactionGroupUser);
                await dbx.SaveChangesAsync();
            });

            await Task.WhenAll(tasks);

            // Assert
            await using var finalDbContext = await DbContextFactory.CreateDbContextAsync();
            var persistedTransactions = await finalDbContext.Transactions
                .Include(t => t.Category)
                .Include(t => t.TransactionGroupUsers)
                .Where(t => t.CategoryId == categoryId)
                .ToListAsync();

            Assert.Equal(12, persistedTransactions.Count); // 10 new + 2 seeded

            foreach (var (expectedTransaction, expectedTransactionGroupUser) in transactionsToCreate)
            {
                var actualTransaction = persistedTransactions.SingleOrDefault(t => t.Id == expectedTransaction.Id);
                Assert.NotNull(actualTransaction);
                Assert.NotEmpty(actualTransaction.TransactionGroupUsers);

                var actualTransactionGroupUser = actualTransaction.TransactionGroupUsers.SingleOrDefault(tgu => tgu.Id == expectedTransactionGroupUser.Id);
                Assert.NotNull(actualTransactionGroupUser);

                DeepAssert.Equal(expectedTransaction, actualTransaction, propertiesToIgnore: new[] { "Category", "TransactionGroupUsers" });
                DeepAssert.Equal(expectedTransactionGroupUser, actualTransactionGroupUser, propertiesToIgnore: new[] { "Transaction", "GroupUser" });
            }
        }


        /// <summary>
        /// Tests that the method for retrieving the total amount of transactions for user John Doe returns the correct sum of amounts.
        /// </summary>
        /// <returns>An asynchronous task representing the test operation.</returns>
        [Fact]
        public async Task GetTotalAmount_ForJohnDoeTransactions_ReturnsCorrectSum()
        {
            // Arrange
            var johnDoeUserId = UserSeeds.UserJohnDoe.Id; // ID of user John Doe
            var startDate = new DateTime(2024, 6, 15, 0, 0, 0, DateTimeKind.Utc); // Start date in UTC
            var endDate = DateTime.UtcNow; // End date in UTC

            // Act
            // Determine which groups user John Doe is part of
            var groupUserIds = await SpendWiseDbContextSUT.GroupUsers
                .Where(gu => gu.UserId == johnDoeUserId)
                .Select(gu => gu.Id)
                .ToListAsync();

            // Based on these groups, determine which transactions are associated with them
            var transactionIds = await SpendWiseDbContextSUT.TransactionGroupUsers
                .Where(tgu => groupUserIds.Contains(tgu.GroupUserId))
                .Select(tgu => tgu.TransactionId)
                .ToListAsync();

            // Retrieve transactions matching IDs and falling within the specified date range
            var totalAmount = await SpendWiseDbContextSUT.Transactions
                .Where(t => transactionIds.Contains(t.Id) && t.Date >= startDate && t.Date <= endDate)
                .SumAsync(t => t.Amount);

            // Assert
            var expectedTotalAmount = 50.0m + 150.0m + 200.0m + 175.0m; // Sum of transactions associated with John Doe
            Assert.Equal(expectedTotalAmount, totalAmount);
        }

        /// <summary>
        /// Tests that attempting to add a transaction with a negative amount to the database results in a <see cref="DbUpdateException"/> being thrown.
        /// </summary>
        /// <returns>An asynchronous task representing the test operation.</returns>
        [Fact]
        public void VerifyTransactionAmount_NegativeAmountThrowsException()
        {
            var transaction = new TransactionEntity
            {
                Id = Guid.NewGuid(),
                Amount = -100.00m,
                Date = DateTime.UtcNow,
                Type = 1,
                CategoryId = Guid.NewGuid()
            };

            var transactionGroupUser = new TransactionGroupUserEntity
            {
                Id = Guid.NewGuid(),
                TransactionId = transaction.Id,
                GroupUserId = GroupUserSeeds.GroupUserJohnDoeInFriends.Id,
                Transaction = null!,
                GroupUser = null!
            };

            SpendWiseDbContextSUT.Transactions.Add(transaction);
            SpendWiseDbContextSUT.TransactionGroupUsers.Add(transactionGroupUser);

            Assert.Throws<DbUpdateException>(() => SpendWiseDbContextSUT.SaveChanges());
        }

        /// <summary>
        /// Tests that attempting to add a transaction with a future date to the database results in a <see cref="DbUpdateException"/> being thrown.
        /// </summary>
        /// <returns>An asynchronous task representing the test operation.</returns>
        [Fact]
        public void VerifyTransactionDate_InFutureThrowsException()
        {
            var transaction = new TransactionEntity
            {
                Id = Guid.NewGuid(),
                Amount = 100.00m,
                Date = DateTime.UtcNow.AddDays(1), // Date in the future
                Type = 1,
                CategoryId = Guid.NewGuid()
            };

            var transactionGroupUser = new TransactionGroupUserEntity
            {
                Id = Guid.NewGuid(),
                TransactionId = transaction.Id,
                GroupUserId = GroupUserSeeds.GroupUserJohnDoeInFriends.Id,
                Transaction = null!,
                GroupUser = null!
            };

            SpendWiseDbContextSUT.Transactions.Add(transaction);
            SpendWiseDbContextSUT.TransactionGroupUsers.Add(transactionGroupUser);

            Assert.Throws<DbUpdateException>(() => SpendWiseDbContextSUT.SaveChanges());
        }
        /// <summary>
        /// Verifies that attempting to add a transaction with an invalid type (e.g., type 99) throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>An asynchronous task representing the test operation.</returns>
        [Fact]
        public void VerifyTransactionType_InvalidTypeThrowsException()
        {
            var transaction = new TransactionEntity
            {
                Id = Guid.NewGuid(),
                Amount = 100.00m,
                Date = DateTime.UtcNow,
                Type = 99, // Invalid type
                CategoryId = Guid.NewGuid()
            };

            var transactionGroupUser = new TransactionGroupUserEntity
            {
                Id = Guid.NewGuid(),
                TransactionId = transaction.Id,
                GroupUserId = GroupUserSeeds.GroupUserJohnDoeInFriends.Id,
                Transaction = null!,
                GroupUser = null!

            };

            SpendWiseDbContextSUT.Transactions.Add(transaction);
            SpendWiseDbContextSUT.TransactionGroupUsers.Add(transactionGroupUser);

            Assert.Throws<DbUpdateException>(() => SpendWiseDbContextSUT.SaveChanges());
        }

        /// <summary>
        /// Verifies that attempting to add a transaction with an invalid (empty) CategoryId throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>An asynchronous task representing the test operation.</returns>
        [Fact]
        public void VerifyTransactionCategory_RequiredCategory()
        {
            var transaction = new TransactionEntity
            {
                Id = Guid.NewGuid(),
                Amount = 100.00m,
                Date = DateTime.UtcNow,
                Type = 1,
                CategoryId = Guid.Empty // Invalid CategoryId
            };

            var transactionGroupUser = new TransactionGroupUserEntity
            {
                Id = Guid.NewGuid(),
                TransactionId = transaction.Id,
                GroupUserId = GroupUserSeeds.GroupUserJohnDoeInFriends.Id,
                Transaction = null!,
                GroupUser = null!
            };

            SpendWiseDbContextSUT.Transactions.Add(transaction);
            SpendWiseDbContextSUT.TransactionGroupUsers.Add(transactionGroupUser);

            Assert.Throws<DbUpdateException>(() => SpendWiseDbContextSUT.SaveChanges());
        }

        /// <summary>
        /// Verifies that attempting to add a transaction without any associated TransactionGroupUserEntities throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>An asynchronous task representing the test operation.</returns>
        [Fact]
        public void VerifyTransactionGroupUsers_MustExist()
        {
            var transaction = new TransactionEntity
            {
                Id = Guid.NewGuid(),
                Amount = 100.00m,
                Date = DateTime.UtcNow,
                Type = 1,
                CategoryId = Guid.NewGuid()
            };

            SpendWiseDbContextSUT.Transactions.Add(transaction);

            Assert.Throws<DbUpdateException>(() => SpendWiseDbContextSUT.SaveChanges());
        }

        /// <summary>
        /// Verifies that a transaction with a description exceeding the maximum allowed length (e.g., 200 characters) throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>An asynchronous task representing the test operation.</returns>
        [Fact]
        public async Task VerifyTransactionDescription_LengthConstraint()
        {
            // Arrange
            var longDescription = new string('a', 201); // Assuming the max length is 200 characters
            var transaction = new TransactionEntity
            {
                Id = Guid.NewGuid(),
                Amount = 100.00m,
                Date = DateTime.UtcNow,
                Description = longDescription,
                Type = 1,
                CategoryId = CategorySeeds.CategoryFood.Id
            };

            var transactionGroupUser = new TransactionGroupUserEntity
            {
                Id = Guid.NewGuid(),
                TransactionId = transaction.Id,
                GroupUserId = GroupUserSeeds.GroupUserJohnDoeInFriends.Id,
                Transaction = null!,
                GroupUser = null!
            };

            // Act
            SpendWiseDbContextSUT.Transactions.Add(transaction);
            SpendWiseDbContextSUT.TransactionGroupUsers.Add(transactionGroupUser);
            await Assert.ThrowsAsync<DbUpdateException>(async () => await SpendWiseDbContextSUT.SaveChangesAsync());
        }

        /// <summary>
        /// Verifies that updating a transaction successfully persists changes such as amount, description, and date.
        /// </summary>
        /// <returns>An asynchronous task representing the test operation.</returns>
        [Fact]
        public async Task UpdateTransaction_WhenTransactionIsUpdated_ChangesArePersisted()
        {
            // Arrange
            var newTransaction = TransactionSeeds.TransactionAdminFood with
            {
                Amount = 500m,
                Description = "Updated Transaction",
                Type = 2
            };

            SpendWiseDbContextSUT.Transactions.Update(newTransaction);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            var updatedTransaction = await SpendWiseDbContextSUT.Transactions
                .Include(t => t.TransactionGroupUsers)
                .SingleAsync(t => t.Id == newTransaction.Id);

            Assert.Equal(500.00m, updatedTransaction.Amount);
            Assert.Equal("Updated Transaction", updatedTransaction.Description);
            Assert.Equal(newTransaction.Date, updatedTransaction.Date);
            Assert.NotEmpty(updatedTransaction.TransactionGroupUsers);
        }

        /// <summary>
        /// Verifies that attempting to add a transaction with an amount of zero throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>An asynchronous task representing the test operation.</returns>
        [Fact]
        public void VerifyTransactionAmount_NotZeroThrowsException()
        {
            var transaction = new TransactionEntity
            {
                Id = Guid.NewGuid(),
                Amount = 0.00m, // Zero amount
                Date = DateTime.UtcNow,
                Type = 1,
                CategoryId = CategorySeeds.CategoryFood.Id
            };

            var transactionGroupUser = new TransactionGroupUserEntity
            {
                Id = Guid.NewGuid(),
                TransactionId = transaction.Id,
                GroupUserId = GroupUserSeeds.GroupUserJohnDoeInFriends.Id,
                Transaction = null!,
                GroupUser = null!
            };

            SpendWiseDbContextSUT.Transactions.Add(transaction);
            SpendWiseDbContextSUT.TransactionGroupUsers.Add(transactionGroupUser);

            Assert.Throws<DbUpdateException>(() => SpendWiseDbContextSUT.SaveChanges());
        }
    }
}

