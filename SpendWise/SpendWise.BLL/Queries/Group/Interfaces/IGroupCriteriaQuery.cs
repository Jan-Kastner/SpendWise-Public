namespace SpendWise.BLL.Queries.Interfaces
{
    /// <summary>
    /// Represents an interface for group criteria-based queries.
    /// </summary>
    public interface IGroupCriteriaQuery : ICriteriaQuery
    {
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

        /// <summary>
        /// Gets a value indicating whether the group should be without a description.
        /// </summary>
        bool? WithoutDescription { get; }

        /// <summary>
        /// Gets a value indicating whether the group should not be without a description.
        /// </summary>
        bool? NotWithoutDescription { get; }

        /// <summary>
        /// Gets the unique identifier of the group user.
        /// </summary>
        Guid? GroupUserId { get; }

        /// <summary>
        /// Gets the unique identifier of the group user that should not match.
        /// </summary>
        Guid? NotGroupUserId { get; }

        /// <summary>
        /// Gets the unique identifier of the invitation.
        /// </summary>
        Guid? InvitationId { get; }

        /// <summary>
        /// Gets the unique identifier of the invitation that should not match.
        /// </summary>
        Guid? NotInvitationId { get; }
    }
}