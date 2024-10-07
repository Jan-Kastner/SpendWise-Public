namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents a summary of a transaction group user for listing purposes.
    /// </summary>
    public record TransactionGroupUserListDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the transaction group user.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the transaction has been read.
        /// </summary>
        public required bool IsRead { get; set; } = false;

        /// <summary>
        /// Gets or sets the transaction associated with the group user.
        /// </summary>
        public required TransactionListDto Transaction { get; init; }

        /// <summary>
        /// Gets or sets the group user associated with the transaction.
        /// </summary>
        public required GroupUserListDto GroupUser { get; init; }
    }
}