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
    /// Contains tests for operations related to transaction-group-user relationships using the
    /// Unit of Work pattern.
    /// </summary>
    public class UnitOfWorkTransactionGroupUserTests : UnitOfWorkTestsBase
    {
        public UnitOfWorkTransactionGroupUserTests(ITestOutputHelper output) : base(output)
        {
        }

        #region CRUD Operations Tests

        [Fact]
        public async Task AddTransactionGroupUser_ValidData_SuccessfullyPersists()
        {
            // Arrange
            var transactionGroupUserToAdd = new TransactionGroupUserDto
            {
                Id = Guid.NewGuid(),
                TransactionId = TransactionSeeds.TransactionJohnTaxi.Id,
                GroupUserId = GroupUserSeeds.GroupUserJohnInWork.Id
            };

            // Act
            await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().InsertAsync(transactionGroupUserToAdd);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var actualTransactionGroupUser = await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().GetByIdAsync(transactionGroupUserToAdd.Id);
            Assert.NotNull(actualTransactionGroupUser);
            DeepAssert.Equal(transactionGroupUserToAdd, actualTransactionGroupUser);
        }

        [Fact]
        public async Task FetchTransactionGroupUserById_ExistingId_ReturnsExpectedTransactionGroupUser()
        {
            // Arrange
            var expectedTransactionGroupUser = _mapper.Map<TransactionGroupUserDto>(TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana);

            // Act
            var actualTransactionGroupUser = await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().GetByIdAsync(expectedTransactionGroupUser.Id);

            // Assert
            Assert.NotNull(actualTransactionGroupUser);
            DeepAssert.Equal(expectedTransactionGroupUser, actualTransactionGroupUser);
        }

        [Fact]
        public async Task UpdateTransactionGroupUser_ValidData_SuccessfullyPersistsChanges()
        {
            // Arrange
            var existingTransactionGroupUser = _mapper.Map<TransactionGroupUserDto>(TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana);
            var updatedTransactionGroupUser = new TransactionGroupUserDto
            {
                Id = existingTransactionGroupUser.Id,
                TransactionId = TransactionSeeds.TransactionJohnTaxi.Id,
                GroupUserId = GroupUserSeeds.GroupUserJohnInWork.Id
            };

            // Act
            await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().UpdateAsync(updatedTransactionGroupUser);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var actualTransactionGroupUser = await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().GetByIdAsync(updatedTransactionGroupUser.Id);
            Assert.NotNull(actualTransactionGroupUser);
            DeepAssert.Equal(updatedTransactionGroupUser, actualTransactionGroupUser);
        }

        [Fact]
        public async Task DeleteTransactionGroupUser_ExistingId_SuccessfullyRemovesTransactionGroupUser()
        {
            // Arrange
            var transactionGroupUserToDelete = _mapper.Map<TransactionGroupUserDto>(TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana);

            // Act
            await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().DeleteAsync(transactionGroupUserToDelete.Id);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var deletedTransactionGroupUser = await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().GetByIdAsync(transactionGroupUserToDelete.Id);
            Assert.Null(deletedTransactionGroupUser);
        }

        #endregion
    }
}
