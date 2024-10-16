namespace SpendWise.DAL.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for an invitation.
    /// </summary>
    public record InvitationDto : IDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the invitation.
        /// </summary>
        public required Guid Id { get; init; }

        /// <summary>
        /// Gets or sets the unique identifier for the sender of the invitation.
        /// </summary>
        public required Guid SenderId { get; init; }

        /// <summary>
        /// Gets or sets the unique identifier for the receiver of the invitation.
        /// </summary>
        public required Guid ReceiverId { get; init; }

        /// <summary>
        /// Gets or sets the unique identifier for the group associated with the invitation.
        /// </summary>
        public required Guid GroupId { get; init; }

        /// <summary>
        /// Gets or sets the date and time when the invitation was sent.
        /// </summary>
        public required DateTime SentDate { get; init; }

        /// <summary>
        /// Gets or sets the date and time when the invitation was responded to. Can be null.
        /// </summary>
        public required DateTime? ResponseDate { get; init; } = null;

        /// <summary>
        /// Gets or sets a value indicating whether the invitation was accepted. Can be null.
        /// </summary>
        public required bool? IsAccepted { get; init; } = null;

        /// <summary>
        /// Gets or sets the user entity representing the sender of the invitation. Can be null.
        /// </summary>
        public UserDto? Sender { get; init; } = null;

        /// <summary>
        /// Gets or sets the user entity representing the receiver of the invitation
        /// </summary>
        public UserDto? Receiver { get; init; } = null;

        /// <summary>
        /// Gets or sets the group entity associated with the invitation
        /// </summary>
        public GroupDto? Group { get; init; } = null;
    }
}
