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