using SpendWise.Common.Enums;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects.Interfaces;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object for the <see cref="LimitEntity"/>.
    /// Enables query construction using methods for AND, OR, and NOT operations.
    /// </summary>
    public class LimitQueryObject : BaseQueryObject<LimitEntity, LimitQueryObject>, ILimitQueryObject
    {
        /// <summary>
        /// Gets the collection of include directives used by the RelationConfigGenerator
        /// to generate EntityRelationsConfiguration, which acts as a state machine for managing includes.
        /// </summary>
        public override ICollection<Func<LimitEntity, object>> IncludeDirectives { get; } = new List<Func<LimitEntity, object>>
        {
        };

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
        public LimitQueryObject WithAmountEqual(decimal amount) => ApplyAmountFilter(entity => entity.Amount, amount, filter => And(filter), "Equal");

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified amount.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public LimitQueryObject OrWithAmountEqual(decimal amount) => ApplyAmountFilter(entity => entity.Amount, amount, filter => Or(filter), "Equal");

        /// <summary>
        /// Filters the query to exclude items with the specified amount.
        /// </summary>
        /// <param name="amount">The amount to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public LimitQueryObject NotWithAmountEqual(decimal amount) => ApplyAmountFilter(entity => entity.Amount, amount, filter => Not(filter), "Equal");

        /// <summary>
        /// Filters the query to include items with the amount greater than the specified value.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public LimitQueryObject WithAmountGreaterThan(decimal amount) => ApplyAmountFilter(entity => entity.Amount, amount, filter => And(filter), "GreaterThan");

        /// <summary>
        /// Adds an OR condition to the query to include items with the amount greater than the specified value.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public LimitQueryObject OrWithAmountGreaterThan(decimal amount) => ApplyAmountFilter(entity => entity.Amount, amount, filter => Or(filter), "GreaterThan");

        /// <summary>
        /// Filters the query to exclude items with the amount greater than the specified value.
        /// </summary>
        /// <param name="amount">The amount to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public LimitQueryObject NotWithAmountGreaterThan(decimal amount) => ApplyAmountFilter(entity => entity.Amount, amount, filter => Not(filter), "GreaterThan");

        /// <summary>
        /// Filters the query to include items with the amount less than the specified value.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public LimitQueryObject WithAmountLessThan(decimal amount) => ApplyAmountFilter(entity => entity.Amount, amount, filter => And(filter), "LessThan");

        /// <summary>
        /// Adds an OR condition to the query to include items with the amount less than the specified value.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public LimitQueryObject OrWithAmountLessThan(decimal amount) => ApplyAmountFilter(entity => entity.Amount, amount, filter => Or(filter), "LessThan");

        /// <summary>
        /// Filters the query to exclude items with the amount less than the specified value.
        /// </summary>
        /// <param name="amount">The amount to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public LimitQueryObject NotWithAmountLessThan(decimal amount) => ApplyAmountFilter(entity => entity.Amount, amount, filter => Not(filter), "LessThan");

        #endregion

        #region INoticeTypeQuery

        /// <summary>
        /// Filters the query to include items with the specified notice type.
        /// </summary>
        /// <param name="noticeType">The notice type to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public LimitQueryObject WithNoticeType(NoticeType noticeType) => ApplyNoticeTypeFilter(entity => entity.NoticeType, noticeType, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified notice type.
        /// </summary>
        /// <param name="noticeType">The notice type to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public LimitQueryObject OrWithNoticeType(NoticeType noticeType) => ApplyNoticeTypeFilter(entity => entity.NoticeType, noticeType, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified notice type.
        /// </summary>
        /// <param name="noticeType">The notice type to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public LimitQueryObject NotWithNoticeType(NoticeType noticeType) => ApplyNoticeTypeFilter(entity => entity.NoticeType, noticeType, filter => Not(filter));

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