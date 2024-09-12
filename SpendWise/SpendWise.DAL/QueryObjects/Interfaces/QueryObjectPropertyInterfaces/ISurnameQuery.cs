namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by surname.
    /// Provides methods for specifying surname-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface ISurnameQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with the specified surname.
        /// </summary>
        /// <param name="surname">The surname to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithSurname(string surname);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified surname.
        /// </summary>
        /// <param name="surname">The surname to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithSurname(string surname);

        /// <summary>
        /// Filters the query to exclude items with the specified surname.
        /// </summary>
        /// <param name="surname">The surname to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithSurname(string surname);

        /// <summary>
        /// Filters the query to include items with a partial match of the specified text in the surname.
        /// </summary>
        /// <param name="text">The text to partially match in the surname.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithSurnamePartialMatch(string text);

        /// <summary>
        /// Adds an OR condition to the query to include items with a partial match of the specified text in the surname.
        /// </summary>
        /// <param name="text">The text to partially match in the surname.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithSurnamePartialMatch(string text);

        /// <summary>
        /// Filters the query to exclude items with a partial match of the specified text in the surname.
        /// </summary>
        /// <param name="text">The text to partially match in the surname.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithSurnamePartialMatch(string text);
    }
}