namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents a transaction entity within the SpendWise application.
    /// </summary>
    public record TransactionEntity : IEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the transaction.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the amount of the transaction.
        /// </summary>
        public required decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the transaction occurred.
        /// </summary>
        public required DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the description of the transaction. Can be null.
        /// </summary>
        public required string? Description { get; set; }

        /// <summary>
        /// Gets or sets the type of the transaction.
        /// </summary>
        public required int Type { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the category associated with the transaction. Can be null.
        /// </summary>
        public Guid? CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the category entity associated with this transaction. Can be null.
        /// </summary>
        public CategoryEntity? Category { get; init; }

        /// <summary>
        /// Gets the collection of transaction group-user relationships associated with this transaction.
        /// </summary>
        /// <remarks>
        /// This is a navigation property for the group-user relationships related to this transaction.
        /// </remarks>
        public ICollection<TransactionGroupUserEntity> TransactionGroupUsers { get; init; } = new List<TransactionGroupUserEntity>();
    }
}
