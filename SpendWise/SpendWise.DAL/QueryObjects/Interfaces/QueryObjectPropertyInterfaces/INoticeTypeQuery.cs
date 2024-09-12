using SpendWise.Common.Enums;

namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by notice type.
    /// Provides methods for specifying notice type-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface INoticeTypeQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with the specified notice type.
        /// </summary>
        /// <param name="noticeType">The notice type to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithNoticeType(NoticeType noticeType);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified notice type.
        /// </summary>
        /// <param name="noticeType">The notice type to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithNoticeType(NoticeType noticeType);

        /// <summary>
        /// Filters the query to exclude items with the specified notice type.
        /// </summary>
        /// <param name="noticeType">The notice type to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithNoticeType(NoticeType noticeType);
    }
}