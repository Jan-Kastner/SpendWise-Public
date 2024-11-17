using SpendWise.Common.Enums;

namespace SpendWise.BLL.Queries.Interfaces
{
    /// <summary>
    /// Represents an interface for transaction criteria-based queries.
    /// </summary>
    public interface ITransactionCriteriaQuery : ICriteriaQuery
    {
        /// <summary>
        /// Gets the unique identifier of the transaction that should not match.
        /// </summary>
        Guid? NotId { get; }

        /// <summary>
        /// Gets the amount of the transaction.
        /// </summary>
        decimal? Amount { get; }

        /// <summary>
        /// Gets the amount that should not match the transaction amount.
        /// </summary>
        decimal? NotAmount { get; }

        /// <summary>
        /// Gets the date of the transaction.
        /// </summary>
        DateTime? Date { get; }

        /// <summary>
        /// Gets the date that should not match the transaction date.
        /// </summary>
        DateTime? NotDate { get; }

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
        bool? WithoutDescription { get; }

        /// <summary>
        /// Gets a value indicating whether the transaction should not be without a description.
        /// </summary>
        bool? NotWithoutDescription { get; }

        /// <summary>
        /// Gets the type of the transaction.
        /// </summary>
        TransactionType? Type { get; }

        /// <summary>
        /// Gets the type that should not match the transaction type.
        /// </summary>
        TransactionType? NotType { get; }

        /// <summary>
        /// Gets the unique identifier of the category.
        /// </summary>
        Guid? CategoryId { get; }

        /// <summary>
        /// Gets the unique identifier of the category that should not match.
        /// </summary>
        Guid? NotCategoryId { get; }

        /// <summary>
        /// Gets a value indicating whether the transaction should be without a category.
        /// </summary>
        bool? WithoutCategory { get; }

        /// <summary>
        /// Gets a value indicating whether the transaction should not be without a category.
        /// </summary>
        bool? NotWithoutCategory { get; }

        /// <summary>
        /// Gets the unique identifier of the transaction group user.
        /// </summary>
        Guid? TransactionGroupUserId { get; }

        /// <summary>
        /// Gets the unique identifier of the transaction group user that should not match.
        /// </summary>
        Guid? NotTransactionGroupUserId { get; }
    }
}