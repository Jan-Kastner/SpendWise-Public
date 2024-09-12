namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a transaction ID.
    /// </summary>
    public interface ITransactionId
    {
        /// <summary>
        /// Gets the transaction ID of the entity.
        /// </summary>
        Guid TransactionId { get; init; }
    }
}