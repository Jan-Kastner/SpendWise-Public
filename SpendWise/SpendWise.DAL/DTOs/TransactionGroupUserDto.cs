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
        public required Guid Id { get; init; }

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

        /// <summary>
        /// Gets or sets the transaction entity associated with this relationship.
        /// </summary>
        public TransactionDto? Transaction { get; init; } = null;

        /// <summary>
        /// Gets or sets the group-user entity associated with this relationship.
        /// </summary>
        public GroupUserDto? GroupUser { get; init; }
    }
}
