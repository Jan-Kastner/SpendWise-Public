using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Queries
{
    /// <summary>
    /// Represents a query object for retrieving invitations based on various criteria.
    /// </summary>
    public class GetInvitationsByCriteriaQuery : IInvitationCriteriaQuery, IInvitationIncludeQuery
    {
        #region SentDate

        /// <summary>
        /// Gets the sent date of the invitation.
        /// </summary>
        public DateTime? SentDate { get; }

        /// <summary>
        /// Gets the sent date that should not match.
        /// </summary>
        public DateTime? NotSentDate { get; }

        /// <summary>
        /// Gets the sent date range from.
        /// </summary>
        public DateTime? SentDateFrom { get; }

        /// <summary>
        /// Gets the sent date range to.
        /// </summary>
        public DateTime? SentDateTo { get; }

        #endregion

        #region ResponseDate

        /// <summary>
        /// Gets the response date of the invitation.
        /// </summary>
        public DateTime? ResponseDate { get; }

        /// <summary>
        /// Gets the response date that should not match.
        /// </summary>
        public DateTime? NotResponseDate { get; }

        /// <summary>
        /// Gets the response date range from.
        /// </summary>
        public DateTime? ResponseDateFrom { get; }

        /// <summary>
        /// Gets the response date range to.
        /// </summary>
        public DateTime? ResponseDateTo { get; }

        #endregion

        #region WithoutResponseDate

        /// <summary>
        /// Gets a value indicating whether the invitation should be without a response date.
        /// </summary>
        public bool? WithResponseDate { get; }

        #endregion

        #region Status

        /// <summary>
        /// Gets a value indicating whether the invitation is accepted.
        /// </summary>
        public bool? IsAccepted { get; }

        /// <summary>
        /// Gets a value indicating whether the invitation is pending.
        /// </summary>
        public bool? IsPending { get; }

        #endregion

        #region Sender

        /// <summary>
        /// Gets the unique identifier of the sender.
        /// </summary>
        public Guid? SenderId { get; }

        /// <summary>
        /// Gets the unique identifier of the sender that should not match.
        /// </summary>
        public Guid? NotSenderId { get; }

        #endregion

        #region Receiver

        /// <summary>
        /// Gets the unique identifier of the receiver.
        /// </summary>
        public Guid? ReceiverId { get; }

        /// <summary>
        /// Gets the unique identifier of the receiver that should not match.
        /// </summary>
        public Guid? NotReceiverId { get; }

        #endregion

        #region Group

        /// <summary>
        /// Gets the unique identifier of the group.
        /// </summary>
        public Guid? GroupId { get; }

        /// <summary>
        /// Gets the unique identifier of the group that should not match.
        /// </summary>
        public Guid? NotGroupId { get; }

        #endregion

        #region IncludeOptions

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

        #endregion

        #region LogicalOperators

        /// <summary>
        /// Gets the list of query objects to combine with AND.
        /// </summary>
        public List<IInvitationCriteriaQuery>? And { get; }

        /// <summary>
        /// Gets the list of query objects to combine with OR.
        /// </summary>
        public List<IInvitationCriteriaQuery>? Or { get; }

        /// <summary>
        /// Gets the list of query objects to negate.
        /// </summary>
        public List<IInvitationCriteriaQuery>? Not { get; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="GetInvitationsByCriteriaQuery"/> class.
        /// </summary>
        /// <param name="sentDate">The sent date of the invitation.</param>
        /// <param name="notSentDate">The sent date that should not match.</param>
        /// <param name="sentDateFrom">The sent date range from.</param>
        /// <param name="sentDateTo">The sent date range to.</param>
        /// <param name="responseDate">The response date of the invitation.</param>
        /// <param name="notResponseDate">The response date that should not match.</param>
        /// <param name="responseDateFrom">The response date range from.</param>
        /// <param name="responseDateTo">The response date range to.</param>
        /// <param name="withResponseDate">Indicates whether the invitation should be without a response date.</param>
        /// <param name="isAccepted">Indicates whether the invitation is accepted.</param>
        /// <param name="isPending">Indicates whether the invitation is pending.</param>
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
        /// <param name="and">The list of query objects to combine with AND.</param>
        /// <param name="or">The list of query objects to combine with OR.</param>
        /// <param name="not">The list of query objects to negate.</param>
        public GetInvitationsByCriteriaQuery(
            DateTime? sentDate = null,
            DateTime? notSentDate = null,
            DateTime? sentDateFrom = null,
            DateTime? sentDateTo = null,
            DateTime? responseDate = null,
            DateTime? notResponseDate = null,
            DateTime? responseDateFrom = null,
            DateTime? responseDateTo = null,
            bool? withResponseDate = null,
            bool? isAccepted = null,
            bool? isPending = null,
            Guid? senderId = null,
            Guid? notSenderId = null,
            Guid? receiverId = null,
            Guid? notReceiverId = null,
            Guid? groupId = null,
            Guid? notGroupId = null,
            bool includeGroup = false,
            bool includeSender = false,
            bool includeReceiver = false,
            bool includeGroupParticipants = false,
            List<IInvitationCriteriaQuery>? and = null,
            List<IInvitationCriteriaQuery>? or = null,
            List<IInvitationCriteriaQuery>? not = null)
        {
            SentDate = sentDate;
            NotSentDate = notSentDate;
            SentDateFrom = sentDateFrom;
            SentDateTo = sentDateTo;
            ResponseDate = responseDate;
            NotResponseDate = notResponseDate;
            ResponseDateFrom = responseDateFrom;
            ResponseDateTo = responseDateTo;
            WithResponseDate = withResponseDate;
            IsAccepted = isAccepted;
            IsPending = isPending;
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
            And = and;
            Or = or;
            Not = not;
        }
    }
}