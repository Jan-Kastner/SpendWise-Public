namespace SpendWise.BLL.Queries.Interfaces
{
    /// <summary>
    /// Represents an interface for invitation criteria-based queries.
    /// </summary>
    public interface IInvitationCriteriaQuery : ICriteriaQuery
    {
        /// <summary>
        /// Gets the unique identifier of the invitation that should not match.
        /// </summary>
        Guid? NotId { get; }

        /// <summary>
        /// Gets the sent date of the invitation.
        /// </summary>
        DateTime? SentDate { get; }

        /// <summary>
        /// Gets the sent date that should not match.
        /// </summary>
        DateTime? NotSentDate { get; }

        /// <summary>
        /// Gets the response date of the invitation.
        /// </summary>
        DateTime? ResponseDate { get; }

        /// <summary>
        /// Gets the response date that should not match.
        /// </summary>
        DateTime? NotResponseDate { get; }

        /// <summary>
        /// Gets a value indicating whether the invitation should be without a response date.
        /// </summary>
        bool? WithoutResponseDate { get; }

        /// <summary>
        /// Gets a value indicating whether the invitation should not be without a response date.
        /// </summary>
        bool? NotWithoutResponseDate { get; }

        /// <summary>
        /// Gets a value indicating whether the invitation is accepted.
        /// </summary>
        bool? IsAccepted { get; }

        /// <summary>
        /// Gets a value indicating whether the invitation is not accepted.
        /// </summary>
        bool? NotIsAccepted { get; }

        /// <summary>
        /// Gets a value indicating whether the invitation is pending.
        /// </summary>
        bool? IsPending { get; }

        /// <summary>
        /// Gets a value indicating whether the invitation is not pending.
        /// </summary>
        bool? NotIsPending { get; }

        /// <summary>
        /// Gets the unique identifier of the sender.
        /// </summary>
        Guid? SenderId { get; }

        /// <summary>
        /// Gets the unique identifier of the sender that should not match.
        /// </summary>
        Guid? NotSenderId { get; }

        /// <summary>
        /// Gets the unique identifier of the receiver.
        /// </summary>
        Guid? ReceiverId { get; }

        /// <summary>
        /// Gets the unique identifier of the receiver that should not match.
        /// </summary>
        Guid? NotReceiverId { get; }

        /// <summary>
        /// Gets the unique identifier of the group.
        /// </summary>
        Guid? GroupId { get; }

        /// <summary>
        /// Gets the unique identifier of the group that should not match.
        /// </summary>
        Guid? NotGroupId { get; }
    }
}