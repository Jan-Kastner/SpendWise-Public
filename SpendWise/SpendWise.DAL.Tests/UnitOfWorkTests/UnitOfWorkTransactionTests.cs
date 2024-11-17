using Xunit;
using Xunit.Abstractions;
using SpendWise.DAL.DTOs;
using Microsoft.EntityFrameworkCore;
using SpendWise.Common.Tests.Seeds;
using SpendWise.Common.Tests.Helpers;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;
using SpendWise.Common.Enums;

namespace SpendWise.DAL.Tests.UnitOfWorkTests
{
    /// <summary>
    /// Contains tests for operations related to transactions using the Unit of Work pattern.
    /// </summary>
    public class UnitOfWorkTransactionTests : UnitOfWorkTestsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkTransactionTests"/> class.
        /// </summary>
        /// <param name="output">The test output helper.</param>
        public UnitOfWorkTransactionTests(ITestOutputHelper output) : base(output)
        {
        }

        #region CRUD Operations Tests

        /// <summary>
        /// Tests that a transaction with valid data is added and persisted successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddTransaction_ValidData_SuccessfullyPersists()
        {
            // Arrange
            var transactionToAdd = new TransactionDto
            {
                Id = Guid.NewGuid(),
                Amount = 300m,
                Date = DateTime.UtcNow,
                Description = "Test Transaction",
                Type = TransactionType.Expense,
                CategoryId = null
            };

            // Act
            await _unitOfWork.TransactionRepository.InsertAsync(transactionToAdd);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var queryObject = new TransactionQueryObject().WithId(transactionToAdd.Id);
            var actualTransaction = await _unitOfWork.TransactionRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(actualTransaction);
            DeepAssert.Equal(transactionToAdd, actualTransaction);
        }

        /// <summary>
        /// Tests that fetching a transaction by its ID returns the expected transaction.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchTransactionById_ExistingId_ReturnsExpectedTransaction()
        {
            // Arrange
            var expectedTransaction = _mapper.Map<TransactionDto>(TransactionSeeds.TransactionDianaDinner);
            var queryObject = new TransactionQueryObject().WithId(expectedTransaction.Id);

            // Act
            var actualTransaction = await _unitOfWork.TransactionRepository.SingleOrDefaultAsync(queryObject);

            // Assert
            Assert.NotNull(actualTransaction);
            DeepAssert.Equal(expectedTransaction, actualTransaction);
        }

        /// <summary>
        /// Tests that updating a transaction with valid data persists the changes successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateTransaction_ValidData_SuccessfullyPersistsChanges()
        {
            // Arrange
            var existingTransaction = _mapper.Map<TransactionDto>(TransactionSeeds.TransactionDianaDinner);
            var updatedTransaction = existingTransaction with
            {
                Amount = 500m,
                Description = "Updated Transaction",
                Type = TransactionType.Income,
            };

            // Act
            await _unitOfWork.TransactionRepository.UpdateAsync(updatedTransaction);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var queryObject = new TransactionQueryObject().WithId(updatedTransaction.Id);
            var actualUpdatedTransaction = await _unitOfWork.TransactionRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(actualUpdatedTransaction);
            DeepAssert.Equal(updatedTransaction, actualUpdatedTransaction);
        }

        /// <summary>
        /// Tests that deleting a transaction with an existing ID removes the transaction successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteTransaction_ExistingId_SuccessfullyRemovesTransaction()
        {
            // Arrange
            var transactionToDelete = _mapper.Map<TransactionDto>(TransactionSeeds.TransactionDianaDinner);

            // Act
            await _unitOfWork.TransactionRepository.DeleteAsync(transactionToDelete.Id);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var queryObject = new TransactionQueryObject().WithId(transactionToDelete.Id);
            var deletedTransaction = await _unitOfWork.TransactionRepository.SingleOrDefaultAsync(queryObject);
            Assert.Null(deletedTransaction);
        }

        #endregion

        #region Error Handling Tests

