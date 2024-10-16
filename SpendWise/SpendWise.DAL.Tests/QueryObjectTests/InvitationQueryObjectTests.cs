using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpendWise.DAL.DTOs;
using SpendWise.Common.Tests.Seeds;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;
using SpendWise.Common.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace SpendWise.DAL.Tests.QueryObjectTests
{
    public class InvitationQueryObjectTests : UnitOfWorkTestsBase
    {
        public InvitationQueryObjectTests(ITestOutputHelper output) : base(output)
        {
        }

        #region IdQuery Tests

        /// <summary>
        /// Verifies that querying an invitation by its ID 
        /// returns the correct entry from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithId_ShouldReturnCorrectInvitation()
        {
            // Arrange
            var invitationId = InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id;
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.WithId(invitationId));

            // Assert
            Assert.NotNull(invitations);
            Assert.Single(invitations);
            Assert.Equal(invitationId, invitations.First().Id);
        }

        /// <summary>
        /// Verifies that querying invitations by multiple IDs using an OR condition 
        /// returns entries matching either of the specified IDs.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithId_ShouldReturnCorrectInvitations()
        {
            // Arrange
            var invitationId1 = InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id;
            var invitationId2 = InvitationSeeds.InvitationJohnToDianaIntoFamily.Id;
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.OrWithId(invitationId1).OrWithId(invitationId2));

            // Assert
            Assert.NotNull(invitations);
            Assert.All(invitations, i => Assert.True(i.Id == invitationId1 || i.Id == invitationId2));
        }

        /// <summary>
        /// Verifies that querying invitations with a NOT condition by ID 
        /// excludes the invitation with the specified ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithId_ShouldExcludeInvitation()
        {
            // Arrange
            var invitationId = InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id;
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.NotWithId(invitationId));

            // Assert
            Assert.NotNull(invitations);
            Assert.DoesNotContain(invitations, i => i.Id == invitationId);
        }

        #endregion

        #region SentDateQuery Tests

        /// <summary>
        /// Verifies that querying invitations by sent date 
        /// returns all correct entries associated with that sent date.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithSentDate_ShouldReturnCorrectInvitations()
        {
            // Arrange
            var sentDate = new DateTime(2024, 7, 1, 12, 0, 0, DateTimeKind.Utc);
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.WithSentDate(sentDate));

            // Assert
            Assert.NotNull(invitations);
            Assert.All(invitations, i => Assert.Equal(sentDate.Date, i.SentDate.Date));
        }

        /// <summary>
        /// Verifies that querying invitations by multiple sent dates using an OR condition 
        /// returns entries matching either of the specified sent dates.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithSentDate_ShouldReturnCorrectInvitations()
        {
            // Arrange
            var sentDate1 = new DateTime(2024, 7, 1, 12, 0, 0, DateTimeKind.Utc);
            var sentDate2 = new DateTime(2024, 7, 2, 12, 0, 0, DateTimeKind.Utc);
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.OrWithSentDate(sentDate1).OrWithSentDate(sentDate2));

            // Assert
            Assert.NotNull(invitations);
            Assert.All(invitations, i => Assert.True(i.SentDate.Date == sentDate1.Date || i.SentDate.Date == sentDate2.Date));
        }

        /// <summary>
        /// Verifies that querying invitations with a NOT condition by sent date 
        /// excludes all invitations sent on the specified date.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithSentDate_ShouldExcludeInvitations()
        {
            // Arrange
            var sentDate = new DateTime(2024, 7, 1, 12, 0, 0, DateTimeKind.Utc);
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.NotWithSentDate(sentDate));

            // Assert
            Assert.NotNull(invitations);
            Assert.All(invitations, i => Assert.NotEqual(sentDate.Date, i.SentDate.Date));
        }

        #endregion

        #region ResponseDateQuery Tests

        /// <summary>
        /// Verifies that querying invitations by response date 
        /// returns all correct entries associated with that response date.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithResponseDate_ShouldReturnCorrectInvitations()
        {
            // Arrange
            var responseDate = new DateTime(2024, 7, 2, 12, 0, 0, DateTimeKind.Utc);
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.WithResponseDate(responseDate));

            // Assert
            Assert.NotNull(invitations);
            Assert.All(invitations, i => Assert.True(i.ResponseDate.HasValue && i.ResponseDate.Value.Date == responseDate.Date));
        }

        /// <summary>
        /// Verifies that querying invitations by multiple response dates using an OR condition 
        /// returns entries matching either of the specified response dates.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithResponseDate_ShouldReturnCorrectInvitations()
        {
            // Arrange
            var responseDate1 = new DateTime(2024, 7, 2, 12, 0, 0, DateTimeKind.Utc);
            var responseDate2 = new DateTime(2024, 7, 3, 12, 0, 0, DateTimeKind.Utc);
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.OrWithResponseDate(responseDate1).OrWithResponseDate(responseDate2));

            // Assert
            Assert.NotNull(invitations);
            Assert.All(invitations, i => Assert.True(i.ResponseDate.HasValue && (i.ResponseDate.Value.Date == responseDate1.Date || i.ResponseDate.Value.Date == responseDate2.Date)));
        }

        /// <summary>
        /// Verifies that querying invitations with a NOT condition by response date 
        /// excludes all invitations with the specified response date.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithResponseDate_ShouldExcludeInvitations()
        {
            // Arrange
            var responseDate = new DateTime(2024, 7, 2, 12, 0, 0, DateTimeKind.Utc);
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.NotWithResponseDate(responseDate));

            // Assert
            Assert.NotNull(invitations);
            Assert.All(invitations, i => Assert.False(i.ResponseDate.HasValue && i.ResponseDate.Value.Date == responseDate.Date));
        }

        /// <summary>
        /// Verifies that querying invitations without any response date (null)
        /// returns all correct entries with null response date.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithoutResponseDate_ShouldReturnInvitationsWithNullResponseDate()
        {
            // Arrange
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.WithoutResponseDate());

            // Assert
            Assert.NotNull(invitations);
            Assert.All(invitations, i => Assert.Null(i.ResponseDate));
        }

        /// <summary>
        /// Verifies that querying invitations with an OR condition for null response date
        /// returns all correct entries with null response date.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithoutResponseDate_ShouldReturnInvitationsWithNullResponseDate()
        {
            // Arrange
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.OrWithoutResponseDate());

            // Assert
            Assert.NotNull(invitations);
            Assert.All(invitations, i => Assert.Null(i.ResponseDate));
        }

        /// <summary>
        /// Verifies that querying invitations excluding null response date
        /// does not return entries with null response date.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithoutResponseDate_ShouldExcludeInvitationsWithNullResponseDate()
        {
            // Arrange
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.NotWithoutResponseDate());

            // Assert
            Assert.NotNull(invitations);
            Assert.All(invitations, i => Assert.NotNull(i.ResponseDate));
        }

        #endregion

        #region IsAcceptedQuery Tests

        /// <summary>
        /// Verifies that querying invitations by acceptance status 
        /// returns all correct entries associated with that status.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task IsAccepted_ShouldReturnCorrectInvitations()
        {
            // Arrange
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.IsAccepted());

            // Assert
            Assert.NotNull(invitations);
            Assert.All(invitations, i =>
            {
                Assert.NotNull(i.IsAccepted);
                Assert.True(i.IsAccepted);
            });
        }

        /// <summary>
        /// Verifies that querying invitations by multiple acceptance statuses using an OR condition 
        /// returns all correct entries associated with either of the specified statuses.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrIsAccepted_ShouldReturnCorrectInvitations()
        {
            // Arrange
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.OrIsAccepted().OrIsPending());

            // Assert
            Assert.NotNull(invitations);
            Assert.All(invitations, i =>
            {
                Assert.True(i.IsAccepted == true || i.IsAccepted == null);
            });
        }

        /// <summary>
        /// Verifies that querying invitations with a NOT condition by acceptance status 
        /// excludes all invitations containing the specified status.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotIsAccepted_ShouldExcludeInvitations()
        {
            // Arrange
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.NotIsAccepted());

            // Assert
            Assert.NotNull(invitations);
            Assert.All(invitations, i =>
            {
                Assert.NotEqual(true, i.IsAccepted);
            });
        }

        /// <summary>
        /// Verifies that querying invitations by not accepted status 
        /// returns all correct entries associated with that status.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task IsNotAccepted_ShouldReturnCorrectInvitations()
        {
            // Arrange
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.IsNotAccepted());

            // Assert
            Assert.NotNull(invitations);
            Assert.All(invitations, i =>
            {
                Assert.NotNull(i.IsAccepted);
                Assert.False(i.IsAccepted);
            });
        }

        /// <summary>
        /// Verifies that querying invitations by pending status 
        /// returns all correct entries associated with that status.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task IsPending_ShouldReturnCorrectInvitations()
        {
            // Arrange
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.IsPending());

            // Assert
            Assert.NotNull(invitations);
            Assert.All(invitations, i =>
            {
                Assert.Null(i.IsAccepted);
            });
        }

        #endregion

        #region SenderQuery Tests

        /// <summary>
        /// Verifies that querying invitations by sender ID 
        /// returns all correct entries associated with that sender ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithSender_ShouldReturnCorrectInvitations()
        {
            // Arrange
            var senderId = UserSeeds.UserJohnDoe.Id;
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.WithSender(senderId));

            // Assert
            Assert.NotNull(invitations);
            Assert.All(invitations, i => Assert.Equal(senderId, i.SenderId));
        }


        /// <summary>
        /// Verifies that querying invitations by multiple sender IDs using an OR condition 
        /// returns entries matching either of the specified sender IDs.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithSender_ShouldReturnCorrectInvitations()
        {
            // Arrange
            var senderId1 = UserSeeds.UserJohnDoe.Id;
            var senderId2 = UserSeeds.UserDianaGreen.Id;
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.OrWithSender(senderId1).OrWithSender(senderId2));

            // Assert
            Assert.NotNull(invitations);
            Assert.All(invitations, i => Assert.True(i.SenderId == senderId1 || i.SenderId == senderId2));
        }

        /// <summary>
        /// Verifies that querying invitations with a NOT condition by sender ID 
        /// excludes all invitations with the specified sender ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithSender_ShouldExcludeInvitations()
        {
            // Arrange
            var senderId = UserSeeds.UserJohnDoe.Id;
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.NotWithSender(senderId));

            // Assert
            Assert.NotNull(invitations);
            Assert.All(invitations, i => Assert.NotEqual(senderId, i.SenderId));
        }

        #endregion

        #region ReceiverQuery Tests

        /// <summary>
        /// Verifies that querying invitations by receiver ID 
        /// returns all correct entries associated with that receiver ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithReceiver_ShouldReturnCorrectInvitations()
        {
            // Arrange
            var receiverId = UserSeeds.UserDianaGreen.Id;
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.WithReceiver(receiverId));

            // Assert
            Assert.NotNull(invitations);
            Assert.All(invitations, i => Assert.Equal(receiverId, i.ReceiverId));
        }


        /// <summary>
        /// Verifies that querying invitations by multiple receiver IDs using an OR condition 
        /// returns entries matching either of the specified receiver IDs.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithReceiver_ShouldReturnCorrectInvitations()
        {
            // Arrange
            var receiverId1 = UserSeeds.UserDianaGreen.Id;
            var receiverId2 = UserSeeds.UserCharlieBlack.Id;
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.OrWithReceiver(receiverId1).OrWithReceiver(receiverId2));

            // Assert
            Assert.NotNull(invitations);
            Assert.All(invitations, i => Assert.True(i.ReceiverId == receiverId1 || i.ReceiverId == receiverId2));
        }

        /// <summary>
        /// Verifies that querying invitations with a NOT condition by receiver ID 
        /// excludes all invitations with the specified receiver ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithReceiverId_ShouldExcludeInvitations()
        {
            // Arrange
            var receiverId = UserSeeds.UserDianaGreen.Id;
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.NotWithReceiver(receiverId));

            // Assert
            Assert.NotNull(invitations);
            Assert.All(invitations, i => Assert.NotEqual(receiverId, i.ReceiverId));
        }

        #endregion

        #region GroupQuery Tests

        /// <summary>
        /// Verifies that querying invitations by group ID 
        /// returns all correct entries associated with that group ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithGroup_ShouldReturnCorrectInvitations()
        {
            // Arrange
            var groupId = GroupSeeds.GroupFamily.Id;
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.WithGroup(groupId));

            // Assert
            Assert.NotNull(invitations);
            Assert.All(invitations, i => Assert.Equal(groupId, i.GroupId));
        }

        /// <summary>
        /// Verifies that querying invitations by multiple group IDs using an OR condition 
        /// returns entries matching either of the specified group IDs.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithGroup_ShouldReturnCorrectInvitations()
        {
            // Arrange
            var groupId1 = GroupSeeds.GroupFamily.Id;
            var groupId2 = GroupSeeds.GroupWork.Id;
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.OrWithGroup(groupId1).OrWithGroup(groupId2));

            // Assert
            Assert.NotNull(invitations);
            Assert.All(invitations, i => Assert.True(i.GroupId == groupId1 || i.GroupId == groupId2));
        }

        /// <summary>
        /// Verifies that querying invitations with a NOT condition by group ID 
        /// excludes all invitations with the specified group ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithGroupId_ShouldExcludeInvitations()
        {
            // Arrange
            var groupId = GroupSeeds.GroupFamily.Id;
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.NotWithGroup(groupId));

            // Assert
            Assert.NotNull(invitations);
            Assert.All(invitations, i => Assert.NotEqual(groupId, i.GroupId));
        }

        #endregion

        #region Complex Tests

        /// <summary>
        /// Verifies that querying invitations by ID and sender ID using an AND condition
        /// returns the entry that matches both criteria.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithIdAndSenderId_ShouldReturnCorrectEntry()
        {
            // Arrange
            var invitationId = InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id;
            var senderId = InvitationSeeds.InvitationDianaToCharlieIntoFamily.SenderId;
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.WithId(invitationId).WithSender(senderId));

            // Assert
            Assert.NotNull(invitations);
            Assert.Single(invitations);
            Assert.Equal(invitationId, invitations.First().Id);
            Assert.Equal(senderId, invitations.First().SenderId);
        }

        /// <summary>
        /// Verifies that querying invitations by group ID and sent date using an AND condition
        /// returns entries that match both criteria.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithGroupIdAndSentDate_ShouldReturnCorrectEntries()
        {
            // Arrange
            var groupId = GroupSeeds.GroupFamily.Id;
            var sentDate = new DateTime(2024, 7, 1, 12, 0, 0, DateTimeKind.Utc);
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.WithGroup(groupId).WithSentDate(sentDate));

            // Assert
            Assert.NotNull(invitations);
            Assert.Single(invitations);
            Assert.Equal(groupId, invitations.First().GroupId);
            Assert.Equal(sentDate.Date, invitations.First().SentDate.Date);
        }

        /// <summary>
        /// Verifies that querying invitations by sender ID or receiver ID using an OR condition
        /// returns entries that match either criterion.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithSenderIdOrReceiverId_ShouldReturnCorrectEntries()
        {
            // Arrange
            var senderId = UserSeeds.UserJohnDoe.Id;
            var receiverId = UserSeeds.UserDianaGreen.Id;
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.OrWithSender(senderId).OrWithReceiver(receiverId));

            // Assert
            Assert.NotNull(invitations);
            Assert.NotEmpty(invitations);
            Assert.All(invitations, i => Assert.True(i.SenderId == senderId || i.ReceiverId == receiverId));
        }

        /// <summary>
        /// Verifies that querying invitations by sender ID and receiver ID using an AND condition
        /// and excluding a specific group ID using a NOT condition works together.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithSenderIdAndReceiverIdNotWithGroupId_ShouldReturnCorrectEntries()
        {
            // Arrange
            var senderId = UserSeeds.UserJohnDoe.Id;
            var receiverId = UserSeeds.UserDianaGreen.Id;
            var excludedGroupId = GroupSeeds.GroupWork.Id;
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.WithSender(senderId)
                                     .WithReceiver(receiverId)
                                     .NotWithGroup(excludedGroupId));

            // Assert
            Assert.NotNull(invitations);
            Assert.All(invitations, i =>
            {
                bool isSenderIdMatch = i.SenderId == senderId;
                bool isReceiverIdMatch = i.ReceiverId == receiverId;
                bool isGroupIdMatch = i.GroupId == excludedGroupId;

                Assert.True(isSenderIdMatch && isReceiverIdMatch && !isGroupIdMatch);
            });
        }

        /// <summary>
        /// Verifies that querying invitations by partial sent date match using an OR condition
        /// and excluding a specific ID using a NOT condition works together.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithSentDatePartialMatchNotWithId_ShouldReturnCorrectEntries()
        {
            // Arrange
            var excludedInvitationId = InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id;
            var queryObject = new InvitationQueryObject();

            // Act
            var invitations = await _unitOfWork.InvitationRepository
                .ListAsync(queryObject.OrWithSentDate(new DateTime(2024, 7, 1, 12, 0, 0, DateTimeKind.Utc)).NotWithId(excludedInvitationId));

            // Assert
            Assert.NotNull(invitations);
            Assert.All(invitations, i =>
            {
                Assert.Equal(new DateTime(2024, 7, 1).Date, i.SentDate.Date);
                Assert.NotEqual(excludedInvitationId, i.Id);
            });
        }

        #endregion
    }
}