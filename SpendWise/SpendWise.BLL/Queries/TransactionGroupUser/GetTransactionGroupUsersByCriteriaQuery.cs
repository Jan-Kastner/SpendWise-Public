using SpendWise.BLL.Queries.Interfaces;
using SpendWise.Common.Enums;

namespace SpendWise.BLL.Queries
{
    /// <summary>
    /// Represents a query object for retrieving transaction group users by criteria.
    /// </summary>
    internal class GetTransactionGroupUsersByCriteriaQuery : ITransactionGroupUserCriteriaQuery, ITransactionGroupUserIncludeQuery
    {
        #region Id

        /// <summary>
        /// Gets or sets the unique identifier for the transaction group user.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the transaction group user that should not be included in the query result.
        /// </summary>
        public Guid? NotId { get; set; }

        #endregion

        #region IsRead

        /// <summary>
        /// Gets or sets a value indicating whether the transaction has been read by the user.
        /// </summary>
        public bool? IsRead { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the transaction should not be read by the user.
        /// </summary>
        public bool? NotIsRead { get; set; }

        #endregion

        #region Transaction

        /// <summary>
        /// Gets or sets the unique identifier for the associated transaction.
        /// </summary>
        public Guid? TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the associated transaction that should not be included in the query result.
        /// </summary>
        public Guid? NotTransactionId { get; set; }

        #endregion

        #region User

        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the user that should not be included in the query result.
        /// </summary>
        public Guid? NotUserId { get; set; }

        #endregion

        #region Group

        /// <summary>
        /// Gets or sets the unique identifier for the group.
        /// </summary>
        public Guid? GroupId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the group that should not be included in the query result.
        /// </summary>
        public Guid? NotGroupId { get; set; }

        #endregion

        #region TransactionDate

        /// <summary>
        /// Gets or sets the date of the transaction.
        /// </summary>
        public DateTime? TransactionDate { get; set; }

        /// <summary>
        /// Gets or sets the date of the transaction that should not be included in the query result.
        /// </summary>
        public DateTime? NotTransactionDate { get; set; }

        /// <summary>
        /// Gets or sets the date from which the transaction should be.
        /// </summary>
        public DateTime? TransactionDateFrom { get; set; }

        /// <summary>
        /// Gets or sets the date to which the transaction should be.
        /// </summary>
        public DateTime? TransactionDateTo { get; set; }

        #endregion

        #region TransactionAmount

        /// <summary>
        /// Gets or sets the transaction amount.
        /// </summary>
        public decimal? TransactionAmount { get; set; }

        /// <summary>
        /// Gets or sets the transaction amount that should not be included in the query result.
        /// </summary>
        public decimal? NotTransactionAmount { get; set; }

        /// <summary>
        /// Gets or sets the transaction amount that should be greater than the specified value.
        /// </summary>
        public decimal? TransactionAmountGreaterThan { get; set; }

        /// <summary>
        /// Gets or sets the transaction amount that should not be greater than the specified value.
        /// </summary>
        public decimal? NotTransactionAmountGreaterThan { get; set; }

        /// <summary>
        /// Gets or sets the transaction amount that should be less than the specified value.
        /// </summary>
        public decimal? TransactionAmountLessThan { get; set; }

        /// <summary>
        /// Gets or sets the transaction amount that should not be less than the specified value.
        /// </summary>
        public decimal? NotTransactionAmountLessThan { get; set; }

        #endregion

        #region TransactionDescription

        /// <summary>
        /// Gets or sets the transaction description.
        /// </summary>
        public string? TransactionDescription { get; set; }

        /// <summary>
        /// Gets or sets the transaction description that should not be included in the query result.
        /// </summary>
        public string? NotTransactionDescription { get; set; }

        /// <summary>
        /// Gets or sets the partial match for the transaction description.
        /// </summary>
        public string? TransactionDescriptionPartialMatch { get; set; }

        /// <summary>
        /// Gets or sets the partial match for the transaction description that should not be included in the query result.
        /// </summary>
        public string? NotTransactionDescriptionPartialMatch { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the transaction has a description.
        /// </summary>
        public bool? WithTransactionDescription { get; set; }

        #endregion

        #region TransactionType

        /// <summary>
        /// Gets or sets the transaction type.
        /// </summary>
        public TransactionType? TransactionType { get; set; }

        /// <summary>
        /// Gets or sets the transaction type that should not be included in the query result.
        /// </summary>
        public TransactionType? NotTransactionType { get; set; }

        #endregion

        #region TransactionCategory

        /// <summary>
        /// Gets or sets the unique identifier for the transaction category.
        /// </summary>
        public Guid? TransactionCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the transaction category that should not be included in the query result.
        /// </summary>
        public Guid? NotTransactionCategoryId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the transaction should be with a category.
        /// </summary>
        public bool? WithTransactionCategory { get; set; }

        #endregion

        #region IncludeOptions

        /// <summary>
        /// Gets a value indicating whether to include transactions in the query result.
        /// </summary>
        public bool IncludeTransactions { get; set; }

        /// <summary>
        /// Gets a value indicating whether to include user in the query result.
        /// </summary>
        public bool IncludeCategory { get; set; }

        #endregion

        #region LogicalOperators

        /// <summary>
        /// Gets the list of query objects to combine with AND.
        /// </summary>
        public List<ITransactionGroupUserCriteriaQuery>? And { get; set; }

        /// <summary>
        /// Gets the list of query objects to combine with OR.
        /// </summary>
        public List<ITransactionGroupUserCriteriaQuery>? Or { get; set; }

        /// <summary>
        /// Gets the list of query objects to negate.
        /// </summary>
        public List<ITransactionGroupUserCriteriaQuery>? Not { get; set; }

        #endregion
    }
}