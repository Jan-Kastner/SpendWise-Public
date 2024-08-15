using Xunit.Abstractions;
using SpendWise.DAL.DTOs;
using SpendWise.Common.Tests.Seeds;
using SpendWise.Common.Tests.Helpers;

namespace SpendWise.DAL.Tests
{
    /// <summary>
    /// Contains tests for operations related to transaction-group-user relationships using the
    /// Unit of Work pattern.
    /// </summary>
    public class UnitOfWorkTransactionGroupUserTests : UnitOfWorkTestsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkTransactionGroupUserTests"/> class.
        /// </summary>
        /// <param name="output">The output helper instance.</param>
        public UnitOfWorkTransactionGroupUserTests(ITestOutputHelper output) : base(output)
        {
        }

        // ====================================
        // CRUD Operations Tests
        // ====================================

        /// <summary>
        /// Tests if inserting a new transaction-group-user relationship with valid data correctly adds the relationship to the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task InsertTransactionGroupUser_AddsTransactionGroupUserToDatabase()
        {
            // Arrange
            var newTransactionGroupUserDto = new TransactionGroupUserDto
            {
                Id = Guid.NewGuid(),
                TransactionId = TransactionSeeds.TransactionMinus26Hours.Id,
                GroupUserId = GroupUserSeeds.GroupUserJohnDoeInFriends.Id
            };

            // Act
            await _unitOfWork.TransactionGroupUsers.InsertAsync(newTransactionGroupUserDto);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var transactionGroupUserInDb = await _unitOfWork.TransactionGroupUsers.GetByIdAsync(newTransactionGroupUserDto.Id);
            Assert.NotNull(transactionGroupUserInDb);
            DeepAssert.Equal(newTransactionGroupUserDto, transactionGroupUserInDb);
        }

        /// <summary>
        /// Tests if fetching a transaction-group-user relationship by an existing ID returns the correct relationship.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetTransactionGroupUserById_ReturnsCorrectTransactionGroupUser()
        {
            // Arrange
            var expectedTransactionGroupUserDto = _mapper.Map<TransactionGroupUserDto>(TransactionGroupUserSeeds.TransactionGroupUserJohnDoeInFriendsForJohnDoeTransport);

            // Act
            var fetchedTransactionGroupUserDto = await _unitOfWork.TransactionGroupUsers.GetByIdAsync(expectedTransactionGroupUserDto.Id);

            // Assert
            Assert.NotNull(fetchedTransactionGroupUserDto);
            DeepAssert.Equal(expectedTransactionGroupUserDto, fetchedTransactionGroupUserDto);
        }

        /// <summary>
        /// Tests if updating a transaction-group-user relationship with valid data correctly updates the relationship in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateTransactionGroupUser_UpdatesTransactionGroupUserInDatabase()
        {
            // Arrange
            var existingTransactionGroupUserDto = _mapper.Map<TransactionGroupUserDto>(TransactionGroupUserSeeds.TransactionGroupUserJohnDoeInFamilyForJohnDoeTransport);

            var updatedTransactionGroupUserDto = new TransactionGroupUserDto
            {
                Id = existingTransactionGroupUserDto.Id,
                TransactionId = TransactionSeeds.TransactionMinus26Hours.Id,
                GroupUserId = GroupUserSeeds.GroupUserJohnDoeInFriends.Id
            };

            // Act
            await _unitOfWork.TransactionGroupUsers.UpdateAsync(updatedTransactionGroupUserDto);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var resultTransactionGroupUserDto = await _unitOfWork.TransactionGroupUsers.GetByIdAsync(updatedTransactionGroupUserDto.Id);
            Assert.NotNull(resultTransactionGroupUserDto);
            DeepAssert.Equal(updatedTransactionGroupUserDto, resultTransactionGroupUserDto);
        }

        /// <summary>
        /// Tests if deleting a transaction-group-user relationship by an existing ID correctly removes the relationship from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteTransactionGroupUser_RemovesTransactionGroupUserFromDatabase()
        {
            // Arrange
            var transactionGroupUserDto = _mapper.Map<TransactionGroupUserDto>(TransactionGroupUserSeeds.TransactionGroupUserAdminInFamilyForDelete);

            // Act
            await _unitOfWork.TransactionGroupUsers.DeleteAsync(transactionGroupUserDto.Id);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var deletedTransactionGroupUser = await _unitOfWork.TransactionGroupUsers.GetByIdAsync(transactionGroupUserDto.Id);
            Assert.Null(deletedTransactionGroupUser);
        }
    }
}
