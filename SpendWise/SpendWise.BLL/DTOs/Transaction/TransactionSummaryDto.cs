using SpendWise.Common.Enums;
using SpendWise.BLL.DTOs.Interfaces;

namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents a summary of a transaction for listing purposes.
    /// </summary>
    public record TransactionSummaryDto : IQueryableDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the transaction.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the amount of the transaction.
        /// </summary>
        public required decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the date of the transaction.
        /// </summary>
        public required DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the description of the transaction.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the type of the transaction.
        /// </summary>
        public required TransactionType Type { get; set; }

    }
}