using Xunit;
using Xunit.Abstractions;
using SpendWise.DAL.DTOs;
using SpendWise.Common.Tests.Seeds;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;
using SpendWise.Common.Tests.Helpers;


namespace SpendWise.DAL.Tests.QueryObjectTests
{
    public class TransactionGroupUserQueryObjectTests : UnitOfWorkTestsBase
    {
        public TransactionGroupUserQueryObjectTests(ITestOutputHelper output) : base(output)
        {
        }

        #region IdQuery Tests

        /// <summary>
        /// Verifies that querying a transaction group user by its ID 
        /// returns the correct entry from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithId_ShouldReturnCorrectTransactionGroupUser()
        {
            // Arrange
            var transactionGroupUserId = TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana.Id;
            var queryObject = new TransactionGroupUserQueryObject();

            // Act
            var transactionGroupUsers = await _unitOfWork.TransactionGroupUserRepository
                .ListAsync(queryObject.WithId(transactionGroupUserId));

            // Assert
            Assert.NotNull(transactionGroupUsers);
            Assert.Single(transactionGroupUsers);
            Assert.Equal(transactionGroupUserId, transactionGroupUsers.First().Id);
        }

        /// <summary>
        /// Verifies that querying transaction group users by multiple IDs 
        /// returns the correct entries that match any of the provided IDs.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithId_ShouldReturnCorrectTransactionGroupUsers()
        {
            // Arrange
            var transactionGroupUserId1 = TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana.Id;
            var transactionGroupUserId2 = TransactionGroupUserSeeds.TransactionGroupUserFoodFamilyJohn.Id;
            var queryObject = new TransactionGroupUserQueryObject();

            // Act
            var transactionGroupUsers = await _unitOfWork.TransactionGroupUserRepository
                .ListAsync(queryObject.OrWithId(transactionGroupUserId1).OrWithId(transactionGroupUserId2));

            // Assert
            Assert.NotNull(transactionGroupUsers);
            Assert.All(transactionGroupUsers, tgu => Assert.True(tgu.Id == transactionGroupUserId1 || tgu.Id == transactionGroupUserId2));
        }

        /// <summary>
        /// Verifies that querying transaction group users by ID excludes the entry with the specified ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithId_ShouldReturnCorrectTransactionGroupUsers()
        {
            // Arrange
            var excludedTransactionGroupUserId = TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana.Id;
            var queryObject = new TransactionGroupUserQueryObject();

            // Act
            var transactionGroupUsers = await _unitOfWork.TransactionGroupUserRepository
                .ListAsync(queryObject.NotWithId(excludedTransactionGroupUserId));

            // Assert
            Assert.NotNull(transactionGroupUsers);
            Assert.DoesNotContain(transactionGroupUsers, tgu => tgu.Id == excludedTransactionGroupUserId);
        }

        #endregion

        #region IsReadQuery Tests

        /// <summary>
        /// Verifies that querying transaction group users by IsRead returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task IsRead_ShouldReturnCorrectTransactionGroupUsers()
        {
            // Arrange
            var queryObject = new TransactionGroupUserQueryObject();

            // Act
            var transactionGroupUsers = await _unitOfWork.TransactionGroupUserRepository
                .ListAsync(queryObject.IsRead());

            // Assert
            Assert.NotNull(transactionGroupUsers);
            Assert.All(transactionGroupUsers, tgu => Assert.True(tgu.IsRead));
        }

        /// <summary>
        /// Verifies that querying transaction group users by IsRead using OR returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrIsRead_ShouldReturnCorrectTransactionGroupUsers()
        {
            // Arrange
            var queryObject = new TransactionGroupUserQueryObject();

            // Act
            var transactionGroupUsers = await _unitOfWork.TransactionGroupUserRepository
                .ListAsync(queryObject.OrIsRead());

            // Assert
            Assert.NotNull(transactionGroupUsers);
            Assert.All(transactionGroupUsers, tgu => Assert.True(tgu.IsRead));
        }

        /// <summary>
        /// Verifies that querying transaction group users by IsRead using NOT returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotIsRead_ShouldReturnCorrectTransactionGroupUsers()
        {
            // Arrange
            var queryObject = new TransactionGroupUserQueryObject();

            // Act
            var transactionGroupUsers = await _unitOfWork.TransactionGroupUserRepository
                .ListAsync(queryObject.NotIsRead());

            // Assert
            Assert.NotNull(transactionGroupUsers);
            Assert.All(transactionGroupUsers, tgu => Assert.False(tgu.IsRead));
        }

        /// <summary>
        /// Verifies that querying transaction group users by IsNotRead returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task IsNotRead_ShouldReturnCorrectTransactionGroupUsers()
        {
            // Arrange
            var queryObject = new TransactionGroupUserQueryObject();

            // Act
            var transactionGroupUsers = await _unitOfWork.TransactionGroupUserRepository
                .ListAsync(queryObject.IsNotRead());

            // Assert
            Assert.NotNull(transactionGroupUsers);
            Assert.All(transactionGroupUsers, tgu => Assert.False(tgu.IsRead));
        }

