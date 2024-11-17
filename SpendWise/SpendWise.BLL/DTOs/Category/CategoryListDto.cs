using SpendWise.BLL.DTOs.Interfaces;

namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents a summary of a category for listing purposes.
    /// </summary>
    public record CategoryListDto : IQueryableDto
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
        /// Gets or sets the color associated with the category.
        /// </summary>
        public required string Color { get; init; }

        /// <summary>
        /// Gets or sets the icon representing the category.
        /// </summary>
        public required byte[] Icon { get; init; }
    }
}