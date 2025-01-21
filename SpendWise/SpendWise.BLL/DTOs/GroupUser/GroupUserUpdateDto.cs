using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.Common.Enums;

namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for updating a group-user relationship.
    /// </summary>
    public record GroupUserUpdateDto : IUpdatableDto
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
        public Guid? LimitId { get; init; } = null;
    }
}