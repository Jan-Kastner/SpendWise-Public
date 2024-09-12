namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by amount.
    /// Provides methods for specifying amount-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface IAmountQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with the specified amount.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithAmount(decimal amount);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified amount.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithAmount(decimal amount);

        /// <summary>
        /// Filters the query to exclude items with the specified amount.
        /// </summary>
        /// <param name="amount">The amount to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithAmount(decimal amount);
    }
}