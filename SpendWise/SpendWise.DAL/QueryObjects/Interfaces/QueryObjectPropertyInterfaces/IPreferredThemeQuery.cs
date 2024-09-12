using SpendWise.Common.Enums;

namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by preferred theme.
    /// Provides methods for specifying preferred theme-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface IPreferredThemeQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with the specified preferred theme.
        /// </summary>
        /// <param name="theme">The preferred theme to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithPreferredTheme(Theme theme);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified preferred theme.
        /// </summary>
        /// <param name="theme">The preferred theme to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithPreferredTheme(Theme theme);

        /// <summary>
        /// Filters the query to exclude items with the specified preferred theme.
        /// </summary>
        /// <param name="theme">The preferred theme to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithPreferredTheme(Theme theme);
    }
}