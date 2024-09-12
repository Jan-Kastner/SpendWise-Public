using System;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object for the <see cref="InvitationEntity"/>.
    /// Enables query construction using methods for AND, OR, and NOT operations.
    /// </summary>
    public class InvitationQueryObject : BaseQueryObject<InvitationEntity, InvitationQueryObject>, IInvitationQueryObject<InvitationQueryObject>
    {
        #region IIdQuery

        /// <summary>
        /// Filters the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new InvitationQueryObject WithId(Guid id) => base.WithId(id);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new InvitationQueryObject OrWithId(Guid id) => base.OrWithId(id);

        /// <summary>
        /// Filters the query to exclude items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new InvitationQueryObject NotWithId(Guid id) => base.NotWithId(id);

        #endregion

        #region ISentDateQuery

        /// <summary>
        /// Filters the query to include items with the specified sent date.
        /// </summary>
        /// <param name="sentDate">The sent date to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new InvitationQueryObject WithSentDate(DateTime sentDate) => base.WithSentDate(sentDate);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified sent date.
        /// </summary>
        /// <param name="sentDate">The sent date to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new InvitationQueryObject OrWithSentDate(DateTime sentDate) => base.OrWithSentDate(sentDate);

        /// <summary>
        /// Filters the query to exclude items with the specified sent date.
        /// </summary>
        /// <param name="sentDate">The sent date to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new InvitationQueryObject NotWithSentDate(DateTime sentDate) => base.NotWithSentDate(sentDate);

        #endregion

        #region IResponseDateQuery

        /// <summary>
        /// Filters the query to include items with the specified response date.
        /// </summary>
        /// <param name="responseDate">The response date to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new InvitationQueryObject WithResponseDate(DateTime? responseDate) => base.WithResponseDate(responseDate);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified response date.
        /// </summary>
        /// <param name="responseDate">The response date to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new InvitationQueryObject OrWithResponseDate(DateTime? responseDate) => base.OrWithResponseDate(responseDate);

        /// <summary>
        /// Filters the query to exclude items with the specified response date.
        /// </summary>
        /// <param name="responseDate">The response date to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new InvitationQueryObject NotWithResponseDate(DateTime? responseDate) => base.NotWithResponseDate(responseDate);

        #endregion

        #region IIsAcceptedQuery

        /// <summary>
        /// Filters the query to include items that are accepted.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public InvitationQueryObject IsAccepted() => base.WithIsAccepted(true);

        /// <summary>
        /// Adds an OR condition to the query to include items that are accepted.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public InvitationQueryObject OrIsAccepted() => base.OrWithIsAccepted(true);

        /// <summary>
        /// Filters the query to exclude items that are accepted.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public InvitationQueryObject NotIsAccepted() => base.NotWithIsAccepted(true);

        /// <summary>
        /// Filters the query to include items that are not accepted.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public InvitationQueryObject IsNotAccepted() => base.WithIsAccepted(false);

        /// <summary>
        /// Adds an OR condition to the query to include items that are not accepted.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public InvitationQueryObject OrIsNotAccepted() => base.OrWithIsAccepted(false);

        /// <summary>
        /// Filters the query to exclude items that are not accepted.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public InvitationQueryObject NotIsNotAccepted() => base.NotWithIsAccepted(false);

        /// <summary>
        /// Filters the query to include items that are pending.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public InvitationQueryObject IsPending() => base.WithIsAccepted(null);

        /// <summary>
        /// Adds an OR condition to the query to include items that are pending.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public InvitationQueryObject OrIsPending() => base.OrWithIsAccepted(null);

        /// <summary>
        /// Filters the query to exclude items that are pending.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public InvitationQueryObject NotIsPending() => base.NotWithIsAccepted(null);

        #endregion

        #region ISenderQuery

        /// <summary>
        /// Filters the query to include items with the specified sender ID.
        /// </summary>
        /// <param name="senderId">The sender ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public InvitationQueryObject WithSender(Guid senderId)
        {
            And(entity => entity.SenderId == senderId);
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified sender ID.
        /// </summary>
        /// <param name="senderId">The sender ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public InvitationQueryObject OrWithSender(Guid senderId)
        {
            Or(entity => entity.SenderId == senderId);
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified sender ID.
        /// </summary>
        /// <param name="senderId">The sender ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public InvitationQueryObject NotWithSender(Guid senderId)
        {
            Not(entity => entity.SenderId == senderId);
            return this;
        }

        #endregion

        #region IReceiverQuery

        /// <summary>
        /// Filters the query to include items with the specified receiver ID.
        /// </summary>
        /// <param name="receiverId">The receiver ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public InvitationQueryObject WithReceiver(Guid receiverId)
        {
            And(entity => entity.ReceiverId == receiverId);
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified receiver ID.
        /// </summary>
        /// <param name="receiverId">The receiver ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public InvitationQueryObject OrWithReceiver(Guid receiverId)
        {
            Or(entity => entity.ReceiverId == receiverId);
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified receiver ID.
        /// </summary>
        /// <param name="receiverId">The receiver ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public InvitationQueryObject NotWithReceiver(Guid receiverId)
        {
            Not(entity => entity.ReceiverId == receiverId);
            return this;
        }

        #endregion

        #region IGroupQuery

        /// <summary>
        /// Filters the query to include items with the specified group ID.
        /// </summary>
        /// <param name="groupId">The group ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public InvitationQueryObject WithGroup(Guid groupId)
        {
            And(entity => entity.GroupId == groupId);
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified group ID.
        /// </summary>
        /// <param name="groupId">The group ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public InvitationQueryObject OrWithGroup(Guid groupId)
        {
            Or(entity => entity.GroupId == groupId);
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified group ID.
        /// </summary>
        /// <param name="groupId">The group ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public InvitationQueryObject NotWithGroup(Guid groupId)
        {
            Not(entity => entity.GroupId == groupId);
            return this;
        }

        #endregion
    }
}