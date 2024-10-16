using Xunit.Abstractions;
using SpendWise.DAL.DTOs;
using SpendWise.Common.Tests.Seeds;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;
using SpendWise.Common.Tests.Helpers;
using SpendWise.Common.Enums;

namespace SpendWise.DAL.Tests.QueryObjectTests
{
    public class GroupUserQueryObjectTests : UnitOfWorkTestsBase
    {
        public GroupUserQueryObjectTests(ITestOutputHelper output) : base(output)
        {
        }

        #region IdQuery Tests

        /// <summary>
        /// Verifies that querying a group user by its ID 
        /// returns the correct entry from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithId_ShouldReturnCorrectGroupUser()
        {
            // Arrange
            var groupUserId = GroupUserSeeds.GroupUserBobInFamily.Id;
            var queryObject = new GroupUserQueryObject();

            // Act
            var groupUsers = await _unitOfWork.GroupUserRepository
                .ListAsync(queryObject.WithId(groupUserId));

            // Assert
            Assert.NotNull(groupUsers);
            Assert.Single(groupUsers);
            Assert.Equal(groupUserId, groupUsers.First().Id);
        }

        /// <summary>
        /// Verifies that querying group users by multiple IDs 
        /// returns all correct entries associated with those IDs.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithId_ShouldReturnCorrectGroupUsers()
        {
            // Arrange
            var groupUserId1 = GroupUserSeeds.GroupUserBobInFamily.Id;
            var groupUserId2 = GroupUserSeeds.GroupUserCharlieInFamily.Id;
            var queryObject = new GroupUserQueryObject();

            // Act
            var groupUsers = await _unitOfWork.GroupUserRepository
                .ListAsync(queryObject.OrWithId(groupUserId1).OrWithId(groupUserId2));

            // Assert
            Assert.NotNull(groupUsers);
            Assert.All(groupUsers, gu => Assert.True(gu.Id == groupUserId1 || gu.Id == groupUserId2));
        }

        /// <summary>
        /// Verifies that querying group users excluding a specific ID 
        /// does not return the entry with that ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithId_ShouldExcludeGroupUser()
        {
            // Arrange
            var excludedGroupUserId = GroupUserSeeds.GroupUserBobInFamily.Id;
            var queryObject = new GroupUserQueryObject();

            // Act
            var groupUsers = await _unitOfWork.GroupUserRepository
                .ListAsync(queryObject.NotWithId(excludedGroupUserId));

            // Assert
            Assert.NotNull(groupUsers);
            Assert.DoesNotContain(groupUsers, gu => gu.Id == excludedGroupUserId);
        }

        #endregion

        #region RoleQuery Tests

        /// <summary>
        /// Verifies that querying a user by their role returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithUserRole_ShouldReturnCorrectUsers()
        {
            // Arrange
            var userRole = UserRole.GroupFounder;
            var queryObject = new GroupUserQueryObject();

            // Act
            var groupUsers = await _unitOfWork.GroupUserRepository
                .ListAsync(queryObject.WithUserRole(userRole));

            // Assert
            Assert.NotNull(groupUsers);
            Assert.All(groupUsers, gu => Assert.Equal(userRole, gu.Role));
        }

        /// <summary>
        /// Verifies that querying a user by multiple roles returns the correct entries that match any of the provided roles.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithUserRole_ShouldReturnCorrectUsers()
        {
            // Arrange
            var userRole1 = UserRole.GroupFounder;
            var userRole2 = UserRole.GroupCoordinator;
            var queryObject = new GroupUserQueryObject();

            // Act
            var groupUsers = await _unitOfWork.GroupUserRepository
                .ListAsync(queryObject.OrWithUserRole(userRole1).OrWithUserRole(userRole2));

            // Assert
            Assert.NotNull(groupUsers);
            Assert.All(groupUsers, gu => Assert.True(gu.Role == userRole1 || gu.Role == userRole2));
        }

