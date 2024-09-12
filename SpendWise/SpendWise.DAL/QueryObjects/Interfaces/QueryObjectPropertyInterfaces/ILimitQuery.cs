namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by limit.
    /// Provides methods for specifying limit-based query conditions.
    /// </summary>
    /// <typeparam name="TReturn">The type of the query object.</typeparam>
    public interface ILimitQuery<TReturn>
    {
        /// <summary>
        /// Filters the query to include items with the specified limit ID.
        /// </summary>
        /// <param name="limitId">The limit ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        TReturn WithLimit(Guid? limitId);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified limit ID.
        /// </summary>
        /// <param name="limitId">The limit ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        TReturn OrWithLimit(Guid? limitId);

        /// <summary>
        /// Filters the query to exclude items with the specified limit ID.
        /// </summary>
        /// <param name="limitId">The limit ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        TReturn NotWithLimit(Guid? limitId);
    }
}