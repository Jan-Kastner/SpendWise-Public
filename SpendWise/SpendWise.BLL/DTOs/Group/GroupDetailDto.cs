using SpendWise.BLL.DTOs.Interfaces;

namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents detailed information about a group.
    /// </summary>
    public record GroupDetailDto : IQueryableDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the group.
        /// </summary>
        public required Guid Id { get; init; }

        /// <summary>
        /// Gets or sets the name of the group.
        /// </summary>
        public required string Name { get; init; }

        /// <summary>
        /// Gets or sets the description of the group.
        /// </summary>
        public required string? Description { get; init; }

        /// <summary>
        /// Gets or sets the list of users associated with the group.
        /// </summary>
        public IEnumerable<UserListDto> GroupParticipants { get; init; } = new List<UserListDto>();
    }
}