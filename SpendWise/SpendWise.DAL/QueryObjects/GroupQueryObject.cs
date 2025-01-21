using SpendWise.DAL.Entities;
using SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupEntity;
using SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupEntity.Interfaces;
using SpendWise.DAL.QueryObjects.Interfaces;
using System.Linq.Expressions;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Provides a set of query methods to filter <see cref="GroupEntity"/> instances based on various criteria.
    /// Allows combining conditions with AND, OR, and NOT operations for flexible query building.
    /// </summary>
    public class GroupQueryObject : BaseQueryObject<GroupEntity, GroupQueryObject>, IGroupQueryObject
    {
        private GroupEntityRelationsConfig _relations = new GroupEntityRelationsConfig();

        /// <summary>
        /// Gets the initial state for group relations.
        /// </summary>
        public IGroupEntityInitialState Relations => _relations;

        /// <summary>
        /// Gets the list of include properties for the query.
        /// </summary>
        public override List<string> Includes => _relations.Includes;

        /// <summary>
        /// Gets the collection of include directives used by the RelationConfigGenerator
        /// to generate EntityRelationsConfiguration, which acts as a state machine for managing includes.
        /// </summary>
        public override ICollection<Func<GroupEntity, object>> IncludeDirectives { get; } = new List<Func<GroupEntity, object>>
        {
            entity => entity.GroupUsers,
            entity => entity.GroupUsers.Select(gu => gu.User),
            entity => entity.GroupUsers.Select(gu => gu.TransactionGroupUsers),
            entity => entity.GroupUsers.Select(gu => gu.TransactionGroupUsers.Select(tgu => tgu.Transaction)),
            entity => entity.GroupUsers.Select(gu => gu.TransactionGroupUsers.Select(tgu => tgu.Transaction.Category))
        };

        #region IIdQuery

        /// <summary>
        /// Filters the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public GroupQueryObject WithId(Guid id) => ApplyIdFilter(id, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupQueryObject OrWithId(Guid id) => ApplyIdFilter(id, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupQueryObject NotWithId(Guid id) => ApplyIdFilter(id, filter => Not(filter));

        #endregion

        #region INameQuery

        /// <summary>
        /// Filters the query to include items with the specified name.
        /// </summary>
        /// <param name="name">The name to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public GroupQueryObject WithName(string name) => ApplyNameFilter(name, entity => entity.Name, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified name.
        /// </summary>
        /// <param name="name">The name to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupQueryObject OrWithName(string name) => ApplyNameFilter(name, entity => entity.Name, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified name.
        /// </summary>
        /// <param name="name">The name to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupQueryObject NotWithName(string name) => ApplyNameFilter(name, entity => entity.Name, filter => Not(filter));

        /// <summary>
        /// Filters the query to include items with a partial match of the specified text in the name.
        /// </summary>
        /// <param name="text">The text to partially match in the name.</param>
        /// <returns>The query object with the applied filter.</returns>
        public GroupQueryObject WithNamePartialMatch(string text) => ApplyNameFilter(text, entity => entity.Name, filter => And(filter), true);

        /// <summary>
        /// Adds an OR condition to the query to include items with a partial match of the specified text in the name.
        /// </summary>
        /// <param name="text">The text to partially match in the name.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupQueryObject OrWithNamePartialMatch(string text) => ApplyNameFilter(text, entity => entity.Name, filter => Or(filter), true);

        /// <summary>
        /// Filters the query to exclude items with a partial match of the specified text in the name.
        /// </summary>
        /// <param name="text">The text to partially match in the name.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupQueryObject NotWithNamePartialMatch(string text) => ApplyNameFilter(text, entity => entity.Name, filter => Not(filter), true);

        #endregion

        #region IDescriptionQuery

        /// <summary>
        /// Filters the query to include items with the specified description.
        /// </summary>
        /// <param name="description">The description to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public GroupQueryObject WithDescription(string? description) => ApplyDescriptionFilter(description, entity => entity.Description, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified description.
        /// </summary>
        /// <param name="description">The description to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupQueryObject OrWithDescription(string? description) => ApplyDescriptionFilter(description, entity => entity.Description, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified description.
        /// </summary>
        /// <param name="description">The description to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupQueryObject NotWithDescription(string? description) => ApplyDescriptionFilter(description, entity => entity.Description, filter => Not(filter));

        /// <summary>
        /// Filters the query to include items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied filter.</returns>
        public GroupQueryObject WithDescriptionPartialMatch(string text) => ApplyDescriptionFilter(text, entity => entity.Description, filter => And(filter), true);

        /// <summary>
        /// Adds an OR condition to the query to include items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupQueryObject OrWithDescriptionPartialMatch(string text) => ApplyDescriptionFilter(text, entity => entity.Description, filter => Or(filter), true);

        /// <summary>
        /// Filters the query to exclude items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupQueryObject NotWithDescriptionPartialMatch(string text) => ApplyDescriptionFilter(text, entity => entity.Description, filter => Not(filter), true);

        /// <summary>
        /// Filters the query to include items without a description.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public GroupQueryObject WithoutDescription() => ApplyDescriptionFilter(null, entity => entity.Description, filter => And(filter), false, true);

        /// <summary>
        /// Adds an OR condition to the query to include items without a description.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupQueryObject OrWithoutDescription() => ApplyDescriptionFilter(null, entity => entity.Description, filter => Or(filter), false, true);

        /// <summary>
        /// Filters the query to exclude items without a description.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupQueryObject NotWithoutDescription() => ApplyDescriptionFilter(null, entity => entity.Description, filter => Not(filter), false, true);

        #endregion

        #region IGroupUserQuery

        /// <summary>
        /// Filters the query to include items with the specified group user.
        /// </summary>
        /// <param name="groupUserId">The group user ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public GroupQueryObject WithGroupUser(Guid groupUserId)
        {
            And(entity => entity.GroupUsers.Any(gu => gu.Id == groupUserId));
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified group user.
        /// </summary>
        /// <param name="groupUserId">The group user ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupQueryObject OrWithGroupUser(Guid groupUserId)
        {
            Or(entity => entity.GroupUsers.Any(gu => gu.Id == groupUserId));
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified group user.
        /// </summary>
        /// <param name="groupUserId">The group user ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupQueryObject NotWithGroupUser(Guid groupUserId)
        {
            Not(entity => entity.GroupUsers.Any(gu => gu.Id == groupUserId));
            return this;
        }
        #endregion

        #region IUserQuery
        /// <summary>
        /// Filters the query to include items with the specified group user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public GroupQueryObject WithUser(Guid userId)
        {
            And(entity => entity.GroupUsers.Any(gu => gu.UserId == userId));
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified group user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public GroupQueryObject OrWithUser(Guid userId)
        {
            Or(entity => entity.GroupUsers.Any(gu => gu.UserId == userId));
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified group user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public GroupQueryObject NotWithUser(Guid userId)
        {
            Not(entity => entity.GroupUsers.Any(gu => gu.UserId == userId));
            return this;
        }

        #endregion

        #region IInvitationQuery

        /// <summary>
        /// Filters the query to include items with the specified invitation.
        /// </summary>
        /// <param name="invitationId">The invitation ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public GroupQueryObject WithInvitation(Guid invitationId)
        {
            And(entity => entity.Invitations.Any(i => i.Id == invitationId));
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified invitation.
        /// </summary>
        /// <param name="invitationId">The invitation ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupQueryObject OrWithInvitation(Guid invitationId)
        {
            Or(entity => entity.Invitations.Any(i => i.Id == invitationId));
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified invitation.
        /// </summary>
        /// <param name="invitationId">The invitation ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupQueryObject NotWithInvitation(Guid invitationId)
        {
            Not(entity => entity.Invitations.Any(i => i.Id == invitationId));
            return this;
        }

        #endregion
    }
}