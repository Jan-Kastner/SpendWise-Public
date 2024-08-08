namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an invitation entity within the SpendWise application.
    /// </summary>
    public record InvitationEntity : IEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the invitation.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the sender of the invitation.
        /// </summary>
        public required Guid SenderId { get; set; }

        /// <summary>
        /// Gets or sets the user entity representing the sender of the invitation. Can be null.
        /// </summary>
        public required UserEntity? Sender { get; init; }

        /// <summary>
        /// Gets or sets the unique identifier for the receiver of the invitation.
        /// </summary>
        public required Guid ReceiverId { get; set; }

        /// <summary>
        /// Gets or sets the user entity representing the receiver of the invitation
        /// </summary>
        public required UserEntity Receiver { get; init; }

        /// <summary>
        /// Gets or sets the unique identifier for the group associated with the invitation.
        /// </summary>
        public required Guid GroupId { get; set; }

        /// <summary>
        /// Gets or sets the group entity associated with the invitation
        /// </summary>
        public required GroupEntity Group { get; init; }

        /// <summary>
        /// Gets or sets the date and time when the invitation was sent.
        /// </summary>
        public required DateTime SentDate { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the invitation was responded to. Can be null.
        /// </summary>
        public required DateTime? ResponseDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the invitation was accepted. Can be null.
        /// </summary>
        public bool? IsAccepted { get; set; }
    }
}
