namespace SpendWise.BLL.DTOs.Category
{
    /// <summary>
    /// Represents a list data transfer object (DTO) for a category.
    /// </summary>
    public record CategoryListDto
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
        /// Gets or sets the color associated with the category.
        /// </summary>
        public required string Color { get; set; }
    }
}