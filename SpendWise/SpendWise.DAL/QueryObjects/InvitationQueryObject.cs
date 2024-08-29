using System;
using System.Linq.Expressions;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object for the <see cref="InvitationEntity"/>.
    /// Enables query construction using methods for AND, OR, and NOT operations.
    /// </summary>
    public class InvitationQueryObject : QueryObject<InvitationEntity>
    {
        #region AND

        /// <summary>
        /// Adds a condition to compare the invitation ID using an AND operation.
        /// </summary>
        /// <param name="id">The invitation ID to compare.</param>
        /// <returns>The current instance of <see cref="InvitationQueryObject"/>.</returns>
        public InvitationQueryObject WithId(Guid id)
        {
            And(entity => entity.Id == id);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the sender ID using an AND operation.
        /// </summary>
        /// <param name="senderId">The sender ID to compare.</param>
        /// <returns>The current instance of <see cref="InvitationQueryObject"/>.</returns>
        public InvitationQueryObject WithSenderId(Guid senderId)
        {
            And(entity => entity.SenderId == senderId);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the receiver ID using an AND operation.
        /// </summary>
        /// <param name="receiverId">The receiver ID to compare.</param>
        /// <returns>The current instance of <see cref="InvitationQueryObject"/>.</returns>
        public InvitationQueryObject WithReceiverId(Guid receiverId)
        {
            And(entity => entity.ReceiverId == receiverId);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the group ID using an AND operation.
        /// </summary>
        /// <param name="groupId">The group ID to compare.</param>
        /// <returns>The current instance of <see cref="InvitationQueryObject"/>.</returns>
        public InvitationQueryObject WithGroupId(Guid groupId)
        {
            And(entity => entity.GroupId == groupId);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the sent date using an AND operation.
        /// </summary>
        /// <param name="sentDate">The sent date to compare.</param>
        /// <returns>The current instance of <see cref="InvitationQueryObject"/>.</returns>
        public InvitationQueryObject WithSentDate(DateTime sentDate)
        {
            And(entity => entity.SentDate.Date == sentDate.Date);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the response date using an AND operation, if the response date is provided.
        /// </summary>
        /// <param name="responseDate">The response date to compare.</param>
        /// <returns>The current instance of <see cref="InvitationQueryObject"/>.</returns>
        public InvitationQueryObject WithResponseDate(DateTime? responseDate)
        {
            if (responseDate.HasValue)
            {
                And(entity => entity.ResponseDate.HasValue && entity.ResponseDate.Value.Date == responseDate.Value.Date);
            }
            return this;
        }

        /// <summary>
        /// Adds a condition to compare whether the invitation was accepted using an AND operation.
        /// </summary>
        /// <param name="isAccepted">The acceptance status to compare.</param>
        /// <returns>The current instance of <see cref="InvitationQueryObject"/>.</returns>
        public InvitationQueryObject WithIsAccepted(bool? isAccepted)
        {
            And(entity => entity.IsAccepted == isAccepted);
            return this;
        }

        #endregion

        #region OR

        /// <summary>
        /// Adds a condition to compare the invitation ID using an OR operation.
        /// </summary>
        /// <param name="id">The invitation ID to compare.</param>
        /// <returns>The current instance of <see cref="InvitationQueryObject"/>.</returns>
        public InvitationQueryObject OrWithId(Guid id)
        {
            Or(entity => entity.Id == id);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the sender ID using an OR operation.
        /// </summary>
        /// <param name="senderId">The sender ID to compare.</param>
        /// <returns>The current instance of <see cref="InvitationQueryObject"/>.</returns>
        public InvitationQueryObject OrWithSenderId(Guid senderId)
        {
            Or(entity => entity.SenderId == senderId);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the receiver ID using an OR operation.
        /// </summary>
        /// <param name="receiverId">The receiver ID to compare.</param>
        /// <returns>The current instance of <see cref="InvitationQueryObject"/>.</returns>
        public InvitationQueryObject OrWithReceiverId(Guid receiverId)
        {
            Or(entity => entity.ReceiverId == receiverId);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the group ID using an OR operation.
        /// </summary>
        /// <param name="groupId">The group ID to compare.</param>
        /// <returns>The current instance of <see cref="InvitationQueryObject"/>.</returns>
        public InvitationQueryObject OrWithGroupId(Guid groupId)
        {
            Or(entity => entity.GroupId == groupId);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the sent date using an OR operation.
        /// </summary>
        /// <param name="sentDate">The sent date to compare.</param>
        /// <returns>The current instance of <see cref="InvitationQueryObject"/>.</returns>
        public InvitationQueryObject OrWithSentDate(DateTime sentDate)
        {
            Or(entity => entity.SentDate.Date == sentDate.Date);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the response date using an OR operation, if the response date is provided.
        /// </summary>
        /// <param name="responseDate">The response date to compare.</param>
        /// <returns>The current instance of <see cref="InvitationQueryObject"/>.</returns>
        public InvitationQueryObject OrWithResponseDate(DateTime? responseDate)
        {
            if (responseDate.HasValue)
            {
                Or(entity => entity.ResponseDate.HasValue && entity.ResponseDate.Value.Date == responseDate.Value.Date);
            }
            return this;
        }

        /// <summary>
        /// Adds a condition to compare whether the invitation was accepted using an OR operation.
        /// </summary>
        /// <param name="isAccepted">The acceptance status to compare.</param>
        /// <returns>The current instance of <see cref="InvitationQueryObject"/>.</returns>
        public InvitationQueryObject OrWithIsAccepted(bool? isAccepted)
        {
            Or(entity => entity.IsAccepted == isAccepted);
            return this;
        }

        #endregion

        #region NOT

        /// <summary>
        /// Adds a condition to exclude invitations with a specific ID using a NOT operation.
        /// </summary>
        /// <param name="id">The invitation ID to exclude.</param>
        /// <returns>The current instance of <see cref="InvitationQueryObject"/>.</returns>
        public InvitationQueryObject NotWithId(Guid id)
        {
            Not(entity => entity.Id == id);
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude invitations with a specific sender ID using a NOT operation.
        /// </summary>
        /// <param name="senderId">The sender ID to exclude.</param>
        /// <returns>The current instance of <see cref="InvitationQueryObject"/>.</returns>
        public InvitationQueryObject NotWithSenderId(Guid senderId)
        {
            Not(entity => entity.SenderId == senderId);
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude invitations with a specific receiver ID using a NOT operation.
        /// </summary>
        /// <param name="receiverId">The receiver ID to exclude.</param>
        /// <returns>The current instance of <see cref="InvitationQueryObject"/>.</returns>
        public InvitationQueryObject NotWithReceiverId(Guid receiverId)
        {
            Not(entity => entity.ReceiverId == receiverId);
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude invitations with a specific group ID using a NOT operation.
        /// </summary>
        /// <param name="groupId">The group ID to exclude.</param>
        /// <returns>The current instance of <see cref="InvitationQueryObject"/>.</returns>
        public InvitationQueryObject NotWithGroupId(Guid groupId)
        {
            Not(entity => entity.GroupId == groupId);
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude invitations sent on a specific date using a NOT operation.
        /// </summary>
        /// <param name="sentDate">The sent date to exclude.</param>
        /// <returns>The current instance of <see cref="InvitationQueryObject"/>.</returns>
        public InvitationQueryObject NotWithSentDate(DateTime sentDate)
        {
            Not(entity => entity.SentDate.Date == sentDate.Date);
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude invitations with a specific response date using a NOT operation.
        /// </summary>
        /// <param name="responseDate">The response date to exclude.</param>
        /// <returns>The current instance of <see cref="InvitationQueryObject"/>.</returns>
        public InvitationQueryObject NotWithResponseDate(DateTime? responseDate)
        {
            if (responseDate.HasValue)
            {
                Not(entity => entity.ResponseDate.HasValue && entity.ResponseDate.Value.Date == responseDate.Value.Date);
            }
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude invitations with a specific acceptance status using a NOT operation.
        /// </summary>
        /// <param name="isAccepted">The acceptance status to exclude.</param>
        /// <returns>The current instance of <see cref="InvitationQueryObject"/>.</returns>
        public InvitationQueryObject NotWithIsAccepted(bool? isAccepted)
        {
            Not(entity => entity.IsAccepted == isAccepted);
            return this;
        }

        #endregion
    }
}
