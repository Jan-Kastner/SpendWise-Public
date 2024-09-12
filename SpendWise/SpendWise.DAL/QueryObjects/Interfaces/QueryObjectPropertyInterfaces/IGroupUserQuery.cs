namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by group user.
    /// Provides methods for specifying group user-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface IGroupUserQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with the specified group user ID.
        /// </summary>
        /// <param name="groupUserId">The group user ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithGroupUser(Guid groupUserId);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified group user ID.
        /// </summary>
        /// <param name="groupUserId">The group user ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithGroupUser(Guid groupUserId);

        /// <summary>
        /// Filters the query to exclude items with the specified group user ID.
        /// </summary>
        /// <param name="groupUserId">The group user ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithGroupUser(Guid groupUserId);
    }
}