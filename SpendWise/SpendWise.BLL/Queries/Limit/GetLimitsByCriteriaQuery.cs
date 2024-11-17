using SpendWise.BLL.Queries.Interfaces;
using SpendWise.Common.Enums;
using System;

namespace SpendWise.BLL.Queries
{
    /// <summary>
    /// Represents a query object for retrieving limits based on various criteria.
    /// </summary>
    public class GetLimitsByCriteriaQuery : ILimitCriteriaQuery, ILimitIncludeQuery
    {
        /// <summary>
        /// Gets the unique identifier of the limit.
        /// </summary>
        public Guid? Id { get; }

        /// <summary>
        /// Gets the amount of the limit.
        /// </summary>
        public decimal? Amount { get; }

        /// <summary>
        /// Gets the amount that should not match the limit amount.
        /// </summary>
        public decimal? NotAmount { get; }

        /// <summary>
        /// Gets the notice type of the limit.
        /// </summary>
        public NoticeType? NoticeType { get; }

        /// <summary>
        /// Gets the notice type that should not match the limit notice type.
        /// </summary>
        public NoticeType? NotNoticeType { get; }

        /// <summary>
        /// Gets the group user ID associated with the limit.
        /// </summary>
        public Guid? GroupUserId { get; }

        /// <summary>
        /// Gets the group user ID that should not match the limit group user ID.
        /// </summary>
        public Guid? NotGroupUserId { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetLimitsByCriteriaQuery"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the limit.</param>
        /// <param name="amount">The amount of the limit.</param>
        /// <param name="notAmount">The amount that should not match the limit amount.</param>
        /// <param name="noticeType">The notice type of the limit.</param>
        /// <param name="notNoticeType">The notice type that should not match the limit notice type.</param>
        /// <param name="groupUserId">The group user ID associated with the limit.</param>
        /// <param name="notGroupUserId">The group user ID that should not match the limit group user ID.</param>
        public GetLimitsByCriteriaQuery(
            Guid? id = null,
            decimal? amount = null,
            decimal? notAmount = null,
            NoticeType? noticeType = null,
            NoticeType? notNoticeType = null,
            Guid? groupUserId = null,
            Guid? notGroupUserId = null)
        {
            Id = id;
            Amount = amount;
            NotAmount = notAmount;
            NoticeType = noticeType;
            NotNoticeType = notNoticeType;
            GroupUserId = groupUserId;
            NotGroupUserId = notGroupUserId;
        }
    }
}