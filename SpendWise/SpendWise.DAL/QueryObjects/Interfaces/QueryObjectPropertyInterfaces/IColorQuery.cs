namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by color.
    /// Provides methods for specifying color-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface IColorQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with the specified color.
        /// </summary>
        /// <param name="color">The color to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithColor(string color);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified color.
        /// </summary>
        /// <param name="color">The color to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithColor(string color);

        /// <summary>
        /// Filters the query to exclude items with the specified color.
        /// </summary>
        /// <param name="color">The color to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithColor(string color);
    }
}