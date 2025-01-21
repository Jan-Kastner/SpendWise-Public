using SpendWise.BLL.Queries.Interfaces;
using SpendWise.Common.Enums;

namespace SpendWise.BLL.Queries
{
    /// <summary>
    /// Represents a query object for retrieving limits based on various criteria.
    /// </summary>
    public class GetLimitsByCriteriaQuery : ILimitCriteriaQuery, ILimitIncludeQuery
    {
        #region Id

        /// <summary>
        /// Gets the unique identifier of the limit.
        /// </summary>
        public Guid? Id { get; }

        #endregion

        #region Amount

        /// <summary>
        /// Gets the amount of the limit.
        /// </summary>
        public decimal? AmountEqual { get; }

        /// <summary>
        /// Gets the amount that should not match the limit amount.
        /// </summary>
        public decimal? NotAmountEqual { get; }

        /// <summary>
        /// Gets the amount greater than the limit amount.
        /// </summary>
        public decimal? AmountGreaterThan { get; }

        /// <summary>
        /// Gets the amount that should not be greater than the limit amount.
        /// </summary>
        public decimal? NotAmountGreaterThan { get; }

        /// <summary>
        /// Gets the amount less than the limit amount.
        /// </summary>
        public decimal? AmountLessThan { get; }

        /// <summary>
        /// Gets the amount that should not be less than the limit amount.
        /// </summary>
        public decimal? NotAmountLessThan { get; }

        #endregion

        #region NoticeType

        /// <summary>
        /// Gets the notice type of the limit.
        /// </summary>
        public NoticeType? NoticeType { get; }

        /// <summary>
        /// Gets the notice type that should not match the limit notice type.
        /// </summary>
        public NoticeType? NotNoticeType { get; }

        #endregion

        #region GroupUserId

        /// <summary>
        /// Gets the group user ID associated with the limit.
        /// </summary>
        public Guid? GroupUserId { get; }

        /// <summary>
        /// Gets the group user ID that should not match the limit group user ID.
        /// </summary>
        public Guid? NotGroupUserId { get; }

        #endregion

        #region GroupId

        /// <summary>
        /// Gets the group ID associated with the limit.
        /// </summary>
        public Guid? GroupId { get; }

        /// <summary>
        /// Gets the group ID that should not match the limit group ID.
        /// </summary>
        public Guid? UserId { get; }

        #endregion

        #region LogicalOperators

        /// <summary>
        /// Gets the list of query objects to combine with AND.
        /// </summary>
        public List<ILimitCriteriaQuery>? And { get; }

        /// <summary>
        /// Gets the list of query objects to combine with OR.
        /// </summary>
        public List<ILimitCriteriaQuery>? Or { get; }

        /// <summary>
        /// Gets the list of query objects to negate.
        /// </summary>
        public List<ILimitCriteriaQuery>? Not { get; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="GetLimitsByCriteriaQuery"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the limit.</param>
        /// <param name="amountEqual">The amount of the limit.</param>
        /// <param name="notAmountEqual">The amount that should not match the limit amount.</param>
        /// <param name="amountGreaterThan">The amount greater than the limit amount.</param>
        /// <param name="notAmountGreaterThan">The amount that should not be greater than the limit amount.</param>
        /// <param name="amountLessThan">The amount less than the limit amount.</param>
        /// <param name="notAmountLessThan">The amount that should not be less than the limit amount.</param>
        /// <param name="noticeType">The notice type of the limit.</param>
        /// <param name="notNoticeType">The notice type that should not match the limit notice type.</param>
        /// <param name="groupUserId">The group user ID associated with the limit.</param>
        /// <param name="notGroupUserId">The group user ID that should not match the limit group user ID.</param>
        /// <param name="groupId">The group ID associated with the limit.</param>
        /// <param name="userId">The group ID that should not match the limit group ID.</param>
        /// <param name="and">The list of query objects to combine with AND.</param>
        /// <param name="or">The list of query objects to combine with OR.</param>
        /// <param name="not">The list of query objects to negate.</param>
        public GetLimitsByCriteriaQuery(
            Guid? id = null,
            decimal? amountEqual = null,
            decimal? notAmountEqual = null,
            decimal? amountGreaterThan = null,
            decimal? notAmountGreaterThan = null,
            decimal? amountLessThan = null,
            decimal? notAmountLessThan = null,
            NoticeType? noticeType = null,
            NoticeType? notNoticeType = null,
            Guid? groupUserId = null,
            Guid? notGroupUserId = null,
            Guid? groupId = null,
            Guid? userId = null,
            List<ILimitCriteriaQuery>? and = null,
            List<ILimitCriteriaQuery>? or = null,
            List<ILimitCriteriaQuery>? not = null)
        {
            Id = id;
            AmountEqual = amountEqual;
            NotAmountEqual = notAmountEqual;
            AmountGreaterThan = amountGreaterThan;
            NotAmountGreaterThan = notAmountGreaterThan;
            AmountLessThan = amountLessThan;
            NotAmountLessThan = notAmountLessThan;
            NoticeType = noticeType;
            NotNoticeType = notNoticeType;
            GroupUserId = groupUserId;
            NotGroupUserId = notGroupUserId;
            GroupId = groupId;
            UserId = userId;
            And = and;
            Or = or;
            Not = not;
        }
    }
}