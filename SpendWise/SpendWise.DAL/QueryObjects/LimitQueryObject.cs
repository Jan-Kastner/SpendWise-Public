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
        public new LimitQueryObject WithId(Guid id) => base.WithId(id);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new LimitQueryObject OrWithId(Guid id) => base.OrWithId(id);

        /// <summary>
        /// Filters the query to exclude items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new LimitQueryObject NotWithId(Guid id) => base.NotWithId(id);

        #endregion

        #region IAmountQuery

        /// <summary>
        /// Filters the query to include items with the specified amount.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new LimitQueryObject WithAmount(decimal amount) => base.WithAmount(amount);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified amount.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new LimitQueryObject OrWithAmount(decimal amount) => base.OrWithAmount(amount);

        /// <summary>
        /// Filters the query to exclude items with the specified amount.
        /// </summary>
        /// <param name="amount">The amount to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new LimitQueryObject NotWithAmount(decimal amount) => base.NotWithAmount(amount);

        #endregion

        #region INoticeTypeQuery

        /// <summary>
        /// Filters the query to include items with the specified notice type.
        /// </summary>
        /// <param name="noticeType">The notice type to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new LimitQueryObject WithNoticeType(NoticeType noticeType) => base.WithNoticeType(noticeType);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified notice type.
        /// </summary>
        /// <param name="noticeType">The notice type to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new LimitQueryObject OrWithNoticeType(NoticeType noticeType) => base.OrWithNoticeType(noticeType);

        /// <summary>
        /// Filters the query to exclude items with the specified notice type.
        /// </summary>
        /// <param name="noticeType">The notice type to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new LimitQueryObject NotWithNoticeType(NoticeType noticeType) => base.NotWithNoticeType(noticeType);

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