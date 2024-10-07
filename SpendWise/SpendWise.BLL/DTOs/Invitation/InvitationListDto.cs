namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents a summary of an invitation for listing purposes.
    /// </summary>
    public record InvitationListDto
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
    }
}