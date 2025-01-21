namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by date.
    /// Provides methods for specifying date-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface IDateQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with the specified date.
        /// </summary>
        /// <param name="date">The date to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithDate(DateTime date);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified date.
        /// </summary>
        /// <param name="date">The date to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithDate(DateTime date);

        /// <summary>
        /// Filters the query to exclude items with the specified date.
        /// </summary>
        /// <param name="date">The date to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithDate(DateTime date);
    }
}