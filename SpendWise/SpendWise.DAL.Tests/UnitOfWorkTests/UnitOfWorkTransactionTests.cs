using Xunit;
using Xunit.Abstractions;
using SpendWise.DAL.DTOs;
using Microsoft.EntityFrameworkCore;
using SpendWise.Common.Tests.Seeds;
using SpendWise.Common.Tests.Helpers;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;

namespace SpendWise.DAL.Tests.UnitOfWorkTests
{
    /// <summary>
    /// Contains tests for operations related to transactions using the Unit of Work pattern.
    /// </summary>
    public class UnitOfWorkTransactionTests : UnitOfWorkTestsBase
    {
        public UnitOfWorkTransactionTests(ITestOutputHelper output) : base(output)
        {
        }

        #region CRUD Operations Tests

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
                Type = 1,
                CategoryId = null // Optional, depending on your business logic
            };

            // Act
            await _unitOfWork.Repository<TransactionEntity, TransactionDto>().InsertAsync(transactionToAdd);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var actualTransaction = await _unitOfWork.Repository<TransactionEntity, TransactionDto>().GetByIdAsync(transactionToAdd.Id);
            Assert.NotNull(actualTransaction);
            DeepAssert.Equal(transactionToAdd, actualTransaction);
        }

        [Fact]
        public async Task FetchTransactionById_ExistingId_ReturnsExpectedTransaction()
        {
            // Arrange
            var expectedTransaction = _mapper.Map<TransactionDto>(TransactionSeeds.TransactionDianaDinner);

            // Act
            var actualTransaction = await _unitOfWork.Repository<TransactionEntity, TransactionDto>().GetByIdAsync(expectedTransaction.Id);

            // Assert
            Assert.NotNull(actualTransaction);
            DeepAssert.Equal(expectedTransaction, actualTransaction);
        }

        [Fact]
        public async Task UpdateTransaction_ValidData_SuccessfullyPersistsChanges()
        {
            // Arrange
            var existingTransaction = _mapper.Map<TransactionDto>(TransactionSeeds.TransactionDianaDinner);
            var updatedTransaction = existingTransaction with
            {
                Amount = 500m,
                Description = "Updated Transaction",
                Type = 2
            };

            // Act
            await _unitOfWork.Repository<TransactionEntity, TransactionDto>().UpdateAsync(updatedTransaction);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var actualUpdatedTransaction = await _unitOfWork.Repository<TransactionEntity, TransactionDto>().GetByIdAsync(updatedTransaction.Id);
            Assert.NotNull(actualUpdatedTransaction);
            DeepAssert.Equal(updatedTransaction, actualUpdatedTransaction);
        }

        [Fact]
        public async Task DeleteTransaction_ExistingId_SuccessfullyRemovesTransaction()
        {
            // Arrange
            var transactionToDelete = _mapper.Map<TransactionDto>(TransactionSeeds.TransactionDianaDinner);

            // Act
            await _unitOfWork.Repository<TransactionEntity, TransactionDto>().DeleteAsync(transactionToDelete.Id);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var deletedTransaction = await _unitOfWork.Repository<TransactionEntity, TransactionDto>().GetByIdAsync(transactionToDelete.Id);
            Assert.Null(deletedTransaction);
        }

        #endregion
    }
}
