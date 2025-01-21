using SpendWise.Common.Enums;

namespace SpendWise.BLL.Queries.Interfaces
{
    /// <summary>
    /// Represents an interface for limit criteria-based queries.
    /// </summary>
    public interface ILimitCriteriaQuery : ICriteriaQuery<ILimitCriteriaQuery>
    {
        #region Amount

        /// <summary>
        /// Gets the amount of the limit.
        /// </summary>
        decimal? AmountEqual { get; }

        /// <summary>
        /// Gets the amount that should not match the limit amount.
        /// </summary>
        decimal? NotAmountEqual { get; }

        /// <summary>
        /// Gets the amount greater than the limit amount.
        /// </summary>
        decimal? AmountGreaterThan { get; }

        /// <summary>
        /// Gets the amount that should not be greater than the limit amount.
        /// </summary>
        decimal? NotAmountGreaterThan { get; }

        /// <summary>
        /// Gets the amount less than the limit amount.
        /// </summary>
        decimal? AmountLessThan { get; }

        /// <summary>
        /// Gets the amount that should not be less than the limit amount.
        /// </summary>
        decimal? NotAmountLessThan { get; }

        #endregion

        #region NoticeType

        /// <summary>
        /// Gets the notice type of the limit.
        /// </summary>
        NoticeType? NoticeType { get; }

        /// <summary>
        /// Gets the notice type that should not match the limit notice type.
        /// </summary>
        NoticeType? NotNoticeType { get; }

        #endregion

        #region GroupUserId

        /// <summary>
        /// Gets the group user ID associated with the limit.
        /// </summary>
        Guid? GroupUserId { get; }

        /// <summary>
        /// Gets the group user ID that should not match the limit group user ID.
        /// </summary>
        Guid? NotGroupUserId { get; }

        #endregion

        #region GroupId

        /// <summary>
        /// Gets the group ID associated with the limit.
        /// </summary>
        Guid? GroupId { get; }

        /// <summary>
        /// Gets the group ID that should not match the limit group ID.
        /// </summary>
        Guid? UserId { get; }

        #endregion
    }
}