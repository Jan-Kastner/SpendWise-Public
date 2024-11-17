using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.Common.Enums;

namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents a summary of a transaction for listing purposes.
    /// </summary>
    public record TransactionListDto : IQueryableDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the transaction.
        /// </summary>
        public required Guid Id { get; init; }

        /// <summary>
        /// Gets or sets the amount of the transaction.
        /// </summary>
        public required decimal Amount { get; init; }

        /// <summary>
        /// Gets or sets the date and time when the transaction occurred.
        /// </summary>
        public required DateTime Date { get; init; }

        /// <summary>
        /// Gets or sets the description of the transaction. Can be null.
        /// </summary>
        public required string? Description { get; init; }

        /// <summary>
        /// Gets or sets the type of the transaction.
        /// </summary>
        public required TransactionType Type { get; init; }

        /// <summary>
        /// Gets or sets a value indicating whether the transaction has been read by the user.
        /// </summary>
        public required bool IsRead { get; init; } = false;

        /// <summary>
        /// Gets or sets the category associated with the transaction.
        /// </summary>
        public CategoryListDto? Category { get; init; }

        /// <summary>
        /// Gets or sets the unique identifier for the category associated with the transaction. Can be null.
        /// </summary>
        public required Guid? CategoryId { get; init; } = null;
    }
}