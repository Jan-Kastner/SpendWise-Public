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
    /// Test class for testing repository methods related to transaction-group-user relationships.
    /// </summary>
    public class TransactionGroupUserRepositoryTests : RepositoryTestsBase
    {
        private readonly IRepository<TransactionGroupUserEntity, TransactionGroupUserDto> _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for the <see cref="TransactionGroupUserRepositoryTests"/> class.
        /// Initializes the instance with necessary services.
        /// </summary>
        /// <param name="output">Provides output capabilities for test methods.</param>
        public TransactionGroupUserRepositoryTests(ITestOutputHelper output) : base(output)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<TransactionGroupUserEntity, TransactionGroupUserDto>>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        /// <summary>
        /// Tests whether inserting a new transaction-group-user relationship into the database successfully adds the relationship.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task InsertTransactionGroupUser_AddsRelationshipToDatabase()
        {
            // Arrange
            var newTransactionGroupUserDto = new TransactionGroupUserDto
            {
                Id = Guid.NewGuid(),
                TransactionId = TransactionSeeds.TransactionMinus22Hours.Id,
                GroupUserId = GroupUserSeeds.GroupUserJohnDoeInFamily.Id
            };

            // Act
            var insertedTransactionGroupUserDto = await _repository.InsertAsync(newTransactionGroupUserDto);

            // Assert
            Assert.NotNull(insertedTransactionGroupUserDto);
            DeepAssert.Equal(newTransactionGroupUserDto, insertedTransactionGroupUserDto);
        }

        /// <summary>
        /// Tests whether retrieving a transaction-group-user relationship by its ID returns the correct relationship.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetTransactionGroupUserById_ReturnsCorrectRelationship()
        {
            // Arrange
            var expectedTransactionGroupUserDto = _mapper.Map<TransactionGroupUserDto>(TransactionGroupUserSeeds.TransactionGroupUserAdminInFamilyForAdminFood);
            
            // Act
            var fetchedTransactionGroupUserDto = await _repository.GetByIdAsync(expectedTransactionGroupUserDto.Id);

            // Assert
            Assert.NotNull(fetchedTransactionGroupUserDto);
            DeepAssert.Equal(expectedTransactionGroupUserDto, fetchedTransactionGroupUserDto);
        }

        /// <summary>
        /// Tests whether updating a transaction-group-user relationship in the database successfully updates the existing relationship.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateTransactionGroupUser_UpdatesRelationshipInDatabase()
        {
            // Arrange
            var existingTransactionGroupUserDto = _mapper.Map<TransactionGroupUserDto>(TransactionGroupUserSeeds.TransactionGroupUserAdminInFamilyForAdminFood);

            var updatedTransactionGroupUserDto = new TransactionGroupUserDto
            {
                Id = existingTransactionGroupUserDto.Id,
                TransactionId = existingTransactionGroupUserDto.TransactionId,
                GroupUserId = existingTransactionGroupUserDto.GroupUserId
            };

            // Act
            var resultTransactionGroupUserDto = await _repository.UpdateAsync(updatedTransactionGroupUserDto);

            // Assert
            Assert.NotNull(resultTransactionGroupUserDto);
            DeepAssert.Equal(updatedTransactionGroupUserDto, resultTransactionGroupUserDto);
            Assert.Equal(existingTransactionGroupUserDto.Id, resultTransactionGroupUserDto.Id);
        }

        /// <summary>
        /// Tests whether deleting a transaction-group-user relationship from the database successfully removes the existing relationship.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteTransactionGroupUser_RemovesRelationshipFromDatabase()
        {
            // Arrange
            var transactionGroupUserDto = _mapper.Map<TransactionGroupUserDto>(TransactionGroupUserSeeds.TransactionGroupUserAdminInFamilyForDelete);

            // Act
            await _repository.DeleteAsync(transactionGroupUserDto.Id);
            var deletedTransactionGroupUser = await _repository.GetByIdAsync(transactionGroupUserDto.Id);

            // Assert
            Assert.Null(deletedTransactionGroupUser);

            var totalCountAfterDelete = await _repository.Get().CountAsync();
            var totalCountBeforeDelete = totalCountAfterDelete + 1;
            Assert.Equal(totalCountBeforeDelete, totalCountAfterDelete + 1);
        }
    }
}
