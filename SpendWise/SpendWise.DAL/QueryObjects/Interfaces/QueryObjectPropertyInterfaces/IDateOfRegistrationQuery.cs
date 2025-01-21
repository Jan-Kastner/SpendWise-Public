namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by date of registration.
    /// Provides methods for specifying date of registration-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface IDateOfRegistrationQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with the specified date of registration.
        /// </summary>
        /// <param name="dateOfRegistration">The date of registration to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithDateOfRegistration(DateTime dateOfRegistration);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified date of registration.
        /// </summary>
        /// <param name="dateOfRegistration">The date of registration to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithDateOfRegistration(DateTime dateOfRegistration);

        /// <summary>
        /// Filters the query to exclude items with the specified date of registration.
        /// </summary>
        /// <param name="dateOfRegistration">The date of registration to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithDateOfRegistration(DateTime dateOfRegistration);
    }
}