using System;

namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by category.
    /// Provides methods for specifying category-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface ICategoryQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with the specified category.
        /// </summary>
        /// <param name="categoryId">The category ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithCategory(Guid categoryId);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified category.
        /// </summary>
        /// <param name="categoryId">The category ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithCategory(Guid categoryId);

        /// <summary>
        /// Filters the query to exclude items with the specified category.
        /// </summary>
        /// <param name="categoryId">The category ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithCategory(Guid categoryId);

        /// <summary>
        /// Filters the query to include items without any category.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        T WithoutCategory();

        /// <summary>
        /// Adds an OR condition to the query to include items without any category.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithoutCategory();

        /// <summary>
        /// Filters the query to exclude items without any category.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithoutCategory();
    }
}