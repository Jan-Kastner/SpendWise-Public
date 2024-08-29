using System;
using System.Linq.Expressions;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object for the <see cref="GroupUserEntity"/>.
    /// Enables query construction using methods for AND, OR, and NOT operations.
    /// </summary>
    public class GroupUserQueryObject : QueryObject<GroupUserEntity>
    {
        #region AND

        /// <summary>
        /// Adds a condition to compare the group user ID using an AND operation.
        /// </summary>
        /// <param name="id">The group user ID to compare.</param>
        /// <returns>The current instance of <see cref="GroupUserQueryObject"/>.</returns>
        public GroupUserQueryObject WithId(Guid id)
        {
            And(entity => entity.Id == id);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the user ID using an AND operation.
        /// </summary>
        /// <param name="userId">The user ID to compare.</param>
        /// <returns>The current instance of <see cref="GroupUserQueryObject"/>.</returns>
        public GroupUserQueryObject WithUserId(Guid userId)
        {
            And(entity => entity.UserId == userId);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the group ID using an AND operation.
        /// </summary>
        /// <param name="groupId">The group ID to compare.</param>
        /// <returns>The current instance of <see cref="GroupUserQueryObject"/>.</returns>
        public GroupUserQueryObject WithGroupId(Guid groupId)
        {
            And(entity => entity.GroupId == groupId);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the limit ID using an AND operation.
        /// </summary>
        /// <param name="limitId">The limit ID to compare.</param>
        /// <returns>The current instance of <see cref="GroupUserQueryObject"/>.</returns>
        public GroupUserQueryObject WithLimitId(Guid? limitId)
        {
            And(entity => entity.LimitId == limitId);
            return this;
        }

        /// <summary>
        /// Adds a condition to include entities that have a specific transaction group user ID using an AND operation.
        /// </summary>
        /// <param name="transactionGroupUserId">The transaction group user ID to match.</param>
        /// <returns>The current instance of <see cref="GroupUserQueryObject"/>.</returns>
        public GroupUserQueryObject WithTransactionGroupUser(Guid transactionGroupUserId)
        {
            And(entity => entity.TransactionGroupUsers.Any(tgu => tgu.Id == transactionGroupUserId));
            return this;
        }

        #endregion

        #region OR

        /// <summary>
        /// Adds a condition to compare the group user ID using an OR operation.
        /// </summary>
        /// <param name="id">The group user ID to compare.</param>
        /// <returns>The current instance of <see cref="GroupUserQueryObject"/>.</returns>
        public GroupUserQueryObject OrWithId(Guid id)
        {
            Or(entity => entity.Id == id);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the user ID using an OR operation.
        /// </summary>
        /// <param name="userId">The user ID to compare.</param>
        /// <returns>The current instance of <see cref="GroupUserQueryObject"/>.</returns>
        public GroupUserQueryObject OrWithUserId(Guid userId)
        {
            Or(entity => entity.UserId == userId);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the group ID using an OR operation.
        /// </summary>
        /// <param name="groupId">The group ID to compare.</param>
        /// <returns>The current instance of <see cref="GroupUserQueryObject"/>.</returns>
        public GroupUserQueryObject OrWithGroupId(Guid groupId)
        {
            Or(entity => entity.GroupId == groupId);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the limit ID using an OR operation.
        /// </summary>
        /// <param name="limitId">The limit ID to compare.</param>
        /// <returns>The current instance of <see cref="GroupUserQueryObject"/>.</returns>
        public GroupUserQueryObject OrWithLimitId(Guid? limitId)
        {
            Or(entity => entity.LimitId == limitId);
            return this;
        }

        /// <summary>
        /// Adds a condition to include entities that have a specific transaction group user ID using an OR operation.
        /// </summary>
        /// <param name="transactionGroupUserId">The transaction group user ID to match.</param>
        /// <returns>The current instance of <see cref="GroupUserQueryObject"/>.</returns>
        public GroupUserQueryObject OrWithTransactionGroupUser(Guid transactionGroupUserId)
        {
            Or(entity => entity.TransactionGroupUsers.Any(tgu => tgu.Id == transactionGroupUserId));
            return this;
        }

        #endregion

        #region NOT

        /// <summary>
        /// Adds a condition to exclude entities with a specific group user ID using a NOT operation.
        /// </summary>
        /// <param name="id">The group user ID to exclude.</param>
        /// <returns>The current instance of <see cref="GroupUserQueryObject"/>.</returns>
        public GroupUserQueryObject NotWithId(Guid id)
        {
            Not(entity => entity.Id == id);
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude entities with a specific user ID using a NOT operation.
        /// </summary>
        /// <param name="userId">The user ID to exclude.</param>
        /// <returns>The current instance of <see cref="GroupUserQueryObject"/>.</returns>
        public GroupUserQueryObject NotWithUserId(Guid userId)
        {
            Not(entity => entity.UserId == userId);
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude entities with a specific group ID using a NOT operation.
        /// </summary>
        /// <param name="groupId">The group ID to exclude.</param>
        /// <returns>The current instance of <see cref="GroupUserQueryObject"/>.</returns>
        public GroupUserQueryObject NotWithGroupId(Guid groupId)
        {
            Not(entity => entity.GroupId == groupId);
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude entities with a specific limit ID using a NOT operation.
        /// </summary>
        /// <param name="limitId">The limit ID to exclude.</param>
        /// <returns>The current instance of <see cref="GroupUserQueryObject"/>.</returns>
        public GroupUserQueryObject NotWithLimitId(Guid? limitId)
        {
            Not(entity => entity.LimitId == limitId);
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude entities that have a specific transaction group user ID using a NOT operation.
        /// </summary>
        /// <param name="transactionGroupUserId">The transaction group user ID to exclude.</param>
        /// <returns>The current instance of <see cref="GroupUserQueryObject"/>.</returns>
        public GroupUserQueryObject NotWithTransactionGroupUser(Guid transactionGroupUserId)
        {
            Not(entity => entity.TransactionGroupUsers.Any(tgu => tgu.Id == transactionGroupUserId));
            return this;
        }

        #endregion
    }
}
