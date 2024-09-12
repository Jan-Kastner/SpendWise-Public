namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by email confirmation status.
    /// Provides methods for specifying email confirmation-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface IEmailConfirmedQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with email confirmed.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        T WithEmailConfirmed();

        /// <summary>
        /// Adds an OR condition to the query to include items with email confirmed.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithEmailConfirmed();

        /// <summary>
        /// Filters the query to exclude items with email confirmed.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithEmailConfirmed();

        /// <summary>
        /// Filters the query to include items without email confirmed.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        T WithoutEmailConfirmed();

        /// <summary>
        /// Adds an OR condition to the query to include items without email confirmed.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithoutEmailConfirmed();

        /// <summary>
        /// Filters the query to exclude items without email confirmed.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithoutEmailConfirmed();
    }
}