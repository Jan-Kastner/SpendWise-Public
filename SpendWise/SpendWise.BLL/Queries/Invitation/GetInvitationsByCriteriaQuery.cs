using SpendWise.BLL.Queries.Interfaces;
using System;

namespace SpendWise.BLL.Queries
{
    /// <summary>
    /// Represents a query object for retrieving invitations based on various criteria.
    /// </summary>
    public class GetInvitationsByCriteriaQuery : IInvitationCriteriaQuery, IInvitationIncludeQuery
    {
        /// <summary>
        /// Gets the unique identifier of the invitation.
        /// </summary>
        public Guid? Id { get; }

        /// <summary>
        /// Gets the unique identifier of the invitation that should not match.
        /// </summary>
        public Guid? NotId { get; }

        /// <summary>
        /// Gets the sent date of the invitation.
        /// </summary>
        public DateTime? SentDate { get; }

        /// <summary>
        /// Gets the sent date that should not match.
        /// </summary>
        public DateTime? NotSentDate { get; }

        /// <summary>
        /// Gets the response date of the invitation.
        /// </summary>
        public DateTime? ResponseDate { get; }

        /// <summary>
        /// Gets the response date that should not match.
        /// </summary>
        public DateTime? NotResponseDate { get; }

        /// <summary>
        /// Gets a value indicating whether the invitation should be without a response date.
        /// </summary>
        public bool? WithoutResponseDate { get; }

        /// <summary>
        /// Gets a value indicating whether the invitation should not be without a response date.
        /// </summary>
        public bool? NotWithoutResponseDate { get; }

        /// <summary>
        /// Gets a value indicating whether the invitation is accepted.
        /// </summary>
        public bool? IsAccepted { get; }

        /// <summary>
        /// Gets a value indicating whether the invitation is not accepted.
        /// </summary>
        public bool? NotIsAccepted { get; }

        /// <summary>
        /// Gets a value indicating whether the invitation is pending.
        /// </summary>
        public bool? IsPending { get; }

        /// <summary>
        /// Gets a value indicating whether the invitation is not pending.
        /// </summary>
        public bool? NotIsPending { get; }

        /// <summary>
        /// Gets the unique identifier of the sender.
        /// </summary>
        public Guid? SenderId { get; }

        /// <summary>
        /// Gets the unique identifier of the sender that should not match.
        /// </summary>
        public Guid? NotSenderId { get; }

        /// <summary>
        /// Gets the unique identifier of the receiver.
        /// </summary>
        public Guid? ReceiverId { get; }

        /// <summary>
        /// Gets the unique identifier of the receiver that should not match.
        /// </summary>
        public Guid? NotReceiverId { get; }

        /// <summary>
        /// Gets the unique identifier of the group.
        /// </summary>
        public Guid? GroupId { get; }

        /// <summary>
        /// Gets the unique identifier of the group that should not match.
        /// </summary>
        public Guid? NotGroupId { get; }

        /// <summary>
        /// Gets a value indicating whether to include the group in the query result.
        /// </summary>
        public bool IncludeGroup { get; }

        /// <summary>
        /// Gets a value indicating whether to include the sender in the query result.
        /// </summary>
        public bool IncludeSender { get; }

        /// <summary>
        /// Gets a value indicating whether to include the receiver in the query result.
        /// </summary>
        public bool IncludeReceiver { get; }

        /// <summary>
        /// Gets a value indicating whether to include the group participants in the query result.
        /// </summary>
        public bool IncludeGroupParticipants { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetInvitationsByCriteriaQuery"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the invitation.</param>
        /// <param name="notId">The unique identifier of the invitation that should not match.</param>
        /// <param name="sentDate">The sent date of the invitation.</param>
        /// <param name="notSentDate">The sent date that should not match.</param>
        /// <param name="responseDate">The response date of the invitation.</param>
        /// <param name="notResponseDate">The response date that should not match.</param>
        /// <param name="withoutResponseDate">Indicates whether the invitation should be without a response date.</param>
        /// <param name="notWithoutResponseDate">Indicates whether the invitation should not be without a response date.</param>
        /// <param name="isAccepted">Indicates whether the invitation is accepted.</param>
        /// <param name="notIsAccepted">Indicates whether the invitation is not accepted.</param>
        /// <param name="isPending">Indicates whether the invitation is pending.</param>
        /// <param name="notIsPending">Indicates whether the invitation is not pending.</param>
        /// <param name="senderId">The unique identifier of the sender.</param>
        /// <param name="notSenderId">The unique identifier of the sender that should not match.</param>
        /// <param name="receiverId">The unique identifier of the receiver.</param>
        /// <param name="notReceiverId">The unique identifier of the receiver that should not match.</param>
        /// <param name="groupId">The unique identifier of the group.</param>
        /// <param name="notGroupId">The unique identifier of the group that should not match.</param>
        /// <param name="includeGroup">A value indicating whether to include the group in the query result. Default is false.</param>
        /// <param name="includeSender">A value indicating whether to include the sender in the query result. Default is false.</param>
        /// <param name="includeReceiver">A value indicating whether to include the receiver in the query result. Default is false.</param>
        /// <param name="includeGroupParticipants">A value indicating whether to include the group participants in the query result. Default is false.</param>
        public GetInvitationsByCriteriaQuery(
            Guid? id = null,
            Guid? notId = null,
            DateTime? sentDate = null,
            DateTime? notSentDate = null,
            DateTime? responseDate = null,
            DateTime? notResponseDate = null,
            bool? withoutResponseDate = null,
            bool? notWithoutResponseDate = null,
            bool? isAccepted = null,
            bool? notIsAccepted = null,
            bool? isPending = null,
            bool? notIsPending = null,
            Guid? senderId = null,
            Guid? notSenderId = null,
            Guid? receiverId = null,
            Guid? notReceiverId = null,
            Guid? groupId = null,
            Guid? notGroupId = null,
            bool includeGroup = false,
            bool includeSender = false,
            bool includeReceiver = false,
            bool includeGroupParticipants = false)
        {
            Id = id;
            NotId = notId;
            SentDate = sentDate;
            NotSentDate = notSentDate;
            ResponseDate = responseDate;
            NotResponseDate = notResponseDate;
            WithoutResponseDate = withoutResponseDate;
            NotWithoutResponseDate = notWithoutResponseDate;
            IsAccepted = isAccepted;
            NotIsAccepted = notIsAccepted;
            IsPending = isPending;
            NotIsPending = notIsPending;
            SenderId = senderId;
            NotSenderId = notSenderId;
            ReceiverId = receiverId;
            NotReceiverId = notReceiverId;
            GroupId = groupId;
            NotGroupId = notGroupId;
            IncludeGroup = includeGroup;
            IncludeSender = includeSender;
            IncludeReceiver = includeReceiver;
            IncludeGroupParticipants = includeGroupParticipants;
        }
    }
}