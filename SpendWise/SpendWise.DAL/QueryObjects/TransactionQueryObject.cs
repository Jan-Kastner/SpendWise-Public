using System;
using System.Linq.Expressions;
using SpendWise.Common.Enums;
using SpendWise.DAL.Entities;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object for the <see cref="TransactionEntity"/>.
    /// Enables query construction using methods for AND, OR, and NOT operations.
    /// </summary>
    public class TransactionQueryObject : BaseQueryObject<TransactionEntity, TransactionQueryObject>, ITransactionQueryObject<TransactionQueryObject>
    {
        #region IIdQuery

        /// <summary>
        /// Filters the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new TransactionQueryObject WithId(Guid id) => base.WithId(id);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new TransactionQueryObject OrWithId(Guid id) => base.OrWithId(id);

        /// <summary>
        /// Filters the query to exclude items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new TransactionQueryObject NotWithId(Guid id) => base.NotWithId(id);

        #endregion

        #region IAmountQuery

        /// <summary>
        /// Filters the query to include items with the specified amount.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new TransactionQueryObject WithAmount(decimal amount) => base.WithAmount(amount);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified amount.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new TransactionQueryObject OrWithAmount(decimal amount) => base.OrWithAmount(amount);

        /// <summary>
        /// Filters the query to exclude items with the specified amount.
        /// </summary>
        /// <param name="amount">The amount to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new TransactionQueryObject NotWithAmount(decimal amount) => base.NotWithAmount(amount);

        #endregion

        #region IDateQuery

        /// <summary>
        /// Filters the query to include items with the specified date.
        /// </summary>
        /// <param name="date">The date to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new TransactionQueryObject WithDate(DateTime date) => base.WithDate(date);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified date.
        /// </summary>
        /// <param name="date">The date to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new TransactionQueryObject OrWithDate(DateTime date) => base.OrWithDate(date);

        /// <summary>
        /// Filters the query to exclude items with the specified date.
        /// </summary>
        /// <param name="date">The date to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new TransactionQueryObject NotWithDate(DateTime date) => base.NotWithDate(date);

        #endregion

        #region IDescriptionQuery

        /// <summary>
        /// Filters the query to include items with the specified description.
        /// </summary>
        /// <param name="description">The description to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new TransactionQueryObject WithDescription(string? description) => base.WithDescription(description);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified description.
        /// </summary>
        /// <param name="description">The description to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new TransactionQueryObject OrWithDescription(string? description) => base.OrWithDescription(description);

        /// <summary>
        /// Filters the query to exclude items with the specified description.
        /// </summary>
        /// <param name="description">The description to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new TransactionQueryObject NotWithDescription(string? description) => base.NotWithDescription(description);

        /// <summary>
        /// Filters the query to include items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new TransactionQueryObject WithDescriptionPartialMatch(string text) => base.WithDescriptionPartialMatch(text);

        /// <summary>
        /// Adds an OR condition to the query to include items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new TransactionQueryObject OrWithDescriptionPartialMatch(string text) => base.OrWithDescriptionPartialMatch(text);

        /// <summary>
        /// Filters the query to exclude items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new TransactionQueryObject NotWithDescriptionPartialMatch(string text) => base.NotWithDescriptionPartialMatch(text);

        /// <summary>
        /// Filters the query to include items without a description.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public new TransactionQueryObject WithoutDescription() => base.WithoutDescription();

        /// <summary>
        /// Adds an OR condition to the query to include items without a description.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public new TransactionQueryObject OrWithoutDescription() => base.OrWithoutDescription();

        /// <summary>
        /// Filters the query to exclude items without a description.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new TransactionQueryObject NotWithoutDescription() => base.NotWithoutDescription();

        #endregion

        #region ITypeQuery

        /// <summary>
        /// Filters the query to include items with the specified transaction type.
        /// </summary>
        /// <param name="type">The transaction type to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new TransactionQueryObject WithType(TransactionType type) => base.WithType(type);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified transaction type.
        /// </summary>
        /// <param name="type">The transaction type to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new TransactionQueryObject OrWithType(TransactionType type) => base.OrWithType(type);

        /// <summary>
        /// Filters the query to exclude items with the specified transaction type.
        /// </summary>
        /// <param name="type">The transaction type to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new TransactionQueryObject NotWithType(TransactionType type) => base.NotWithType(type);

        #endregion

        #region ICategoryQuery

        /// <summary>
        /// Filters the query to include items with the specified category ID.
        /// </summary>
        /// <param name="categoryId">The category ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionQueryObject WithCategory(Guid? categoryId)
        {
            And(entity => entity.CategoryId == categoryId);
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified category ID.
        /// </summary>
        /// <param name="categoryId">The category ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionQueryObject OrWithCategory(Guid? categoryId)
        {
            Or(entity => entity.CategoryId == categoryId);
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified category ID.
        /// </summary>
        /// <param name="categoryId">The category ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionQueryObject NotWithCategory(Guid? categoryId)
        {
            Not(entity => entity.CategoryId == categoryId);
            return this;
        }

        /// <summary>
        /// Filters the query to include items without a category.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionQueryObject WithoutCategory()
        {
            And(entity => entity.CategoryId == null);
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items without a category.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionQueryObject OrWithoutCategory()
        {
            Or(entity => entity.CategoryId == null);
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items without a category.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionQueryObject NotWithoutCategory()
        {
            Not(entity => entity.CategoryId == null);
            return this;
        }

        #endregion

        #region ITransactionGroupUserQuery

        /// <summary>
        /// Filters the query to include items with the specified transaction group user ID.
        /// </summary>
        /// <param name="transactionGroupUserId">The transaction group user ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionQueryObject WithTransactionGroupUser(Guid transactionGroupUserId)
        {
            And(entity => entity.TransactionGroupUsers.Any(tgu => tgu.Id == transactionGroupUserId));
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified transaction group user ID.
        /// </summary>
        /// <param name="transactionGroupUserId">The transaction group user ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionQueryObject OrWithTransactionGroupUser(Guid transactionGroupUserId)
        {
            Or(entity => entity.TransactionGroupUsers.Any(tgu => tgu.Id == transactionGroupUserId));
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified transaction group user ID.
        /// </summary>
        /// <param name="transactionGroupUserId">The transaction group user ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionQueryObject NotWithTransactionGroupUser(Guid transactionGroupUserId)
        {
            Not(entity => entity.TransactionGroupUsers.Any(tgu => tgu.Id == transactionGroupUserId));
            return this;
        }

        #endregion
    }
}