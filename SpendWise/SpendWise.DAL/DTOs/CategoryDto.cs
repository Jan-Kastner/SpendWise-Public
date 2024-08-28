using System.ComponentModel.DataAnnotations;
namespace SpendWise.DAL.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for a category.
    /// </summary>
    public record CategoryDto : IDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the category.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the category. Can be null.
        /// </summary>
        public required string? Description { get; set; }

        /// <summary>
        /// Gets or sets the color associated with the category.
        /// </summary>
        public required string Color { get; set; }

        /// <summary>
        /// Gets or sets the icon for the category. Can be null.
        /// </summary>
        public required byte[]? Icon { get; set; }
    }
}
