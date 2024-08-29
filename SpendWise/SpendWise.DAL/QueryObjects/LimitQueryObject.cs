using System;
using System.Linq.Expressions;
using SpendWise.Common.Enums;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object for the <see cref="LimitEntity"/>.
    /// Enables query construction using methods for AND, OR, and NOT operations.
    /// </summary>
    public class LimitQueryObject : QueryObject<LimitEntity>
    {
        #region AND

        /// <summary>
        /// Adds a condition to compare the limit ID using an AND operation.
        /// </summary>
        /// <param name="id">The limit ID to compare.</param>
        /// <returns>The current instance of <see cref="LimitQueryObject"/>.</returns>
        public LimitQueryObject WithId(Guid id)
        {
            And(entity => entity.Id == id);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the group user ID using an AND operation.
        /// </summary>
        /// <param name="groupUserId">The group user ID to compare.</param>
        /// <returns>The current instance of <see cref="LimitQueryObject"/>.</returns>
        public LimitQueryObject WithGroupUserId(Guid groupUserId)
        {
            And(entity => entity.GroupUserId == groupUserId);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the amount using an AND operation.
        /// </summary>
        /// <param name="amount">The amount to compare.</param>
        /// <returns>The current instance of <see cref="LimitQueryObject"/>.</returns>
        public LimitQueryObject WithAmount(decimal amount)
        {
            And(entity => entity.Amount == amount);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the notice type using an AND operation.
        /// </summary>
        /// <param name="noticeType">The notice type to compare.</param>
        /// <returns>The current instance of <see cref="LimitQueryObject"/>.</returns>
        public LimitQueryObject WithNoticeType(NoticeType noticeType)
        {
            And(entity => entity.NoticeType == noticeType);
            return this;
        }

        #endregion

        #region OR

        /// <summary>
        /// Adds a condition to compare the limit ID using an OR operation.
        /// </summary>
        /// <param name="id">The limit ID to compare.</param>
        /// <returns>The current instance of <see cref="LimitQueryObject"/>.</returns>
        public LimitQueryObject OrWithId(Guid id)
        {
            Or(entity => entity.Id == id);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the group user ID using an OR operation.
        /// </summary>
        /// <param name="groupUserId">The group user ID to compare.</param>
        /// <returns>The current instance of <see cref="LimitQueryObject"/>.</returns>
        public LimitQueryObject OrWithGroupUserId(Guid groupUserId)
        {
            Or(entity => entity.GroupUserId == groupUserId);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the amount using an OR operation.
        /// </summary>
        /// <param name="amount">The amount to compare.</param>
        /// <returns>The current instance of <see cref="LimitQueryObject"/>.</returns>
        public LimitQueryObject OrWithAmount(decimal amount)
        {
            Or(entity => entity.Amount == amount);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the notice type using an OR operation.
        /// </summary>
        /// <param name="noticeType">The notice type to compare.</param>
        /// <returns>The current instance of <see cref="LimitQueryObject"/>.</returns>
        public LimitQueryObject OrWithNoticeType(NoticeType noticeType)
        {
            Or(entity => entity.NoticeType == noticeType);
            return this;
        }

        #endregion

        #region NOT

        /// <summary>
        /// Adds a condition to exclude limits with a specific ID using a NOT operation.
        /// </summary>
        /// <param name="id">The limit ID to exclude.</param>
        /// <returns>The current instance of <see cref="LimitQueryObject"/>.</returns>
        public LimitQueryObject NotWithId(Guid id)
        {
            Not(entity => entity.Id == id);
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude limits with a specific group user ID using a NOT operation.
        /// </summary>
        /// <param name="groupUserId">The group user ID to exclude.</param>
        /// <returns>The current instance of <see cref="LimitQueryObject"/>.</returns>
        public LimitQueryObject NotWithGroupUserId(Guid groupUserId)
        {
            Not(entity => entity.GroupUserId == groupUserId);
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude limits with a specific amount using a NOT operation.
        /// </summary>
        /// <param name="amount">The amount to exclude.</param>
        /// <returns>The current instance of <see cref="LimitQueryObject"/>.</returns>
        public LimitQueryObject NotWithAmount(decimal amount)
        {
            Not(entity => entity.Amount == amount);
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude limits with a specific notice type using a NOT operation.
        /// </summary>
        /// <param name="noticeType">The notice type to exclude.</param>
        /// <returns>The current instance of <see cref="LimitQueryObject"/>.</returns>
        public LimitQueryObject NotWithNoticeType(NoticeType noticeType)
        {
            Not(entity => entity.NoticeType == noticeType);
            return this;
        }

        #endregion
    }
}
