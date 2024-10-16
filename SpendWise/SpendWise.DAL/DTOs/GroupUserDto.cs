using SpendWise.Common.Enums;

namespace SpendWise.DAL.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for a group-user.
    /// </summary>
    public record GroupUserDto : IDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the group-user relationship.
        /// </summary>
        public required Guid Id { get; init; }

        /// <summary>
        /// Gets or sets the user's role within the application (e.g., Admin, User).
        /// </summary>
        public required UserRole Role { get; init; }

        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public required Guid UserId { get; init; }

        /// <summary>
        /// Gets or sets the unique identifier for the group.
        /// </summary>
        public required Guid GroupId { get; init; }

        /// <summary>
        /// Gets or sets the unique identifier for the associated limit, if any.
        /// </summary>
        public required Guid? LimitId { get; init; } = null;

        /// <summary>
        /// Gets or sets the user entity associated with this group-user relationship.
        /// </summary>
        public UserDto? User { get; init; } = null;

        /// <summary>
        /// Gets or sets the group entity associated with this group-user relationship.
        /// </summary>
        public GroupDto? Group { get; init; } = null;

        /// <summary>
        /// Gets or sets the limit entity associated with this group-user relationship. Can be null.
        /// </summary>
        public LimitDto? Limit { get; init; } = null;

        /// <summary>
        /// Gets the collection of transaction group-user relationships associated with this group-user relationship.
        /// </summary>
        public ICollection<TransactionGroupUserDto> TransactionGroupUsers { get; init; } = new List<TransactionGroupUserDto>();
    }
}
