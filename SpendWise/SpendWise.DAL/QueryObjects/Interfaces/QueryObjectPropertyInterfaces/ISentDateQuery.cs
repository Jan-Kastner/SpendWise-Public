namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by sent date.
    /// Provides methods for specifying sent date-based query conditions.
    /// </summary>
    /// <typeparam name="TReturn">The type of the query object.</typeparam>
    public interface ISentDateQuery<TReturn>
    {
        /// <summary>
        /// Filters the query to include items with the specified sent date.
        /// </summary>
        /// <param name="sentDate">The sent date to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        TReturn WithSentDate(DateTime sentDate);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified sent date.
        /// </summary>
        /// <param name="sentDate">The sent date to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        TReturn OrWithSentDate(DateTime sentDate);

        /// <summary>
        /// Filters the query to exclude items with the specified sent date.
        /// </summary>
        /// <param name="sentDate">The sent date to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        TReturn NotWithSentDate(DateTime sentDate);
    }
}