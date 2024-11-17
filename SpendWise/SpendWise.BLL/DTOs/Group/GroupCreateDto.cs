using SpendWise.BLL.DTOs.Interfaces;

namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for creating a group.
    /// </summary>
    public record GroupCreateDto : ICreatableDto
    {
        /// <summary>
        /// Gets or sets the name of the group.
        /// </summary>
        public required string Name { get; init; }

        /// <summary>
        /// Gets or sets the description of the group. Can be null.
        /// </summary>
        public string? Description { get; init; } = null;
    }
}