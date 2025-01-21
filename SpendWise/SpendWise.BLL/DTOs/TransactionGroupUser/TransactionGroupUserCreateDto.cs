using SpendWise.BLL.DTOs.Interfaces;

namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for creating a transaction-group-user relationship.
    /// </summary>
    public record TransactionGroupUserCreateDto : ICreatableDto
    {
        /// <summary>
        /// Gets or sets a value indicating whether the transaction has been read by the user.
        /// </summary>
        public required bool IsRead { get; init; } = false;

        /// <summary>
        /// Gets or sets the unique identifier for the associated transaction.
        /// </summary>
        public required Guid TransactionId { get; init; }

        /// <summary>
        /// Gets or sets the unique identifier for the associated group-user relationship.
        /// </summary>
        public required Guid GroupUserId { get; init; }
    }
}