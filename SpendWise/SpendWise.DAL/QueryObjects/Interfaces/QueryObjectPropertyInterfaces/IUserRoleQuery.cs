using SpendWise.Common.Enums;

namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by user role.
    /// Provides methods for specifying user role-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface IUserRoleQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with the specified user role.
        /// </summary>
        /// <param name="role">The user role to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithUserRole(UserRole role);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user role.
        /// </summary>
        /// <param name="role">The user role to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithUserRole(UserRole role);

        /// <summary>
        /// Filters the query to exclude items with the specified user role.
        /// </summary>
        /// <param name="role">The user role to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithUserRole(UserRole role);
    }
}