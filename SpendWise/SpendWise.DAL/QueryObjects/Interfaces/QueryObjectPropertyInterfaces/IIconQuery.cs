namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by icon.
    /// Provides methods for specifying icon-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface IIconQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with an icon.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        T WithIcon();

        /// <summary>
        /// Adds an OR condition to the query to include items with an icon.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithIcon();

        /// <summary>
        /// Filters the query to exclude items with an icon.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithIcon();

        /// <summary>
        /// Filters the query to include items without an icon.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        T WithoutIcon();

        /// <summary>
        /// Adds an OR condition to the query to include items without an icon.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithoutIcon();

        /// <summary>
        /// Filters the query to exclude items without an icon.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithoutIcon();
    }
}