namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents a transaction-group-user relationship entity within the SpendWise application.
    /// </summary>
    public record TransactionGroupUserEntity : IEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the transaction-group-user relationship.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the associated transaction.
        /// </summary>
        public required Guid TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the transaction entity associated with this relationship.
        /// </summary>
        public required TransactionEntity Transaction { get; init; }

        /// <summary>
        /// Gets or sets the unique identifier for the associated group-user relationship.
        /// </summary>
        public required Guid GroupUserId { get; set; }

        /// <summary>
        /// Gets or sets the group-user entity associated with this relationship.
        /// </summary>
        public required GroupUserEntity GroupUser { get; init; }
    }
}
