namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by reset password token.
    /// Provides methods for specifying reset password token-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface IResetPasswordTokenQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with the specified reset password token.
        /// </summary>
        /// <param name="token">The reset password token to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithResetPasswordToken(string token);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified reset password token.
        /// </summary>
        /// <param name="token">The reset password token to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithResetPasswordToken(string token);

        /// <summary>
        /// Filters the query to exclude items with the specified reset password token.
        /// </summary>
        /// <param name="token">The reset password token to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithResetPasswordToken(string token);

        /// <summary>
        /// Filters the query to include items without a reset password token.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        T WithoutResetPasswordToken();

        /// <summary>
        /// Adds an OR condition to the query to include items without a reset password token.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithoutResetPasswordToken();

        /// <summary>
        /// Filters the query to exclude items without a reset password token.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithoutResetPasswordToken();
    }
}