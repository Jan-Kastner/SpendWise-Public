using System.ComponentModel.DataAnnotations;

namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents a category entity within the SpendWise application.
    /// </summary>
    public record CategoryEntity : IEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the category.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the category. Must be at least 2 characters long.
        /// </summary>
        [MinLength(2)]
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the category. Can be null.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the color associated with the category. Must be at most 9 characters long.
        /// </summary>
        [MaxLength(9)]
        public required string Color { get; set; }

        /// <summary>
        /// Gets or sets the icon for the category. Can be null.
        /// </summary>
        public byte[]? Icon { get; set; }

        /// <summary>
        /// Gets the collection of transactions associated with this category.
        /// </summary>
        /// <remarks>
        /// This is a navigation property for the transactions related to this category.
        /// </remarks>
        public ICollection<TransactionEntity> Transactions { get; init; } = new List<TransactionEntity>();
    }
}
