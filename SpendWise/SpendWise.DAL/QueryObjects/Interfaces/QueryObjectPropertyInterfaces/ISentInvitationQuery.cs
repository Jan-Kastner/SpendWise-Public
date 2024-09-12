using System;

namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents a query interface for filtering by sent invitation.
    /// Provides methods for specifying sent invitation-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface ISentInvitationQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with the specified sent invitation ID.
        /// </summary>
        /// <param name="invitationId">The sent invitation ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithSentInvitation(Guid invitationId);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified sent invitation ID.
        /// </summary>
        /// <param name="invitationId">The sent invitation ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithSentInvitation(Guid invitationId);

        /// <summary>
        /// Filters the query to exclude items with the specified sent invitation ID.
        /// </summary>
        /// <param name="invitationId">The sent invitation ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithSentInvitation(Guid invitationId);
    }
}