        /// <summary>
        /// Verifies that querying transaction group users by IsNotRead using OR returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrIsNotRead_ShouldReturnCorrectTransactionGroupUsers()
        {
            // Arrange
            var queryObject = new TransactionGroupUserQueryObject();

            // Act
            var transactionGroupUsers = await _unitOfWork.TransactionGroupUserRepository
                .ListAsync(queryObject.OrIsNotRead());

            // Assert
            Assert.NotNull(transactionGroupUsers);
            Assert.All(transactionGroupUsers, tgu => Assert.False(tgu.IsRead));
        }

        /// <summary>
        /// Verifies that querying transaction group users by IsNotRead using NOT returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotIsNotRead_ShouldReturnCorrectTransactionGroupUsers()
        {
            // Arrange
            var queryObject = new TransactionGroupUserQueryObject();

            // Act
            var transactionGroupUsers = await _unitOfWork.TransactionGroupUserRepository
                .ListAsync(queryObject.NotIsNotRead());

            // Assert
            Assert.NotNull(transactionGroupUsers);
            Assert.All(transactionGroupUsers, tgu => Assert.True(tgu.IsRead));
        }

        #endregion

        #region TransactionQuery Tests

        /// <summary>
        /// Verifies that querying transaction group users by transaction ID 
        /// returns all correct entries associated with that transaction.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithTransactionId_ShouldReturnCorrectTransactionGroupUsers()
        {
            // Arrange
            var transactionId = TransactionSeeds.TransactionDianaDinner.Id;
            var queryObject = new TransactionGroupUserQueryObject();

            // Act
            var transactionGroupUsers = await _unitOfWork.TransactionGroupUserRepository
                .ListAsync(queryObject.WithTransaction(transactionId));

            // Assert
            Assert.NotNull(transactionGroupUsers);
            Assert.All(transactionGroupUsers, tgu => Assert.Equal(transactionId, tgu.TransactionId));
        }

        /// <summary>
        /// Verifies that querying transaction group users by multiple transaction IDs 
        /// returns the correct entries that match any of the provided transaction IDs.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithTransactionId_ShouldReturnCorrectTransactionGroupUsers()
        {
            // Arrange
            var transactionId1 = TransactionSeeds.TransactionDianaDinner.Id;
            var transactionId2 = TransactionSeeds.TransactionJohnFood.Id;
            var queryObject = new TransactionGroupUserQueryObject();

            // Act
            var transactionGroupUsers = await _unitOfWork.TransactionGroupUserRepository
                .ListAsync(queryObject.OrWithTransaction(transactionId1).OrWithTransaction(transactionId2));

            // Assert
            Assert.NotNull(transactionGroupUsers);
            Assert.All(transactionGroupUsers, tgu => Assert.True(tgu.TransactionId == transactionId1 || tgu.TransactionId == transactionId2));
        }

        /// <summary>
        /// Verifies that querying transaction group users by transaction ID excludes entries with the specified transaction ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithTransactionId_ShouldReturnCorrectTransactionGroupUsers()
        {
            // Arrange
            var excludedTransactionId = TransactionSeeds.TransactionDianaDinner.Id;
            var queryObject = new TransactionGroupUserQueryObject();

            // Act
            var transactionGroupUsers = await _unitOfWork.TransactionGroupUserRepository
                .ListAsync(queryObject.NotWithTransaction(excludedTransactionId));

            // Assert
            Assert.NotNull(transactionGroupUsers);
            Assert.DoesNotContain(transactionGroupUsers, tgu => tgu.TransactionId == excludedTransactionId);
        }

        #endregion

        #region GroupUserQuery Tests

        /// <summary>
        /// Verifies that querying transaction group users by group user ID 
        /// returns all correct entries associated with that group user.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithGroupUserId_ShouldReturnCorrectTransactionGroupUsers()
        {
            // Arrange
            var groupUserId = GroupUserSeeds.GroupUserDianaInFamily.Id;
            var queryObject = new TransactionGroupUserQueryObject();

            // Act
            var transactionGroupUsers = await _unitOfWork.TransactionGroupUserRepository
                .ListAsync(queryObject.WithGroupUser(groupUserId));

            // Assert
            Assert.NotNull(transactionGroupUsers);
            Assert.All(transactionGroupUsers, tgu => Assert.Equal(groupUserId, tgu.GroupUserId));
        }

        /// <summary>
        /// Verifies that querying transaction group users by multiple group user IDs 
        /// returns the correct entries that match any of the provided group user IDs.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithGroupUserId_ShouldReturnCorrectTransactionGroupUsers()
        {
            // Arrange
            var groupUserId1 = GroupUserSeeds.GroupUserDianaInFamily.Id;
            var groupUserId2 = GroupUserSeeds.GroupUserJohnInFriends.Id;
            var queryObject = new TransactionGroupUserQueryObject();

            // Act
            var transactionGroupUsers = await _unitOfWork.TransactionGroupUserRepository
                .ListAsync(queryObject.OrWithGroupUser(groupUserId1).OrWithGroupUser(groupUserId2));

            // Assert
            Assert.NotNull(transactionGroupUsers);
            Assert.All(transactionGroupUsers, tgu => Assert.True(tgu.GroupUserId == groupUserId1 || tgu.GroupUserId == groupUserId2));
        }

