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
        public TransactionGroupUserQueryObject WithId(Guid id) => ApplyIdFilter(id, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionGroupUserQueryObject OrWithId(Guid id) => ApplyIdFilter(id, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionGroupUserQueryObject NotWithId(Guid id) => ApplyIdFilter(id, filter => Not(filter));

        #endregion

        #region IIsReadQuery

        /// <summary>
        /// Filters the query to include items that are read.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject IsRead() => ApplyIsReadFilter(true, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items that are read.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionGroupUserQueryObject OrIsRead() => ApplyIsReadFilter(true, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items that are read.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionGroupUserQueryObject NotIsRead() => ApplyIsReadFilter(true, filter => Not(filter));

        /// <summary>
        /// Filters the query to include items that are not read.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject IsNotRead() => ApplyIsReadFilter(false, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items that are not read.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionGroupUserQueryObject OrIsNotRead() => ApplyIsReadFilter(false, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items that are not read.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionGroupUserQueryObject NotIsNotRead() => ApplyIsReadFilter(false, filter => Not(filter));

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