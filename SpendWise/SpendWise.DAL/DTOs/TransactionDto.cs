namespace SpendWise.DAL.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for a transaction.
    /// </summary>
    public record TransactionDto : IDto
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
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the type of the transaction.
        /// </summary>
        public required int Type { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the category associated with the transaction. Can be null.
        /// </summary>
        public Guid? CategoryId { get; set; }
    }
}
