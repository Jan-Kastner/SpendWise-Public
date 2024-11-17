using System;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Queries
{
    /// <summary>
    /// Represents a query object for retrieving a user by its unique identifier.
    /// </summary>
    public class GetUserByIdQuery : IIdQuery, IUserIncludeQuery
    {
        /// <summary>
        /// Gets the unique identifier of the entity.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets a value indicating whether to include the group users in the query result.
        /// </summary>
        public bool IncludeGroupUsers { get; }

        /// <summary>
        /// Gets a value indicating whether to include the sent invitations in the query result.
        /// </summary>
        public bool IncludeSentInvitations { get; }

        /// <summary>
        /// Gets a value indicating whether to include the received invitations in the query result.
        /// </summary>
        public bool IncludeReceivedInvitations { get; }

        /// <summary>
        /// Gets a value indicating whether to include the groups in the query result.
        /// </summary>
        public bool IncludeGroups { get; }

        /// <summary>
        /// Gets a value indicating whether to include the group participants in the query result.
        /// </summary>
        public bool IncludeGroupParticipants { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserByIdQuery"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <param name="includeGroupUsers">A value indicating whether to include the group users in the query result. Default is false.</param>
        /// <param name="includeSentInvitations">A value indicating whether to include the sent invitations in the query result. Default is false.</param>
        /// <param name="includeReceivedInvitations">A value indicating whether to include the received invitations in the query result. Default is false.</param>
        /// <param name="includeGroups">A value indicating whether to include the groups in the query result. Default is false.</param>
        /// <param name="includeGroupParticipants">A value indicating whether to include the group participants in the query result. Default is false.</param>
        public GetUserByIdQuery(Guid id, bool includeGroupUsers = false, bool includeSentInvitations = false, bool includeReceivedInvitations = false, bool includeGroups = false, bool includeGroupParticipants = false)
        {
            Id = id;
            IncludeGroupUsers = includeGroupUsers;
            IncludeSentInvitations = includeSentInvitations;
            IncludeReceivedInvitations = includeReceivedInvitations;
            IncludeGroups = includeGroups;
            IncludeGroupParticipants = includeGroupParticipants;
        }
    }
}