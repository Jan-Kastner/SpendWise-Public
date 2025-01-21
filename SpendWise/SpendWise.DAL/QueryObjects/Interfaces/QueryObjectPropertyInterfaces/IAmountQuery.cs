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
        T WithAmountEqual(decimal amount);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified amount.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithAmountEqual(decimal amount);

        /// <summary>
        /// Filters the query to exclude items with the specified amount.
        /// </summary>
        /// <param name="amount">The amount to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithAmountEqual(decimal amount);

        /// <summary>
        /// Filters the query to include items with the amount greater than the specified value.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithAmountGreaterThan(decimal amount);

        /// <summary>
        /// Adds an OR condition to the query to include items with the amount greater than the specified value.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithAmountGreaterThan(decimal amount);

        /// <summary>
        /// Filters the query to exclude items with the amount greater than the specified value.
        /// </summary>
        /// <param name="amount">The amount to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithAmountGreaterThan(decimal amount);

        /// <summary>
        /// Filters the query to include items with the amount less than the specified value.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithAmountLessThan(decimal amount);

        /// <summary>
        /// Adds an OR condition to the query to include items with the amount less than the specified value.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithAmountLessThan(decimal amount);

        /// <summary>
        /// Filters the query to exclude items with the amount less than the specified value.
        /// </summary>
        /// <param name="amount">The amount to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithAmountLessThan(decimal amount);
    }
}