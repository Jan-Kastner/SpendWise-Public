using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Queries
{
    /// <summary>
    /// Represents a query object for retrieving an invitation by its unique identifier.
    /// </summary>
    public class GetInvitationByIdQuery : IIdQuery, IInvitationIncludeQuery
    {
        /// <summary>
        /// Gets the unique identifier of the entity.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets a value indicating whether to include the group in the query result.
        /// </summary>
        public bool IncludeGroup { get; }

        /// <summary>
        /// Gets a value indicating whether to include the sender in the query result.
        /// </summary>
        public bool IncludeSender { get; }

        /// <summary>
        /// Gets a value indicating whether to include the receiver in the query result.
        /// </summary>
        public bool IncludeReceiver { get; }

        /// <summary>
        /// Gets a value indicating whether to include the group participants in the query result.
        /// </summary>
        public bool IncludeGroupParticipants { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetInvitationByIdQuery"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <param name="includeGroup">A value indicating whether to include the group in the query result. Default is false.</param>
        /// <param name="includeSender">A value indicating whether to include the sender in the query result. Default is false.</param>
        /// <param name="includeReceiver">A value indicating whether to include the receiver in the query result. Default is false.</param>
        /// <param name="includeGroupParticipants">A value indicating whether to include the group participants in the query result. Default is false.</param>
        public GetInvitationByIdQuery(Guid id, bool includeGroup = false, bool includeSender = false, bool includeReceiver = false, bool includeGroupParticipants = false)
        {
            Id = id;
            IncludeGroup = includeGroup;
            IncludeSender = includeSender;
            IncludeReceiver = includeReceiver;
            IncludeGroupParticipants = includeGroupParticipants;
        }
    }
}