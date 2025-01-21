using SpendWise.Common.Enums;

namespace SpendWise.BLL.Queries.Interfaces
{
    /// <summary>
    /// Represents an interface for transaction criteria-based queries.
    /// </summary>
    public interface ITransactionCriteriaQuery : ICriteriaQuery<ITransactionCriteriaQuery>
    {
        #region Amount

        /// <summary>
        /// Gets the amount of the transaction.
        /// </summary>
        decimal? AmountEqual { get; }

        /// <summary>
        /// Gets the amount that should not match the transaction amount.
        /// </summary>
        decimal? NotAmountEqual { get; }

        /// <summary>
        /// Gets the amount greater than the transaction amount.
        /// </summary>
        decimal? AmountGreaterThan { get; }

        /// <summary>
        /// Gets the amount that should not be greater than the transaction amount.
        /// </summary>
        decimal? NotAmountGreaterThan { get; }

        /// <summary>
        /// Gets the amount less than the transaction amount.
        /// </summary>
        decimal? AmountLessThan { get; }

        /// <summary>
        /// Gets the amount that should not be less than the transaction amount.
        /// </summary>
        decimal? NotAmountLessThan { get; }

        #endregion

        #region Date

        /// <summary>
        /// Gets the date of the transaction.
        /// </summary>
        DateTime? Date { get; }

        /// <summary>
        /// Gets the date that should not match the transaction date.
        /// </summary>
        DateTime? NotDate { get; }

        /// <summary>
        /// Gets the date from which the transaction should be.
        /// </summary>
        DateTime? DateFrom { get; }

        /// <summary>
        /// Gets the date to which the transaction should be.
        /// </summary>
        DateTime? DateTo { get; }

        #endregion

        #region Description

        /// <summary>
        /// Gets the description of the transaction.
        /// </summary>
        string? Description { get; }

        /// <summary>
        /// Gets the partial match for the transaction description.
        /// </summary>
        string? DescriptionPartialMatch { get; }

        /// <summary>
        /// Gets the description that should not match the transaction description.
        /// </summary>
        string? NotDescription { get; }

        /// <summary>
        /// Gets the partial match for the description that should not match the transaction description.
        /// </summary>
        string? NotDescriptionPartialMatch { get; }

        /// <summary>
        /// Gets a value indicating whether the transaction should be without a description.
        /// </summary>
        bool? WithDescription { get; }

        #endregion

        #region Type

        /// <summary>
        /// Gets the type of the transaction.
        /// </summary>
        TransactionType? Type { get; }

        /// <summary>
        /// Gets the type that should not match the transaction type.
        /// </summary>
        TransactionType? NotType { get; }

        #endregion

        #region Category

        /// <summary>
        /// Gets the unique identifier of the category.
        /// </summary>
        Guid? CategoryId { get; }

        /// <summary>
        /// Gets the unique identifier of the category that should not match.
        /// </summary>
        Guid? NotCategoryId { get; }

        /// <summary>
        /// Gets a value indicating whether the transaction should be with a category.
        /// </summary>
        bool? WithCategory { get; }

        #endregion

        #region User

        /// <summary>
        /// Gets the unique identifier of the user.
        /// </summary>
        Guid? UserId { get; }

        /// <summary>
        /// Gets the unique identifier of the user that should not match.
        /// </summary>
        Guid? NotUserId { get; }

        #endregion

        #region Group

        /// <summary>
        /// Gets the unique identifier of the group.
        /// </summary>
        Guid? GroupId { get; }

        /// <summary>
        /// Gets the unique identifier of the group that should not match.
        /// </summary>
        Guid? NotGroupId { get; }

        #endregion

        #region TransactionGroupUser

        /// <summary>
        /// Gets the unique identifier of the transaction group user.
        /// </summary>
        Guid? TransactionGroupUserId { get; }

        /// <summary>
        /// Gets the unique identifier of the transaction group user that should not match.
        /// </summary>
        Guid? NotTransactionGroupUserId { get; }

        #endregion
    }
}