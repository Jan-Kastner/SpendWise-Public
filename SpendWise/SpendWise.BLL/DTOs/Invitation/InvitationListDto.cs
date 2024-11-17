using SpendWise.BLL.DTOs.Interfaces;

namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents a summary of an invitation for listing purposes.
    /// </summary>
    public record InvitationListDto : IQueryableDto
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
    }
}