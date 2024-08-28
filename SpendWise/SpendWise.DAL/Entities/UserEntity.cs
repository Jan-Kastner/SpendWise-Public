using System.ComponentModel.DataAnnotations;

namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents a user entity within the SpendWise application.
    /// </summary>
    public record UserEntity : IEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the user. Must be at least 2 characters long.
        /// </summary>
        [MinLength(2)]
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the surname of the user. Must be at least 2 characters long.
        /// </summary>
        [MinLength(2)]
        public required string Surname { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user. Must be at least 5 characters long.
        /// </summary>
        [MinLength(5)]
        public required string Email { get; set; }

        /// <summary>
        /// Gets or sets the password for the user. Must be at least 8 characters long.
        /// </summary>
        [MinLength(8)]
        public required string Password { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the user registered.
        /// </summary>
        public required DateTime Date_of_registration { get; set; }

        /// <summary>
        /// Gets or sets the photo of the user. Can be null.
        /// </summary>
        public required byte[]? Photo { get; set; }

        /// <summary>
        /// Gets the collection of invitations sent by the user.
        /// </summary>
        /// <remarks>
        /// This is a navigation property for the invitations that the user has sent.
        /// </remarks>
        public ICollection<InvitationEntity> SentInvitations { get; init; } = new List<InvitationEntity>();

        /// <summary>
        /// Gets the collection of invitations received by the user.
        /// </summary>
        /// <remarks>
        /// This is a navigation property for the invitations that the user has received.
        /// </remarks>
        public ICollection<InvitationEntity> ReceivedInvitations { get; init; } = new List<InvitationEntity>();

        /// <summary>
        /// Gets the collection of group-user relationships associated with the user.
        /// </summary>
        /// <remarks>
        /// This is a navigation property for the group-user relationships in which the user is involved.
        /// </remarks>
        public ICollection<GroupUserEntity> GroupUsers { get; init; } = new List<GroupUserEntity>();
    }
}
