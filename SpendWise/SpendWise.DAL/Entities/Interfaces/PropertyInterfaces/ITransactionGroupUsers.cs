namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a collection of transaction group users.
    /// </summary>
    public interface ITransactionGroupUsers
    {
        /// <summary>
        /// Gets the collection of transaction group users of the entity.
        /// </summary>
        ICollection<TransactionGroupUserEntity> TransactionGroupUsers { get; init; }
    }
}