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
        /// Contains tests for the Create, Read, Update, and Delete (CRUD) operations
        /// on the `TransactionEntity` in the database. These tests ensure that basic
        /// database operations are correctly implemented and function as expected.
        /// </summary>

        [Fact]
        /// <summary>
        /// Tests the addition of a valid transaction to the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddTransaction_ValidTransaction_SuccessfullyPersists()
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

        [Fact]
        /// <summary>
        /// Tests the deletion of an existing transaction from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteTransaction_ExistingTransaction_SuccessfullyRemoves()
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

        [Fact]
        /// <summary>
        /// Tests the update of an existing transaction in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateTransaction_ExistingEntity_SuccessfullyPersistsChanges()
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
        /// Contains tests focused on verifying the application's error handling capabilities.
        /// These tests ensure that the system correctly identifies and handles invalid data inputs
        /// during database operations by throwing appropriate exceptions.
        /// </summary>

        [Fact]
        /// <summary>
        /// Tests that adding a transaction with a negative amount throws a `DbUpdateException`.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddTransaction_InvalidNegativeAmount_ThrowsDbUpdateException()
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

        [Fact]
        /// <summary>
        /// Tests that updating a transaction with a non-existent category throws a `DbUpdateConcurrencyException`.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateTransaction_NonExistentCategory_ThrowsDbUpdateConcurrencyException()
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

        [Fact]
        /// <summary>
        /// Tests that adding a transaction with an invalid category ID throws a `DbUpdateException`.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddTransaction_InvalidCategory_ThrowsDbUpdateException()
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

        [Fact]
        /// <summary>
        /// Tests that adding a transaction with a description exceeding the maximum allowed length throws a `DbUpdateException`.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddTransaction_ExceedsDescriptionLength_ThrowsDbUpdateException()
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

        [Fact]
        /// <summary>
        /// Tests that adding a transaction with a zero amount throws a `DbUpdateException`.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddTransaction_ZeroAmount_ThrowsDbUpdateException()
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
        /// Contains tests that focus on retrieving data from the database, specifically related to transactions.
        /// These tests ensure that queries return the correct data based on specific criteria such as category, date range, and user-specific transactions.
        /// </summary>

        [Fact]
        /// <summary>
        /// Tests the retrieval of transactions based on a specific category ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task FetchTransactions_ByCategory_ReturnsExpectedTransactions()
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

        [Fact]
        /// <summary>
        /// Tests the retrieval of transactions within a specified date range.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task FetchTransactions_ByDateRange_ReturnsTransactionsInRange()
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

        [Fact]
        /// <summary>
        /// Tests the calculation of the total amount of transactions for a specific user (John Doe) within a given date range.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
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
                .Distinct()
                .ToListAsync();

            // Calculate the total amount based on these transactions
            var totalAmount = await SpendWiseDbContextSUT.Transactions
                .Where(t => transactionIds.Contains(t.Id) && t.Date >= startDate && t.Date <= endDate)
                .SumAsync(t => t.Amount);

            // Assert
            Assert.Equal(175.00m, totalAmount);
        }

        #endregion

        #region Update and Special Cases Tests

        /// <summary>
        /// Contains tests for special cases and concurrent updates involving the `TransactionEntity`
        /// to ensure that the database can handle multiple additions correctly.
        /// </summary>
        [Fact]
        /// <summary>
        /// Tests the addition of multiple transactions concurrently.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddCategories_ConcurrentAdditions_SuccessfullyPersistAllCategories()
        {
            // Arrange
            var baseDateTime = DateTime.UtcNow;
            baseDateTime = new DateTime(
                baseDateTime.Ticks - (baseDateTime.Ticks % TimeSpan.TicksPerMillisecond),
                DateTimeKind.Utc
            );

            var transactionToAdd = Enumerable.Range(0, 10).Select(i => new TransactionEntity
            {
                Id = Guid.NewGuid(),
                Amount = 150.0m,
                Date = baseDateTime,
                Description = $"Utilities{i}",
                Type = TransactionType.Income,
                CategoryId = CategorySeeds.CategoryTransport.Id,
            }).ToList();

            // Act
            var tasks = transactionToAdd.Select(async transaction =>
            {
                await using var dbx = await DbContextFactory.CreateDbContextAsync();
                dbx.Transactions.Add(transaction);
                await dbx.SaveChangesAsync();
            });

            await Task.WhenAll(tasks);

            // Assert
            var verificationTasks = transactionToAdd.Select(async transaction =>
            {
                await using var dbx = await DbContextFactory.CreateDbContextAsync();
                var actualTransaction = await dbx.Transactions.FindAsync(transaction.Id);
                Assert.NotNull(actualTransaction);
                DeepAssert.Equal(transaction, actualTransaction);
            });

            await Task.WhenAll(verificationTasks);
        }

        #endregion

        #region Related Entities Handling Tests

        /// <summary>
        /// Contains tests to verify the proper loading of related navigation properties for `TransactionEntity`.
        /// </summary>
        [Fact]
        /// <summary>
        /// Tests the retrieval of a transaction and its related navigation properties.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task FetchTransaction_NavigationPropertiesAreCorrectlyLoaded()
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
        /// Contains tests to verify the integrity of the database after operations that modify data.
        /// </summary>
        [Fact]
        /// <summary>
        /// Tests the integrity of the database after a transaction deletion.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteTransaction_CheckIntegrityConstraints_AfterDeletion()
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
            // Check that the transaction is no longer present
            Assert.False(await SpendWiseDbContextSUT.Transactions.AnyAsync(t => t.Id == existingTransactionId));

            // Check that related TransactionGroupUser entities are also deleted
            Assert.False(await SpendWiseDbContextSUT.TransactionGroupUsers
                .AnyAsync(tgu => tgu.TransactionId == existingTransactionId));
        }

        #endregion
    }
}