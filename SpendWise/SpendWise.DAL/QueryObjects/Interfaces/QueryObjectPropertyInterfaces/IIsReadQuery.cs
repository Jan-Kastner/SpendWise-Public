namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by read status.
    /// Provides methods for specifying read status-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface IIsReadQuery<T>
    {
        /// <summary>
        /// Filters the query to include items that are read.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        T IsRead();

        /// <summary>
        /// Adds an OR condition to the query to include items that are read.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrIsRead();

        /// <summary>
        /// Filters the query to exclude items that are read.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotIsRead();

        /// <summary>
        /// Filters the query to include items that are not read.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        T IsNotRead();

        /// <summary>
        /// Adds an OR condition to the query to include items that are not read.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrIsNotRead();

        /// <summary>
        /// Filters the query to exclude items that are not read.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotIsNotRead();
    }
}