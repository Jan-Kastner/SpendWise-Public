
using Xunit;
using Xunit.Abstractions;
using SpendWise.DAL.DTOs;
using SpendWise.Common.Tests.Seeds;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;
using SpendWise.Common.Tests.Helpers;
using SpendWise.Common.Enums;

namespace SpendWise.DAL.Tests.QueryObjectTests
{
    public class LimitQueryObjectTests : UnitOfWorkTestsBase
    {
        public LimitQueryObjectTests(ITestOutputHelper output) : base(output)
        {
        }

        #region IdQuery Tests

        /// <summary>
        /// Verifies that querying a limit by its ID 
        /// returns the correct entry from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithId_ShouldReturnCorrectLimit()
        {
            // Arrange
            var limitId = LimitSeeds.LimitDianaFamily.Id;
            var queryObject = new LimitQueryObject();

            // Act
            var limits = await _unitOfWork.LimitRepository
                .ListAsync(queryObject.WithId(limitId));

            // Assert
            Assert.NotNull(limits);
            Assert.Single(limits);
            Assert.Equal(limitId, limits.First().Id);
        }

        /// <summary>
        /// Verifies that querying limits by multiple IDs 
        /// returns the correct entries that match any of the provided IDs.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithId_ShouldReturnCorrectLimits()
        {
            // Arrange
            var limitId1 = LimitSeeds.LimitCharlieFamily.Id;
            var limitId2 = LimitSeeds.LimitDianaFamily.Id;
            var queryObject = new LimitQueryObject();

            // Act
            var limits = await _unitOfWork.LimitRepository
                .ListAsync(queryObject.OrWithId(limitId1).OrWithId(limitId2));

            // Assert
            Assert.NotNull(limits);
            Assert.All(limits, l => Assert.True(l.Id == limitId1 || l.Id == limitId2));
        }

        /// <summary>
        /// Verifies that querying limits by ID excludes the entry with the specified ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithId_ShouldReturnCorrectLimits()
        {
            // Arrange
            var excludedId = LimitSeeds.LimitDianaFamily.Id;
            var queryObject = new LimitQueryObject();

            // Act
            var limits = await _unitOfWork.LimitRepository
                .ListAsync(queryObject.NotWithId(excludedId));

            // Assert
            Assert.NotNull(limits);
            Assert.DoesNotContain(limits, l => l.Id == excludedId);
        }

        #endregion

        #region GroupUserQuery Tests

        /// <summary>
        /// Verifies that querying limits by group user ID 
        /// returns all correct entries associated with that group user.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithGroupUser_ShouldReturnCorrectLimits()
        {
            // Arrange
            var groupUserId = GroupUserSeeds.GroupUserDianaInFamily.Id;
            var queryObject = new LimitQueryObject();

            // Act
            var limits = await _unitOfWork.LimitRepository
                .ListAsync(queryObject.WithGroupUser(groupUserId));

            // Assert
            Assert.NotNull(limits);
            Assert.All(limits, l => Assert.Equal(groupUserId, l.GroupUserId));
        }

        /// <summary>
        /// Verifies that querying limits by multiple group user IDs 
        /// returns the correct entries that match any of the provided group user IDs.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithGroupUser_ShouldReturnCorrectLimits()
        {
            // Arrange
            var groupUserId1 = GroupUserSeeds.GroupUserCharlieInFamily.Id;
            var groupUserId2 = GroupUserSeeds.GroupUserDianaInFamily.Id;
            var queryObject = new LimitQueryObject();

            // Act
            var limits = await _unitOfWork.LimitRepository
                .ListAsync(queryObject.OrWithGroupUser(groupUserId1).OrWithGroupUser(groupUserId2));

            // Assert
            Assert.NotNull(limits);
            Assert.All(limits, l => Assert.True(l.GroupUserId == groupUserId1 || l.GroupUserId == groupUserId2));
        }

