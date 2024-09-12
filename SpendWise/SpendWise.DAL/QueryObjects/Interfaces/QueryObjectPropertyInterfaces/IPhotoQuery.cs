namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by photo.
    /// Provides methods for specifying photo-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface IPhotoQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with a photo.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        T WithPhoto();

        /// <summary>
        /// Adds an OR condition to the query to include items with a photo.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithPhoto();

        /// <summary>
        /// Filters the query to exclude items with a photo.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithPhoto();

        /// <summary>
        /// Filters the query to include items without a photo.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        T WithoutPhoto();

        /// <summary>
        /// Adds an OR condition to the query to include items without a photo.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithoutPhoto();

        /// <summary>
        /// Filters the query to exclude items without a photo.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithoutPhoto();
    }
}