namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by password.
    /// Provides methods for specifying password-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface IPasswordQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with the specified password.
        /// </summary>
        /// <param name="password">The password to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithPassword(string password);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified password.
        /// </summary>
        /// <param name="password">The password to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithPassword(string password);

        /// <summary>
        /// Filters the query to exclude items with the specified password.
        /// </summary>
        /// <param name="password">The password to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithPassword(string password);
    }
}