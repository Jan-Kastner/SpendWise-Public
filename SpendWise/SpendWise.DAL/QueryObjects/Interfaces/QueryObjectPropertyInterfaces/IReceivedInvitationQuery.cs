namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by received invitation.
    /// Provides methods for specifying received invitation-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface IReceivedInvitationQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with the specified received invitation ID.
        /// </summary>
        /// <param name="invitationId">The received invitation ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithReceivedInvitation(Guid invitationId);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified received invitation ID.
        /// </summary>
        /// <param name="invitationId">The received invitation ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithReceivedInvitation(Guid invitationId);

        /// <summary>
        /// Filters the query to exclude items with the specified received invitation ID.
        /// </summary>
        /// <param name="invitationId">The received invitation ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithReceivedInvitation(Guid invitationId);
    }
}