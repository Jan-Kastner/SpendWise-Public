namespace SpendWise.BLL.Queries.Interfaces
{
    /// <summary>
    /// Interface for queries that support includes for users.
    /// </summary>
    public interface IUserIncludeQuery
    {
        /// <summary>
        /// Gets a value indicating whether to include the group users in the query result.
        /// </summary>
        bool IncludeGroupUsers { get; }

        /// <summary>
        /// Gets a value indicating whether to include the sent invitations in the query result.
        /// </summary>
        bool IncludeSentInvitations { get; }

        /// <summary>
        /// Gets a value indicating whether to include the received invitations in the query result.
        /// </summary>
        bool IncludeReceivedInvitations { get; }

        /// <summary>
        /// Gets a value indicating whether to include the groups in the query result.
        /// </summary>
        bool IncludeGroups { get; }

        /// <summary>
        /// Gets a value indicating whether to include the group participants in the query result.
        /// </summary>
        bool IncludeGroupParticipants { get; }

        /// <summary>
        /// Gets a value indicating whether to include the transactions in the query result.
        /// </summary>
        bool IncludeTransactions { get; }
    }
}