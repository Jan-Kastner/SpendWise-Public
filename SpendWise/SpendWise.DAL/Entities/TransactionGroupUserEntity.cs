namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents a transaction-group-user relationship entity within the SpendWise application.
    /// </summary>
    public record TransactionGroupUserEntity : ITransactionGroupUserEntity
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
        public required Guid TransactionId { get; init; }

        /// <summary>
        /// Gets or sets the transaction entity associated with this relationship.
        /// </summary>
        public required TransactionEntity Transaction { get; init; }

        /// <summary>
        /// Gets or sets the unique identifier for the associated group-user relationship.
        /// </summary>
        public required Guid GroupUserId { get; init; }

        /// <summary>
        /// Gets or sets the group-user entity associated with this relationship.
        /// </summary>
        public required GroupUserEntity GroupUser { get; init; }
    }
}
