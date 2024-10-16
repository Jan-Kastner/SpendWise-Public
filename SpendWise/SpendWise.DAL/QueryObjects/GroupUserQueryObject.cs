using SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupUserEntity.Interfaces;
using SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupUserEntity;
using SpendWise.DAL.Entities;
using SpendWise.Common.Enums;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object for the <see cref="GroupUserEntity"/>.
    /// Enables query construction using methods for AND, OR, and NOT operations.
    /// </summary>
    public class GroupUserQueryObject : BaseQueryObject<GroupUserEntity, GroupUserQueryObject>, IGroupUserQueryObject
    {
        private GroupUserEntityRelationsConfig _relations = new GroupUserEntityRelationsConfig();

        /// <summary>
        /// Gets the initial state for group user relations.
        /// </summary>
        public IGroupUserEntityInitialState Relations => _relations;

        /// <summary>
        /// Gets the list of include properties for the query.
        /// </summary>
        public override List<string> Includes => _relations.Includes;

        /// <summary>
        /// Gets the collection of include directives used by the RelationConfigGenerator
        /// to generate EntityRelationsConfiguration, which acts as a state machine for managing includes.
        /// </summary>
        public override ICollection<Func<GroupUserEntity, object>> IncludeDirectives { get; } = new List<Func<GroupUserEntity, object>>
        {
            entity => entity.User,
            entity => entity.Group,
            entity => entity.Limit!,
            entity => entity.TransactionGroupUsers,
            entity => entity.TransactionGroupUsers.Select(tgu => tgu.Transaction)
        };

        #region IIdQuery

        /// <summary>
        /// Filters the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public GroupUserQueryObject WithId(Guid id) => ApplyIdFilter(id, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupUserQueryObject OrWithId(Guid id) => ApplyIdFilter(id, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupUserQueryObject NotWithId(Guid id) => ApplyIdFilter(id, filter => Not(filter));

        #endregion

        #region IRoleQuery

        /// <summary>
        /// Filters the query to include items with the specified user role.
        /// </summary>
        /// <param name="role">The user role to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public GroupUserQueryObject WithUserRole(UserRole role) => ApplyUserRoleFilter(role, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user role.
        /// </summary>
        /// <param name="role">The user role to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupUserQueryObject OrWithUserRole(UserRole role) => ApplyUserRoleFilter(role, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified user role.
        /// </summary>
        /// <param name="role">The user role to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupUserQueryObject NotWithUserRole(UserRole role) => ApplyUserRoleFilter(role, filter => Not(filter));

        #endregion

        #region IUserQuery

        /// <summary>
        /// Filters the query to include items with the specified user ID.
        /// </summary>
        /// <param name="userId">The user ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public GroupUserQueryObject WithUser(Guid userId)
        {
            And(entity => entity.UserId == userId);
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user ID.
        /// </summary>
        /// <param name="userId">The user ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupUserQueryObject OrWithUser(Guid userId)
        {
            Or(entity => entity.UserId == userId);
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified user ID.
        /// </summary>
        /// <param name="userId">The user ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupUserQueryObject NotWithUser(Guid userId)
        {
            Not(entity => entity.UserId == userId);
            return this;
        }

        #endregion

        #region IGroupQuery

        /// <summary>
        /// Filters the query to include items with the specified group ID.
        /// </summary>
        /// <param name="groupId">The group ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public GroupUserQueryObject WithGroup(Guid groupId)
        {
            And(entity => entity.GroupId == groupId);
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified group ID.
        /// </summary>
        /// <param name="groupId">The group ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupUserQueryObject OrWithGroup(Guid groupId)
        {
            Or(entity => entity.GroupId == groupId);
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified group ID.
        /// </summary>
        /// <param name="groupId">The group ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupUserQueryObject NotWithGroup(Guid groupId)
        {
            Not(entity => entity.GroupId == groupId);
            return this;
        }

        #endregion

        #region ILimitQuery

        /// <summary>
        /// Filters the query to include items with the specified limit ID.
        /// </summary>
        /// <param name="limitId">The limit ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public GroupUserQueryObject WithLimit(Guid limitId)
        {
            And(entity => entity.LimitId != null && entity.LimitId == limitId);
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified limit ID.
        /// </summary>
        /// <param name="limitId">The limit ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupUserQueryObject OrWithLimit(Guid limitId)
        {
            Or(entity => entity.LimitId != null && entity.LimitId == limitId);
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified limit ID.
        /// </summary>
        /// <param name="limitId">The limit ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupUserQueryObject NotWithLimit(Guid limitId)
        {
            Not(entity => entity.LimitId != null && entity.LimitId == limitId);
            return this;
        }

        /// <summary>
        /// Filters the query to include items without any limit ID (null).
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public GroupUserQueryObject WithoutLimit()
        {
            And(entity => entity.LimitId == null);
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items without any limit ID (null).
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupUserQueryObject OrWithoutLimit()
        {
            Or(entity => entity.LimitId == null);
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items without any limit ID (null).
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupUserQueryObject NotWithoutLimit()
        {
            Not(entity => entity.LimitId == null);
            return this;
        }

        #endregion

        #region ITransactionGroupUserQuery

        /// <summary>
        /// Filters the query to include items with the specified transaction group user ID.
        /// </summary>
        /// <param name="transactionGroupUserId">The transaction group user ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public GroupUserQueryObject WithTransactionGroupUser(Guid transactionGroupUserId)
        {
            And(entity => entity.TransactionGroupUsers.Any(tgu => tgu.Id == transactionGroupUserId));
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified transaction group user ID.
        /// </summary>
        /// <param name="transactionGroupUserId">The transaction group user ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupUserQueryObject OrWithTransactionGroupUser(Guid transactionGroupUserId)
        {
            Or(entity => entity.TransactionGroupUsers.Any(tgu => tgu.Id == transactionGroupUserId));
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified transaction group user ID.
        /// </summary>
        /// <param name="transactionGroupUserId">The transaction group user ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupUserQueryObject NotWithTransactionGroupUser(Guid transactionGroupUserId)
        {
            Not(entity => entity.TransactionGroupUsers.Any(tgu => tgu.Id == transactionGroupUserId));
            return this;
        }

        #endregion
    }
}