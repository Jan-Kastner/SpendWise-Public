namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by two-factor authentication status.
    /// Provides methods for specifying two-factor authentication-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface ITwoFactorEnabledQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with two-factor authentication enabled.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        T WithTwoFactorEnabled();

        /// <summary>
        /// Adds an OR condition to the query to include items with two-factor authentication enabled.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithTwoFactorEnabled();

        /// <summary>
        /// Filters the query to exclude items with two-factor authentication enabled.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithTwoFactorEnabled();

        /// <summary>
        /// Filters the query to include items without two-factor authentication enabled.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        T WithoutTwoFactorEnabled();

        /// <summary>
        /// Adds an OR condition to the query to include items without two-factor authentication enabled.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithoutTwoFactorEnabled();

        /// <summary>
        /// Filters the query to exclude items without two-factor authentication enabled.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithoutTwoFactorEnabled();
    }
}