        /// <summary>
        /// Verifies that querying users by excluding a specific role returns entries that do not contain the role.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithUserRole_ShouldReturnCorrectUsers()
        {
            // Arrange
            var excludedRole = UserRole.GroupFounder;
            var queryObject = new GroupUserQueryObject();

            // Act
            var groupUsers = await _unitOfWork.GroupUserRepository
                .ListAsync(queryObject.NotWithUserRole(excludedRole));

            // Assert
            Assert.NotNull(groupUsers);
            Assert.All(groupUsers, gu => Assert.NotEqual(excludedRole, gu.Role));
        }

        #endregion

        #region UserQuery Tests


        /// <summary>
        /// Verifies that querying group users by user ID 
        /// returns all correct entries associated with that user ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithUser_ShouldReturnCorrectGroupUsers()
        {
            // Arrange
            var userId = UserSeeds.UserBobBrown.Id;
            var queryObject = new GroupUserQueryObject();

            // Act
            var groupUsers = await _unitOfWork.GroupUserRepository
                .ListAsync(queryObject.WithUser(userId));

            // Assert
            Assert.NotNull(groupUsers);
            Assert.All(groupUsers, gu => Assert.Equal(userId, gu.UserId));
        }

        /// <summary>
        /// Verifies that querying group users by multiple user IDs 
        /// returns all correct entries associated with those user IDs.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithUser_ShouldReturnCorrectGroupUsers()
        {
            // Arrange
            var userId1 = UserSeeds.UserBobBrown.Id;
            var userId2 = UserSeeds.UserCharlieBlack.Id;
            var queryObject = new GroupUserQueryObject();

            // Act
            var groupUsers = await _unitOfWork.GroupUserRepository
                .ListAsync(queryObject.OrWithUser(userId1).OrWithUser(userId2));

            // Assert
            Assert.NotNull(groupUsers);
            Assert.All(groupUsers, gu => Assert.True(gu.UserId == userId1 || gu.UserId == userId2));
        }

        /// <summary>
        /// Verifies that querying group users excluding a specific user ID 
        /// does not return entries with that user ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithUser_ShouldExcludeGroupUsers()
        {
            // Arrange
            var excludedUserId = UserSeeds.UserBobBrown.Id;
            var queryObject = new GroupUserQueryObject();

            // Act
            var groupUsers = await _unitOfWork.GroupUserRepository
                .ListAsync(queryObject.NotWithUser(excludedUserId));

            // Assert
            Assert.NotNull(groupUsers);
            Assert.All(groupUsers, gu => Assert.NotEqual(excludedUserId, gu.UserId));
        }

        #endregion

        #region GroupQuery Tests

        /// <summary>
        /// Verifies that querying group users by group ID 
        /// returns all correct entries associated with that group ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithGroup_ShouldReturnCorrectGroupUsers()
        {
            // Arrange
            var groupId = GroupSeeds.GroupFamily.Id;
            var queryObject = new GroupUserQueryObject();

            // Act
            var groupUsers = await _unitOfWork.GroupUserRepository
                .ListAsync(queryObject.WithGroup(groupId));

            // Assert
            Assert.NotNull(groupUsers);
            Assert.All(groupUsers, gu => Assert.Equal(groupId, gu.GroupId));
        }

        /// <summary>
        /// Verifies that querying group users by multiple group IDs 
        /// returns all correct entries associated with those group IDs.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithGroup_ShouldReturnCorrectGroupUsers()
        {
            // Arrange
            var groupId1 = GroupSeeds.GroupFamily.Id;
            var groupId2 = GroupSeeds.GroupFriends.Id;
            var queryObject = new GroupUserQueryObject();

            // Act
            var groupUsers = await _unitOfWork.GroupUserRepository
                .ListAsync(queryObject.OrWithGroup(groupId1).OrWithGroup(groupId2));

            // Assert
            Assert.NotNull(groupUsers);
            Assert.All(groupUsers, gu => Assert.True(gu.GroupId == groupId1 || gu.GroupId == groupId2));
        }

