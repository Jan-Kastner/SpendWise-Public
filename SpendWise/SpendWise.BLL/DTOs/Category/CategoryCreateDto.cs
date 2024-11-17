using SpendWise.BLL.DTOs.Interfaces;

namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for creating a category.
    /// </summary>
    public record CategoryCreateDto : ICreatableDto
    {
        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public required string Name { get; init; }

        /// <summary>
        /// Gets or sets the description of the category. Can be null.
        /// </summary>
        public string? Description { get; init; } = null;

        /// <summary>
        /// Gets or sets the color associated with the category.
        /// </summary>
        public required string Color { get; init; }

        /// <summary>
        /// Gets or sets the icon for the category. Can be null.
        /// </summary>
        public byte[] Icon { get; init; } = new byte[] { };
    }
}