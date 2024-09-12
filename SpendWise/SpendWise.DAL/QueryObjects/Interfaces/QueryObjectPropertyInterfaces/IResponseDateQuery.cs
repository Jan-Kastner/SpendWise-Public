namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by response date.
    /// Provides methods for specifying response date-based query conditions.
    /// </summary>
    /// <typeparam name="TReturn">The type of the query object.</typeparam>
    public interface IResponseDateQuery<TReturn>
    {
        /// <summary>
        /// Filters the query to include items with the specified response date.
        /// </summary>
        /// <param name="responseDate">The response date to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        TReturn WithResponseDate(DateTime? responseDate);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified response date.
        /// </summary>
        /// <param name="responseDate">The response date to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        TReturn OrWithResponseDate(DateTime? responseDate);

        /// <summary>
        /// Filters the query to exclude items with the specified response date.
        /// </summary>
        /// <param name="responseDate">The response date to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        TReturn NotWithResponseDate(DateTime? responseDate);
    }
}