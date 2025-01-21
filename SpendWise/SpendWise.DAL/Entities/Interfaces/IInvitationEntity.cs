using System;

namespace SpendWise.DAL.Entities.Interfaces
{
    /// <summary>
    /// Represents an interface for invitation entities within the SpendWise application.
    /// </summary>
    public interface IInvitationEntity : IEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the sender of the invitation.
        /// </summary>
        Guid SenderId { get; init; }

        /// <summary>
        /// Gets or sets the user entity representing the sender of the invitation. Can be null.
        /// </summary>
        UserEntity Sender { get; init; }

        /// <summary>
        /// Gets or sets the unique identifier for the receiver of the invitation.
        /// </summary>
        Guid ReceiverId { get; init; }

        /// <summary>
        /// Gets or sets the user entity representing the receiver of the invitation.
        /// </summary>
        UserEntity Receiver { get; init; }

        /// <summary>
        /// Gets or sets the unique identifier for the group associated with the invitation.
        /// </summary>
        Guid GroupId { get; init; }

        /// <summary>
        /// Gets or sets the group entity associated with the invitation.
        /// </summary>
        GroupEntity Group { get; init; }

        /// <summary>
        /// Gets or sets the date and time when the invitation was sent.
        /// </summary>
        DateTime SentDate { get; init; }

        /// <summary>
        /// Gets or sets the date and time when the invitation was responded to. Can be null.
        /// </summary>
        DateTime? ResponseDate { get; init; }

        /// <summary>
        /// Gets or sets a value indicating whether the invitation was accepted. Can be null.
        /// </summary>
        bool? IsAccepted { get; init; }
    }
}