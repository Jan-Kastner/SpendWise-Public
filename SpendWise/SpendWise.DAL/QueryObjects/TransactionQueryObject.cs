using System;
using System.Linq.Expressions;
using SpendWise.Common.Enums;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object for the <see cref="TransactionEntity"/>.
    /// Enables query construction using methods for AND, OR, and NOT operations.
    /// </summary>
    public class TransactionQueryObject : QueryObject<TransactionEntity>
    {
        #region AND

        /// <summary>
        /// Adds a condition to compare the transaction ID using an AND operation.
        /// </summary>
        /// <param name="id">The transaction ID to compare.</param>
        /// <returns>The current instance of <see cref="TransactionQueryObject"/>.</returns>
        public TransactionQueryObject WithId(Guid id)
        {
            And(entity => entity.Id == id);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the transaction amount using an AND operation.
        /// </summary>
        /// <param name="amount">The amount to compare.</param>
        /// <returns>The current instance of <see cref="TransactionQueryObject"/>.</returns>
        public TransactionQueryObject WithAmount(decimal amount)
        {
            And(entity => entity.Amount == amount);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the transaction date using an AND operation.
        /// </summary>
        /// <param name="date">The date to compare.</param>
        /// <returns>The current instance of <see cref="TransactionQueryObject"/>.</returns>
        public TransactionQueryObject WithDate(DateTime date)
        {
            And(entity => entity.Date.Date == date.Date);
            return this;
        }

        /// <summary>
        /// Adds a condition to filter transactions by description using an AND operation.
        /// </summary>
        /// <param name="description">The description to filter by.</param>
        /// <returns>The current instance of <see cref="TransactionQueryObject"/>.</returns>
        public TransactionQueryObject WithDescription(string description)
        {
            And(entity => entity.Description != null && entity.Description.Contains(description));
            return this;
        }

        /// <summary>
        /// Adds a condition to filter transactions with a null description using an AND operation.
        /// </summary>
        /// <returns>The current instance of <see cref="TransactionQueryObject"/>.</returns>
        public TransactionQueryObject WithNullDescription()
        {
            And(entity => entity.Description == null);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the transaction type using an AND operation.
        /// </summary>
        /// <param name="type">The transaction type to compare.</param>
        /// <returns>The current instance of <see cref="TransactionQueryObject"/>.</returns>
        public TransactionQueryObject WithType(TransactionType type)
        {
            And(entity => entity.Type == type);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the transaction category ID using an AND operation.
        /// </summary>
        /// <param name="categoryId">The category ID to compare.</param>
        /// <returns>The current instance of <see cref="TransactionQueryObject"/>.</returns>
        public TransactionQueryObject WithCategoryId(Guid? categoryId)
        {
            And(entity => entity.CategoryId == categoryId);
            return this;
        }

        /// <summary>
        /// Adds a condition to check if a specific group user is associated with the transaction using an AND operation.
        /// </summary>
        /// <param name="transactionGroupUserId">The transaction group user ID to compare.</param>
        /// <returns>The current instance of <see cref="TransactionQueryObject"/>.</returns>
        public TransactionQueryObject WithTransactionGroupUser(Guid transactionGroupUserId)
        {
            And(entity => entity.TransactionGroupUsers.Any(tgu => tgu.Id == transactionGroupUserId));
            return this;
        }

        #endregion

        #region OR

        /// <summary>
        /// Adds a condition to compare the transaction ID using an OR operation.
        /// </summary>
        /// <param name="id">The transaction ID to compare.</param>
        /// <returns>The current instance of <see cref="TransactionQueryObject"/>.</returns>
        public TransactionQueryObject OrWithId(Guid id)
        {
            Or(entity => entity.Id == id);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the transaction amount using an OR operation.
        /// </summary>
        /// <param name="amount">The amount to compare.</param>
        /// <returns>The current instance of <see cref="TransactionQueryObject"/>.</returns>
        public TransactionQueryObject OrWithAmount(decimal amount)
        {
            Or(entity => entity.Amount == amount);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the transaction date using an OR operation.
        /// </summary>
        /// <param name="date">The date to compare.</param>
        /// <returns>The current instance of <see cref="TransactionQueryObject"/>.</returns>
        public TransactionQueryObject OrWithDate(DateTime date)
        {
            Or(entity => entity.Date.Date == date.Date);
            return this;
        }

        /// <summary>
        /// Adds a condition to filter transactions by description using an OR operation.
        /// </summary>
        /// <param name="description">The description to filter by.</param>
        /// <returns>The current instance of <see cref="TransactionQueryObject"/>.</returns>
        public TransactionQueryObject OrWithDescription(string description)
        {
            Or(entity => entity.Description != null && entity.Description.Contains(description));
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the transaction type using an OR operation.
        /// </summary>
        /// <param name="type">The transaction type to compare.</param>
        /// <returns>The current instance of <see cref="TransactionQueryObject"/>.</returns>
        public TransactionQueryObject OrWithType(TransactionType type)
        {
            Or(entity => entity.Type == type);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the transaction category ID using an OR operation.
        /// </summary>
        /// <param name="categoryId">The category ID to compare.</param>
        /// <returns>The current instance of <see cref="TransactionQueryObject"/>.</returns>
        public TransactionQueryObject OrWithCategoryId(Guid? categoryId)
        {
            Or(entity => entity.CategoryId == categoryId);
            return this;
        }

        /// <summary>
        /// Adds a condition to check if a specific group user is associated with the transaction using an OR operation.
        /// </summary>
        /// <param name="transactionGroupUserId">The transaction group user ID to compare.</param>
        /// <returns>The current instance of <see cref="TransactionQueryObject"/>.</returns>
        public TransactionQueryObject OrWithTransactionGroupUser(Guid transactionGroupUserId)
        {
            Or(entity => entity.TransactionGroupUsers.Any(tgu => tgu.Id == transactionGroupUserId));
            return this;
        }

        #endregion

        #region NOT

        /// <summary>
        /// Adds a condition to exclude transactions with a specific ID using a NOT operation.
        /// </summary>
        /// <param name="id">The transaction ID to exclude.</param>
        /// <returns>The current instance of <see cref="TransactionQueryObject"/>.</returns>
        public TransactionQueryObject NotWithId(Guid id)
        {
            Not(entity => entity.Id == id);
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude transactions with a specific amount using a NOT operation.
        /// </summary>
        /// <param name="amount">The amount to exclude.</param>
        /// <returns>The current instance of <see cref="TransactionQueryObject"/>.</returns>
        public TransactionQueryObject NotWithAmount(decimal amount)
        {
            Not(entity => entity.Amount == amount);
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude transactions with a specific date using a NOT operation.
        /// </summary>
        /// <param name="date">The date to exclude.</param>
        /// <returns>The current instance of <see cref="TransactionQueryObject"/>.</returns>
        public TransactionQueryObject NotWithDate(DateTime date)
        {
            Not(entity => entity.Date.Date == date.Date);
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude transactions by description using a NOT operation.
        /// </summary>
        /// <param name="description">The description to exclude.</param>
        /// <returns>The current instance of <see cref="TransactionQueryObject"/>.</returns>
        public TransactionQueryObject NotWithDescription(string description)
        {
            Not(entity => entity.Description != null && entity.Description.Contains(description));
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude transactions with a specific type using a NOT operation.
        /// </summary>
        /// <param name="type">The transaction type to exclude.</param>
        /// <returns>The current instance of <see cref="TransactionQueryObject"/>.</returns>
        public TransactionQueryObject NotWithType(TransactionType type)
        {
            Not(entity => entity.Type == type);
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude transactions with a specific category ID using a NOT operation.
        /// </summary>
        /// <param name="categoryId">The category ID to exclude.</param>
        /// <returns>The current instance of <see cref="TransactionQueryObject"/>.</returns>
        public TransactionQueryObject NotWithCategoryId(Guid? categoryId)
        {
            Not(entity => entity.CategoryId == categoryId);
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude transactions associated with a specific group user using a NOT operation.
        /// </summary>
        /// <param name="transactionGroupUserId">The transaction group user ID to exclude.</param>
        /// <returns>The current instance of <see cref="TransactionQueryObject"/>.</returns>
        public TransactionQueryObject NotWithTransactionGroupUser(Guid transactionGroupUserId)
        {
            Not(entity => entity.TransactionGroupUsers.Any(tgu => tgu.Id == transactionGroupUserId));
            return this;
        }

        #endregion
    }
}
