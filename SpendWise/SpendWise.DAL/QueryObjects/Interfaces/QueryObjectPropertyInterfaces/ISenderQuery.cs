namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by sender.
    /// Provides methods for specifying sender-based query conditions.
    /// </summary>
    /// <typeparam name="TReturn">The type of the query object.</typeparam>
    public interface ISenderQuery<TReturn>
    {
        /// <summary>
        /// Filters the query to include items with the specified sender ID.
        /// </summary>
        /// <param name="senderId">The sender ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        TReturn WithSender(Guid senderId);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified sender ID.
        /// </summary>
        /// <param name="senderId">The sender ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        TReturn OrWithSender(Guid senderId);

        /// <summary>
        /// Filters the query to exclude items with the specified sender ID.
        /// </summary>
        /// <param name="senderId">The sender ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        TReturn NotWithSender(Guid senderId);
    }
}