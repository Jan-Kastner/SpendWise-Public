using System;
using System.Linq.Expressions;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Provides a set of query methods to filter Group entities based on various criteria.
    /// Allows combining conditions with AND, OR, and NOT operations for flexible query building.
    /// </summary>
    public class GroupQueryObject : QueryObject<GroupEntity>
    {
        // Methods for AND operations

        public GroupQueryObject WithId(Guid id)
        {
            And(entity => entity.Id == id);
            return this;
        }

        public GroupQueryObject WithName(string name)
        {
            And(entity => entity.Name.Contains(name));
            return this;
        }

        public GroupQueryObject WithDescription(string description)
        {
            And(entity => entity.Description != null && entity.Description.Contains(description));
            return this;
        }

        public GroupQueryObject WithNullDescription()
        {
            And(entity => entity.Description == null);
            return this;
        }

        public GroupQueryObject WithUser(Guid userId)
        {
            And(entity => entity.GroupUsers.Any(gu => gu.UserId == userId));
            return this;
        }

        public GroupQueryObject WithInvitation(Guid invitationId)
        {
            And(entity => entity.Invitations.Any(i => i.Id == invitationId));
            return this;
        }

        // Methods for OR operations

        public GroupQueryObject OrWithId(Guid id)
        {
            Or(entity => entity.Id == id);
            return this;
        }

        public GroupQueryObject OrWithName(string name)
        {
            Or(entity => entity.Name.Contains(name));
            return this;
        }

        public GroupQueryObject OrWithDescription(string description)
        {
            Or(entity => entity.Description != null && entity.Description.Contains(description));
            return this;
        }

        public GroupQueryObject OrWithNullDescription()
        {
            Or(entity => entity.Description == null);
            return this;
        }

        public GroupQueryObject OrWithUser(Guid userId)
        {
            Or(entity => entity.GroupUsers.Any(gu => gu.UserId == userId));
            return this;
        }

        public GroupQueryObject OrWithInvitation(Guid invitationId)
        {
            Or(entity => entity.Invitations.Any(i => i.Id == invitationId));
            return this;
        }

        // Methods for NOT operations

        public GroupQueryObject NotWithId(Guid id)
        {
            Not(entity => entity.Id == id);
            return this;
        }

        public GroupQueryObject NotWithName(string name)
        {
            Not(entity => entity.Name.Contains(name));
            return this;
        }

        public GroupQueryObject NotWithDescription(string description)
        {
            Not(entity => entity.Description != null && entity.Description.Contains(description));
            return this;
        }

        public GroupQueryObject NotWithNullDescription()
        {
            Not(entity => entity.Description == null);
            return this;
        }

        public GroupQueryObject NotWithUser(Guid userId)
        {
            Not(entity => entity.GroupUsers.Any(gu => gu.UserId == userId));
            return this;
        }

        public GroupQueryObject NotWithInvitation(Guid invitationId)
        {
            Not(entity => entity.Invitations.Any(i => i.Id == invitationId));
            return this;
        }
    }
}
