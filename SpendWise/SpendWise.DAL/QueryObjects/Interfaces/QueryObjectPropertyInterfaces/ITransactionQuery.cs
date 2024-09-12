using System;

namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by transaction.
    /// Provides methods for specifying transaction-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface ITransactionQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with the specified transaction ID.
        /// </summary>
        /// <param name="transactionId">The transaction ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithTransaction(Guid transactionId);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified transaction ID.
        /// </summary>
        /// <param name="transactionId">The transaction ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithTransaction(Guid transactionId);

        /// <summary>
        /// Filters the query to exclude items with the specified transaction ID.
        /// </summary>
        /// <param name="transactionId">The transaction ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithTransaction(Guid transactionId);
    }
}