        /// <summary>
        /// Verifies that querying group users excluding a specific group ID 
        /// does not return entries with that group ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithGroup_ShouldExcludeGroupUsers()
        {
            // Arrange
            var excludedGroupId = GroupSeeds.GroupFamily.Id;
            var queryObject = new GroupUserQueryObject();

            // Act
            var groupUsers = await _unitOfWork.GroupUserRepository
                .ListAsync(queryObject.NotWithGroup(excludedGroupId));

            // Assert
            Assert.NotNull(groupUsers);
            Assert.All(groupUsers, gu => Assert.NotEqual(excludedGroupId, gu.GroupId));
        }

        #endregion

        #region LimitQuery Tests

        /// <summary>
        /// Verifies that querying group users by limit ID 
        /// returns all correct entries associated with that limit ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithLimit_ShouldReturnCorrectGroupUsers()
        {
            // Arrange
            var limitId = LimitSeeds.LimitCharlieFamily.Id;
            var queryObject = new GroupUserQueryObject();

            // Act
            var groupUsers = await _unitOfWork.GroupUserRepository
                .ListAsync(queryObject.WithLimit(limitId));

            // Assert
            Assert.NotNull(groupUsers);
            Assert.All(groupUsers, gu => Assert.Equal(limitId, gu.LimitId));
        }

        /// <summary>
        /// Verifies that querying group users by multiple limit IDs 
        /// returns all correct entries associated with those limit IDs.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithLimit_ShouldReturnCorrectGroupUsers()
        {
            // Arrange
            var limitId1 = LimitSeeds.LimitCharlieFamily.Id;
            var limitId2 = LimitSeeds.LimitDianaFamily.Id;
            var queryObject = new GroupUserQueryObject();

            // Act
            var groupUsers = await _unitOfWork.GroupUserRepository
                .ListAsync(queryObject.OrWithLimit(limitId1).OrWithLimit(limitId2));

            // Assert
            Assert.NotNull(groupUsers);
            Assert.All(groupUsers, gu => Assert.True(gu.LimitId == limitId1 || gu.LimitId == limitId2));
        }

        /// <summary>
        /// Verifies that querying group users excluding a specific limit ID
        /// does not return entries with that limit ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithLimit_ShouldExcludeGroupUsers()
        {
            // Arrange
            var excludedLimitId = LimitSeeds.LimitCharlieFamily.Id;
            var queryObject = new GroupUserQueryObject();

            // Act
            var groupUsers = await _unitOfWork.GroupUserRepository
                .ListAsync(queryObject.NotWithLimit(excludedLimitId));

            // Assert
            Assert.NotNull(groupUsers);
            Assert.All(groupUsers, gu => Assert.NotEqual(excludedLimitId, gu.LimitId));
        }

        /// <summary>
        /// Verifies that querying group users without any limit ID (null)
        /// returns all correct entries with null limit ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithoutLimit_ShouldReturnGroupUsersWithNullLimitId()
        {
            // Arrange
            var queryObject = new GroupUserQueryObject();

            // Act
            var groupUsers = await _unitOfWork.GroupUserRepository
                .ListAsync(queryObject.WithoutLimit());

            // Assert
            Assert.NotNull(groupUsers);
            Assert.All(groupUsers, gu => Assert.Null(gu.LimitId));
        }

        /// <summary>
        /// Verifies that querying group users with an OR condition for null limit ID
        /// returns all correct entries with null limit ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithoutLimit_ShouldReturnGroupUsersWithNullLimitId()
        {
            // Arrange
            var queryObject = new GroupUserQueryObject();

            // Act
            var groupUsers = await _unitOfWork.GroupUserRepository
                .ListAsync(queryObject.OrWithoutLimit());

            // Assert
            Assert.NotNull(groupUsers);
            Assert.All(groupUsers, gu => Assert.Null(gu.LimitId));
        }

