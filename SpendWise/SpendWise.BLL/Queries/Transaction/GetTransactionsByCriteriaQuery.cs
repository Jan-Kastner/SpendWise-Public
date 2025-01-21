using SpendWise.BLL.Queries.Interfaces;
using SpendWise.Common.Enums;

namespace SpendWise.BLL.Queries
{
    /// <summary>
    /// Represents a query object for retrieving transactions based on various criteria.
    /// </summary>
    public class GetTransactionsByCriteriaQuery : ITransactionCriteriaQuery, ITransactionIncludeQuery
    {
        #region Id

        /// <summary>
        /// Gets the unique identifier of the transaction.
        /// </summary>
        public Guid? Id { get; }

        #endregion

        #region Amount

        /// <summary>
        /// Gets the amount of the transaction.
        /// </summary>
        public decimal? AmountEqual { get; }

        /// <summary>
        /// Gets the amount that should not match the transaction amount.
        /// </summary>
        public decimal? NotAmountEqual { get; }

        /// <summary>
        /// Gets the amount greater than the transaction amount.
        /// </summary>
        public decimal? AmountGreaterThan { get; }

        /// <summary>
        /// Gets the amount that should not be greater than the transaction amount.
        /// </summary>
        public decimal? NotAmountGreaterThan { get; }

        /// <summary>
        /// Gets the amount less than the transaction amount.
        /// </summary>
        public decimal? AmountLessThan { get; }

        /// <summary>
        /// Gets the amount that should not be less than the transaction amount.
        /// </summary>
        public decimal? NotAmountLessThan { get; }

        #endregion

        #region Date

        /// <summary>
        /// Gets the date of the transaction.
        /// </summary>
        public DateTime? Date { get; }

        /// <summary>
        /// Gets the date that should not match the transaction date.
        /// </summary>
        public DateTime? NotDate { get; }

        /// <summary>
        /// Gets the date from which the transaction should be.
        /// </summary>
        public DateTime? DateFrom { get; }

        /// <summary>
        /// Gets the date to which the transaction should be.
        /// </summary>
        public DateTime? DateTo { get; }

        #endregion

        #region Description

        /// <summary>
        /// Gets the description of the transaction.
        /// </summary>
        public string? Description { get; }

        /// <summary>
        /// Gets the partial match for the transaction description.
        /// </summary>
        public string? DescriptionPartialMatch { get; }

        /// <summary>
        /// Gets the description that should not match the transaction description.
        /// </summary>
        public string? NotDescription { get; }

        /// <summary>
        /// Gets the partial match for the description that should not match the transaction description.
        /// </summary>
        public string? NotDescriptionPartialMatch { get; }

        /// <summary>
        /// Gets a value indicating whether the transaction should be without a description.
        /// </summary>
        public bool? WithDescription { get; }

        #endregion

        #region Type

        /// <summary>
        /// Gets the type of the transaction.
        /// </summary>
        public TransactionType? Type { get; }

        /// <summary>
        /// Gets the type that should not match the transaction type.
        /// </summary>
        public TransactionType? NotType { get; }

        #endregion

        #region Category

        /// <summary>
        /// Gets the unique identifier of the category.
        /// </summary>
        public Guid? CategoryId { get; }

        /// <summary>
        /// Gets the unique identifier of the category that should not match.
        /// </summary>
        public Guid? NotCategoryId { get; }

        /// <summary>
        /// Gets a value indicating whether the transaction should be without a category.
        /// </summary>
        public bool? WithCategory { get; }

        #endregion

        #region User

        /// <summary>
        /// Gets the unique identifier of the user.
        /// </summary>
        public Guid? UserId { get; }

        /// <summary>
        /// Gets the unique identifier of the user that should not match.
        /// </summary>
        public Guid? NotUserId { get; }

        #endregion

        #region Group

        /// <summary>
        /// Gets the unique identifier of the group.
        /// </summary>
        public Guid? GroupId { get; }

        /// <summary>
        /// Gets the unique identifier of the group that should not match.
        /// </summary>
        public Guid? NotGroupId { get; }

        #endregion

        #region TransactionGroupUser

        /// <summary>
        /// Gets the unique identifier of the transaction group user.
        /// </summary>
        public Guid? TransactionGroupUserId { get; }

        /// <summary>
        /// Gets the unique identifier of the transaction group user that should not match.
        /// </summary>
        public Guid? NotTransactionGroupUserId { get; }

        #endregion

        #region IncludeOptions

        /// <summary>
        /// Gets a value indicating whether to include the category in the query result.
        /// </summary>
        public bool IncludeCategory { get; }

        /// <summary>
        /// Gets a value indicating whether to include the transaction group users in the query result.
        /// </summary>
        public bool IncludeGroups { get; }

        /// <summary>
        /// Gets a value indicating whether to include the user in the query result.
        /// </summary>
        public bool IncludeUser { get; }

        /// <summary>
        /// Gets a value indicating whether to include the participants in the query result.
        /// </summary>
        public bool IncludeParticipants { get; }

        #endregion

        #region LogicalOperators

        /// <summary>
        /// Gets the list of query objects to combine with AND.
        /// </summary>
        public List<ITransactionCriteriaQuery>? And { get; }

        /// <summary>
        /// Gets the list of query objects to combine with OR.
        /// </summary>
        public List<ITransactionCriteriaQuery>? Or { get; }

