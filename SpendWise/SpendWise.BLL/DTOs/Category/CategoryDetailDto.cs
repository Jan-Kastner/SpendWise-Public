namespace SpendWise.BLL.DTOs.Category
{
    /// <summary>
    /// Represents a detailed data transfer object (DTO) for a category.
    /// </summary>
    public record CategoryDetailDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the category.
        /// </summary>
        public Guid Id { get; set; }

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