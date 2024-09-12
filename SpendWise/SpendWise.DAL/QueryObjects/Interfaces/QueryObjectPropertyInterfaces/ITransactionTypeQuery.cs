using SpendWise.Common.Enums;

namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by transaction type.
    /// Provides methods for specifying transaction type-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface ITransactionTypeQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with the specified transaction type.
        /// </summary>
        /// <param name="type">The transaction type to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithType(TransactionType type);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified transaction type.
        /// </summary>
        /// <param name="type">The transaction type to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithType(TransactionType type);

        /// <summary>
        /// Filters the query to exclude items with the specified transaction type.
        /// </summary>
        /// <param name="type">The transaction type to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithType(TransactionType type);
    }
}