        /// <summary>
        /// Tests that adding a transaction with an invalid CategoryId throws a Exception.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddTransaction_WithInvalidCategoryId_ThrowsException()
        {
            var invalidTransaction = new TransactionDto
            {
                Id = Guid.NewGuid(),
                Amount = 100m,
                Date = DateTime.UtcNow,
                Description = "Invalid Transaction",
                Type = TransactionType.Expense,
                CategoryId = Guid.NewGuid() // Invalid CategoryId
            };

            await Assert.ThrowsAsync<Exception>(async () =>
            {
                await _unitOfWork.TransactionRepository.InsertAsync(invalidTransaction);
                await _unitOfWork.SaveChangesAsync();
            });
        }

        /// <summary>
        /// Tests that updating a non-existent transaction throws an Exception.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateTransaction_NonExistentTransaction_ThrowsException()
        {
            var nonExistentTransaction = new TransactionDto
            {
                Id = Guid.NewGuid(), // Non-existent ID
                Amount = 100m,
                Date = DateTime.UtcNow,
                Description = "Non-existent Transaction",
                Type = TransactionType.Expense,
                CategoryId = Guid.Empty
            };

            await Assert.ThrowsAsync<Exception>(async () =>
            {
                await _unitOfWork.TransactionRepository.UpdateAsync(nonExistentTransaction);
                await _unitOfWork.SaveChangesAsync();
            });
        }

        /// <summary>
        /// Tests that deleting a non-existent transaction throws a Exception.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteTransaction_NonExistentTransaction_ThrowsException()
        {
            var nonExistentTransactionId = Guid.NewGuid(); // Non-existent ID

            await Assert.ThrowsAsync<Exception>(async () =>
            {
                await _unitOfWork.TransactionRepository.DeleteAsync(nonExistentTransactionId);
                await _unitOfWork.SaveChangesAsync();
            });
        }

        #endregion

        #region Update and Special Cases Tests

        /// <summary>
        /// Tests that changing a transaction's CategoryId updates the CategoryId successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateTransaction_ChangeCategoryId_ShouldChange()
        {
            var existingTransaction = _mapper.Map<TransactionDto>(TransactionSeeds.TransactionJohnFood);

            var updatedTransaction = existingTransaction with
            {
                CategoryId = CategorySeeds.CategoryTransport.Id // Change CategoryId
            };
            await _unitOfWork.TransactionRepository.UpdateAsync(updatedTransaction);
            await _unitOfWork.SaveChangesAsync();

            var queryObject = new TransactionQueryObject().WithId(existingTransaction.Id);
            var actualTransaction = await _unitOfWork.TransactionRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(actualTransaction);
            Assert.Equal(updatedTransaction.CategoryId, actualTransaction.CategoryId); // CategoryId should be changed
        }

        /// <summary>
        /// Tests that changing a transaction's amount updates the amount successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateTransaction_ChangeAmount_ShouldChange()
        {
            var existingTransaction = _mapper.Map<TransactionDto>(TransactionSeeds.TransactionJohnFood);

            var updatedTransaction = existingTransaction with
            {
                Amount = 200m, // Change Amount
            };

            await _unitOfWork.TransactionRepository.UpdateAsync(updatedTransaction);
            await _unitOfWork.SaveChangesAsync();

            var queryObject = new TransactionQueryObject().WithId(existingTransaction.Id);
            var actualTransaction = await _unitOfWork.TransactionRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(actualTransaction);
            Assert.Equal(updatedTransaction.Amount, actualTransaction.Amount); // Amount should be changed
        }

        /// <summary>
        /// Tests that changing a transaction's date updates the date successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateTransaction_ChangeDate_ShouldChange()
        {
            var existingTransaction = _mapper.Map<TransactionDto>(TransactionSeeds.TransactionJohnFood);

            var updatedTransaction = existingTransaction with
            {
                Date = DateTime.UtcNow, // Change Date
            };

            await _unitOfWork.TransactionRepository.UpdateAsync(updatedTransaction);
            await _unitOfWork.SaveChangesAsync();

            var queryObject = new TransactionQueryObject().WithId(existingTransaction.Id);
            var actualTransaction = await _unitOfWork.TransactionRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(actualTransaction);
            Assert.Equal(updatedTransaction.Date, actualTransaction.Date); // Date should be changed
        }

