using SpendWise.Common.Enums;

namespace SpendWise.BLL.Queries.Interfaces
{
    /// <summary>
    /// Represents an interface for transaction group user criteria-based queries.
    /// </summary>
    internal interface ITransactionGroupUserCriteriaQuery : ICriteriaQuery<ITransactionGroupUserCriteriaQuery>
    {
        #region Id

        /// <summary>
        /// Gets the unique identifier for the transaction group user.
        /// </summary>
        Guid? Id { get; set; }

        /// <summary>
        /// Gets the unique identifier for the transaction group user that should not be included in the query result.
        /// </summary>
        Guid? NotId { get; set; }

        #endregion

        #region IsRead

        /// <summary>
        /// Gets a value indicating whether the transaction has been read by the user.
        /// </summary>
        bool? IsRead { get; set; }

        #endregion

        #region Transaction

        /// <summary>
        /// Gets the unique identifier for the associated transaction.
        /// </summary>
        Guid? TransactionId { get; set; }

        /// <summary>
        /// Gets the unique identifier for the associated transaction that should not be included in the query result.
        /// </summary>
        Guid? NotTransactionId { get; set; }

        #endregion

        #region User

        /// <summary>
        /// Gets the unique identifier for the user.
        /// </summary>
        Guid? UserId { get; set; }

        /// <summary>
        /// Gets the unique identifier for the user that should not be included in the query result.
        /// </summary>
        Guid? NotUserId { get; set; }

        #endregion

        #region Group

        /// <summary>
        /// Gets the unique identifier for the group.
        /// </summary>
        Guid? GroupId { get; set; }

        /// <summary>
        /// Gets the unique identifier for the group that should not be included in the query result.
        /// </summary>
        Guid? NotGroupId { get; set; }

        #endregion

        #region TransactionDate

        /// <summary>
        /// Gets the date of the transaction.
        /// </summary>
        DateTime? TransactionDate { get; set; }

        /// <summary>
        /// Gets the date of the transaction that should not be included in the query result.
        /// </summary>
        DateTime? NotTransactionDate { get; set; }

        /// <summary>
        /// Gets the date from which the transaction should be.
        /// </summary>
        DateTime? TransactionDateFrom { get; set; }

        /// <summary>
        /// Gets the date to which the transaction should be.
        /// </summary>
        DateTime? TransactionDateTo { get; set; }

        #endregion

        #region TransactionAmount

        /// <summary>
        /// Gets the transaction amount.
        /// </summary>
        decimal? TransactionAmount { get; set; }

        /// <summary>
        /// Gets the transaction amount that should not be included in the query result.
        /// </summary>
        decimal? NotTransactionAmount { get; set; }

        /// <summary>
        /// Gets the transaction amount that should be greater than the specified value.
        /// </summary>
        decimal? TransactionAmountGreaterThan { get; set; }

        /// <summary>
        /// Gets the transaction amount that should not be greater than the specified value.
        /// </summary>
        decimal? NotTransactionAmountGreaterThan { get; set; }

        /// <summary>
        /// Gets the transaction amount that should be less than the specified value.
        /// </summary>
        decimal? TransactionAmountLessThan { get; set; }

        /// <summary>
        /// Gets the transaction amount that should not be less than the specified value.
        /// </summary>
        decimal? NotTransactionAmountLessThan { get; set; }

        #endregion

        #region TransactionDescription

        /// <summary>
        /// Gets the transaction description.
        /// </summary>
        string? TransactionDescription { get; set; }

        /// <summary>
        /// Gets the transaction description that should not be included in the query result.
        /// </summary>
        string? NotTransactionDescription { get; set; }

        /// <summary>
        /// Gets the partial match for the transaction description.
        /// </summary>
        string? TransactionDescriptionPartialMatch { get; set; }

        /// <summary>
        /// Gets the partial match for the transaction description that should not be included in the query result.
        /// </summary>
        string? NotTransactionDescriptionPartialMatch { get; set; }

        /// <summary>
        /// Gets a value indicating whether the transaction should be with a description.
        /// </summary>
        bool? WithTransactionDescription { get; set; }

        #endregion

        #region TransactionType

        /// <summary>
        /// Gets the transaction type.
        /// </summary>
        TransactionType? TransactionType { get; set; }

        /// <summary>
        /// Gets the transaction type that should not be included in the query result.
        /// </summary>
        TransactionType? NotTransactionType { get; set; }

        #endregion

        #region TransactionCategory

        /// <summary>
        /// Gets the unique identifier for the transaction category.
        /// </summary>
        Guid? TransactionCategoryId { get; set; }

        /// <summary>
        /// Gets the unique identifier for the transaction category that should not be included in the query result.
        /// </summary>
        Guid? NotTransactionCategoryId { get; set; }

        /// <summary>
        /// Gets a value indicating whether the transaction should be with a category.
        /// </summary>
        bool? WithTransactionCategory { get; set; }

        #endregion
    }
}