using SpendWise.BLL.DTOs.Interfaces;

namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for updating a group.
    /// </summary>
    public record GroupUpdateDto : IUpdatableDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the group.
        /// </summary>
        public required Guid Id { get; init; }

        /// <summary>
        /// Gets or sets the name of the group.
        /// </summary>
        public required string Name { get; init; }

        /// <summary>
        /// Gets or sets the description of the group. Can be null.
        /// </summary>
        public required string? Description { get; init; }
    }
}