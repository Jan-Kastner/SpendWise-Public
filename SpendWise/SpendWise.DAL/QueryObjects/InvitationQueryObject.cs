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
        public InvitationQueryObject WithId(Guid id) => ApplyIdFilter(id, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public InvitationQueryObject OrWithId(Guid id) => ApplyIdFilter(id, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public InvitationQueryObject NotWithId(Guid id) => ApplyIdFilter(id, filter => Not(filter));

        #endregion

        #region ISentDateQuery

        /// <summary>
        /// Filters the query to include items with the specified sent date.
        /// </summary>
        /// <param name="sentDate">The sent date to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public InvitationQueryObject WithSentDate(DateTime sentDate) => ApplySentDateFilter(sentDate, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified sent date.
        /// </summary>
        /// <param name="sentDate">The sent date to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public InvitationQueryObject OrWithSentDate(DateTime sentDate) => ApplySentDateFilter(sentDate, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified sent date.
        /// </summary>
        /// <param name="sentDate">The sent date to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public InvitationQueryObject NotWithSentDate(DateTime sentDate) => ApplySentDateFilter(sentDate, filter => Not(filter));

        #endregion

        #region IResponseDateQuery

        /// <summary>
        /// Filters the query to include items with the specified response date.
        /// </summary>
        /// <param name="responseDate">The response date to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public InvitationQueryObject WithResponseDate(DateTime? responseDate) => ApplyResponseDateFilter(responseDate, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified response date.
        /// </summary>
        /// <param name="responseDate">The response date to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public InvitationQueryObject OrWithResponseDate(DateTime? responseDate) => ApplyResponseDateFilter(responseDate, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified response date.
        /// </summary>
        /// <param name="responseDate">The response date to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public InvitationQueryObject NotWithResponseDate(DateTime? responseDate) => ApplyResponseDateFilter(responseDate, filter => Not(filter));

        /// <summary>
        /// Filters the query to include items without any response date (null).
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public InvitationQueryObject WithoutResponseDate() => ApplyResponseDateFilter(null, filter => And(filter), isNullCheck: true);

        /// <summary>
        /// Adds an OR condition to the query to include items without any response date (null).
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public InvitationQueryObject OrWithoutResponseDate() => ApplyResponseDateFilter(null, filter => Or(filter), isNullCheck: true);

        /// <summary>
        /// Filters the query to exclude items without any response date (null).
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public InvitationQueryObject NotWithoutResponseDate() => ApplyResponseDateFilter(null, filter => Not(filter), isNullCheck: true);

        #endregion

        #region IIsAcceptedQuery

        /// <summary>
        /// Filters the query to include items that are accepted.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public InvitationQueryObject IsAccepted() => ApplyIsAcceptedFilter(true, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items that are accepted.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public InvitationQueryObject OrIsAccepted() => ApplyIsAcceptedFilter(true, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items that are accepted.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public InvitationQueryObject NotIsAccepted() => ApplyIsAcceptedFilter(true, filter => Not(filter));

        /// <summary>
        /// Filters the query to include items that are not accepted.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public InvitationQueryObject IsNotAccepted() => ApplyIsAcceptedFilter(false, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items that are not accepted.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public InvitationQueryObject OrIsNotAccepted() => ApplyIsAcceptedFilter(false, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items that are not accepted.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public InvitationQueryObject NotIsNotAccepted() => ApplyIsAcceptedFilter(false, filter => Not(filter));

        /// <summary>
        /// Filters the query to include items that are pending.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public InvitationQueryObject IsPending() => ApplyIsAcceptedFilter(null, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items that are pending.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public InvitationQueryObject OrIsPending() => ApplyIsAcceptedFilter(null, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items that are pending.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public InvitationQueryObject NotIsPending() => ApplyIsAcceptedFilter(null, filter => Not(filter));

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