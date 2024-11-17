using SpendWise.BLL.Queries.Interfaces;
using SpendWise.Common.Enums;
using System;

namespace SpendWise.BLL.Queries
{
    /// <summary>
    /// Represents a query object for retrieving transactions based on various criteria.
    /// </summary>
    public class GetTransactionsByCriteriaQuery : ITransactionCriteriaQuery, ITransactionIncludeQuery
    {
        /// <summary>
        /// Gets the unique identifier of the transaction.
        /// </summary>
        public Guid? Id { get; }

        /// <summary>
        /// Gets the unique identifier of the transaction that should not match.
        /// </summary>
        public Guid? NotId { get; }

        /// <summary>
        /// Gets the amount of the transaction.
        /// </summary>
        public decimal? Amount { get; }

        /// <summary>
        /// Gets the amount that should not match the transaction amount.
        /// </summary>
        public decimal? NotAmount { get; }

        /// <summary>
        /// Gets the date of the transaction.
        /// </summary>
        public DateTime? Date { get; }

        /// <summary>
        /// Gets the date that should not match the transaction date.
        /// </summary>
        public DateTime? NotDate { get; }

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
        public bool? WithoutDescription { get; }

        /// <summary>
        /// Gets a value indicating whether the transaction should not be without a description.
        /// </summary>
        public bool? NotWithoutDescription { get; }

        /// <summary>
        /// Gets the type of the transaction.
        /// </summary>
        public TransactionType? Type { get; }

        /// <summary>
        /// Gets the type that should not match the transaction type.
        /// </summary>
        public TransactionType? NotType { get; }

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
        public bool? WithoutCategory { get; }

        /// <summary>
        /// Gets a value indicating whether the transaction should not be without a category.
        /// </summary>
        public bool? NotWithoutCategory { get; }

        /// <summary>
        /// Gets the unique identifier of the transaction group user.
        /// </summary>
        public Guid? TransactionGroupUserId { get; }

        /// <summary>
        /// Gets the unique identifier of the transaction group user that should not match.
        /// </summary>
        public Guid? NotTransactionGroupUserId { get; }

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

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTransactionsByCriteriaQuery"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the transaction.</param>
        /// <param name="notId">The unique identifier of the transaction that should not match.</param>
        /// <param name="amount">The amount of the transaction.</param>
        /// <param name="notAmount">The amount that should not match the transaction amount.</param>
        /// <param name="date">The date of the transaction.</param>
        /// <param name="notDate">The date that should not match the transaction date.</param>
        /// <param name="description">The description of the transaction.</param>
        /// <param name="descriptionPartialMatch">The partial match for the transaction description.</param>
        /// <param name="notDescription">The description that should not match the transaction description.</param>
        /// <param name="notDescriptionPartialMatch">The partial match for the description that should not match the transaction description.</param>
        /// <param name="withoutDescription">Indicates whether the transaction should be without a description.</param>
        /// <param name="notWithoutDescription">Indicates whether the transaction should not be without a description.</param>
        /// <param name="type">The type of the transaction.</param>
        /// <param name="notType">The type that should not match the transaction type.</param>
        /// <param name="categoryId">The unique identifier of the category.</param>
        /// <param name="notCategoryId">The unique identifier of the category that should not match.</param>
        /// <param name="withoutCategory">Indicates whether the transaction should be without a category.</param>
        /// <param name="notWithoutCategory">Indicates whether the transaction should not be without a category.</param>
        /// <param name="transactionGroupUserId">The unique identifier of the transaction group user.</param>
        /// <param name="notTransactionGroupUserId">The unique identifier of the transaction group user that should not match.</param>
        /// <param name="includeCategory">A value indicating whether to include the category in the query result. Default is false.</param>
        /// <param name="includeGroups">A value indicating whether to include the transaction group users in the query result. Default is false.</param>
        /// <param name="includeUser">A value indicating whether to include the user in the query result. Default is false.</param>
        /// <param name="includeParticipants">A value indicating whether to include the participants in the query result. Default is false.</param>
        public GetTransactionsByCriteriaQuery(
            Guid? id = null,
            Guid? notId = null,
            decimal? amount = null,
            decimal? notAmount = null,
            DateTime? date = null,
            DateTime? notDate = null,
            string? description = null,
            string? descriptionPartialMatch = null,
            string? notDescription = null,
            string? notDescriptionPartialMatch = null,
            bool? withoutDescription = null,
            bool? notWithoutDescription = null,
            TransactionType? type = null,
            TransactionType? notType = null,
            Guid? categoryId = null,
            Guid? notCategoryId = null,
            bool? withoutCategory = null,
            bool? notWithoutCategory = null,
            Guid? transactionGroupUserId = null,
            Guid? notTransactionGroupUserId = null,
            bool includeCategory = false,
            bool includeGroups = false,
            bool includeUser = false,
            bool includeParticipants = false)
        {
            Id = id;
            NotId = notId;
            Amount = amount;
            NotAmount = notAmount;
            Date = date;
            NotDate = notDate;
            Description = description;
            DescriptionPartialMatch = descriptionPartialMatch;
            NotDescription = notDescription;
            NotDescriptionPartialMatch = notDescriptionPartialMatch;
            WithoutDescription = withoutDescription;
            NotWithoutDescription = notWithoutDescription;
            Type = type;
            NotType = notType;
            CategoryId = categoryId;
            NotCategoryId = notCategoryId;
            WithoutCategory = withoutCategory;
            NotWithoutCategory = notWithoutCategory;
            TransactionGroupUserId = transactionGroupUserId;
            NotTransactionGroupUserId = notTransactionGroupUserId;
            IncludeCategory = includeCategory;
            IncludeGroups = includeGroups;
            IncludeUser = includeUser;
            IncludeParticipants = includeParticipants;
        }
    }
}