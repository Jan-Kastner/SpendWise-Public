using System;
using System.Collections.Generic;
using SpendWise.Common.Enums;

namespace SpendWise.DAL.Entities.Interfaces
{
    /// <summary>
    /// Represents an interface for transaction entities within the SpendWise application.
    /// </summary>
    public interface ITransactionEntity : IEntity
    {
        /// <summary>
        /// Gets or sets the amount of the transaction.
        /// </summary>
        decimal Amount { get; init; }

        /// <summary>
        /// Gets or sets the date and time when the transaction occurred.
        /// </summary>
        DateTime Date { get; init; }

        /// <summary>
        /// Gets or sets the description of the transaction. Can be null.
        /// </summary>
        string? Description { get; init; }

        /// <summary>
        /// Gets or sets the type of the transaction.
        /// </summary>
        TransactionType Type { get; init; }

        /// <summary>
        /// Gets or sets the unique identifier for the category associated with the transaction. Can be null.
        /// </summary>
        Guid? CategoryId { get; init; }

        /// <summary>
        /// Gets or sets the category entity associated with this transaction. Can be null.
        /// </summary>
        CategoryEntity? Category { get; init; }

        /// <summary>
        /// Gets the collection of transaction group-user relationships associated with this transaction.
        /// </summary>
        ICollection<TransactionGroupUserEntity> TransactionGroupUsers { get; init; }
    }
}