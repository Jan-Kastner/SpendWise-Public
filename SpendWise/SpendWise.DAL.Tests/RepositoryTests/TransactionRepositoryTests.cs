using SpendWise.DAL.Entities;
using SpendWise.DAL.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using SpendWise.DAL.Tests.Helpers;
using SpendWise.DAL.DTOs;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace SpendWise.DAL.Tests
{
    /// <summary>
    /// Test class for testing repository methods related to transactions.
    /// </summary>
    public class TransactionRepositoryTests : RepositoryTestsBase
    {
        private readonly IRepository<TransactionEntity, TransactionDto> _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for the <see cref="TransactionRepositoryTests"/> class.
        /// Initializes the instance with necessary services.
        /// </summary>
        /// <param name="output">Provides output capabilities for test methods.</param>
        public TransactionRepositoryTests(ITestOutputHelper output) : base(output)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<TransactionEntity, TransactionDto>>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        /// <summary>
        /// Tests whether inserting a new transaction into the database successfully adds the transaction.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task InsertTransaction_AddsTransactionToDatabase()
        {
            // Arrange
            var newTransactionDto = new TransactionDto
            {
                Id = Guid.NewGuid(),
                Amount = 200.0m,
                Date = DateTime.UtcNow,
                Description = "Test Transaction",
                Type = 1,
                CategoryId = CategorySeeds.CategoryFood.Id
            };

            // Act
            var insertedTransactionDto = await _repository.InsertAsync(newTransactionDto);

            // Assert
            Assert.NotNull(insertedTransactionDto);
            DeepAssert.Equal(newTransactionDto, insertedTransactionDto);
        }

        /// <summary>
        /// Tests whether retrieving a transaction by its ID returns the correct transaction.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetTransactionById_ReturnsCorrectTransaction()
        {
            // Arrange
            var expectedTransactionDto = _mapper.Map<TransactionDto>(TransactionSeeds.TransactionAdminFood);
            // Act
            var fetchedTransactionDto = await _repository.GetByIdAsync(expectedTransactionDto.Id);

            // Assert
            Assert.NotNull(expectedTransactionDto);
            DeepAssert.Equal(expectedTransactionDto, fetchedTransactionDto);
        }

        /// <summary>
        /// Tests whether updating a transaction in the database successfully updates the existing transaction.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateTransaction_UpdatesTransactionInDatabase()
        {
            // Arrange
            var existingTransactionDto = _mapper.Map<TransactionDto>(TransactionSeeds.TransactionAdminFood);

            var updatedTransactionDto = new TransactionDto
            {
                Id = existingTransactionDto.Id,
                Amount = 250.0m,
                Date = DateTime.UtcNow,
                Description = "Updated Transaction",
                Type = 2,
                CategoryId = CategorySeeds.CategoryTransport.Id
            };

            // Act
            var resultTransactionDto = await _repository.UpdateAsync(updatedTransactionDto);

            // Assert
            Assert.NotNull(resultTransactionDto);
            DeepAssert.Equal(updatedTransactionDto, resultTransactionDto);
            Assert.Equal(existingTransactionDto.Id, resultTransactionDto.Id);
        }

        /// <summary>
        /// Tests whether deleting a transaction from the database successfully removes the existing transaction.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteTransaction_RemovesTransactionFromDatabase()
        {
            // Arrange
            var transactionDto = _mapper.Map<TransactionDto>(TransactionSeeds.TransactionDelete);

            // Act
            await _repository.DeleteAsync(transactionDto.Id);
            var deletedTransaction = await _repository.GetByIdAsync(transactionDto.Id);

            // Assert
            Assert.Null(deletedTransaction);

            var totalCountAfterDelete = await _repository.Get().CountAsync();
            var totalCountBeforeDelete = totalCountAfterDelete + 1;
            Assert.Equal(totalCountBeforeDelete, totalCountAfterDelete + 1);
        }
    }
}
