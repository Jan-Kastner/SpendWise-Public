using SpendWise.Common.Enums;

namespace SpendWise.BLL.Queries.Interfaces
{
    /// <summary>
    /// Represents an interface for limit criteria-based queries.
    /// </summary>
    public interface ILimitCriteriaQuery : ICriteriaQuery
    {
        /// <summary>
        /// Gets the amount of the limit.
        /// </summary>
        decimal? Amount { get; }

        /// <summary>
        /// Gets the amount that should not match the limit amount.
        /// </summary>
        decimal? NotAmount { get; }

        /// <summary>
        /// Gets the notice type of the limit.
        /// </summary>
        NoticeType? NoticeType { get; }

        /// <summary>
        /// Gets the notice type that should not match the limit notice type.
        /// </summary>
        NoticeType? NotNoticeType { get; }

        /// <summary>
        /// Gets the group user ID associated with the limit.
        /// </summary>
        Guid? GroupUserId { get; }

        /// <summary>
        /// Gets the group user ID that should not match the limit group user ID.
        /// </summary>
        Guid? NotGroupUserId { get; }
    }
}