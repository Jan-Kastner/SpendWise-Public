namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by full name.
    /// Provides methods for specifying full name-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface IFullNameQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with the specified full name.
        /// </summary>
        /// <param name="fullName">The full name to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithFullName(string fullName);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified full name.
        /// </summary>
        /// <param name="fullName">The full name to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithFullName(string fullName);

        /// <summary>
        /// Filters the query to exclude items with the specified full name.
        /// </summary>
        /// <param name="fullName">The full name to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithFullName(string fullName);
    }
}