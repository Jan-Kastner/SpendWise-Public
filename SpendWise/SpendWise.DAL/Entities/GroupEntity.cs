using System.ComponentModel.DataAnnotations;

namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents a group entity within the SpendWise application.
    /// </summary>
    public record GroupEntity : IGroupEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the group.
        /// </summary>
        public required Guid Id { get; init; }

        /// <summary>
        /// Gets or sets the name of the group. Must be at least 2 characters long.
        /// </summary>
        [MinLength(2)]
        public required string Name { get; init; }

        /// <summary>
        /// Gets or sets the description of the group. Can be null.
        /// </summary>
        public required string? Description { get; init; } = null;

        /// <summary>
        /// Gets the collection of users associated with this group.
        /// </summary>
        /// <remarks>
        /// This is a navigation property for the users related to this group.
        /// </remarks>
        public required ICollection<GroupUserEntity> GroupUsers { get; init; } = new List<GroupUserEntity>();

        /// <summary>
        /// Gets the collection of invitations associated with this group.
        /// </summary>
        /// <remarks>
        /// This is a navigation property for the invitations related to this group.
        /// </remarks>
        public required ICollection<InvitationEntity> Invitations { get; init; } = new List<InvitationEntity>();
    }
}
