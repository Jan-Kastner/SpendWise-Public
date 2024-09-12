namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by receiver.
    /// Provides methods for specifying receiver-based query conditions.
    /// </summary>
    /// <typeparam name="TReturn">The type of the query object.</typeparam>
    public interface IReceiverQuery<TReturn>
    {
        /// <summary>
        /// Filters the query to include items with the specified receiver ID.
        /// </summary>
        /// <param name="receiverId">The receiver ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        TReturn WithReceiver(Guid receiverId);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified receiver ID.
        /// </summary>
        /// <param name="receiverId">The receiver ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        TReturn OrWithReceiver(Guid receiverId);

        /// <summary>
        /// Filters the query to exclude items with the specified receiver ID.
        /// </summary>
        /// <param name="receiverId">The receiver ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        TReturn NotWithReceiver(Guid receiverId);
    }
}