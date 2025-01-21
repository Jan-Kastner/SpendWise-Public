namespace SpendWise.BLL.Queries.Interfaces
{
    /// <summary>
    /// Represents an interface for invitation criteria-based queries.
    /// </summary>
    public interface IInvitationCriteriaQuery : ICriteriaQuery<IInvitationCriteriaQuery>
    {
        #region SentDate

        /// <summary>
        /// Gets the sent date of the invitation.
        /// </summary>
        DateTime? SentDate { get; }

        /// <summary>
        /// Gets the sent date that should not match.
        /// </summary>
        DateTime? NotSentDate { get; }

        /// <summary>
        /// Gets the sent date range from.
        /// </summary>
        DateTime? SentDateFrom { get; }

        /// <summary>
        /// Gets the sent date range to.
        /// </summary>
        DateTime? SentDateTo { get; }

        #endregion

        #region ResponseDate

        /// <summary>
        /// Gets the response date of the invitation.
        /// </summary>
        DateTime? ResponseDate { get; }

        /// <summary>
        /// Gets the response date that should not match.
        /// </summary>
        DateTime? NotResponseDate { get; }

        /// <summary>
        /// Gets the response date range from.
        /// </summary>
        DateTime? ResponseDateFrom { get; }

        /// <summary>
        /// Gets the response date range to.
        /// </summary>
        DateTime? ResponseDateTo { get; }

        #endregion

        #region WithResponseDate

        /// <summary>
        /// Gets a value indicating whether the invitation should be without a response date.
        /// </summary>
        bool? WithResponseDate { get; }

        #endregion

        #region Status

        /// <summary>
        /// Gets a value indicating whether the invitation is accepted.
        /// </summary>
        bool? IsAccepted { get; }

        /// <summary>
        /// Gets a value indicating whether the invitation is pending.
        /// </summary>
        bool? IsPending { get; }

        #endregion

        #region Sender

        /// <summary>
        /// Gets the unique identifier of the sender.
        /// </summary>
        Guid? SenderId { get; }

        /// <summary>
        /// Gets the unique identifier of the sender that should not match.
        /// </summary>
        Guid? NotSenderId { get; }

        #endregion

        #region Receiver

        /// <summary>
        /// Gets the unique identifier of the receiver.
        /// </summary>
        Guid? ReceiverId { get; }

        /// <summary>
        /// Gets the unique identifier of the receiver that should not match.
        /// </summary>
        Guid? NotReceiverId { get; }

        #endregion

        #region Group

        /// <summary>
        /// Gets the unique identifier of the group.
        /// </summary>
        Guid? GroupId { get; }

        /// <summary>
        /// Gets the unique identifier of the group that should not match.
        /// </summary>
        Guid? NotGroupId { get; }

        #endregion
    }
}