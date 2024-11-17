namespace SpendWise.BLL.Queries.Interfaces
{
    /// <summary>
    /// Interface for queries that support includes for invitations.
    /// </summary>
    public interface IInvitationIncludeQuery
    {
        /// <summary>
        /// Gets a value indicating whether to include the group in the query result.
        /// </summary>
        bool IncludeGroup { get; }

        /// <summary>
        /// Gets a value indicating whether to include the sender in the query result.
        /// </summary>
        bool IncludeSender { get; }

        /// <summary>
        /// Gets a value indicating whether to include the receiver in the query result.
        /// </summary>
        bool IncludeReceiver { get; }

        /// <summary>
        /// Gets a value indicating whether to include the group participants in the query result.
        /// </summary>
        bool IncludeGroupParticipants { get; }
    }
}