namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by group.
    /// Provides methods for specifying group-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface IGroupQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with the specified group ID.
        /// </summary>
        /// <param name="groupId">The group ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithGroup(Guid groupId);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified group ID.
        /// </summary>
        /// <param name="groupId">The group ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithGroup(Guid groupId);

        /// <summary>
        /// Filters the query to exclude items with the specified group ID.
        /// </summary>
        /// <param name="groupId">The group ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithGroup(Guid groupId);
    }
}