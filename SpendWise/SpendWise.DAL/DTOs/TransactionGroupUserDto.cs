namespace SpendWise.DAL.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for a transaction-group-user.
    /// </summary>
    public record TransactionGroupUserDto : IDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the transaction-group-user relationship.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the transaction has been read by the user.
        /// </summary>
        public required bool IsRead { get; set; } = false;

        /// <summary>
        /// Gets or sets the unique identifier for the associated transaction.
        /// </summary>
        public required Guid TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the associated group-user relationship.
        /// </summary>
        public required Guid GroupUserId { get; set; }
    }
}
