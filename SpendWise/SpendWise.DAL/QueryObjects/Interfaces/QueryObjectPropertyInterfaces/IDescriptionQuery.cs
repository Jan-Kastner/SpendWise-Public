namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by description.
    /// Provides methods for specifying description-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface IDescriptionQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with the specified description.
        /// </summary>
        /// <param name="description">The description to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithDescription(string description);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified description.
        /// </summary>
        /// <param name="description">The description to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithDescription(string description);

        /// <summary>
        /// Filters the query to exclude items with the specified description.
        /// </summary>
        /// <param name="description">The description to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithDescription(string description);

        /// <summary>
        /// Filters the query to include items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithDescriptionPartialMatch(string text);

        /// <summary>
        /// Adds an OR condition to the query to include items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithDescriptionPartialMatch(string text);

        /// <summary>
        /// Filters the query to exclude items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithDescriptionPartialMatch(string text);

        /// <summary>
        /// Filters the query to include items without any description.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        T WithoutDescription();

        /// <summary>
        /// Adds an OR condition to the query to include items without any description.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithoutDescription();

        /// <summary>
        /// Filters the query to exclude items without any description.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithoutDescription();
    }
}