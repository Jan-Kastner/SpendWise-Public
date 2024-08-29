using System;
using System.Linq.Expressions;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object for the <see cref="TransactionGroupUserEntity"/>.
    /// Enables query construction using methods for AND, OR, and NOT operations.
    /// </summary>
    public class TransactionGroupUserQueryObject : QueryObject<TransactionGroupUserEntity>
    {
        #region AND

        /// <summary>
        /// Adds a condition to compare the entity ID using an AND operation.
        /// </summary>
        /// <param name="id">The ID to compare.</param>
        /// <returns>The current instance of <see cref="TransactionGroupUserQueryObject"/>.</returns>
        public TransactionGroupUserQueryObject WithId(Guid id)
        {
            And(entity => entity.Id == id);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the transaction ID using an AND operation.
        /// </summary>
        /// <param name="transactionId">The transaction ID to compare.</param>
        /// <returns>The current instance of <see cref="TransactionGroupUserQueryObject"/>.</returns>
        public TransactionGroupUserQueryObject WithTransactionId(Guid transactionId)
        {
            And(entity => entity.TransactionId == transactionId);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the group user ID using an AND operation.
        /// </summary>
        /// <param name="groupUserId">The group user ID to compare.</param>
        /// <returns>The current instance of <see cref="TransactionGroupUserQueryObject"/>.</returns>
        public TransactionGroupUserQueryObject WithGroupUserId(Guid groupUserId)
        {
            And(entity => entity.GroupUserId == groupUserId);
            return this;
        }

        #endregion

        #region OR

        /// <summary>
        /// Adds a condition to compare the entity ID using an OR operation.
        /// </summary>
        /// <param name="id">The ID to compare.</param>
        /// <returns>The current instance of <see cref="TransactionGroupUserQueryObject"/>.</returns>
        public TransactionGroupUserQueryObject OrWithId(Guid id)
        {
            Or(entity => entity.Id == id);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the transaction ID using an OR operation.
        /// </summary>
        /// <param name="transactionId">The transaction ID to compare.</param>
        /// <returns>The current instance of <see cref="TransactionGroupUserQueryObject"/>.</returns>
        public TransactionGroupUserQueryObject OrWithTransactionId(Guid transactionId)
        {
            Or(entity => entity.TransactionId == transactionId);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the group user ID using an OR operation.
        /// </summary>
        /// <param name="groupUserId">The group user ID to compare.</param>
        /// <returns>The current instance of <see cref="TransactionGroupUserQueryObject"/>.</returns>
        public TransactionGroupUserQueryObject OrWithGroupUserId(Guid groupUserId)
        {
            Or(entity => entity.GroupUserId == groupUserId);
            return this;
        }

        #endregion

        #region NOT

        /// <summary>
        /// Adds a condition to exclude entities with a specific ID using a NOT operation.
        /// </summary>
        /// <param name="id">The ID to exclude.</param>
        /// <returns>The current instance of <see cref="TransactionGroupUserQueryObject"/>.</returns>
        public TransactionGroupUserQueryObject NotWithId(Guid id)
        {
            Not(entity => entity.Id == id);
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude entities with a specific transaction ID using a NOT operation.
        /// </summary>
        /// <param name="transactionId">The transaction ID to exclude.</param>
        /// <returns>The current instance of <see cref="TransactionGroupUserQueryObject"/>.</returns>
        public TransactionGroupUserQueryObject NotWithTransactionId(Guid transactionId)
        {
            Not(entity => entity.TransactionId == transactionId);
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude entities with a specific group user ID using a NOT operation.
        /// </summary>
        /// <param name="groupUserId">The group user ID to exclude.</param>
        /// <returns>The current instance of <see cref="TransactionGroupUserQueryObject"/>.</returns>
        public TransactionGroupUserQueryObject NotWithGroupUserId(Guid groupUserId)
        {
            Not(entity => entity.GroupUserId == groupUserId);
            return this;
        }

        #endregion
    }
}
