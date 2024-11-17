using SpendWise.BLL.DTOs.Interfaces;

namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents a summary of a group for listing purposes.
    /// </summary>
    public record GroupListDto : IQueryableDto
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
        public IEnumerable<UserSummaryDto> GroupParticipants { get; init; } = new List<UserSummaryDto>();
    }
}