        /// <summary>
        /// Verifies that querying limits by group user ID excludes entries with the specified group user ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithGroupUser_ShouldReturnCorrectLimits()
        {
            // Arrange
            var excludedGroupUserId = GroupUserSeeds.GroupUserDianaInFamily.Id;
            var queryObject = new LimitQueryObject();

            // Act
            var limits = await _unitOfWork.LimitRepository
                .ListAsync(queryObject.NotWithGroupUser(excludedGroupUserId));

            // Assert
            Assert.NotNull(limits);
            Assert.DoesNotContain(limits, l => l.GroupUserId == excludedGroupUserId);
        }

        #endregion

        #region AmountQuery Tests

        /// <summary>
        /// Verifies that querying limits by amount 
        /// returns all correct entries associated with that amount.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithAmount_ShouldReturnCorrectLimits()
        {
            // Arrange
            var limitAmount = LimitSeeds.LimitDianaFamily.Amount;
            var queryObject = new LimitQueryObject();

            // Act
            var limits = await _unitOfWork.LimitRepository
                .ListAsync(queryObject.WithAmountEqual(limitAmount));

            // Assert
            Assert.NotNull(limits);
            Assert.All(limits, l => Assert.Equal(limitAmount, l.Amount));
        }

        /// <summary>
        /// Verifies that querying limits by multiple amounts 
        /// returns the correct entries that match any of the provided amounts.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithAmount_ShouldReturnCorrectLimits()
        {
            // Arrange
            var amount1 = LimitSeeds.LimitCharlieFamily.Amount;
            var amount2 = LimitSeeds.LimitDianaFamily.Amount;
            var queryObject = new LimitQueryObject();

            // Act
            var limits = await _unitOfWork.LimitRepository
                .ListAsync(queryObject.OrWithAmountEqual(amount1).OrWithAmountEqual(amount2));

            // Assert
            Assert.NotNull(limits);
            Assert.All(limits, l => Assert.True(l.Amount == amount1 || l.Amount == amount2));
        }

        /// <summary>
        /// Verifies that querying limits by amount excludes entries with the specified amount.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithAmount_ShouldReturnCorrectLimits()
        {
            // Arrange
            var excludedAmount = LimitSeeds.LimitDianaFamily.Amount;
            var queryObject = new LimitQueryObject();

            // Act
            var limits = await _unitOfWork.LimitRepository
                .ListAsync(queryObject.NotWithAmountEqual(excludedAmount));

            // Assert
            Assert.NotNull(limits);
            Assert.DoesNotContain(limits, l => l.Amount == excludedAmount);
        }

        #endregion

        #region NoticeTypeQuery Tests

        /// <summary>
        /// Verifies that querying limits by notice type 
        /// returns all correct entries associated with that notice type.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithNoticeType_ShouldReturnCorrectLimits()
        {
            // Arrange
            var noticeType = LimitSeeds.LimitDianaFamily.NoticeType;
            var queryObject = new LimitQueryObject();

            // Act
            var limits = await _unitOfWork.LimitRepository
                .ListAsync(queryObject.WithNoticeType(noticeType));

            // Assert
            Assert.NotNull(limits);
            Assert.All(limits, l => Assert.Equal(noticeType, l.NoticeType));
        }

        /// <summary>
        /// Verifies that querying limits by multiple notice types 
        /// returns the correct entries that match any of the provided notice types.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithNoticeType_ShouldReturnCorrectLimits()
        {
            // Arrange
            var noticeType1 = LimitSeeds.LimitCharlieFamily.NoticeType;
            var noticeType2 = LimitSeeds.LimitDianaFamily.NoticeType;
            var queryObject = new LimitQueryObject();

            // Act
            var limits = await _unitOfWork.LimitRepository
                .ListAsync(queryObject.OrWithNoticeType(noticeType1).OrWithNoticeType(noticeType2));

            // Assert
            Assert.NotNull(limits);
            Assert.All(limits, l => Assert.True(l.NoticeType == noticeType1 || l.NoticeType == noticeType2));
        }