        /// <summary>
        /// Tests that changing a transaction's description updates the description successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateTransaction_ChangeDescription_ShouldChange()
        {
            var existingTransaction = _mapper.Map<TransactionDto>(TransactionSeeds.TransactionJohnFood);

            var updatedTransaction = existingTransaction with
            {
                Description = "Updated Description", // Change Description
            };

            await _unitOfWork.TransactionRepository.UpdateAsync(updatedTransaction);
            await _unitOfWork.SaveChangesAsync();

            var queryObject = new TransactionQueryObject().WithId(existingTransaction.Id);
            var actualTransaction = await _unitOfWork.TransactionRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(actualTransaction);
            Assert.Equal(updatedTransaction.Description, actualTransaction.Description); // Description should be changed
        }

        /// <summary>
        /// Tests that changing a transaction's type updates the type successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateTransaction_ChangeType_ShouldChange()
        {
            var existingTransaction = _mapper.Map<TransactionDto>(TransactionSeeds.TransactionJohnFood);

            var updatedTransaction = existingTransaction with
            {
                Type = TransactionType.Income, // Change Type
            };

            await _unitOfWork.TransactionRepository.UpdateAsync(updatedTransaction);
            await _unitOfWork.SaveChangesAsync();

            var queryObject = new TransactionQueryObject().WithId(existingTransaction.Id);
            var actualTransaction = await _unitOfWork.TransactionRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(actualTransaction);
            Assert.Equal(updatedTransaction.Type, actualTransaction.Type); // Type should be changed
        }

        #endregion

        #region Related Entities Handling Tests

        /// <summary>
        /// Tests that deleting a transaction with an associated category keeps the category intact.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteTransaction_WithAssociatedCategory_KeepsCategoryIntact()
        {
            // Arrange
            var transactionToDelete = TransactionSeeds.TransactionJohnFood;
            var associatedCategoryId = CategorySeeds.CategoryFood.Id;

            // Verify the initial state before deletion
            var initialTransactionGroupUsers = await _unitOfWork.TransactionGroupUserRepository.ListAsync(new TransactionGroupUserQueryObject().WithTransaction(transactionToDelete.Id));
            Assert.NotEmpty(initialTransactionGroupUsers); // Ensure there are transaction group users related to the transaction

            // Act
            await _unitOfWork.TransactionRepository.DeleteAsync(transactionToDelete.Id);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var queryObject = new CategoryQueryObject().WithId(associatedCategoryId);
            var category = await _unitOfWork.CategoryRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(category); // Ensure the category is still intact

            var transactionGroupUsersAfterDelete = await _unitOfWork.TransactionGroupUserRepository.ListAsync(new TransactionGroupUserQueryObject().WithTransaction(transactionToDelete.Id));
            Assert.Empty(transactionGroupUsersAfterDelete); // Ensure all transaction group users related to the transaction are removed
        }

        #endregion

        #region Consistency Tests

        /// <summary>
        /// Tests that after multiple transaction operations (insert, update, delete), the final state is consistent.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task TransactionalConsistency_AfterMultipleTransactionOperations()
        {
            // Arrange
            var newTransactionDto = new TransactionDto
            {
                Id = Guid.NewGuid(),
                Amount = 150m,
                Date = DateTime.UtcNow,
                Description = "New Transaction",
                Type = TransactionType.Expense,
                CategoryId = CategorySeeds.CategoryFood.Id
            };

            var updatedTransactionDto = new TransactionDto
            {
                Id = newTransactionDto.Id,
                Amount = 200m,
                Date = newTransactionDto.Date,
                Description = "Updated Transaction",
                Type = TransactionType.Expense,
                CategoryId = newTransactionDto.CategoryId,
            };

            try
            {
                // Act
                // Insert
                await _unitOfWork.TransactionRepository.InsertAsync(newTransactionDto);
                await _unitOfWork.SaveChangesAsync();

                // Update
                await _unitOfWork.TransactionRepository.UpdateAsync(updatedTransactionDto);
                await _unitOfWork.SaveChangesAsync();

                // Delete
                await _unitOfWork.TransactionRepository.DeleteAsync(newTransactionDto.Id);
                await _unitOfWork.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            // Assert
            var queryObject = new TransactionQueryObject().WithId(newTransactionDto.Id);
            var deletedTransaction = await _unitOfWork.TransactionRepository.SingleOrDefaultAsync(queryObject);
            Assert.Null(deletedTransaction);
        }

        #endregion
    }
}