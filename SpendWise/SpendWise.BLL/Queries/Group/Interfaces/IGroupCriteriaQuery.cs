namespace SpendWise.BLL.Queries.Interfaces
{
    /// <summary>
    /// Represents an interface for group criteria-based queries.
    /// </summary>
    public interface IGroupCriteriaQuery : ICriteriaQuery<IGroupCriteriaQuery>
    {
        #region Name

        /// <summary>
        /// Gets the name of the group.
        /// </summary>
        string? Name { get; }

        /// <summary>
        /// Gets the partial match for the group name.
        /// </summary>
        string? NamePartialMatch { get; }

        /// <summary>
        /// Gets the name that should not match the group name.
        /// </summary>
        string? NotName { get; }

        /// <summary>
        /// Gets the partial match for the name that should not match the group name.
        /// </summary>
        string? NotNamePartialMatch { get; }

        #endregion

        #region Description

        /// <summary>
        /// Gets the description of the group.
        /// </summary>
        string? Description { get; }

        /// <summary>
        /// Gets the partial match for the group description.
        /// </summary>
        string? DescriptionPartialMatch { get; }

        /// <summary>
        /// Gets the description that should not match the group description.
        /// </summary>
        string? NotDescription { get; }

        /// <summary>
        /// Gets the partial match for the description that should not match the group description.
        /// </summary>
        string? NotDescriptionPartialMatch { get; }

        #endregion

        #region WithDescription

        /// <summary>
        /// Gets a value indicating whether the group has a description.
        /// </summary>
        bool? WithDescription { get; }

        #endregion

        #region InvitationId

        /// <summary>
        /// Gets the unique identifier of the invitation.
        /// </summary>
        Guid? InvitationId { get; }

        /// <summary>
        /// Gets the unique identifier of the invitation that should not match.
        /// </summary>
        Guid? NotInvitationId { get; }

        #endregion
    }
}