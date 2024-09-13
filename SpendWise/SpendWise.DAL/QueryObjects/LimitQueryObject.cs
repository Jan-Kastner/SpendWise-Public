using System;
using SpendWise.Common.Enums;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object for the <see cref="LimitEntity"/>.
    /// Enables query construction using methods for AND, OR, and NOT operations.
    /// </summary>
    public class LimitQueryObject : BaseQueryObject<LimitEntity, LimitQueryObject>, ILimitQueryObject<LimitQueryObject>
    {
        #region IIdQuery

        /// <summary>
        /// Filters the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public LimitQueryObject WithId(Guid id) => ApplyIdFilter(id, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public LimitQueryObject OrWithId(Guid id) => ApplyIdFilter(id, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public LimitQueryObject NotWithId(Guid id) => ApplyIdFilter(id, filter => Not(filter));

        #endregion

        #region IAmountQuery

        /// <summary>
        /// Filters the query to include items with the specified amount.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public LimitQueryObject WithAmount(decimal amount) => ApplyAmountFilter(amount, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified amount.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public LimitQueryObject OrWithAmount(decimal amount) => ApplyAmountFilter(amount, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified amount.
        /// </summary>
        /// <param name="amount">The amount to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public LimitQueryObject NotWithAmount(decimal amount) => ApplyAmountFilter(amount, filter => Not(filter));

        #endregion

        #region INoticeTypeQuery

        /// <summary>
        /// Filters the query to include items with the specified notice type.
        /// </summary>
        /// <param name="noticeType">The notice type to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public LimitQueryObject WithNoticeType(NoticeType noticeType) => ApplyNoticeTypeFilter(noticeType, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified notice type.
        /// </summary>
        /// <param name="noticeType">The notice type to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public LimitQueryObject OrWithNoticeType(NoticeType noticeType) => ApplyNoticeTypeFilter(noticeType, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified notice type.
        /// </summary>
        /// <param name="noticeType">The notice type to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public LimitQueryObject NotWithNoticeType(NoticeType noticeType) => ApplyNoticeTypeFilter(noticeType, filter => Not(filter));

        #endregion

        #region IGroupUserQuery

        /// <summary>
        /// Filters the query to include items with the specified group user ID.
        /// </summary>
        /// <param name="groupUserId">The group user ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public LimitQueryObject WithGroupUser(Guid groupUserId)
        {
            And(entity => entity.GroupUserId == groupUserId);
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified group user ID.
        /// </summary>
        /// <param name="groupUserId">The group user ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public LimitQueryObject OrWithGroupUser(Guid groupUserId)
        {
            Or(entity => entity.GroupUserId == groupUserId);
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified group user ID.
        /// </summary>
        /// <param name="groupUserId">The group user ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public LimitQueryObject NotWithGroupUser(Guid groupUserId)
        {
            Not(entity => entity.GroupUserId == groupUserId);
            return this;
        }

        #endregion
    }
}