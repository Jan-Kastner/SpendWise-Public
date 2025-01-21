using System;

namespace SpendWise.DAL.Entities.Interfaces
{
    /// <summary>
    /// Represents an interface for transaction-group-user relationship entities within the SpendWise application.
    /// </summary>
    public interface ITransactionGroupUserEntity : IEntity
    {
        /// <summary>
        /// Gets or sets a value indicating whether the transaction has been read by the user.
        /// </summary>
        bool IsRead { get; init; }

        /// <summary>
        /// Gets or sets the unique identifier for the associated transaction.
        /// </summary>
        Guid TransactionId { get; init; }

        /// <summary>
        /// Gets or sets the transaction entity associated with this relationship.
        /// </summary>
        TransactionEntity Transaction { get; init; }

        /// <summary>
        /// Gets or sets the unique identifier for the associated group-user relationship.
        /// </summary>
        Guid GroupUserId { get; init; }

        /// <summary>
        /// Gets or sets the group-user entity associated with this relationship.
        /// </summary>
        GroupUserEntity GroupUser { get; init; }
    }
}