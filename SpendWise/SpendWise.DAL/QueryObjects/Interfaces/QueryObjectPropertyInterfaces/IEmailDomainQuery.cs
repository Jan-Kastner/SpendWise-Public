namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by email domain.
    /// Provides methods for specifying email domain-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface IEmailDomainQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with the specified email domain.
        /// </summary>
        /// <param name="domain">The email domain to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithEmailDomain(string domain);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified email domain.
        /// </summary>
        /// <param name="domain">The email domain to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithEmailDomain(string domain);

        /// <summary>
        /// Filters the query to exclude items with the specified email domain.
        /// </summary>
        /// <param name="domain">The email domain to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithEmailDomain(string domain);
    }
}