        /// <summary>
        /// Verifies that querying transaction group users by group user ID excludes entries with the specified group user ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithGroupUserId_ShouldReturnCorrectTransactionGroupUsers()
        {
            // Arrange
            var excludedGroupUserId = GroupUserSeeds.GroupUserDianaInFamily.Id;
            var queryObject = new TransactionGroupUserQueryObject();

            // Act
            var transactionGroupUsers = await _unitOfWork.TransactionGroupUserRepository
                .ListAsync(queryObject.NotWithGroupUser(excludedGroupUserId));

            // Assert
            Assert.NotNull(transactionGroupUsers);
            Assert.DoesNotContain(transactionGroupUsers, tgu => tgu.GroupUserId == excludedGroupUserId);
        }

        #endregion

        #region Complex Queries

        /// <summary>
        /// Verifies that querying transaction group users by a combination of 
        /// transaction ID and group user ID using AND and OR operations returns correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithTransactionIdOrGroupUserId_ShouldReturnCorrectTransactionGroupUsers()
        {
            // Arrange
            var transactionId = TransactionSeeds.TransactionDianaDinner.Id;
            var groupUserId = GroupUserSeeds.GroupUserJohnInFamily.Id;
            var queryObject = new TransactionGroupUserQueryObject();

            // Act
            var transactionGroupUsers = await _unitOfWork.TransactionGroupUserRepository
                .ListAsync(queryObject.WithTransaction(transactionId)
                                     .OrWithGroupUser(groupUserId));

            // Assert
            Assert.NotNull(transactionGroupUsers);
            Assert.All(transactionGroupUsers, e =>
            {
                bool isTransactionIdMatch = e.TransactionId == transactionId;
                bool isGroupUserIdMatch = e.GroupUserId == groupUserId;

                Assert.True(isTransactionIdMatch || isGroupUserIdMatch);
            });
        }

        /// <summary>
        /// Verifies that querying transaction group users by a combination of 
        /// group user ID and not with a specific transaction ID returns correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrGroupUserIdNotTransactionId_ShouldReturnCorrectTransactionGroupUsers()
        {
            // Arrange
            var groupUserId = GroupUserSeeds.GroupUserDianaInFamily.Id;
            var excludedTransactionId = TransactionSeeds.TransactionJohnFood.Id; // This transaction should be excluded
            var queryObject = new TransactionGroupUserQueryObject();

            // Act
            var transactionGroupUsers = await _unitOfWork.TransactionGroupUserRepository
                .ListAsync(queryObject.OrWithGroupUser(groupUserId)
                                     .NotWithTransaction(excludedTransactionId));

            // Assert
            Assert.NotNull(transactionGroupUsers);
            Assert.All(transactionGroupUsers, e =>
            {
                bool isGroupUserIdMatch = e.GroupUserId == groupUserId;
                bool isTransactionIdMatch = e.TransactionId == excludedTransactionId;

                Assert.True(isGroupUserIdMatch && !isTransactionIdMatch);
            });
        }

        /// <summary>
        /// Verifies that querying transaction group users by multiple group user IDs
        /// and excluding specific transaction IDs returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrGroupUserIdsNotTransactionIds_ShouldReturnCorrectTransactionGroupUsers()
        {
            // Arrange
            var groupUserId1 = GroupUserSeeds.GroupUserDianaInFamily.Id;
            var groupUserId2 = GroupUserSeeds.GroupUserJohnInFriends.Id;
            var excludedTransactionId1 = TransactionSeeds.TransactionDianaDinner.Id; // Exclude this one
            var excludedTransactionId2 = TransactionSeeds.TransactionJohnFood.Id; // Exclude this one
            var queryObject = new TransactionGroupUserQueryObject();

            // Act
            var transactionGroupUsers = await _unitOfWork.TransactionGroupUserRepository
                .ListAsync(queryObject.OrWithGroupUser(groupUserId1)
                                     .OrWithGroupUser(groupUserId2)
                                     .NotWithTransaction(excludedTransactionId1)
                                     .NotWithTransaction(excludedTransactionId2));

            // Assert
            Assert.NotNull(transactionGroupUsers);
            Assert.All(transactionGroupUsers, e =>
            {
                bool isGroupUserId1Match = e.GroupUserId == groupUserId1;
                bool isGroupUserId2Match = e.GroupUserId == groupUserId2;
                bool isTransactionId1Match = e.TransactionId == excludedTransactionId1;
                bool isTransactionId2Match = e.TransactionId == excludedTransactionId2;

                Assert.True((isGroupUserId1Match || isGroupUserId2Match) && !isTransactionId1Match && !isTransactionId2Match);
            });
        }

        #endregion
    }
}