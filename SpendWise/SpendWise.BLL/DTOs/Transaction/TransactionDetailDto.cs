using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.Common.Enums;

namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents detailed information about a transaction.
    /// </summary>
    public record TransactionDetailDto : IQueryableDto
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
        /// Gets or sets the unique identifier for the category associated with the transaction. Can be null.
        /// </summary>
        public Guid? CategoryId { get; init; } = null;

        /// <summary>
        /// Gets the collection of transaction group-user relationships associated with this transaction.
        /// </summary>
        public CategorySummaryDto? Category { get; init; }
        /// <remarks>
        /// This is a navigation property for the group-user relationships related to this transaction.
        /// </remarks>
        public ICollection<GroupListDto> Groups { get; init; } = new List<GroupListDto>();

        /// <remarks>
        /// This is a navigation property for the group-user relationships related to this transaction.
        /// </remarks>
        public UserSummaryDto? User { get; init; } = null;
    }
}