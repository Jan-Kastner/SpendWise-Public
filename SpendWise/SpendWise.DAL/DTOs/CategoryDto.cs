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
        public required Guid Id { get; init; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public required string Name { get; init; }

        /// <summary>
        /// Gets or sets the description of the category. Can be null.
        /// </summary>
        public required string? Description { get; init; } = null;

        /// <summary>
        /// Gets or sets the color associated with the category.
        /// </summary>
        public required string Color { get; init; }

        /// <summary>
        /// Gets or sets the icon for the category. Can be null.
        /// </summary>
        public required byte[] Icon { get; init; }

        /// <summary>
        /// Gets or sets the collection of transactions associated with this category.
        /// </summary>
        public ICollection<TransactionDto> Transactions { get; init; } = Array.Empty<TransactionDto>();
    }
}