        /// <summary>
        /// Verifies that querying group users excluding null limit ID
        /// does not return entries with null limit ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithoutLimit_ShouldExcludeGroupUsersWithNullLimitId()
        {
            // Arrange
            var queryObject = new GroupUserQueryObject();

            // Act
            var groupUsers = await _unitOfWork.GroupUserRepository
                .ListAsync(queryObject.WithoutLimit());

            // Assert
            Assert.NotNull(groupUsers);
            Assert.All(groupUsers, gu => Assert.Null(gu.LimitId));
        }

        #endregion

        #region TransactionGroupUserQuery Tests

        /// <summary>
        /// Verifies that querying group users by transaction group user ID 
        /// returns all correct entries associated with that transaction group user ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithTransactionGroupUser_ShouldReturnCorrectGroupUsers()
        {
            // Arrange
            var transactionGroupUser = TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana;
            var queryObject = new GroupUserQueryObject();

            // Act
            var groupUsers = await _unitOfWork.GroupUserRepository
                .ListAsync(queryObject.WithTransactionGroupUser(transactionGroupUser.Id));

            // Assert
            Assert.NotNull(groupUsers);
            Assert.All(groupUsers, gu => Assert.Equal(transactionGroupUser.GroupUserId, gu.Id));
        }

        /// <summary>
        /// Verifies that querying group users by multiple transaction group user IDs 
        /// returns all correct entries associated with those transaction group user IDs.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithTransactionGroupUser_ShouldReturnCorrectGroupUsers()
        {
            // Arrange
            var transactionGroupUser1 = TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana;
            var transactionGroupUser2 = TransactionGroupUserSeeds.TransactionGroupUserFoodFamilyJohn;
            var queryObject = new GroupUserQueryObject();

            // Act
            var groupUsers = await _unitOfWork.GroupUserRepository
                .ListAsync(queryObject.OrWithTransactionGroupUser(transactionGroupUser1.Id).OrWithTransactionGroupUser(transactionGroupUser2.Id));

            // Assert
            Assert.NotNull(groupUsers);
            Assert.All(groupUsers, gu =>
            {
                Assert.True(gu.Id == transactionGroupUser1.GroupUserId || gu.Id == transactionGroupUser2.GroupUserId);
            });
        }

        /// <summary>
        /// Verifies that querying group users excluding a specific transaction group user ID
        /// does not return entries with that transaction group user ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithTransactionGroupUser_ShouldExcludeGroupUsers()
        {
            // Arrange
            var excludedTransactionGroupUser = TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana;
            var queryObject = new GroupUserQueryObject();

            // Act
            var groupUsers = await _unitOfWork.GroupUserRepository
                .ListAsync(queryObject.NotWithTransactionGroupUser(excludedTransactionGroupUser.Id));

            // Assert
            Assert.NotNull(groupUsers);
            Assert.DoesNotContain(groupUsers, gu => gu.Id == excludedTransactionGroupUser.GroupUserId);
        }

        #endregion

        #region Complex Tests

        /// <summary>
        /// Verifies that querying group users by multiple conditions
        /// returns all correct entries that satisfy those conditions.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithUserWithGroupWithLimitAndWithTransactionGroupUser_ShouldReturnCorrectGroupUsers()
        {
            // Arrange
            var userId = UserSeeds.UserDianaGreen.Id;
            var groupId = GroupSeeds.GroupFamily.Id;
            var limitId = LimitSeeds.LimitDianaFamily.Id;
            var transactionGroupUser = TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana;
            var queryObject = new GroupUserQueryObject();

            // Act
            var groupUsers = await _unitOfWork.GroupUserRepository
                .ListAsync(queryObject.WithUser(userId)
                    .WithGroup(groupId)
                    .WithLimit(limitId)
                    .WithTransactionGroupUser(transactionGroupUser.Id));

            // Assert
            Assert.NotNull(groupUsers);
            Assert.Single(groupUsers);
            Assert.All(groupUsers, gu =>
            {
                Assert.Equal(userId, gu.UserId);
                Assert.Equal(groupId, gu.GroupId);
                Assert.Equal(limitId, gu.LimitId);
                Assert.Equal(transactionGroupUser.GroupUserId, gu.Id);
            });
        }

        #endregion
    }
}