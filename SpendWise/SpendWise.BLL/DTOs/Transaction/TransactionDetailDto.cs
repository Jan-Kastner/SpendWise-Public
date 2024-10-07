using SpendWise.Common.Enums;

namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents detailed information about a transaction.
    /// </summary>
    public record TransactionDetailDto
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

        /// <summary>
        /// Gets or sets the unique identifier of the category associated with the transaction, if any.
        /// </summary>
        public Guid? CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the category associated with the transaction, if any.
        /// </summary>
        public CategoryListDto? Category { get; init; }

        /// <summary>
        /// Gets or sets the list of group users associated with the transaction.
        /// </summary>
        public IEnumerable<TransactionGroupUserListDto> TransactionGroupUsers { get; set; } = new List<TransactionGroupUserListDto>();
    }
}