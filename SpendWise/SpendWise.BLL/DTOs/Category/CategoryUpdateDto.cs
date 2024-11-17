using SpendWise.BLL.DTOs.Interfaces;

namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for updating a category.
    /// </summary>
    public record CategoryUpdateDto : IUpdatableDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the category.
        /// </summary>
        public required Guid Id { get; init; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public required string Name { get; init; }

        /// <summary>
        /// Gets or sets the description of the category. Can be null.
        /// </summary>
        public required string? Description { get; init; }

        /// <summary>
        /// Gets or sets the color associated with the category.
        /// </summary>
        public required string Color { get; init; }

        /// <summary>
        /// Gets or sets the icon for the category. Can be null.
        /// </summary>
        public required byte[] Icon { get; init; }
    }
}