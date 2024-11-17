using SpendWise.BLL.DTOs.Interfaces;

namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents detailed information about a category.
    /// </summary>
    public record CategoryDetailDto : IQueryableDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the category.
        /// </summary>
        public required Guid Id { get; init; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public required string Name { get; init; }

        /// <summary>
        /// Gets or sets the description of the category.
        /// </summary>
        public required string? Description { get; init; }

        /// <summary>
        /// Gets or sets the color associated with the category.
        /// </summary>
        public required string Color { get; init; }

        /// <summary>
        /// Gets or sets the icon representing the category.
        /// </summary>
        public required byte[] Icon { get; init; }
    }
}