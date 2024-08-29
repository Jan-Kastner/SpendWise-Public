using System;
using System.Linq.Expressions;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Provides a set of query methods to filter <see cref="GroupEntity"/> instances based on various criteria.
    /// Allows combining conditions with AND, OR, and NOT operations for flexible query building.
    /// </summary>
    public class GroupQueryObject : QueryObject<GroupEntity>
    {
        #region AND

        /// <summary>
        /// Adds a condition to compare the group ID using an AND operation.
        /// </summary>
        /// <param name="id">The group ID to compare.</param>
        /// <returns>The current instance of <see cref="GroupQueryObject"/>.</returns>
        public GroupQueryObject WithId(Guid id)
        {
            And(entity => entity.Id == id);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the group name using an AND operation.
        /// </summary>
        /// <param name="name">The group name to compare.</param>
        /// <returns>The current instance of <see cref="GroupQueryObject"/>.</returns>
        public GroupQueryObject WithName(string name)
        {
            And(entity => entity.Name.Contains(name));
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the group description using an AND operation.
        /// </summary>
        /// <param name="description">The group description to compare.</param>
        /// <returns>The current instance of <see cref="GroupQueryObject"/>.</returns>
        public GroupQueryObject WithDescription(string description)
        {
            And(entity => entity.Description != null && entity.Description.Contains(description));
            return this;
        }

        /// <summary>
        /// Adds a condition to include groups with a null description using an AND operation.
        /// </summary>
        /// <returns>The current instance of <see cref="GroupQueryObject"/>.</returns>
        public GroupQueryObject WithNullDescription()
        {
            And(entity => entity.Description == null);
            return this;
        }

        /// <summary>
        /// Adds a condition to include groups that contain a specific user using an AND operation.
        /// </summary>
        /// <param name="userId">The user ID to match within the group.</param>
        /// <returns>The current instance of <see cref="GroupQueryObject"/>.</returns>
        public GroupQueryObject WithUser(Guid userId)
        {
            And(entity => entity.GroupUsers.Any(gu => gu.UserId == userId));
            return this;
        }

        /// <summary>
        /// Adds a condition to include groups that contain a specific invitation using an AND operation.
        /// </summary>
        /// <param name="invitationId">The invitation ID to match within the group.</param>
        /// <returns>The current instance of <see cref="GroupQueryObject"/>.</returns>
        public GroupQueryObject WithInvitation(Guid invitationId)
        {
            And(entity => entity.Invitations.Any(i => i.Id == invitationId));
            return this;
        }

        #endregion

        #region OR

        /// <summary>
        /// Adds a condition to compare the group ID using an OR operation.
        /// </summary>
        /// <param name="id">The group ID to compare.</param>
        /// <returns>The current instance of <see cref="GroupQueryObject"/>.</returns>
        public GroupQueryObject OrWithId(Guid id)
        {
            Or(entity => entity.Id == id);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the group name using an OR operation.
        /// </summary>
        /// <param name="name">The group name to compare.</param>
        /// <returns>The current instance of <see cref="GroupQueryObject"/>.</returns>
        public GroupQueryObject OrWithName(string name)
        {
            Or(entity => entity.Name.Contains(name));
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the group description using an OR operation.
        /// </summary>
        /// <param name="description">The group description to compare.</param>
        /// <returns>The current instance of <see cref="GroupQueryObject"/>.</returns>
        public GroupQueryObject OrWithDescription(string description)
        {
            Or(entity => entity.Description != null && entity.Description.Contains(description));
            return this;
        }

        /// <summary>
        /// Adds a condition to include groups with a null description using an OR operation.
        /// </summary>
        /// <returns>The current instance of <see cref="GroupQueryObject"/>.</returns>
        public GroupQueryObject OrWithNullDescription()
        {
            Or(entity => entity.Description == null);
            return this;
        }

        /// <summary>
        /// Adds a condition to include groups that contain a specific user using an OR operation.
        /// </summary>
        /// <param name="userId">The user ID to match within the group.</param>
        /// <returns>The current instance of <see cref="GroupQueryObject"/>.</returns>
        public GroupQueryObject OrWithUser(Guid userId)
        {
            Or(entity => entity.GroupUsers.Any(gu => gu.UserId == userId));
            return this;
        }

        /// <summary>
        /// Adds a condition to include groups that contain a specific invitation using an OR operation.
        /// </summary>
        /// <param name="invitationId">The invitation ID to match within the group.</param>
        /// <returns>The current instance of <see cref="GroupQueryObject"/>.</returns>
        public GroupQueryObject OrWithInvitation(Guid invitationId)
        {
            Or(entity => entity.Invitations.Any(i => i.Id == invitationId));
            return this;
        }

        #endregion

        #region NOT

        /// <summary>
        /// Adds a condition to exclude groups with a specific ID using a NOT operation.
        /// </summary>
        /// <param name="id">The group ID to exclude.</param>
        /// <returns>The current instance of <see cref="GroupQueryObject"/>.</returns>
        public GroupQueryObject NotWithId(Guid id)
        {
            Not(entity => entity.Id == id);
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude groups with a specific name using a NOT operation.
        /// </summary>
        /// <param name="name">The group name to exclude.</param>
        /// <returns>The current instance of <see cref="GroupQueryObject"/>.</returns>
        public GroupQueryObject NotWithName(string name)
        {
            Not(entity => entity.Name.Contains(name));
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude groups with a specific description using a NOT operation.
        /// </summary>
        /// <param name="description">The group description to exclude.</param>
        /// <returns>The current instance of <see cref="GroupQueryObject"/>.</returns>
        public GroupQueryObject NotWithDescription(string description)
        {
            Not(entity => entity.Description != null && entity.Description.Contains(description));
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude groups with a null description using a NOT operation.
        /// </summary>
        /// <returns>The current instance of <see cref="GroupQueryObject"/>.</returns>
        public GroupQueryObject NotWithNullDescription()
        {
            Not(entity => entity.Description == null);
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude groups that contain a specific user using a NOT operation.
        /// </summary>
        /// <param name="userId">The user ID to exclude from the group.</param>
        /// <returns>The current instance of <see cref="GroupQueryObject"/>.</returns>
        public GroupQueryObject NotWithUser(Guid userId)
        {
            Not(entity => entity.GroupUsers.Any(gu => gu.UserId == userId));
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude groups that contain a specific invitation using a NOT operation.
        /// </summary>
        /// <param name="invitationId">The invitation ID to exclude from the group.</param>
        /// <returns>The current instance of <see cref="GroupQueryObject"/>.</returns>
        public GroupQueryObject NotWithInvitation(Guid invitationId)
        {
            Not(entity => entity.Invitations.Any(i => i.Id == invitationId));
            return this;
        }

        #endregion
    }
}