        /// <summary>
        /// Verifies that querying limits by notice type excludes entries with the specified notice type.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithNoticeType_ShouldReturnCorrectLimits()
        {
            // Arrange
            var excludedNoticeType = LimitSeeds.LimitDianaFamily.NoticeType;
            var queryObject = new LimitQueryObject();

            // Act
            var limits = await _unitOfWork.LimitRepository
                .ListAsync(queryObject.NotWithNoticeType(excludedNoticeType));

            // Assert
            Assert.NotNull(limits);
            Assert.DoesNotContain(limits, l => l.NoticeType == excludedNoticeType);
        }

        #endregion

        #region Complex Query Tests

        /// <summary>
        /// Verifies that querying limits with a combination of AND, OR, and NOT conditions.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithGroupUserIdOrAmountNotNoticeType_ShouldReturnCorrectLimits()
        {
            // Arrange
            var groupUserId = GroupUserSeeds.GroupUserCharlieInFamily.Id;
            var limitAmount = LimitSeeds.LimitDianaFamily.Amount;
            var excludedNoticeType = NoticeType.InApp; // This notice type should not exist in the seeded data

            var queryObject = new LimitQueryObject();

            // Act
            var limits = await _unitOfWork.LimitRepository
                .ListAsync(
                    queryObject.WithGroupUser(groupUserId) // AND condition
                               .OrWithAmountEqual(limitAmount)    // OR condition
                               .NotWithNoticeType(excludedNoticeType) // NOT condition
                );

            // Assert
            Assert.NotNull(limits);
            Assert.All(limits, l =>
            {
                bool isGroupUserIdMatch = l.GroupUserId == groupUserId;
                bool isLimitAmountMatch = l.Amount == limitAmount;
                bool isNoticeTypeMatch = l.NoticeType == excludedNoticeType;

                Assert.True((isGroupUserIdMatch || isLimitAmountMatch) && !isNoticeTypeMatch);
            });
        }

        /// <summary>
        /// Verifies that querying limits with a combination of multiple AND and OR conditions.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithIdOrIdNotGroupUserId_ShouldReturnCorrectLimits()
        {
            // Arrange
            var limitId1 = LimitSeeds.LimitCharlieFamily.Id;
            var limitId2 = LimitSeeds.LimitDianaFamily.Id;
            var excludedGroupUserId = GroupUserSeeds.GroupUserJohnInWork.Id;
            var queryObject = new LimitQueryObject();

            // Act
            var limits = await _unitOfWork.LimitRepository
                .ListAsync(
                    queryObject.WithId(limitId1) // AND condition
                               .OrWithId(limitId2) // OR condition
                               .NotWithGroupUser(excludedGroupUserId) // NOT condition
                );

            // Assert
            Assert.NotNull(limits);
            Assert.All(limits, l =>
            {
                bool isLimitId1Match = l.Id == limitId1;
                bool isLimitId2Match = l.Id == limitId2;
                bool isGroupUserIdMatch = l.GroupUserId == excludedGroupUserId;

                Assert.True((isLimitId1Match || isLimitId2Match) && !isGroupUserIdMatch);
            });
        }

        /// <summary>
        /// Verifies that querying limits using a mix of AND and OR conditions, while excluding specific IDs.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithAmountOrGroupUserIdNotId_ShouldReturnCorrectLimits()
        {
            // Arrange
            var limitAmount = LimitSeeds.LimitCharlieFamily.Amount;
            var groupUserId = GroupUserSeeds.GroupUserDianaInFamily.Id;
            var excludedLimitId = LimitSeeds.LimitJohnWork.Id; // This entry should be excluded

            var queryObject = new LimitQueryObject();

            // Act
            var limits = await _unitOfWork.LimitRepository
                .ListAsync(
                    queryObject.WithAmountEqual(limitAmount) // AND condition
                               .OrWithGroupUser(groupUserId) // OR condition
                               .NotWithId(excludedLimitId) // NOT condition
                );

            // Assert
            Assert.NotNull(limits);
            Assert.All(limits, l =>
            {
                bool isLimitAmountMatch = l.Amount == limitAmount;
                bool isGroupUserIdMatch = l.GroupUserId == groupUserId;
                bool isLimitIdMatch = l.Id == excludedLimitId;

                Assert.True((isLimitAmountMatch || isGroupUserIdMatch) && !isLimitIdMatch);
            });
        }

        #endregion
    }
}
