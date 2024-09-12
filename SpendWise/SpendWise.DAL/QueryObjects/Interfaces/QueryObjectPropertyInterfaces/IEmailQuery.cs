namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by email.
    /// Provides methods for specifying email-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface IEmailQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with the specified email.
        /// </summary>
        /// <param name="email">The email to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithEmail(string email);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified email.
        /// </summary>
        /// <param name="email">The email to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithEmail(string email);

        /// <summary>
        /// Filters the query to exclude items with the specified email.
        /// </summary>
        /// <param name="email">The email to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithEmail(string email);
    }
}