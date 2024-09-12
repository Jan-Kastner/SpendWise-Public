namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by acceptance status.
    /// Provides methods for specifying acceptance status-based query conditions.
    /// </summary>
    /// <typeparam name="TReturn">The type of the query object.</typeparam>
    public interface IIsAcceptedQuery<TReturn>
    {
        /// <summary>
        /// Filters the query to include items that are accepted.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        TReturn IsAccepted();

        /// <summary>
        /// Adds an OR condition to the query to include items that are accepted.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        TReturn OrIsAccepted();

        /// <summary>
        /// Filters the query to exclude items that are accepted.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        TReturn NotIsAccepted();

        /// <summary>
        /// Filters the query to include items that are not accepted.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        TReturn IsNotAccepted();

        /// <summary>
        /// Adds an OR condition to the query to include items that are not accepted.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        TReturn OrIsNotAccepted();

        /// <summary>
        /// Filters the query to exclude items that are not accepted.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        TReturn NotIsNotAccepted();

        /// <summary>
        /// Filters the query to include items that are pending.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        TReturn IsPending();

        /// <summary>
        /// Adds an OR condition to the query to include items that are pending.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        TReturn OrIsPending();

        /// <summary>
        /// Filters the query to exclude items that are pending.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        TReturn NotIsPending();
    }
}