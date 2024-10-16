using SpendWise.Common.Enums;

namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a transaction type.
    /// </summary>
    public interface ITransactionType
    {
        /// <summary>
        /// Gets or sets the transaction type of the entity.
        /// </summary>
        TransactionType Type { get; init; }
    }
}