        /// <summary>
        /// Gets the list of query objects to negate.
        /// </summary>
        public List<ITransactionCriteriaQuery>? Not { get; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTransactionsByCriteriaQuery"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the transaction.</param>
        /// <param name="amountEqual">The amount of the transaction.</param>
        /// <param name="notAmountEqual">The amount that should not match the transaction amount.</param>
        /// <param name="amountGreaterThan">The amount greater than the transaction amount.</param>
        /// <param name="notAmountGreaterThan">The amount that should not be greater than the transaction amount.</param>
        /// <param name="amountLessThan">The amount less than the transaction amount.</param>
        /// <param name="notAmountLessThan">The amount that should not be less than the transaction amount.</param>
        /// <param name="date">The date of the transaction.</param>
        /// <param name="notDate">The date that should not match the transaction date.</param>
        /// <param name="dateFrom">The date from which the transaction should be.</param>
        /// <param name="dateTo">The date to which the transaction should be.</param>
        /// <param name="description">The description of the transaction.</param>
        /// <param name="descriptionPartialMatch">The partial match for the transaction description.</param>
        /// <param name="notDescription">The description that should not match the transaction description.</param>
        /// <param name="notDescriptionPartialMatch">The partial match for the description that should not match the transaction description.</param>
        /// <param name="withDescription">Indicates whether the transaction should be with a description.</param>
        /// <param name="type">The type of the transaction.</param>
        /// <param name="notType">The type that should not match the transaction type.</param>
        /// <param name="categoryId">The unique identifier of the category.</param>
        /// <param name="notCategoryId">The unique identifier of the category that should not match.</param>
        /// <param name="withCategory">Indicates whether the transaction should be with a category.</param>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <param name="notUserId">The unique identifier of the user that should not match.</param>
        /// <param name="groupId">The unique identifier of the group.</param>
        /// <param name="notGroupId">The unique identifier of the group that should not match.</param>
        /// <param name="transactionGroupUserId">The unique identifier of the transaction group user.</param>
        /// <param name="notTransactionGroupUserId">The unique identifier of the transaction group user that should not match.</param>
        /// <param name="includeCategory">A value indicating whether to include the category in the query result. Default is false.</param>
        /// <param name="includeGroups">A value indicating whether to include the transaction group users in the query result. Default is false.</param>
        /// <param name="includeUser">A value indicating whether to include the user in the query result. Default is false.</param>
        /// <param name="includeParticipants">A value indicating whether to include the participants in the query result. Default is false.</param>
        /// <param name="and">The list of query objects to combine with AND.</param>
        /// <param name="or">The list of query objects to combine with OR.</param>
        /// <param name="not">The list of query objects to negate.</param>
        public GetTransactionsByCriteriaQuery(
            Guid? id = null,
            decimal? amountEqual = null,
            decimal? notAmountEqual = null,
            decimal? amountGreaterThan = null,
            decimal? notAmountGreaterThan = null,
            decimal? amountLessThan = null,
            decimal? notAmountLessThan = null,
            DateTime? date = null,
            DateTime? notDate = null,
            DateTime? dateFrom = null,
            DateTime? dateTo = null,
            string? description = null,
            string? descriptionPartialMatch = null,
            string? notDescription = null,
            string? notDescriptionPartialMatch = null,
            bool? withDescription = null,
            TransactionType? type = null,
            TransactionType? notType = null,
            Guid? categoryId = null,
            Guid? notCategoryId = null,
            bool? withCategory = null,
            Guid? userId = null,
            Guid? notUserId = null,
            Guid? groupId = null,
            Guid? notGroupId = null,
            Guid? transactionGroupUserId = null,
            Guid? notTransactionGroupUserId = null,
            bool includeCategory = false,
            bool includeGroups = false,
            bool includeUser = false,
            bool includeParticipants = false,
            List<ITransactionCriteriaQuery>? and = null,
            List<ITransactionCriteriaQuery>? or = null,
            List<ITransactionCriteriaQuery>? not = null)
        {
            Id = id;
            AmountEqual = amountEqual;
            NotAmountEqual = notAmountEqual;
            AmountGreaterThan = amountGreaterThan;
            NotAmountGreaterThan = notAmountGreaterThan;
            AmountLessThan = amountLessThan;
            NotAmountLessThan = notAmountLessThan;
            Date = date;
            NotDate = notDate;
            DateFrom = dateFrom;
            DateTo = dateTo;
            Description = description;
            DescriptionPartialMatch = descriptionPartialMatch;
            NotDescription = notDescription;
            NotDescriptionPartialMatch = notDescriptionPartialMatch;
            WithDescription = withDescription;
            Type = type;
            NotType = notType;
            CategoryId = categoryId;
            NotCategoryId = notCategoryId;
            WithCategory = withCategory;
            UserId = userId;
            NotUserId = notUserId;
            GroupId = groupId;
            NotGroupId = notGroupId;
            TransactionGroupUserId = transactionGroupUserId;
            NotTransactionGroupUserId = notTransactionGroupUserId;
            IncludeCategory = includeCategory;
            IncludeGroups = includeGroups;
            IncludeUser = includeUser;
            IncludeParticipants = includeParticipants;
            And = and;
            Or = or;
            Not = not;
        }
    }
}