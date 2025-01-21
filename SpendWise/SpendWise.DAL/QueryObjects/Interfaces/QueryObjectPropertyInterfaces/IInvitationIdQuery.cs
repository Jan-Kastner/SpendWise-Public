namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by invitation.
    /// Provides methods for specifying invitation-based query conditions.
    /// </summary>
    /// <typeparam name="TReturn">The type of the query object.</typeparam>
    public interface IInvitationIdQuery<TReturn>
    {
        /// <summary>
        /// Filters the query to include items with the specified invitation ID.
        /// </summary>
        /// <param name="invitationId">The invitation ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        TReturn WithInvitation(Guid invitationId);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified invitation ID.
        /// </summary>
        /// <param name="invitationId">The invitation ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        TReturn OrWithInvitation(Guid invitationId);

        /// <summary>
        /// Filters the query to exclude items with the specified invitation ID.
        /// </summary>
        /// <param name="invitationId">The invitation ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        TReturn NotWithInvitation(Guid invitationId);
    }
}