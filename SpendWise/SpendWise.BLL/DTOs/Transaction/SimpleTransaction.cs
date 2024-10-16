using SpendWise.Common.Enums;
using SpendWise.BLL.DTOs.Interfaces;

namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents a summary of a transaction for listing purposes.
    /// </summary>
    public record SimpleTransaction : IQueryableDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the transaction.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the amount of the transaction.
        /// </summary>
        public required decimal Amount { get; set; }

    }
}