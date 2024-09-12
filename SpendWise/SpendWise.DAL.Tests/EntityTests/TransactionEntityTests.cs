using SpendWise.DAL.Entities;
using SpendWise.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using SpendWise.Common.Tests.Helpers;
using SpendWise.Common.Enums;

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

        #region CRUD Operations Tests

        /// <summary>
        /// Tests the addition of a valid transaction to the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddTransaction_ShouldPersistValidTransaction()
        {
            // Arrange
            var baseDateTime = DateTime.UtcNow;
            baseDateTime = new DateTime(
                baseDateTime.Ticks - (baseDateTime.Ticks % TimeSpan.TicksPerMillisecond),
                DateTimeKind.Utc
            );

            var transactionToAdd = new TransactionEntity
            {
                Id = Guid.NewGuid(),
                Amount = 150.0m,
                Date = baseDateTime,
                Description = "Utilities",
                Type = TransactionType.Expense,
                CategoryId = CategorySeeds.CategoryTransport.Id,
            };

            // Act
            SpendWiseDbContextSUT.Transactions.Add(transactionToAdd);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualTransaction = await dbx.Transactions
                .SingleAsync(t => t.Id == transactionToAdd.Id);

            DeepAssert.Equal(transactionToAdd, actualTransaction);
        }

        /// <summary>
        /// Tests the deletion of an existing transaction from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteTransaction_ShouldRemoveExistingTransaction()
        {
            // Arrange
            var transactionToDelete = await SpendWiseDbContextSUT.Transactions
                .AsNoTracking()
                .FirstAsync(t => t.Id == TransactionSeeds.TransactionDianaDinner.Id);

            Assert.NotNull(transactionToDelete);

            // Ensure that TransactionGroupUserEntities associated with the transaction exist
            var relatedTransactionGroupUsers = await SpendWiseDbContextSUT.TransactionGroupUsers
                .Where(tgu => tgu.TransactionId == transactionToDelete.Id)
                .ToListAsync();

            Assert.NotEmpty(relatedTransactionGroupUsers);

            // Act
            SpendWiseDbContextSUT.Transactions.Remove(transactionToDelete);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            Assert.False(await SpendWiseDbContextSUT.Transactions.AnyAsync(i => i.Id == transactionToDelete.Id));
            var deletedTransactionGroupUsers = await SpendWiseDbContextSUT.TransactionGroupUsers
                .Where(tgu => tgu.TransactionId == transactionToDelete.Id)
                .ToListAsync();

            Assert.Empty(deletedTransactionGroupUsers);
        }

        /// <summary>
        /// Tests the update of an existing transaction in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateTransaction_ShouldPersistChanges()
        {
            // Arrange
            var transactionToUpdate = new TransactionEntity()
            {
                Id = TransactionSeeds.TransactionDianaDinner.Id,
                Date = TransactionSeeds.TransactionDianaDinner.Date,
                Amount = 500m,
                Description = "Updated Transaction",
                Type = TransactionType.Income,
            };

            // Act
            SpendWiseDbContextSUT.Transactions.Update(transactionToUpdate);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            var updatedTransaction = await SpendWiseDbContextSUT.Transactions
                .Include(t => t.TransactionGroupUsers)
                .SingleAsync(t => t.Id == transactionToUpdate.Id);

            Assert.Equal(500.00m, updatedTransaction.Amount);
            Assert.Equal("Updated Transaction", updatedTransaction.Description);
            Assert.Equal(transactionToUpdate.Date, updatedTransaction.Date);
            Assert.NotEmpty(updatedTransaction.TransactionGroupUsers);
        }

        #endregion

        #region Error Handling Tests

        /// <summary>
        /// Tests that adding a transaction with a negative amount throws a `DbUpdateException`.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddTransaction_WithNegativeAmount_ShouldThrowDbUpdateException()
        {
            // Arrange
            var invalidTransaction = new TransactionEntity
            {
                Id = Guid.NewGuid(),
                Amount = -100.00m,
                Date = DateTime.UtcNow,
                Type = TransactionType.Expense,
                CategoryId = Guid.NewGuid(),
                Description = null
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                await SpendWiseDbContextSUT.Transactions.AddAsync(invalidTransaction);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });

            Assert.NotNull(exception);
        }

        /// <summary>
        /// Tests that updating a transaction with a non-existent category throws a `DbUpdateConcurrencyException`.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateTransaction_WithNonExistentCategory_ShouldThrowDbUpdateConcurrencyException()
        {
            // Arrange
            var invalidTransaction = new TransactionEntity
            {
                Id = Guid.NewGuid(),
                Amount = 200.00m,
                Date = DateTime.UtcNow,
                Type = TransactionType.Expense,
                CategoryId = Guid.NewGuid(),
                Description = null
            };

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateConcurrencyException>(async () =>
            {
                SpendWiseDbContextSUT.Transactions.Update(invalidTransaction);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });
        }

        /// <summary>
        /// Tests that adding a transaction with an invalid category ID throws a `DbUpdateException`.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddTransaction_WithInvalidCategory_ShouldThrowDbUpdateException()
        {
            // Arrange
            var invalidTransaction = new TransactionEntity
            {
                Id = Guid.NewGuid(),
                Amount = 100.00m,
                Date = DateTime.UtcNow,
                Type = TransactionType.Expense,
                CategoryId = Guid.Empty,
                Description = null
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                await SpendWiseDbContextSUT.Transactions.AddAsync(invalidTransaction);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });

            Assert.NotNull(exception);
        }

        /// <summary>
        /// Tests that adding a transaction with a description exceeding the maximum allowed length throws a `DbUpdateException`.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddTransaction_WithExceedingDescriptionLength_ShouldThrowDbUpdateException()
        {
            // Arrange
            var longDescription = new string('a', 201); // Assuming the max length is 200 characters
            var invalidTransaction = new TransactionEntity
            {
                Id = Guid.NewGuid(),
                Amount = 100.00m,
                Date = DateTime.UtcNow,
                Description = longDescription,
                Type = TransactionType.Expense,
                CategoryId = CategorySeeds.CategoryFood.Id
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                await SpendWiseDbContextSUT.Transactions.AddAsync(invalidTransaction);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });

            Assert.NotNull(exception);
        }

        /// <summary>
        /// Tests that adding a transaction with a zero amount throws a `DbUpdateException`.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddTransaction_WithZeroAmount_ShouldThrowDbUpdateException()
        {
            // Arrange
            var invalidTransaction = new TransactionEntity
            {
                Id = Guid.NewGuid(),
                Amount = 0.00m, // Zero amount
                Date = DateTime.UtcNow,
                Type = TransactionType.Expense,
                CategoryId = CategorySeeds.CategoryFood.Id,
                Description = null
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                await SpendWiseDbContextSUT.Transactions.AddAsync(invalidTransaction);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });

            Assert.NotNull(exception);
        }

        #endregion

        #region Data Retrieval Tests

        /// <summary>
        /// Tests the retrieval of transactions based on a specific category ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchTransactions_ByCategory_ShouldReturnExpectedTransactions()
        {
            // Arrange
            var testCategoryId = CategorySeeds.CategoryTransport.Id;
            var expectedTransactionIds = new[]
            {
                TransactionSeeds.TransactionJohnTaxi.Id,
                TransactionSeeds.TransactionJohnTransport.Id
            };

            // Act
            var transactions = await SpendWiseDbContextSUT.Transactions
                .Where(t => t.CategoryId == testCategoryId)
                .ToArrayAsync();

            // Assert
            Assert.NotEmpty(transactions);
            Assert.Equal(expectedTransactionIds.Length, transactions.Length);
            foreach (var expectedTransactionId in expectedTransactionIds)
            {
                Assert.Contains(transactions, t => t.Id == expectedTransactionId);
            }
        }

        /// <summary>
        /// Tests the retrieval of transactions within a specified date range.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchTransactions_ByDateRange_ShouldReturnTransactionsInRange()
        {
            // Arrange
            var expectedTransactionIds = new[]
            {
                TransactionSeeds.TransactionJohnFood.Id,
                TransactionSeeds.TransactionJohnTaxi.Id
            };

            var startDate = TransactionSeeds.TransactionJohnFood.Date;
            var endDate = TransactionSeeds.TransactionJohnTaxi.Date;

            // Act
            var transactions = await SpendWiseDbContextSUT.Transactions
                .Where(t => t.Date >= startDate && t.Date <= endDate)
                .ToArrayAsync();

            // Assert
            Assert.NotEmpty(transactions);
            Assert.Equal(expectedTransactionIds.Length, transactions.Length);
            foreach (var expectedTransactionId in expectedTransactionIds)
            {
                Assert.Contains(transactions, t => t.Id == expectedTransactionId);
            }
        }

        #endregion

        #region Update and Special Cases Tests

        /// <summary>
        /// Tests the addition of multiple transactions concurrently.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddTransactions_Concurrently_ShouldPersistAllTransactions()
        {
            // Arrange
            var baseDateTime = DateTime.UtcNow;
            baseDateTime = new DateTime(
                baseDateTime.Ticks - (baseDateTime.Ticks % TimeSpan.TicksPerMillisecond),
                DateTimeKind.Utc
            );

            var transactionsToAdd = Enumerable.Range(0, 10).Select(i => new TransactionEntity
            {
                Id = Guid.NewGuid(),
                Amount = 150.0m,
                Date = baseDateTime,
                Description = $"Utilities{i}",
                Type = TransactionType.Income,
                CategoryId = CategorySeeds.CategoryTransport.Id,
            }).ToList();

            // Act
            var addTasks = transactionsToAdd.Select(async transaction =>
            {
                await using var dbContext = await DbContextFactory.CreateDbContextAsync();
                dbContext.Transactions.Add(transaction);
                await dbContext.SaveChangesAsync();
            });

            await Task.WhenAll(addTasks);

            // Assert
            var verificationTasks = transactionsToAdd.Select(async transaction =>
            {
                await using var dbContext = await DbContextFactory.CreateDbContextAsync();
                var actualTransaction = await dbContext.Transactions.FindAsync(transaction.Id);
                Assert.NotNull(actualTransaction);
                DeepAssert.Equal(transaction, actualTransaction);
            });

            await Task.WhenAll(verificationTasks);
        }

        #endregion

        #region Related Entities Handling Tests

        /// <summary>
        /// Tests the retrieval of a transaction and its related navigation properties.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchTransaction_ShouldLoadNavigationProperties()
        {
            // Arrange
            var expectedTransaction = TransactionSeeds.TransactionJohnFood;
            var expectedTransactionGroupUsers = TransactionSeeds.TransactionJohnFood.TransactionGroupUsers;

            // Act
            var actualTransaction = await SpendWiseDbContextSUT.Transactions
                .Include(t => t.Category)
                .Include(t => t.TransactionGroupUsers)
                .SingleOrDefaultAsync(t => t.Id == expectedTransaction.Id);

            // Assert
            Assert.NotNull(actualTransaction);
            Assert.NotNull(actualTransaction.Category);
            Assert.Equal(expectedTransaction.CategoryId, actualTransaction.Category.Id);
            Assert.NotEmpty(actualTransaction.TransactionGroupUsers);

            foreach (var expectedTransactionGroupUser in expectedTransactionGroupUsers)
            {
                DeepAssert.Contains(expectedTransactionGroupUser, actualTransaction.TransactionGroupUsers);
            }
        }

        #endregion

        #region Consistency Tests

        /// <summary>
        /// Tests the integrity of the database after a transaction deletion.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteTransaction_ShouldMaintainIntegrityConstraints()
        {
            // Arrange
            var existingTransactionId = TransactionSeeds.TransactionDianaDinner.Id;

            // Act
            var transactionToDelete = await SpendWiseDbContextSUT.Transactions
                .Include(t => t.TransactionGroupUsers)
                .Where(t => t.Id == existingTransactionId)
                .SingleOrDefaultAsync();

            Assert.NotNull(transactionToDelete);

            SpendWiseDbContextSUT.Transactions.Remove(transactionToDelete);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            Assert.False(await SpendWiseDbContextSUT.Transactions.AnyAsync(t => t.Id == existingTransactionId));
            Assert.False(await SpendWiseDbContextSUT.TransactionGroupUsers
                .AnyAsync(tgu => tgu.TransactionId == existingTransactionId));
        }

        #endregion
    }
}