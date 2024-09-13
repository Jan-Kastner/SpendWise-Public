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
        public TransactionQueryObject WithId(Guid id) => ApplyIdFilter(id, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionQueryObject OrWithId(Guid id) => ApplyIdFilter(id, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionQueryObject NotWithId(Guid id) => ApplyIdFilter(id, filter => Not(filter));

        #endregion

        #region IAmountQuery

        /// <summary>
        /// Filters the query to include items with the specified amount.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionQueryObject WithAmount(decimal amount) => ApplyAmountFilter(amount, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified amount.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionQueryObject OrWithAmount(decimal amount) => ApplyAmountFilter(amount, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified amount.
        /// </summary>
        /// <param name="amount">The amount to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionQueryObject NotWithAmount(decimal amount) => ApplyAmountFilter(amount, filter => Not(filter));

        #endregion

        #region IDateQuery

        /// <summary>
        /// Filters the query to include items with the specified date.
        /// </summary>
        /// <param name="date">The date to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionQueryObject WithDate(DateTime date) => ApplyDateFilter(date, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified date.
        /// </summary>
        /// <param name="date">The date to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionQueryObject OrWithDate(DateTime date) => ApplyDateFilter(date, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified date.
        /// </summary>
        /// <param name="date">The date to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionQueryObject NotWithDate(DateTime date) => ApplyDateFilter(date, filter => Not(filter));

        #endregion

        #region IDescriptionQuery

        /// <summary>
        /// Filters the query to include items with the specified description.
        /// </summary>
        /// <param name="description">The description to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionQueryObject WithDescription(string? description) => ApplyDescriptionFilter(description, filter => And(filter), false);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified description.
        /// </summary>
        /// <param name="description">The description to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionQueryObject OrWithDescription(string? description) => ApplyDescriptionFilter(description, filter => Or(filter), false);

        /// <summary>
        /// Filters the query to exclude items with the specified description.
        /// </summary>
        /// <param name="description">The description to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionQueryObject NotWithDescription(string? description) => ApplyDescriptionFilter(description, filter => Not(filter), false);

        /// <summary>
        /// Filters the query to include items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionQueryObject WithDescriptionPartialMatch(string text) => ApplyDescriptionFilter(text, filter => And(filter), true);

        /// <summary>
        /// Adds an OR condition to the query to include items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionQueryObject OrWithDescriptionPartialMatch(string text) => ApplyDescriptionFilter(text, filter => Or(filter), true);

        /// <summary>
        /// Filters the query to exclude items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionQueryObject NotWithDescriptionPartialMatch(string text) => ApplyDescriptionFilter(text, filter => Not(filter), true);

        /// <summary>
        /// Filters the query to include items without a description.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionQueryObject WithoutDescription() => ApplyDescriptionFilter(null, filter => And(filter), false, true);

        /// <summary>
        /// Adds an OR condition to the query to include items without a description.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionQueryObject OrWithoutDescription() => ApplyDescriptionFilter(null, filter => Or(filter), false, true);

        /// <summary>
        /// Filters the query to exclude items without a description.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionQueryObject NotWithoutDescription() => ApplyDescriptionFilter(null, filter => Not(filter), false, true);

        #endregion

        #region ITypeQuery

        /// <summary>
        /// Filters the query to include items with the specified transaction type.
        /// </summary>
        /// <param name="type">The transaction type to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionQueryObject WithType(TransactionType type) => ApplyTransactionTypeFilter(type, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified transaction type.
        /// </summary>
        /// <param name="type">The transaction type to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionQueryObject OrWithType(TransactionType type) => ApplyTransactionTypeFilter(type, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified transaction type.
        /// </summary>
        /// <param name="type">The transaction type to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionQueryObject NotWithType(TransactionType type) => ApplyTransactionTypeFilter(type, filter => Not(filter));

        #endregion

        #region ICategoryQuery

        /// <summary>
        /// Filters the query to include items with the specified category ID.
        /// </summary>
        /// <param name="categoryId">The category ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionQueryObject WithCategory(Guid? categoryId)
        {
            And(entity => entity.CategoryId != null && entity.CategoryId == categoryId);
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified category ID.
        /// </summary>
        /// <param name="categoryId">The category ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionQueryObject OrWithCategory(Guid? categoryId)
        {
            Or(entity => entity.CategoryId != null && entity.CategoryId == categoryId);
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified category ID.
        /// </summary>
        /// <param name="categoryId">The category ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionQueryObject NotWithCategory(Guid? categoryId)
        {
            Not(entity => entity.CategoryId != null && entity.CategoryId == categoryId);
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