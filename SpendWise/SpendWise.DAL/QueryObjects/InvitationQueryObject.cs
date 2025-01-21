using SpendWise.DAL.Entities;
using SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.InvitationEntity.Interfaces;
using SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.InvitationEntity;
using SpendWise.DAL.QueryObjects.Interfaces;
using System.Linq.Expressions;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object for the <see cref="InvitationEntity"/>.
    /// Enables query construction using methods for AND, OR, and NOT operations.
    /// </summary>
    public class InvitationQueryObject : BaseQueryObject<InvitationEntity, InvitationQueryObject>, IInvitationQueryObject
    {
        private InvitationEntityRelationsConfig _relations = new InvitationEntityRelationsConfig();

        /// <summary>
        /// Gets the initial state for invitation relations.
        /// </summary>
        public IInvitationEntityInitialState Relations => _relations;

        /// <summary>
        /// Gets the list of include properties for the query.
        /// </summary>
        public override List<string> Includes => _relations.Includes;

        /// <summary>
        /// Gets the collection of include directives used by the RelationConfigGenerator
        /// to generate EntityRelationsConfiguration, which acts as a state machine for managing includes.
        /// </summary>
        public override ICollection<Func<InvitationEntity, object>> IncludeDirectives { get; } = new List<Func<InvitationEntity, object>>
        {
            entity => entity.Group,
            entity => entity.Sender,
            entity => entity.Receiver,
            entity => entity.Group.GroupUsers.Select(groupUser => groupUser.User)
        };

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
        public InvitationQueryObject WithSentDate(DateTime sentDate) => ApplyDateFilter(entity => entity.SentDate, sentDate, filter => And(filter), "Equal");

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified sent date.
        /// </summary>
        /// <param name="sentDate">The sent date to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public InvitationQueryObject OrWithSentDate(DateTime sentDate) => ApplyDateFilter(entity => entity.SentDate, sentDate, filter => Or(filter), "Equal");

        /// <summary>
        /// Filters the query to exclude items with the specified sent date.
        /// </summary>
        /// <param name="sentDate">The sent date to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public InvitationQueryObject NotWithSentDate(DateTime sentDate) => ApplyDateFilter(entity => entity.SentDate, sentDate, filter => Not(filter), "Equal");

        /// <summary>
        /// Filters the query to include items with the sent date greater than or equal to the specified date.
        /// </summary>
        /// <param name="sentDateFrom">The start sent date to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public InvitationQueryObject WithSentDateFrom(DateTime sentDateFrom) => ApplyDateFilter(entity => entity.SentDate, sentDateFrom, filter => And(filter), "GreaterThanOrEqual");

        /// <summary>
        /// Adds an OR condition to the query to include items with the sent date greater than or equal to the specified date.
        /// </summary>
        /// <param name="sentDateFrom">The start sent date to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public InvitationQueryObject OrWithSentDateFrom(DateTime sentDateFrom) => ApplyDateFilter(entity => entity.SentDate, sentDateFrom, filter => Or(filter), "GreaterThanOrEqual");

        /// <summary>
        /// Filters the query to exclude items with the sent date greater than or equal to the specified date.
        /// </summary>
        /// <param name="sentDateFrom">The start sent date to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public InvitationQueryObject NotWithSentDateFrom(DateTime sentDateFrom) => ApplyDateFilter(entity => entity.SentDate, sentDateFrom, filter => Not(filter), "GreaterThanOrEqual");

        /// <summary>
        /// Filters the query to include items with the sent date less than or equal to the specified date.
        /// </summary>
        /// <param name="sentDateTo">The end sent date to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public InvitationQueryObject WithSentDateTo(DateTime sentDateTo) => ApplyDateFilter(entity => entity.SentDate, sentDateTo, filter => And(filter), "LessThanOrEqual");

        /// <summary>
        /// Adds an OR condition to the query to include items with the sent date less than or equal to the specified date.
        /// </summary>
        /// <param name="sentDateTo">The end sent date to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public InvitationQueryObject OrWithSentDateTo(DateTime sentDateTo) => ApplyDateFilter(entity => entity.SentDate, sentDateTo, filter => Or(filter), "LessThanOrEqual");

        /// <summary>
        /// Filters the query to exclude items with the sent date less than or equal to the specified date.
        /// </summary>
        /// <param name="sentDateTo">The end sent date to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public InvitationQueryObject NotWithSentDateTo(DateTime sentDateTo) => ApplyDateFilter(entity => entity.SentDate, sentDateTo, filter => Not(filter), "LessThanOrEqual");

        #endregion

        #region IResponseDateQuery

        /// <summary>
        /// Filters the query to include items with the specified response date.
        /// </summary>
        /// <param name="responseDate">The response date to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public InvitationQueryObject WithResponseDate(DateTime? responseDate) => ApplyDateFilter(entity => entity.ResponseDate, responseDate, filter => And(filter), "Equal");

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified response date.
        /// </summary>
        /// <param name="responseDate">The response date to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public InvitationQueryObject OrWithResponseDate(DateTime? responseDate) => ApplyDateFilter(entity => entity.ResponseDate, responseDate, filter => Or(filter), "Equal");

        /// <summary>
        /// Filters the query to exclude items with the specified response date.
        /// </summary>
        /// <param name="responseDate">The response date to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public InvitationQueryObject NotWithResponseDate(DateTime? responseDate) => ApplyDateFilter(entity => entity.ResponseDate, responseDate, filter => Not(filter), "Equal");

        /// <summary>
        /// Filters the query to include items without any response date (null).
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public InvitationQueryObject WithoutResponseDate() => ApplyDateFilter(entity => entity.ResponseDate, null, filter => And(filter), "Equal", true);

        /// <summary>
        /// Adds an OR condition to the query to include items without any response date (null).
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public InvitationQueryObject OrWithoutResponseDate() => ApplyDateFilter(entity => entity.ResponseDate, null, filter => Or(filter), "Equal", true);

        /// <summary>
        /// Filters the query to exclude items without any response date (null).
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public InvitationQueryObject NotWithoutResponseDate() => ApplyDateFilter(entity => entity.ResponseDate, null, filter => Not(filter), "Equal", true);

        /// <summary>
        /// Filters the query to include items with the response date greater than or equal to the specified date.
        /// </summary>
        /// <param name="responseDateFrom">The start response date to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public InvitationQueryObject WithResponseDateFrom(DateTime responseDateFrom) => ApplyDateFilter(entity => entity.ResponseDate, responseDateFrom, filter => And(filter), "GreaterThanOrEqual");

        /// <summary>
        /// Adds an OR condition to the query to include items with the response date greater than or equal to the specified date.
        /// </summary>
        /// <param name="responseDateFrom">The start response date to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public InvitationQueryObject OrWithResponseDateFrom(DateTime responseDateFrom) => ApplyDateFilter(entity => entity.ResponseDate, responseDateFrom, filter => Or(filter), "GreaterThanOrEqual");

        /// <summary>
        /// Filters the query to exclude items with the response date greater than or equal to the specified date.
        /// </summary>
        /// <param name="responseDateFrom">The start response date to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public InvitationQueryObject NotWithResponseDateFrom(DateTime responseDateFrom) => ApplyDateFilter(entity => entity.ResponseDate, responseDateFrom, filter => Not(filter), "GreaterThanOrEqual");

        /// <summary>
        /// Filters the query to include items with the response date less than or equal to the specified date.
        /// </summary>
        /// <param name="responseDateTo">The end response date to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public InvitationQueryObject WithResponseDateTo(DateTime responseDateTo) => ApplyDateFilter(entity => entity.ResponseDate, responseDateTo, filter => And(filter), "LessThanOrEqual");

        /// <summary>
        /// Adds an OR condition to the query to include items with the response date less than or equal to the specified date.
        /// </summary>
        /// <param name="responseDateTo">The end response date to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public InvitationQueryObject OrWithResponseDateTo(DateTime responseDateTo) => ApplyDateFilter(entity => entity.ResponseDate, responseDateTo, filter => Or(filter), "LessThanOrEqual");

        /// <summary>
        /// Filters the query to exclude items with the response date less than or equal to the specified date.
        /// </summary>
        /// <param name="responseDateTo">The end response date to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public InvitationQueryObject NotWithResponseDateTo(DateTime responseDateTo) => ApplyDateFilter(entity => entity.ResponseDate, responseDateTo, filter => Not(filter), "LessThanOrEqual");

        #endregion

        #region IIsAcceptedQuery

        /// <summary>
        /// Filters the query to include items that are accepted.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public InvitationQueryObject IsAccepted() => ApplyIsAcceptedFilter(entity => entity.IsAccepted, true, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items that are accepted.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public InvitationQueryObject OrIsAccepted() => ApplyIsAcceptedFilter(entity => entity.IsAccepted, true, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items that are accepted.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public InvitationQueryObject NotIsAccepted() => ApplyIsAcceptedFilter(entity => entity.IsAccepted, true, filter => Not(filter));

        /// <summary>
        /// Filters the query to include items that are not accepted.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public InvitationQueryObject IsNotAccepted() => ApplyIsAcceptedFilter(entity => entity.IsAccepted, false, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items that are not accepted.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public InvitationQueryObject OrIsNotAccepted() => ApplyIsAcceptedFilter(entity => entity.IsAccepted, false, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items that are not accepted.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public InvitationQueryObject NotIsNotAccepted() => ApplyIsAcceptedFilter(entity => entity.IsAccepted, false, filter => Not(filter));

        /// <summary>
        /// Filters the query to include items that are pending.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public InvitationQueryObject IsPending() => ApplyIsAcceptedFilter(entity => entity.IsAccepted, null, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items that are pending.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public InvitationQueryObject OrIsPending() => ApplyIsAcceptedFilter(entity => entity.IsAccepted, null, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items that are pending.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public InvitationQueryObject NotIsPending() => ApplyIsAcceptedFilter(entity => entity.IsAccepted, null, filter => Not(filter));

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