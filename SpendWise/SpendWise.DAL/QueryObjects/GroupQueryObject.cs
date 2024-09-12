using System;
using SpendWise.DAL.Entities;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Provides a set of query methods to filter <see cref="GroupEntity"/> instances based on various criteria.
    /// Allows combining conditions with AND, OR, and NOT operations for flexible query building.
    /// </summary>
    public class GroupQueryObject : BaseQueryObject<GroupEntity, GroupQueryObject>, IGroupQueryObject<GroupQueryObject>
    {
        #region IIdQuery

        /// <summary>
        /// Filters the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new GroupQueryObject WithId(Guid id) => base.WithId(id);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new GroupQueryObject OrWithId(Guid id) => base.OrWithId(id);

        /// <summary>
        /// Filters the query to exclude items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new GroupQueryObject NotWithId(Guid id) => base.NotWithId(id);

        #endregion

        #region INameQuery

        /// <summary>
        /// Filters the query to include items with the specified name.
        /// </summary>
        /// <param name="name">The name to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new GroupQueryObject WithName(string name) => base.WithName(name);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified name.
        /// </summary>
        /// <param name="name">The name to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new GroupQueryObject OrWithName(string name) => base.OrWithName(name);

        /// <summary>
        /// Filters the query to exclude items with the specified name.
        /// </summary>
        /// <param name="name">The name to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new GroupQueryObject NotWithName(string name) => base.NotWithName(name);

        /// <summary>
        /// Filters the query to include items with a partial match of the specified text in the name.
        /// </summary>
        /// <param name="text">The text to partially match in the name.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new GroupQueryObject WithNamePartialMatch(string text) => base.WithNamePartialMatch(text);

        /// <summary>
        /// Adds an OR condition to the query to include items with a partial match of the specified text in the name.
        /// </summary>
        /// <param name="text">The text to partially match in the name.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new GroupQueryObject OrWithNamePartialMatch(string text) => base.OrWithNamePartialMatch(text);

        /// <summary>
        /// Filters the query to exclude items with a partial match of the specified text in the name.
        /// </summary>
        /// <param name="text">The text to partially match in the name.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new GroupQueryObject NotWithNamePartialMatch(string text) => base.NotWithNamePartialMatch(text);

        #endregion

        #region IDescriptionQuery

        /// <summary>
        /// Filters the query to include items with the specified description.
        /// </summary>
        /// <param name="description">The description to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new GroupQueryObject WithDescription(string? description) => base.WithDescription(description);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified description.
        /// </summary>
        /// <param name="description">The description to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new GroupQueryObject OrWithDescription(string? description) => base.OrWithDescription(description);

        /// <summary>
        /// Filters the query to exclude items with the specified description.
        /// </summary>
        /// <param name="description">The description to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new GroupQueryObject NotWithDescription(string? description) => base.NotWithDescription(description);

        /// <summary>
        /// Filters the query to include items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new GroupQueryObject WithDescriptionPartialMatch(string text) => base.WithDescriptionPartialMatch(text);

        /// <summary>
        /// Adds an OR condition to the query to include items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new GroupQueryObject OrWithDescriptionPartialMatch(string text) => base.OrWithDescriptionPartialMatch(text);

        /// <summary>
        /// Filters the query to exclude items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new GroupQueryObject NotWithDescriptionPartialMatch(string text) => base.NotWithDescriptionPartialMatch(text);

        /// <summary>
        /// Filters the query to include items without a description.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public new GroupQueryObject WithoutDescription() => base.WithoutDescription();

        /// <summary>
        /// Adds an OR condition to the query to include items without a description.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public new GroupQueryObject OrWithoutDescription() => base.OrWithoutDescription();

        /// <summary>
        /// Filters the query to exclude items without a description.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new GroupQueryObject NotWithoutDescription() => base.NotWithoutDescription();

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