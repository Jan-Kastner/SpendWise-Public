namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents detailed information about an invitation.
    /// </summary>
    public record InvitationDetailDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the invitation.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the sender of the invitation.
        /// </summary>
        public required UserListDto Sender { get; init; }

        /// <summary>
        /// Gets or sets the receiver of the invitation.
        /// </summary>
        public required UserListDto Receiver { get; init; }

        /// <summary>
        /// Gets or sets the group associated with the invitation.
        /// </summary>
        public required GroupListDto Group { get; init; }

        /// <summary>
        /// Gets or sets the date the invitation was sent.
        /// </summary>
        public required DateTime SentDate { get; init; }

        /// <summary>
        /// Gets or sets the date the invitation was responded to, if any.
        /// </summary>
        public required DateTime? ResponseDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the invitation was accepted.
        /// </summary>
        public required bool? IsAccepted { get; set; }
    }
}