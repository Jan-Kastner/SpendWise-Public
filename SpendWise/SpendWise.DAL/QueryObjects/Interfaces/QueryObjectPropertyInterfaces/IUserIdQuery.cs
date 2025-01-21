namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by user.
    /// Provides methods for specifying user-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface IUserIdQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with the specified user ID.
        /// </summary>
        /// <param name="userId">The user ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithUser(Guid userId);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user ID.
        /// </summary>
        /// <param name="userId">The user ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithUser(Guid userId);

        /// <summary>
        /// Filters the query to exclude items with the specified user ID.
        /// </summary>
        /// <param name="userId">The user ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithUser(Guid userId);
    }
}