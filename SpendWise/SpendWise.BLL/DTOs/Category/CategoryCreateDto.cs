using SpendWise.Common.Enums;

namespace SpendWise.BLL.DTOs.Category
{
    /// <summary>
    /// Represents a data transfer object (DTO) for creating a category.
    /// </summary>
    public record CategoryCreateDto
    {
        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the category. Can be null.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the color associated with the category.
        /// </summary>
        public required string Color { get; set; }

        /// <summary>
        /// Gets or sets the icon for the category. Can be null.
        /// </summary>
        public required byte[] Icon { get; set; }
    }
}