using System;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object for the <see cref="TransactionGroupUserEntity"/>.
    /// Enables query construction using methods for AND, OR, and NOT operations.
    /// </summary>
    public class TransactionGroupUserQueryObject : BaseQueryObject<TransactionGroupUserEntity, TransactionGroupUserQueryObject>, ITransactionGroupUserQueryObject<TransactionGroupUserQueryObject>, IIsReadQuery<TransactionGroupUserQueryObject>
    {
        #region IIdQuery

        /// <summary>
        /// Filters the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new TransactionGroupUserQueryObject WithId(Guid id) => base.WithId(id);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new TransactionGroupUserQueryObject OrWithId(Guid id) => base.OrWithId(id);

        /// <summary>
        /// Filters the query to exclude items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new TransactionGroupUserQueryObject NotWithId(Guid id) => base.NotWithId(id);

        #endregion

        #region IIsReadQuery

        /// <summary>
        /// Filters the query to include items that are read.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject IsRead() => WithIsRead(true);

        /// <summary>
        /// Adds an OR condition to the query to include items that are read.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionGroupUserQueryObject OrIsRead() => OrWithIsRead(true);

        /// <summary>
        /// Filters the query to exclude items that are read.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionGroupUserQueryObject NotIsRead() => NotWithIsRead(true);

        /// <summary>
        /// Filters the query to include items that are not read.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject IsNotRead() => WithIsRead(false);

        /// <summary>
        /// Adds an OR condition to the query to include items that are not read.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionGroupUserQueryObject OrIsNotRead() => OrWithIsRead(false);

        /// <summary>
        /// Filters the query to exclude items that are not read.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionGroupUserQueryObject NotIsNotRead() => NotWithIsRead(false);

        #endregion

        #region ITransactionQuery

        /// <summary>
        /// Filters the query to include items with the specified transaction ID.
        /// </summary>
        /// <param name="transactionId">The transaction ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject WithTransaction(Guid transactionId)
        {
            And(entity => entity.TransactionId == transactionId);
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified transaction ID.
        /// </summary>
        /// <param name="transactionId">The transaction ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionGroupUserQueryObject OrWithTransaction(Guid transactionId)
        {
            Or(entity => entity.TransactionId == transactionId);
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified transaction ID.
        /// </summary>
        /// <param name="transactionId">The transaction ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionGroupUserQueryObject NotWithTransaction(Guid transactionId)
        {
            Not(entity => entity.TransactionId == transactionId);
            return this;
        }

        #endregion

        #region IGroupUserQuery

        /// <summary>
        /// Filters the query to include items with the specified group user ID.
        /// </summary>
        /// <param name="groupUserId">The group user ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject WithGroupUser(Guid groupUserId)
        {
            And(entity => entity.GroupUserId == groupUserId);
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified group user ID.
        /// </summary>
        /// <param name="groupUserId">The group user ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionGroupUserQueryObject OrWithGroupUser(Guid groupUserId)
        {
            Or(entity => entity.GroupUserId == groupUserId);
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified group user ID.
        /// </summary>
        /// <param name="groupUserId">The group user ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionGroupUserQueryObject NotWithGroupUser(Guid groupUserId)
        {
            Not(entity => entity.GroupUserId == groupUserId);
            return this;
        }

        #endregion
    }
}