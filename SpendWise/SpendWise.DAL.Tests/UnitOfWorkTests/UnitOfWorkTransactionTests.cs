using Xunit.Abstractions;
using SpendWise.DAL.DTOs;
using Microsoft.EntityFrameworkCore;
using SpendWise.Common.Tests.Seeds;
using SpendWise.Common.Tests.Helpers;

namespace SpendWise.DAL.Tests
{
    /// <summary>
    /// Contains tests for operations related to transactions using the Unit of Work pattern.
    /// </summary>
    public class UnitOfWorkTransactionTests : UnitOfWorkTestsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkTransactionTests"/> class.
        /// </summary>
        /// <param name="output">The output helper instance.</param>
        public UnitOfWorkTransactionTests(ITestOutputHelper output) : base(output)
        {
        }

        // ====================================
        // CRUD Operations Tests
        // ====================================

        /// <summary>
        /// Tests if inserting a new transaction with valid data correctly adds the transaction to the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task InsertTransaction_AddsTransactionToDatabase()
        {
            // Arrange
            var newTransactionDto = new TransactionDto
            {
                Id = Guid.NewGuid(),
                Amount = 300m,
                Date = DateTime.UtcNow,
                Description = "Test Transaction",
                Type = 1,
                CategoryId = null // Optional, depending on your business logic
            };

            // Act
            await _unitOfWork.Transactions.InsertAsync(newTransactionDto);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var transactionInDb = await _unitOfWork.Transactions.GetByIdAsync(newTransactionDto.Id);
            Assert.NotNull(transactionInDb);
            DeepAssert.Equal(newTransactionDto, transactionInDb);
        }

        /// <summary>
        /// Tests if fetching a transaction by an existing ID returns the correct transaction.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetTransactionById_ReturnsCorrectTransaction()
        {
            // Arrange
            var expectedTransactionDto = _mapper.Map<TransactionDto>(TransactionSeeds.TransactionAdminFood);

            // Act
            var fetchedTransactionDto = await _unitOfWork.Transactions.GetByIdAsync(expectedTransactionDto.Id);

            // Assert
            Assert.NotNull(fetchedTransactionDto);
            DeepAssert.Equal(expectedTransactionDto, fetchedTransactionDto);
        }

        /// <summary>
        /// Tests if updating a transaction with valid data correctly updates the transaction in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateTransaction_UpdatesTransactionInDatabase()
        {
            // Arrange
            var existingTransactionDto = _mapper.Map<TransactionDto>(TransactionSeeds.TransactionAdminFood);

            var updatedTransactionDto = existingTransactionDto with
            {
                Amount = 500m,
                Description = "Updated Transaction",
                Type = 2
            };

            // Act
            await _unitOfWork.Transactions.UpdateAsync(updatedTransactionDto);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var resultTransactionDto = await _unitOfWork.Transactions.GetByIdAsync(updatedTransactionDto.Id);
            Assert.NotNull(resultTransactionDto);
            DeepAssert.Equal(updatedTransactionDto, resultTransactionDto);
        }

        /// <summary>
        /// Tests if deleting a transaction by an existing ID correctly removes the transaction from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteTransaction_RemovesTransactionFromDatabase()
        {
            // Arrange
            var transactionDto = _mapper.Map<TransactionDto>(TransactionSeeds.TransactionAdminFood);

            // Act
            await _unitOfWork.Transactions.DeleteAsync(transactionDto.Id);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var deletedTransaction = await _unitOfWork.Transactions.GetByIdAsync(transactionDto.Id);
            Assert.Null(deletedTransaction);
        }
    }
}
