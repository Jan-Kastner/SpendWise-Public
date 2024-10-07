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
    /// Unit tests for CRUD operations on the TransactionGroupUser entity using the Unit of Work pattern.
    /// </summary>
    public class UnitOfWorkTransactionGroupUserTests : UnitOfWorkTestsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkTransactionGroupUserTests"/> class.
        /// </summary>
        /// <param name="output">The test output helper.</param>
        public UnitOfWorkTransactionGroupUserTests(ITestOutputHelper output) : base(output)
        {
        }

        #region CRUD Operations Tests

        /// <summary>
        /// Tests that a TransactionGroupUser with valid data is added and persisted successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddTransactionGroupUser_ValidData_SuccessfullyPersists()
        {
            var transactionGroupUserToAdd = new TransactionGroupUserDto
            {
                Id = Guid.NewGuid(),
                IsRead = false,
                TransactionId = TransactionSeeds.TransactionJohnTaxi.Id,
                GroupUserId = GroupUserSeeds.GroupUserJohnInWork.Id
            };

            await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().InsertAsync(transactionGroupUserToAdd);
            await _unitOfWork.SaveChangesAsync();

            var actualTransactionGroupUser = await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().GetByIdAsync(transactionGroupUserToAdd.Id);
            Assert.NotNull(actualTransactionGroupUser);
            DeepAssert.Equal(transactionGroupUserToAdd, actualTransactionGroupUser);
        }

        /// <summary>
        /// Tests that fetching a TransactionGroupUser by its ID returns the expected TransactionGroupUser.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchTransactionGroupUserById_ExistingId_ReturnsExpectedTransactionGroupUser()
        {
            var expectedTransactionGroupUser = _mapper.Map<TransactionGroupUserDto>(TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana);

            var actualTransactionGroupUser = await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().GetByIdAsync(expectedTransactionGroupUser.Id);

            Assert.NotNull(actualTransactionGroupUser);
            DeepAssert.Equal(expectedTransactionGroupUser, actualTransactionGroupUser);
        }

        /// <summary>
        /// Tests that updating a TransactionGroupUser with valid data persists the changes successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateTransactionGroupUser_ValidData_SuccessfullyPersistsChanges()
        {
            var existingTransactionGroupUser = _mapper.Map<TransactionGroupUserDto>(TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana);
            var updatedTransactionGroupUser = new TransactionGroupUserDto
            {
                Id = existingTransactionGroupUser.Id,
                IsRead = false,
                TransactionId = existingTransactionGroupUser.TransactionId,
                GroupUserId = existingTransactionGroupUser.GroupUserId
            };

            await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().UpdateAsync(updatedTransactionGroupUser);
            await _unitOfWork.SaveChangesAsync();

            var actualTransactionGroupUser = await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().GetByIdAsync(updatedTransactionGroupUser.Id);
            Assert.NotNull(actualTransactionGroupUser);
            DeepAssert.Equal(updatedTransactionGroupUser, actualTransactionGroupUser);
        }

        /// <summary>
        /// Tests that deleting a TransactionGroupUser with an existing ID removes the TransactionGroupUser successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteTransactionGroupUser_ExistingId_SuccessfullyRemovesTransactionGroupUser()
        {
            var transactionGroupUserToDelete = _mapper.Map<TransactionGroupUserDto>(TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana);

            await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().DeleteAsync(transactionGroupUserToDelete.Id);
            await _unitOfWork.SaveChangesAsync();

            var deletedTransactionGroupUser = await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().GetByIdAsync(transactionGroupUserToDelete.Id);
            Assert.Null(deletedTransactionGroupUser);
        }

        #endregion

        #region Error Handling Tests

        /// <summary>
        /// Tests that adding a TransactionGroupUser with an invalid GroupUserId throws a Exception.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddTransactionGroupUser_WithInvalidGroupUserId_ThrowsException()
        {
            var invalidTransactionGroupUser = new TransactionGroupUserDto
            {
                Id = Guid.NewGuid(),
                IsRead = false,
                TransactionId = TransactionSeeds.TransactionJohnTaxi.Id,
                GroupUserId = Guid.NewGuid() // Invalid GroupUserId
            };

            await Assert.ThrowsAsync<Exception>(async () =>
            {
                await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().InsertAsync(invalidTransactionGroupUser);
                await _unitOfWork.SaveChangesAsync();
            });
        }

        /// <summary>
        /// Tests that updating a non-existent TransactionGroupUser throws an Exception.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateTransactionGroupUser_NonExistentTransactionGroupUser_ThrowsException()
        {
            var nonExistentTransactionGroupUser = new TransactionGroupUserDto
            {
                Id = Guid.NewGuid(), // Non-existent ID
                IsRead = false,
                TransactionId = TransactionSeeds.TransactionJohnTaxi.Id,
                GroupUserId = GroupUserSeeds.GroupUserJohnInWork.Id
            };

            await Assert.ThrowsAsync<Exception>(async () =>
            {
                await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().UpdateAsync(nonExistentTransactionGroupUser);
                await _unitOfWork.SaveChangesAsync();
            });
        }

        /// <summary>
        /// Tests that deleting a non-existent TransactionGroupUser throws a Exception.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteTransactionGroupUser_NonExistentTransactionGroupUser_ThrowsException()
        {
            var nonExistentTransactionGroupUserId = Guid.NewGuid(); // Non-existent ID

            await Assert.ThrowsAsync<Exception>(async () =>
            {
                await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().DeleteAsync(nonExistentTransactionGroupUserId);
                await _unitOfWork.SaveChangesAsync();
            });
        }

        #endregion

        #region Update and Special Cases Tests

        /// <summary>
        /// Tests that attempting to change a TransactionGroupUser's TransactionId does not change the TransactionId.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateTransactionGroupUser_ChangeTransactionId_ShouldNotChange()
        {
            var existingTransactionGroupUser = _mapper.Map<TransactionGroupUserDto>(TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana);

            var updatedTransactionGroupUser = existingTransactionGroupUser with
            {
                TransactionId = Guid.NewGuid(), // Attempt to change TransactionId
            };

            await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().UpdateAsync(updatedTransactionGroupUser);
            await _unitOfWork.SaveChangesAsync();

            var actualTransactionGroupUser = await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().GetByIdAsync(existingTransactionGroupUser.Id);
            Assert.NotNull(actualTransactionGroupUser);
            Assert.Equal(existingTransactionGroupUser.TransactionId, actualTransactionGroupUser.TransactionId); // TransactionId should remain unchanged
        }

        /// <summary>
        /// Tests that attempting to change a TransactionGroupUser's GroupUserId does not change the GroupUserId.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateTransactionGroupUser_ChangeGroupUserId_ShouldNotChange()
        {
            var existingTransactionGroupUser = _mapper.Map<TransactionGroupUserDto>(TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana);

            var updatedTransactionGroupUser = existingTransactionGroupUser with
            {
                GroupUserId = Guid.NewGuid(), // Attempt to change GroupUserId
            };

            await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().UpdateAsync(updatedTransactionGroupUser);
            await _unitOfWork.SaveChangesAsync();

            var actualTransactionGroupUser = await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().GetByIdAsync(existingTransactionGroupUser.Id);
            Assert.NotNull(actualTransactionGroupUser);
            Assert.Equal(existingTransactionGroupUser.GroupUserId, actualTransactionGroupUser.GroupUserId); // GroupUserId should remain unchanged
        }

        /// <summary>
        /// Tests that changing a TransactionGroupUser's IsRead property updates the IsRead property successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateTransactionGroupUser_ChangeIsRead_ShouldUpdate()
        {
            var existingTransactionGroupUser = _mapper.Map<TransactionGroupUserDto>(TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana);

            var updatedTransactionGroupUser = existingTransactionGroupUser with
            {
                IsRead = !existingTransactionGroupUser.IsRead, // Change IsRead property
            };

            await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().UpdateAsync(updatedTransactionGroupUser);
            await _unitOfWork.SaveChangesAsync();

            var actualTransactionGroupUser = await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().GetByIdAsync(existingTransactionGroupUser.Id);
            Assert.NotNull(actualTransactionGroupUser);
            Assert.Equal(updatedTransactionGroupUser.IsRead, actualTransactionGroupUser.IsRead); // IsRead should be updated
        }

        #endregion

        #region Related Entities Handling Tests

        /// <summary>
        /// Tests that deleting a TransactionGroupUser with associated Transaction and GroupUser keeps the Transaction and GroupUser intact.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteTransactionGroupUser_WithAssociatedTransactionAndGroupUser_KeepsTransactionAndGroupUserIntact()
        {
            // Arrange
            var transactionGroupUserToDelete = TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana;

            // Act
            await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().DeleteAsync(transactionGroupUserToDelete.Id);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var transaction = await _unitOfWork.Repository<TransactionEntity, TransactionDto>().GetByIdAsync(transactionGroupUserToDelete.TransactionId);
            Assert.NotNull(transaction);
            Assert.Equal(transactionGroupUserToDelete.TransactionId, transaction.Id);

            var groupUser = await _unitOfWork.Repository<GroupUserEntity, GroupUserDto>().GetByIdAsync(transactionGroupUserToDelete.GroupUserId);
            Assert.NotNull(groupUser);
            Assert.Equal(transactionGroupUserToDelete.GroupUserId, groupUser.Id);
        }

        #endregion

        #region Consistency Tests

        /// <summary>
        /// Tests that after multiple TransactionGroupUser operations (insert, update, delete), the final state is consistent.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task TransactionalConsistency_AfterMultipleTransactionGroupUserOperations()
        {
            // Arrange
            var newTransactionGroupUserDto = new TransactionGroupUserDto
            {
                Id = Guid.NewGuid(),
                IsRead = false,
                TransactionId = TransactionSeeds.TransactionJohnTaxi.Id,
                GroupUserId = GroupUserSeeds.GroupUserJohnInWork.Id
            };

            var updatedTransactionGroupUserDto = new TransactionGroupUserDto
            {
                Id = newTransactionGroupUserDto.Id,
                IsRead = true,
                TransactionId = newTransactionGroupUserDto.TransactionId,
                GroupUserId = newTransactionGroupUserDto.GroupUserId,
            };

            try
            {
                // Act
                // Insert
                await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().InsertAsync(newTransactionGroupUserDto);
                await _unitOfWork.SaveChangesAsync();

                // Update
                await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().UpdateAsync(updatedTransactionGroupUserDto);
                await _unitOfWork.SaveChangesAsync();

                // Delete
                await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().DeleteAsync(newTransactionGroupUserDto.Id);
                await _unitOfWork.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            // Assert
            var deletedTransactionGroupUser = await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>().GetByIdAsync(newTransactionGroupUserDto.Id);
            Assert.Null(deletedTransactionGroupUser);
        }

        #endregion
    }
}